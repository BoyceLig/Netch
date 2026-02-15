using Netch.Enums;
using Netch.Forms;

namespace Netch.Servers;

[Fody.ConfigureAwait(true)]
internal class TUICForm : ServerForm
{
    public TUICForm(TUICServer? server = default)
    {
        server ??= new TUICServer();
        Server = server;

        CreateTextBox("UserID", "User ID", s => true, s => server.Username = s, server.Username);
        CreateTextBox("Password", "Password", s => true, s => server.Password = s, server.Password);

        //�ײ㴫�䷽ʽ
        CreateComboBox("Network", "Network", Constants.TuicCongestionControls, s => server.HeaderType = s, server.HeaderType);
    }

    protected override EConfigType TypeName { get; } = EConfigType.Anytls;
}