using Netch.Forms;
using Netch.Models;

namespace Netch.Servers;

[Fody.ConfigureAwait(true)]
internal class VLESSForm : ServerForm
{
    public VLESSForm(VLESSServer? server = default)
    {
        server ??= new VLESSServer();
        Server = server;

        CreateTextBox("UUID", "UUID", s => true, s => server.UserID = s, server.UserID);
        CreateComboBox("Flow", "Flow", VLESSGlobal.Flow, s => server.Flow = s, server.Flow);
        CreateTextBox("EncryptMethod", "Encrypt Method", s => true, s => server.EncryptMethod = !string.IsNullOrWhiteSpace(s) ? s : "none", server.EncryptMethod);
        CreateComboBox("UseMux", "Use Mux", VMessGlobal.UseMux, s => server.UseMux = s switch
        {
            "" => null,
            "true" => true,
            "false" => false,
            _ => null
        }, server.UseMux?.ToString().ToLower() ?? "");

        //�ײ㴫�䷽ʽ
        CreateComboBox("TransferProtocol", "Transfer Protocol", TransportGlobal.TransferProtocols, s => server.Transport.TransferProtocol = s, server.Transport.TransferProtocol);
        CreateComboBox("PacketEncoding", "Packet Encoding", VMessGlobal.PacketEncodings, s => server.PacketEncoding = s, server.PacketEncoding);
        CreateComboBox("FakeType", "Fake Type", TransportGlobal.FakeTypes, s => server.Transport.FakeType = s, server.Transport.FakeType);
        CreateTextBox("XHttpObject", "XHttpObject", s => true, s => server.Transport.XHttpObject = s, server.Transport.XHttpObject);
        CreateTextBox("Host", "Host", s => true, s => server.Transport.Host = s, server.Transport.Host);
        CreateTextBox("Path", "Path", s => true, s => server.Transport.Path = s, server.Transport.Path);
    }

    protected override string TypeName { get; } = "VLESS";
}