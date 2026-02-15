using Netch.Enums;
using Netch.Forms;

namespace Netch.Servers;

[Fody.ConfigureAwait(true)]
internal class AnytlsForm : ServerForm
{
    public AnytlsForm(AnytlsServer? server = default)
    {
        server ??= new AnytlsServer();
        Server = server;

        CreateTextBox("Password", "Password", s => true, s => server.Password = s, server.Password);

        //�ײ㴫�䷽ʽ
        CreateComboBox("Network", "Network", Constants.Networks, s => server.Network = s, server.Network);
        CreateComboBox("FakeType", "Fake Type", Constants.AllHeaderTypes, s => server.HeaderType = s, server.HeaderType);
        CreateTextBox("Host", "Host", s => true, s => server.RequestHost = s, server.RequestHost);
        CreateTextBox("Path", "Path", s => true, s => server.Path = s, server.Path);
    }

    protected override EConfigType TypeName { get; } = EConfigType.Anytls;
}