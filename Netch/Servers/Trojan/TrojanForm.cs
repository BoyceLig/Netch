using Netch.Forms;
using Netch.Models;

namespace Netch.Servers;

[Fody.ConfigureAwait(true)]
public class TrojanForm : ServerForm
{
    public TrojanForm(TrojanServer? server = default)
    {
        server ??= new TrojanServer();
        Server = server;
        CreateTextBox("Password", "Password", s => true, s => server.Password = s, server.Password);
        CreateComboBox("Flow", "Flow", VLESSGlobal.Flow, s => server.Flow = s, server.Flow);

        //底层传输方式
        CreateComboBox("TransferProtocol", "Transfer Protocol", TransportGlobal.TransferProtocols, s => server.Transport.TransferProtocol = s, server.Transport.TransferProtocol);
        CreateComboBox("FakeType", "Fake Type", TransportGlobal.FakeTypes, s => server.Transport.FakeType = s, server.Transport.FakeType);
        CreateTextBox("XHttpObject", "XHttpObject", s => true, s => server.Transport.XHttpObject = s, server.Transport.XHttpObject);
        CreateTextBox("Host", "Host", s => true, s => server.Transport.Host = s, server.Transport.Host);
        CreateTextBox("Path", "Path", s => true, s => server.Transport.Path = s, server.Transport.Path);
    }

    protected override string TypeName { get; } = "Trojan";
}