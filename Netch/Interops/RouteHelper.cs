using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Networking.WinSock;
using Windows.Win32.NetworkManagement.IpHelper;

namespace Netch.Interops;

public static unsafe class RouteHelper
{
    [DllImport("RouteHelper.bin", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong ConvertLuidToIndex(ulong id);

    [DllImport("RouteHelper.bin", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CreateIPv4(string address, string netmask, ulong index);

    [DllImport("RouteHelper.bin", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CreateUnicastIP(AddressFamily inet, string address, byte cidr, ulong index);

    [SupportedOSPlatform("windows8.1")]
    public static bool CreateUnicastIPCS(AddressFamily inet, string address, byte cidr, ulong index)
    {
        MIB_UNICASTIPADDRESS_ROW addr;
        PInvoke.InitializeUnicastIpAddressEntry(&addr);

        addr.InterfaceIndex = (uint)index;
        addr.OnLinkPrefixLength = cidr;
        if (inet == AddressFamily.InterNetwork)
        {
            addr.Address.Ipv4.sin_family = ADDRESS_FAMILY.AF_INET;

            if (PInvoke.inet_pton((int)inet, address, &addr.Address.Ipv4.sin_addr) == 0)
                return false;

        }
        else if (inet == AddressFamily.InterNetworkV6)
        {
            addr.Address.Ipv6.sin6_family = ADDRESS_FAMILY.AF_INET6;
            if (PInvoke.inet_pton((int)inet, address, &addr.Address.Ipv6.sin6_addr) == 0)
                return false;
        }
        else
        {
            return false;
        }
        // https://docs.microsoft.com/en-us/windows/win32/api/netioapi/nf-netioapi-createunicastipaddressentry#remarks

        HANDLE handle = default;
        using var obj = new Semaphore(0, 1);

        void Callback(void* context, MIB_UNICASTIPADDRESS_ROW* row, MIB_NOTIFICATION_TYPE type)
        {
            if (type != MIB_NOTIFICATION_TYPE.MibInitialNotification)
            {
                WIN32_ERROR state = PInvoke.GetUnicastIpAddressEntry(row);
                if (state != WIN32_ERROR.NO_ERROR)
                {
                    Log.Error("GetUnicastIpAddressEntry failed: {State}", state);
                    return;
                }

                if (row->DadState == NL_DAD_STATE.IpDadStatePreferred)
                {
                    try
                    {
                        obj.Release();
                    }
                    catch (Exception e)
                    {
                        // i don't trust win32 api
                        Log.Error(e, "semaphore disposed");
                    }
                }
            }
        }

        PInvoke.NotifyUnicastIpAddressChange(ADDRESS_FAMILY.AF_INET, Callback, null, new BOOLEAN(byte.MaxValue), ref handle);

        try
        {
            var state = PInvoke.CreateUnicastIpAddressEntry(&addr);
            if (state != WIN32_ERROR.NO_ERROR)
            {
                Log.Error("CreateUnicastIpAddressEntry failed: {State}", state);
                return false;
            }

            if (!obj.WaitOne(TimeSpan.FromSeconds(10)))
            {
                Log.Error("Wait unicast IP usable timeout");
                return false;
            }

            return true;
        }
        finally
        {
            PInvoke.CancelMibChangeNotify2(handle);
        }
    }

    [DllImport("RouteHelper.bin", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool RefreshIPTable(AddressFamily inet, ulong index);

    [DllImport("RouteHelper.bin", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CreateRoute(AddressFamily inet, string address, byte cidr, string gateway, ulong index, int metric);

    [DllImport("RouteHelper.bin", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DeleteRoute(AddressFamily inet, string address, byte cidr, string gateway, ulong index, int metric);
}