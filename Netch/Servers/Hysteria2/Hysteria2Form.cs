using Netch.Forms;
using Netch.Models;

namespace Netch.Servers;

[Fody.ConfigureAwait(true)]
public class Hysteria2Form : ServerForm
{
    public Hysteria2Form(Hysteria2Server? server = default)
    {
        server ??= new Hysteria2Server();
        Server = server;

        CreateTextBox("Auth", "Auth", s => true, s => server.Auth = s, server.Auth);
        CreateComboBox("Obfs", "Obfs", Hysteria2Globe.Obfs, s => server.Obfs = s, server.Obfs);
        CreateTextBox("ObfsPassword", "Obfs Password", s => true, s => server.ObfsPassword = s, server.ObfsPassword);
        CreateTextBox("PortHoppingRange", "Port Hopping Range", s => true, s => server.PortHoppingRange = s, server.PortHoppingRange);
    }

    protected override string TypeName { get; } = "Hysteria2";
}
