using Netch.Forms;
using Netch.Models;

namespace Netch.Servers;

[Fody.ConfigureAwait(true)]
public class VMessForm : ServerForm
{
    public VMessForm(VMessServer? server = default)
    {
        server ??= new VMessServer();
        Server = server;

        CreateTextBox("UserId", "User ID", s => true, s => server.UserID = s, server.UserID);
        CreateTextBox("AlterId", "Alter ID", s => int.TryParse(s, out _), s => server.AlterID = int.Parse(s), server.AlterID.ToString(), 76);
        CreateComboBox("EncryptMethod", "Encrypt Method", VMessGlobal.EncryptMethods, s => server.EncryptMethod = s, server.EncryptMethod);
        CreateComboBox("UseMux",
            "Use Mux",
            VMessGlobal.UseMux,
            s => server.UseMux = s switch { "" => null, "true" => true, "false" => false, _ => null },
            server.UseMux?.ToString().ToLower() ?? "");

        CreateComboBox("TransferProtocol",
            "Transfer Protocol",
            TransportGlobal.TransferProtocols,
            s => server.Transport.TransferProtocol = s,
            server.Transport.TransferProtocol);
        CreateComboBox("PacketEncoding",
            "Packet Encoding",
            VMessGlobal.PacketEncodings,
            s => server.PacketEncoding = s,
            server.PacketEncoding);
        CreateComboBox("FakeType", "Fake Type", TransportGlobal.FakeTypes, s => server.Transport.FakeType = s, server.Transport.FakeType);
        CreateTextBox("Host", "Host", s => true, s => server.Transport.Host = s, server.Transport.Host);
        CreateTextBox("Path", "Path", s => true, s => server.Transport.Path = s, server.Transport.Path);
    }

    protected override string TypeName { get; } = "VMess";
}