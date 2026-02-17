using System.ComponentModel;

namespace Netch.Forms
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            TabControl = new TabControl();
            GeneralTabPage = new TabPage();
            OutboundDNSFlowLayoutPanel = new FlowLayoutPanel();
            OutboundDNSLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            OutboundDNSComboBox = new ComboBox();
            OutboundDNSAddCurrentPictureBox = new PictureBox();
            OutboundDNSDeleteCurrentPictureBox = new PictureBox();
            UseOutboundDNSCheckBox = new CheckBox();
            UseDomainNameRadioButton = new RadioButton();
            UseResolvedIPRadioButton = new RadioButton();
            ServerPingTypeGroupBox = new GroupBox();
            ServerPingTableLayoutPanel = new TableLayoutPanel();
            TCPingRadioBtn = new RadioButton();
            ICMPingRadioBtn = new RadioButton();
            PortGroupBox = new GroupBox();
            Socks5PortLabel = new Label();
            Socks5PortTextBox = new TextBox();
            AllowDevicesCheckBox = new CheckBox();
            ProfileCountLabel = new Label();
            ProfileCountTextBox = new TextBox();
            DetectionTickLabel = new Label();
            DetectionTickTextBox = new TextBox();
            StartedPingLabel = new Label();
            StartedPingIntervalTextBox = new TextBox();
            STUNServerLabel = new Label();
            STUN_ServerComboBox = new ComboBox();
            LanguageLabel = new Label();
            LanguageComboBox = new ComboBox();
            NFTabPage = new TabPage();
            FilterTCPCheckBox = new CheckBox();
            FilterUDPCheckBox = new CheckBox();
            FilterICMPCheckBox = new CheckBox();
            DNSHijackLabel = new Label();
            ICMPDelayLabel = new Label();
            ICMPDelayTextBox = new TextBox();
            FilterDNSCheckBox = new CheckBox();
            DNSHijackHostTextBox = new TextBox();
            HandleProcDNSCheckBox = new CheckBox();
            DNSProxyCheckBox = new CheckBox();
            ChildProcessHandleCheckBox = new CheckBox();
            WinTUNTabPage = new TabPage();
            WinTUNGroupBox = new GroupBox();
            TUNTAPAddressLabel = new Label();
            TUNTAPAddressTextBox = new TextBox();
            TUNTAPNetmaskLabel = new Label();
            TUNTAPNetmaskTextBox = new TextBox();
            TUNTAPGatewayLabel = new Label();
            TUNTAPGatewayTextBox = new TextBox();
            TUNTAPDNSLabel = new Label();
            TUNTAPDNSTextBox = new TextBox();
            UseCustomDNSCheckBox = new CheckBox();
            ProxyDNSCheckBox = new CheckBox();
            GlobalBypassIPsButton = new Button();
            v2rayTabPage = new TabPage();
            DefFingerprintComboBox = new ComboBox();
            DefFingerprintLabel = new Label();
            EnableFragmentBox = new CheckBox();
            TLSAllowInsecureCheckBox = new CheckBox();
            UseMuxCheckBox = new CheckBox();
            KCPGroupBox = new GroupBox();
            tableLayoutPanel = new TableLayoutPanel();
            mtuLabel = new Label();
            mtuTextBox = new TextBox();
            ttiLabel = new Label();
            ttiTextBox = new TextBox();
            uplinkCapacityLabel = new Label();
            uplinkCapacityTextBox = new TextBox();
            downlinkCapacityLabel = new Label();
            downlinkCapacityTextBox = new TextBox();
            readBufferSizeLabel = new Label();
            readBufferSizeTextBox = new TextBox();
            writeBufferSizeLabel = new Label();
            writeBufferSizeTextBox = new TextBox();
            congestionCheckBox = new CheckBox();
            HysteriaTabPage = new TabPage();
            HysteriaBandwidthGroupBox = new GroupBox();
            HysteriaDownMbpsTextBox = new TextBox();
            HysteriaUpMbpsTextBox = new TextBox();
            SingboxTabPage = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            SingboxMuxProtocolComboBox = new ComboBox();
            SingboxMuxProtocolLabel = new Label();
            OtherTabPage = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            UpdateServersWhenOpenedCheckBox = new CheckBox();
            CheckBetaUpdateCheckBox = new CheckBox();
            NoSupportDialogCheckBox = new CheckBox();
            CheckUpdateWhenOpenedCheckBox = new CheckBox();
            RunAtStartupCheckBox = new CheckBox();
            MinimizeWhenStartedCheckBox = new CheckBox();
            StartWhenOpenedCheckBox = new CheckBox();
            StopWhenExitedCheckBox = new CheckBox();
            ExitWhenClosedCheckBox = new CheckBox();
            AioDNSTabPage = new TabPage();
            ChinaDNSLabel = new Label();
            ChinaDNSTextBox = new TextBox();
            OtherDNSLabel = new Label();
            OtherDNSTextBox = new TextBox();
            ControlButton = new Button();
            errorProvider = new ErrorProvider(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            TabControl.SuspendLayout();
            GeneralTabPage.SuspendLayout();
            OutboundDNSFlowLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)OutboundDNSAddCurrentPictureBox).BeginInit();
            ((ISupportInitialize)OutboundDNSDeleteCurrentPictureBox).BeginInit();
            ServerPingTypeGroupBox.SuspendLayout();
            ServerPingTableLayoutPanel.SuspendLayout();
            PortGroupBox.SuspendLayout();
            NFTabPage.SuspendLayout();
            WinTUNTabPage.SuspendLayout();
            WinTUNGroupBox.SuspendLayout();
            v2rayTabPage.SuspendLayout();
            KCPGroupBox.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            HysteriaTabPage.SuspendLayout();
            HysteriaBandwidthGroupBox.SuspendLayout();
            SingboxTabPage.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            OtherTabPage.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            AioDNSTabPage.SuspendLayout();
            ((ISupportInitialize)errorProvider).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Appearance = TabAppearance.FlatButtons;
            TabControl.Controls.Add(GeneralTabPage);
            TabControl.Controls.Add(NFTabPage);
            TabControl.Controls.Add(WinTUNTabPage);
            TabControl.Controls.Add(v2rayTabPage);
            TabControl.Controls.Add(HysteriaTabPage);
            TabControl.Controls.Add(SingboxTabPage);
            TabControl.Controls.Add(OtherTabPage);
            TabControl.Controls.Add(AioDNSTabPage);
            TabControl.Dock = DockStyle.Top;
            TabControl.Location = new Point(3, 3);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(570, 323);
            TabControl.TabIndex = 0;
            // 
            // GeneralTabPage
            // 
            GeneralTabPage.BackColor = SystemColors.ButtonFace;
            GeneralTabPage.Controls.Add(OutboundDNSFlowLayoutPanel);
            GeneralTabPage.Controls.Add(ServerPingTypeGroupBox);
            GeneralTabPage.Controls.Add(PortGroupBox);
            GeneralTabPage.Controls.Add(ProfileCountLabel);
            GeneralTabPage.Controls.Add(ProfileCountTextBox);
            GeneralTabPage.Controls.Add(DetectionTickLabel);
            GeneralTabPage.Controls.Add(DetectionTickTextBox);
            GeneralTabPage.Controls.Add(StartedPingLabel);
            GeneralTabPage.Controls.Add(StartedPingIntervalTextBox);
            GeneralTabPage.Controls.Add(STUNServerLabel);
            GeneralTabPage.Controls.Add(STUN_ServerComboBox);
            GeneralTabPage.Controls.Add(LanguageLabel);
            GeneralTabPage.Controls.Add(LanguageComboBox);
            GeneralTabPage.Location = new Point(4, 29);
            GeneralTabPage.Name = "GeneralTabPage";
            GeneralTabPage.Padding = new Padding(3);
            GeneralTabPage.Size = new Size(562, 290);
            GeneralTabPage.TabIndex = 0;
            GeneralTabPage.Text = "General";
            // 
            // OutboundDNSFlowLayoutPanel
            // 
            OutboundDNSFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OutboundDNSFlowLayoutPanel.Controls.Add(OutboundDNSLabel);
            OutboundDNSFlowLayoutPanel.Controls.Add(flowLayoutPanel1);
            OutboundDNSFlowLayoutPanel.Controls.Add(UseOutboundDNSCheckBox);
            OutboundDNSFlowLayoutPanel.Controls.Add(UseDomainNameRadioButton);
            OutboundDNSFlowLayoutPanel.Controls.Add(UseResolvedIPRadioButton);
            OutboundDNSFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            OutboundDNSFlowLayoutPanel.Location = new Point(268, 68);
            OutboundDNSFlowLayoutPanel.Name = "OutboundDNSFlowLayoutPanel";
            OutboundDNSFlowLayoutPanel.Size = new Size(285, 149);
            OutboundDNSFlowLayoutPanel.TabIndex = 22;
            // 
            // OutboundDNSLabel
            // 
            OutboundDNSLabel.AutoSize = true;
            OutboundDNSLabel.Location = new Point(3, 3);
            OutboundDNSLabel.Margin = new Padding(3);
            OutboundDNSLabel.Name = "OutboundDNSLabel";
            OutboundDNSLabel.Size = new Size(97, 17);
            OutboundDNSLabel.TabIndex = 2;
            OutboundDNSLabel.Text = "Outbound DNS";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(OutboundDNSComboBox);
            flowLayoutPanel1.Controls.Add(OutboundDNSAddCurrentPictureBox);
            flowLayoutPanel1.Controls.Add(OutboundDNSDeleteCurrentPictureBox);
            flowLayoutPanel1.Location = new Point(3, 26);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(229, 31);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // OutboundDNSComboBox
            // 
            OutboundDNSComboBox.FormattingEnabled = true;
            OutboundDNSComboBox.Location = new Point(3, 3);
            OutboundDNSComboBox.Name = "OutboundDNSComboBox";
            OutboundDNSComboBox.Size = new Size(165, 25);
            OutboundDNSComboBox.TabIndex = 16;
            // 
            // OutboundDNSAddCurrentPictureBox
            // 
            OutboundDNSAddCurrentPictureBox.Cursor = Cursors.Hand;
            OutboundDNSAddCurrentPictureBox.Image = Properties.Resources.Add;
            OutboundDNSAddCurrentPictureBox.Location = new Point(174, 3);
            OutboundDNSAddCurrentPictureBox.Name = "OutboundDNSAddCurrentPictureBox";
            OutboundDNSAddCurrentPictureBox.Size = new Size(23, 23);
            OutboundDNSAddCurrentPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            OutboundDNSAddCurrentPictureBox.TabIndex = 18;
            OutboundDNSAddCurrentPictureBox.TabStop = false;
            OutboundDNSAddCurrentPictureBox.Click += OutboundDNSAddCurrentPictureBox_Click;
            // 
            // OutboundDNSDeleteCurrentPictureBox
            // 
            OutboundDNSDeleteCurrentPictureBox.Cursor = Cursors.Hand;
            OutboundDNSDeleteCurrentPictureBox.Image = Properties.Resources.delete;
            OutboundDNSDeleteCurrentPictureBox.Location = new Point(203, 3);
            OutboundDNSDeleteCurrentPictureBox.Name = "OutboundDNSDeleteCurrentPictureBox";
            OutboundDNSDeleteCurrentPictureBox.Size = new Size(23, 23);
            OutboundDNSDeleteCurrentPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            OutboundDNSDeleteCurrentPictureBox.TabIndex = 18;
            OutboundDNSDeleteCurrentPictureBox.TabStop = false;
            OutboundDNSDeleteCurrentPictureBox.Click += OutboundDNSDeleteCurrentPictureBox_Click;
            // 
            // UseOutboundDNSCheckBox
            // 
            UseOutboundDNSCheckBox.AutoSize = true;
            UseOutboundDNSCheckBox.Location = new Point(3, 63);
            UseOutboundDNSCheckBox.Name = "UseOutboundDNSCheckBox";
            UseOutboundDNSCheckBox.Size = new Size(142, 21);
            UseOutboundDNSCheckBox.TabIndex = 4;
            UseOutboundDNSCheckBox.Text = "Use Outbound DNS";
            UseOutboundDNSCheckBox.TextAlign = ContentAlignment.MiddleRight;
            UseOutboundDNSCheckBox.UseVisualStyleBackColor = true;
            // 
            // ResolveItOnXrayRadioButton
            // 
            UseDomainNameRadioButton.AutoSize = true;
            UseDomainNameRadioButton.Checked = true;
            UseDomainNameRadioButton.Location = new Point(3, 90);
            UseDomainNameRadioButton.Name = "ResolveItOnXrayRadioButton";
            UseDomainNameRadioButton.Size = new Size(120, 21);
            UseDomainNameRadioButton.TabIndex = 4;
            UseDomainNameRadioButton.TabStop = true;
            UseDomainNameRadioButton.Text = "Use Resolved IP";
            UseDomainNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // UseTheResolvedIpDirectlyRadioButton
            // 
            UseResolvedIPRadioButton.AutoSize = true;
            UseResolvedIPRadioButton.Location = new Point(3, 117);
            UseResolvedIPRadioButton.Name = "UseTheResolvedIpDirectlyRadioButton";
            UseResolvedIPRadioButton.Size = new Size(136, 21);
            UseResolvedIPRadioButton.TabIndex = 3;
            UseResolvedIPRadioButton.Text = "Use Domain Name";
            UseResolvedIPRadioButton.UseVisualStyleBackColor = true;
            // 
            // ServerPingTypeGroupBox
            // 
            ServerPingTypeGroupBox.Controls.Add(ServerPingTableLayoutPanel);
            ServerPingTypeGroupBox.Location = new Point(268, 11);
            ServerPingTypeGroupBox.Name = "ServerPingTypeGroupBox";
            ServerPingTypeGroupBox.Size = new Size(288, 51);
            ServerPingTypeGroupBox.TabIndex = 20;
            ServerPingTypeGroupBox.TabStop = false;
            ServerPingTypeGroupBox.Text = "Ping Protocol";
            // 
            // ServerPingTableLayoutPanel
            // 
            ServerPingTableLayoutPanel.ColumnCount = 2;
            ServerPingTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            ServerPingTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            ServerPingTableLayoutPanel.Controls.Add(TCPingRadioBtn, 1, 0);
            ServerPingTableLayoutPanel.Controls.Add(ICMPingRadioBtn, 0, 0);
            ServerPingTableLayoutPanel.Dock = DockStyle.Fill;
            ServerPingTableLayoutPanel.Location = new Point(3, 19);
            ServerPingTableLayoutPanel.Name = "ServerPingTableLayoutPanel";
            ServerPingTableLayoutPanel.RowCount = 1;
            ServerPingTableLayoutPanel.RowStyles.Add(new RowStyle());
            ServerPingTableLayoutPanel.Size = new Size(282, 29);
            ServerPingTableLayoutPanel.TabIndex = 19;
            // 
            // TCPingRadioBtn
            // 
            TCPingRadioBtn.AutoSize = true;
            TCPingRadioBtn.Location = new Point(84, 3);
            TCPingRadioBtn.Name = "TCPingRadioBtn";
            TCPingRadioBtn.Size = new Size(66, 21);
            TCPingRadioBtn.TabIndex = 4;
            TCPingRadioBtn.TabStop = true;
            TCPingRadioBtn.Text = "TCPing";
            TCPingRadioBtn.UseVisualStyleBackColor = true;
            // 
            // ICMPingRadioBtn
            // 
            ICMPingRadioBtn.AutoSize = true;
            ICMPingRadioBtn.Checked = true;
            ICMPingRadioBtn.Location = new Point(3, 3);
            ICMPingRadioBtn.Name = "ICMPingRadioBtn";
            ICMPingRadioBtn.Size = new Size(75, 21);
            ICMPingRadioBtn.TabIndex = 3;
            ICMPingRadioBtn.TabStop = true;
            ICMPingRadioBtn.Text = "ICMPing";
            ICMPingRadioBtn.UseVisualStyleBackColor = true;
            // 
            // PortGroupBox
            // 
            PortGroupBox.Controls.Add(Socks5PortLabel);
            PortGroupBox.Controls.Add(Socks5PortTextBox);
            PortGroupBox.Controls.Add(AllowDevicesCheckBox);
            PortGroupBox.Location = new Point(8, 6);
            PortGroupBox.Name = "PortGroupBox";
            PortGroupBox.Size = new Size(241, 115);
            PortGroupBox.TabIndex = 0;
            PortGroupBox.TabStop = false;
            PortGroupBox.Text = "Local Port";
            // 
            // Socks5PortLabel
            // 
            Socks5PortLabel.AutoSize = true;
            Socks5PortLabel.Location = new Point(9, 25);
            Socks5PortLabel.Name = "Socks5PortLabel";
            Socks5PortLabel.Size = new Size(44, 17);
            Socks5PortLabel.TabIndex = 0;
            Socks5PortLabel.Text = "Mixed";
            // 
            // Socks5PortTextBox
            // 
            Socks5PortTextBox.Location = new Point(120, 22);
            Socks5PortTextBox.Name = "Socks5PortTextBox";
            Socks5PortTextBox.Size = new Size(90, 23);
            Socks5PortTextBox.TabIndex = 1;
            Socks5PortTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AllowDevicesCheckBox
            // 
            AllowDevicesCheckBox.AutoSize = true;
            AllowDevicesCheckBox.Location = new Point(6, 84);
            AllowDevicesCheckBox.Name = "AllowDevicesCheckBox";
            AllowDevicesCheckBox.Size = new Size(206, 21);
            AllowDevicesCheckBox.TabIndex = 4;
            AllowDevicesCheckBox.Text = "Allow other Devices to connect";
            AllowDevicesCheckBox.TextAlign = ContentAlignment.MiddleRight;
            AllowDevicesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProfileCountLabel
            // 
            ProfileCountLabel.AutoSize = true;
            ProfileCountLabel.Location = new Point(15, 140);
            ProfileCountLabel.Name = "ProfileCountLabel";
            ProfileCountLabel.Size = new Size(83, 17);
            ProfileCountLabel.TabIndex = 5;
            ProfileCountLabel.Text = "Profile Count";
            // 
            // ProfileCountTextBox
            // 
            ProfileCountTextBox.Location = new Point(182, 137);
            ProfileCountTextBox.Name = "ProfileCountTextBox";
            ProfileCountTextBox.Size = new Size(70, 23);
            ProfileCountTextBox.TabIndex = 6;
            ProfileCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // DetectionTickLabel
            // 
            DetectionTickLabel.AutoSize = true;
            DetectionTickLabel.Location = new Point(15, 170);
            DetectionTickLabel.Name = "DetectionTickLabel";
            DetectionTickLabel.Size = new Size(117, 17);
            DetectionTickLabel.TabIndex = 7;
            DetectionTickLabel.Text = "Detection Tick(sec)";
            // 
            // DetectionTickTextBox
            // 
            DetectionTickTextBox.Location = new Point(182, 167);
            DetectionTickTextBox.Name = "DetectionTickTextBox";
            DetectionTickTextBox.Size = new Size(70, 23);
            DetectionTickTextBox.TabIndex = 8;
            DetectionTickTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // StartedPingLabel
            // 
            StartedPingLabel.AutoSize = true;
            StartedPingLabel.Location = new Point(15, 200);
            StartedPingLabel.Name = "StartedPingLabel";
            StartedPingLabel.Size = new Size(153, 17);
            StartedPingLabel.TabIndex = 9;
            StartedPingLabel.Text = "Delay test after start(sec)";
            // 
            // StartedPingIntervalTextBox
            // 
            StartedPingIntervalTextBox.Location = new Point(182, 197);
            StartedPingIntervalTextBox.Name = "StartedPingIntervalTextBox";
            StartedPingIntervalTextBox.Size = new Size(70, 23);
            StartedPingIntervalTextBox.TabIndex = 10;
            StartedPingIntervalTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // STUNServerLabel
            // 
            STUNServerLabel.AutoSize = true;
            STUNServerLabel.Location = new Point(15, 230);
            STUNServerLabel.Name = "STUNServerLabel";
            STUNServerLabel.Size = new Size(82, 17);
            STUNServerLabel.TabIndex = 11;
            STUNServerLabel.Text = "STUN Server";
            // 
            // STUN_ServerComboBox
            // 
            STUN_ServerComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            STUN_ServerComboBox.Location = new Point(182, 227);
            STUN_ServerComboBox.Name = "STUN_ServerComboBox";
            STUN_ServerComboBox.Size = new Size(264, 25);
            STUN_ServerComboBox.TabIndex = 12;
            // 
            // LanguageLabel
            // 
            LanguageLabel.AutoSize = true;
            LanguageLabel.Location = new Point(15, 260);
            LanguageLabel.Name = "LanguageLabel";
            LanguageLabel.Size = new Size(65, 17);
            LanguageLabel.TabIndex = 13;
            LanguageLabel.Text = "Language";
            // 
            // LanguageComboBox
            // 
            LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LanguageComboBox.FormattingEnabled = true;
            LanguageComboBox.Location = new Point(182, 257);
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.Size = new Size(110, 25);
            LanguageComboBox.TabIndex = 14;
            // 
            // NFTabPage
            // 
            NFTabPage.BackColor = SystemColors.ButtonFace;
            NFTabPage.Controls.Add(FilterTCPCheckBox);
            NFTabPage.Controls.Add(FilterUDPCheckBox);
            NFTabPage.Controls.Add(FilterICMPCheckBox);
            NFTabPage.Controls.Add(DNSHijackLabel);
            NFTabPage.Controls.Add(ICMPDelayLabel);
            NFTabPage.Controls.Add(ICMPDelayTextBox);
            NFTabPage.Controls.Add(FilterDNSCheckBox);
            NFTabPage.Controls.Add(DNSHijackHostTextBox);
            NFTabPage.Controls.Add(HandleProcDNSCheckBox);
            NFTabPage.Controls.Add(DNSProxyCheckBox);
            NFTabPage.Controls.Add(ChildProcessHandleCheckBox);
            NFTabPage.Location = new Point(4, 29);
            NFTabPage.Name = "NFTabPage";
            NFTabPage.Padding = new Padding(3);
            NFTabPage.Size = new Size(562, 290);
            NFTabPage.TabIndex = 1;
            NFTabPage.Text = "Process Mode";
            // 
            // FilterTCPCheckBox
            // 
            FilterTCPCheckBox.AutoSize = true;
            FilterTCPCheckBox.Location = new Point(16, 16);
            FilterTCPCheckBox.Name = "FilterTCPCheckBox";
            FilterTCPCheckBox.Size = new Size(94, 21);
            FilterTCPCheckBox.TabIndex = 1;
            FilterTCPCheckBox.Text = "Handle TCP";
            FilterTCPCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterUDPCheckBox
            // 
            FilterUDPCheckBox.AutoSize = true;
            FilterUDPCheckBox.Location = new Point(216, 16);
            FilterUDPCheckBox.Name = "FilterUDPCheckBox";
            FilterUDPCheckBox.Size = new Size(97, 21);
            FilterUDPCheckBox.TabIndex = 2;
            FilterUDPCheckBox.Text = "Handle UDP";
            FilterUDPCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterICMPCheckBox
            // 
            FilterICMPCheckBox.AutoSize = true;
            FilterICMPCheckBox.Location = new Point(16, 48);
            FilterICMPCheckBox.Name = "FilterICMPCheckBox";
            FilterICMPCheckBox.Size = new Size(103, 21);
            FilterICMPCheckBox.TabIndex = 3;
            FilterICMPCheckBox.Text = "Handle ICMP";
            FilterICMPCheckBox.UseVisualStyleBackColor = true;
            // 
            // DNSHijackLabel
            // 
            DNSHijackLabel.AutoSize = true;
            DNSHijackLabel.Location = new Point(48, 144);
            DNSHijackLabel.Name = "DNSHijackLabel";
            DNSHijackLabel.Size = new Size(34, 17);
            DNSHijackLabel.TabIndex = 3;
            DNSHijackLabel.Text = "DNS";
            // 
            // ICMPDelayLabel
            // 
            ICMPDelayLabel.AutoSize = true;
            ICMPDelayLabel.Location = new Point(48, 80);
            ICMPDelayLabel.Name = "ICMPDelayLabel";
            ICMPDelayLabel.Size = new Size(99, 17);
            ICMPDelayLabel.TabIndex = 3;
            ICMPDelayLabel.Text = "ICMP delay(ms)";
            // 
            // ICMPDelayTextBox
            // 
            ICMPDelayTextBox.DataBindings.Add(new Binding("Enabled", FilterICMPCheckBox, "Checked", true));
            ICMPDelayTextBox.Location = new Point(216, 80);
            ICMPDelayTextBox.Name = "ICMPDelayTextBox";
            ICMPDelayTextBox.Size = new Size(98, 23);
            ICMPDelayTextBox.TabIndex = 4;
            ICMPDelayTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // FilterDNSCheckBox
            // 
            FilterDNSCheckBox.AutoSize = true;
            FilterDNSCheckBox.Location = new Point(16, 112);
            FilterDNSCheckBox.Name = "FilterDNSCheckBox";
            FilterDNSCheckBox.Size = new Size(191, 21);
            FilterDNSCheckBox.TabIndex = 5;
            FilterDNSCheckBox.Text = "Handle DNS (DNS hijacking)";
            FilterDNSCheckBox.UseVisualStyleBackColor = true;
            // 
            // DNSHijackHostTextBox
            // 
            DNSHijackHostTextBox.DataBindings.Add(new Binding("Enabled", FilterDNSCheckBox, "Checked", true));
            DNSHijackHostTextBox.Location = new Point(216, 144);
            DNSHijackHostTextBox.Name = "DNSHijackHostTextBox";
            DNSHijackHostTextBox.Size = new Size(191, 23);
            DNSHijackHostTextBox.TabIndex = 6;
            DNSHijackHostTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // HandleProcDNSCheckBox
            // 
            HandleProcDNSCheckBox.AutoSize = true;
            HandleProcDNSCheckBox.DataBindings.Add(new Binding("Enabled", FilterDNSCheckBox, "Checked", true));
            HandleProcDNSCheckBox.Location = new Point(16, 176);
            HandleProcDNSCheckBox.Name = "HandleProcDNSCheckBox";
            HandleProcDNSCheckBox.Size = new Size(208, 21);
            HandleProcDNSCheckBox.TabIndex = 7;
            HandleProcDNSCheckBox.Text = "Handle handled process's DNS";
            HandleProcDNSCheckBox.UseVisualStyleBackColor = true;
            // 
            // DNSProxyCheckBox
            // 
            DNSProxyCheckBox.AutoSize = true;
            DNSProxyCheckBox.DataBindings.Add(new Binding("Enabled", FilterDNSCheckBox, "Checked", true));
            DNSProxyCheckBox.Location = new Point(16, 208);
            DNSProxyCheckBox.Name = "DNSProxyCheckBox";
            DNSProxyCheckBox.Size = new Size(185, 21);
            DNSProxyCheckBox.TabIndex = 8;
            DNSProxyCheckBox.Text = "Handle DNS through proxy";
            DNSProxyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChildProcessHandleCheckBox
            // 
            ChildProcessHandleCheckBox.AutoSize = true;
            ChildProcessHandleCheckBox.Location = new Point(16, 240);
            ChildProcessHandleCheckBox.Name = "ChildProcessHandleCheckBox";
            ChildProcessHandleCheckBox.Size = new Size(149, 21);
            ChildProcessHandleCheckBox.TabIndex = 9;
            ChildProcessHandleCheckBox.Text = "Handle child process";
            ChildProcessHandleCheckBox.UseVisualStyleBackColor = true;
            // 
            // WinTUNTabPage
            // 
            WinTUNTabPage.BackColor = SystemColors.ButtonFace;
            WinTUNTabPage.Controls.Add(WinTUNGroupBox);
            WinTUNTabPage.Controls.Add(GlobalBypassIPsButton);
            WinTUNTabPage.Location = new Point(4, 29);
            WinTUNTabPage.Name = "WinTUNTabPage";
            WinTUNTabPage.Padding = new Padding(3);
            WinTUNTabPage.Size = new Size(562, 290);
            WinTUNTabPage.TabIndex = 2;
            WinTUNTabPage.Text = "WinTUN";
            // 
            // WinTUNGroupBox
            // 
            WinTUNGroupBox.Controls.Add(TUNTAPAddressLabel);
            WinTUNGroupBox.Controls.Add(TUNTAPAddressTextBox);
            WinTUNGroupBox.Controls.Add(TUNTAPNetmaskLabel);
            WinTUNGroupBox.Controls.Add(TUNTAPNetmaskTextBox);
            WinTUNGroupBox.Controls.Add(TUNTAPGatewayLabel);
            WinTUNGroupBox.Controls.Add(TUNTAPGatewayTextBox);
            WinTUNGroupBox.Controls.Add(TUNTAPDNSLabel);
            WinTUNGroupBox.Controls.Add(TUNTAPDNSTextBox);
            WinTUNGroupBox.Controls.Add(UseCustomDNSCheckBox);
            WinTUNGroupBox.Controls.Add(ProxyDNSCheckBox);
            WinTUNGroupBox.Location = new Point(6, 6);
            WinTUNGroupBox.Name = "WinTUNGroupBox";
            WinTUNGroupBox.Size = new Size(450, 175);
            WinTUNGroupBox.TabIndex = 0;
            WinTUNGroupBox.TabStop = false;
            // 
            // TUNTAPAddressLabel
            // 
            TUNTAPAddressLabel.AutoSize = true;
            TUNTAPAddressLabel.Location = new Point(9, 25);
            TUNTAPAddressLabel.Name = "TUNTAPAddressLabel";
            TUNTAPAddressLabel.Size = new Size(56, 17);
            TUNTAPAddressLabel.TabIndex = 0;
            TUNTAPAddressLabel.Text = "Address";
            // 
            // TUNTAPAddressTextBox
            // 
            TUNTAPAddressTextBox.Location = new Point(120, 22);
            TUNTAPAddressTextBox.Name = "TUNTAPAddressTextBox";
            TUNTAPAddressTextBox.Size = new Size(294, 23);
            TUNTAPAddressTextBox.TabIndex = 1;
            TUNTAPAddressTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TUNTAPNetmaskLabel
            // 
            TUNTAPNetmaskLabel.AutoSize = true;
            TUNTAPNetmaskLabel.Location = new Point(9, 54);
            TUNTAPNetmaskLabel.Name = "TUNTAPNetmaskLabel";
            TUNTAPNetmaskLabel.Size = new Size(60, 17);
            TUNTAPNetmaskLabel.TabIndex = 2;
            TUNTAPNetmaskLabel.Text = "Netmask";
            // 
            // TUNTAPNetmaskTextBox
            // 
            TUNTAPNetmaskTextBox.Location = new Point(120, 51);
            TUNTAPNetmaskTextBox.Name = "TUNTAPNetmaskTextBox";
            TUNTAPNetmaskTextBox.Size = new Size(294, 23);
            TUNTAPNetmaskTextBox.TabIndex = 3;
            TUNTAPNetmaskTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TUNTAPGatewayLabel
            // 
            TUNTAPGatewayLabel.AutoSize = true;
            TUNTAPGatewayLabel.Location = new Point(9, 83);
            TUNTAPGatewayLabel.Name = "TUNTAPGatewayLabel";
            TUNTAPGatewayLabel.Size = new Size(57, 17);
            TUNTAPGatewayLabel.TabIndex = 4;
            TUNTAPGatewayLabel.Text = "Gateway";
            // 
            // TUNTAPGatewayTextBox
            // 
            TUNTAPGatewayTextBox.Location = new Point(120, 80);
            TUNTAPGatewayTextBox.Name = "TUNTAPGatewayTextBox";
            TUNTAPGatewayTextBox.Size = new Size(294, 23);
            TUNTAPGatewayTextBox.TabIndex = 5;
            TUNTAPGatewayTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TUNTAPDNSLabel
            // 
            TUNTAPDNSLabel.AutoSize = true;
            TUNTAPDNSLabel.Location = new Point(9, 112);
            TUNTAPDNSLabel.Name = "TUNTAPDNSLabel";
            TUNTAPDNSLabel.Size = new Size(34, 17);
            TUNTAPDNSLabel.TabIndex = 6;
            TUNTAPDNSLabel.Text = "DNS";
            // 
            // TUNTAPDNSTextBox
            // 
            TUNTAPDNSTextBox.DataBindings.Add(new Binding("Enabled", UseCustomDNSCheckBox, "Checked", true));
            TUNTAPDNSTextBox.Location = new Point(120, 110);
            TUNTAPDNSTextBox.Name = "TUNTAPDNSTextBox";
            TUNTAPDNSTextBox.Size = new Size(294, 23);
            TUNTAPDNSTextBox.TabIndex = 7;
            TUNTAPDNSTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // UseCustomDNSCheckBox
            // 
            UseCustomDNSCheckBox.AutoSize = true;
            UseCustomDNSCheckBox.Location = new Point(10, 139);
            UseCustomDNSCheckBox.Name = "UseCustomDNSCheckBox";
            UseCustomDNSCheckBox.Size = new Size(125, 21);
            UseCustomDNSCheckBox.TabIndex = 8;
            UseCustomDNSCheckBox.Text = "Use custom DNS";
            UseCustomDNSCheckBox.UseVisualStyleBackColor = true;
            UseCustomDNSCheckBox.Click += TUNTAPUseCustomDNSCheckBox_CheckedChanged;
            // 
            // ProxyDNSCheckBox
            // 
            ProxyDNSCheckBox.AutoSize = true;
            ProxyDNSCheckBox.DataBindings.Add(new Binding("Visible", UseCustomDNSCheckBox, "Checked", true));
            ProxyDNSCheckBox.Location = new Point(175, 139);
            ProxyDNSCheckBox.Name = "ProxyDNSCheckBox";
            ProxyDNSCheckBox.Size = new Size(89, 21);
            ProxyDNSCheckBox.TabIndex = 9;
            ProxyDNSCheckBox.Text = "Proxy DNS";
            ProxyDNSCheckBox.UseVisualStyleBackColor = true;
            // 
            // GlobalBypassIPsButton
            // 
            GlobalBypassIPsButton.Location = new Point(6, 199);
            GlobalBypassIPsButton.Name = "GlobalBypassIPsButton";
            GlobalBypassIPsButton.Size = new Size(128, 23);
            GlobalBypassIPsButton.TabIndex = 1;
            GlobalBypassIPsButton.Text = "Global Bypass IPs";
            GlobalBypassIPsButton.UseVisualStyleBackColor = true;
            GlobalBypassIPsButton.Click += GlobalBypassIPsButton_Click;
            // 
            // v2rayTabPage
            // 
            v2rayTabPage.BackColor = SystemColors.ButtonFace;
            v2rayTabPage.Controls.Add(DefFingerprintComboBox);
            v2rayTabPage.Controls.Add(DefFingerprintLabel);
            v2rayTabPage.Controls.Add(EnableFragmentBox);
            v2rayTabPage.Controls.Add(TLSAllowInsecureCheckBox);
            v2rayTabPage.Controls.Add(UseMuxCheckBox);
            v2rayTabPage.Controls.Add(KCPGroupBox);
            v2rayTabPage.Location = new Point(4, 29);
            v2rayTabPage.Name = "v2rayTabPage";
            v2rayTabPage.Padding = new Padding(3);
            v2rayTabPage.Size = new Size(562, 290);
            v2rayTabPage.TabIndex = 3;
            v2rayTabPage.Text = "V2Ray";
            // 
            // DefFingerprintComboBox
            // 
            DefFingerprintComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DefFingerprintComboBox.FormattingEnabled = true;
            DefFingerprintComboBox.Location = new Point(150, 43);
            DefFingerprintComboBox.Name = "DefFingerprintComboBox";
            DefFingerprintComboBox.Size = new Size(140, 25);
            DefFingerprintComboBox.TabIndex = 15;
            // 
            // DefFingerprintLabel
            // 
            DefFingerprintLabel.AutoSize = true;
            DefFingerprintLabel.Location = new Point(15, 46);
            DefFingerprintLabel.Name = "DefFingerprintLabel";
            DefFingerprintLabel.Size = new Size(116, 17);
            DefFingerprintLabel.TabIndex = 0;
            DefFingerprintLabel.Text = "Default Fingerprint";
            // 
            // EnableFragmentBox
            // 
            EnableFragmentBox.AutoSize = true;
            EnableFragmentBox.Location = new Point(17, 16);
            EnableFragmentBox.Name = "EnableFragmentBox";
            EnableFragmentBox.Size = new Size(125, 21);
            EnableFragmentBox.TabIndex = 0;
            EnableFragmentBox.Text = "Enable Fragment";
            EnableFragmentBox.UseVisualStyleBackColor = true;
            // 
            // TLSAllowInsecureCheckBox
            // 
            TLSAllowInsecureCheckBox.AutoSize = true;
            TLSAllowInsecureCheckBox.Location = new Point(159, 16);
            TLSAllowInsecureCheckBox.Name = "TLSAllowInsecureCheckBox";
            TLSAllowInsecureCheckBox.Size = new Size(131, 21);
            TLSAllowInsecureCheckBox.TabIndex = 1;
            TLSAllowInsecureCheckBox.Text = "TLS AllowInsecure";
            TLSAllowInsecureCheckBox.UseVisualStyleBackColor = true;
            // 
            // UseMuxCheckBox
            // 
            UseMuxCheckBox.AutoSize = true;
            UseMuxCheckBox.Location = new Point(311, 16);
            UseMuxCheckBox.Name = "UseMuxCheckBox";
            UseMuxCheckBox.Size = new Size(78, 21);
            UseMuxCheckBox.TabIndex = 2;
            UseMuxCheckBox.Text = "Use Mux";
            UseMuxCheckBox.UseVisualStyleBackColor = true;
            // 
            // KCPGroupBox
            // 
            KCPGroupBox.Controls.Add(tableLayoutPanel);
            KCPGroupBox.Location = new Point(9, 75);
            KCPGroupBox.Name = "KCPGroupBox";
            KCPGroupBox.Size = new Size(547, 204);
            KCPGroupBox.TabIndex = 3;
            KCPGroupBox.TabStop = false;
            KCPGroupBox.Text = "KCP";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.Controls.Add(mtuLabel);
            tableLayoutPanel.Controls.Add(mtuTextBox);
            tableLayoutPanel.Controls.Add(ttiLabel);
            tableLayoutPanel.Controls.Add(ttiTextBox);
            tableLayoutPanel.Controls.Add(uplinkCapacityLabel);
            tableLayoutPanel.Controls.Add(uplinkCapacityTextBox);
            tableLayoutPanel.Controls.Add(downlinkCapacityLabel);
            tableLayoutPanel.Controls.Add(downlinkCapacityTextBox);
            tableLayoutPanel.Controls.Add(readBufferSizeLabel);
            tableLayoutPanel.Controls.Add(readBufferSizeTextBox);
            tableLayoutPanel.Controls.Add(writeBufferSizeLabel);
            tableLayoutPanel.Controls.Add(writeBufferSizeTextBox);
            tableLayoutPanel.Controls.Add(congestionCheckBox);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(3, 19);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(541, 182);
            tableLayoutPanel.TabIndex = 13;
            // 
            // mtuLabel
            // 
            mtuLabel.AutoSize = true;
            mtuLabel.Dock = DockStyle.Fill;
            mtuLabel.Location = new Point(3, 3);
            mtuLabel.Margin = new Padding(3);
            mtuLabel.Name = "mtuLabel";
            mtuLabel.Size = new Size(96, 23);
            mtuLabel.TabIndex = 0;
            mtuLabel.Text = "MTU";
            mtuLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mtuTextBox
            // 
            mtuTextBox.Location = new Point(105, 3);
            mtuTextBox.Name = "mtuTextBox";
            mtuTextBox.Size = new Size(90, 23);
            mtuTextBox.TabIndex = 1;
            mtuTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ttiLabel
            // 
            ttiLabel.AutoSize = true;
            ttiLabel.Dock = DockStyle.Fill;
            ttiLabel.Location = new Point(201, 3);
            ttiLabel.Margin = new Padding(3);
            ttiLabel.Name = "ttiLabel";
            ttiLabel.Size = new Size(110, 23);
            ttiLabel.TabIndex = 2;
            ttiLabel.Text = "TTI";
            ttiLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ttiTextBox
            // 
            ttiTextBox.Location = new Point(317, 3);
            ttiTextBox.Name = "ttiTextBox";
            ttiTextBox.Size = new Size(90, 23);
            ttiTextBox.TabIndex = 3;
            ttiTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // uplinkCapacityLabel
            // 
            uplinkCapacityLabel.AutoSize = true;
            uplinkCapacityLabel.Dock = DockStyle.Fill;
            uplinkCapacityLabel.Location = new Point(3, 32);
            uplinkCapacityLabel.Margin = new Padding(3);
            uplinkCapacityLabel.Name = "uplinkCapacityLabel";
            uplinkCapacityLabel.Size = new Size(96, 23);
            uplinkCapacityLabel.TabIndex = 4;
            uplinkCapacityLabel.Text = "UplinkCapacity";
            uplinkCapacityLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uplinkCapacityTextBox
            // 
            uplinkCapacityTextBox.Location = new Point(105, 32);
            uplinkCapacityTextBox.Name = "uplinkCapacityTextBox";
            uplinkCapacityTextBox.Size = new Size(90, 23);
            uplinkCapacityTextBox.TabIndex = 5;
            uplinkCapacityTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // downlinkCapacityLabel
            // 
            downlinkCapacityLabel.Dock = DockStyle.Fill;
            downlinkCapacityLabel.Location = new Point(201, 32);
            downlinkCapacityLabel.Margin = new Padding(3);
            downlinkCapacityLabel.Name = "downlinkCapacityLabel";
            downlinkCapacityLabel.Size = new Size(110, 23);
            downlinkCapacityLabel.TabIndex = 6;
            downlinkCapacityLabel.Text = "DownlinkCapacity";
            downlinkCapacityLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // downlinkCapacityTextBox
            // 
            downlinkCapacityTextBox.Location = new Point(317, 32);
            downlinkCapacityTextBox.Name = "downlinkCapacityTextBox";
            downlinkCapacityTextBox.Size = new Size(90, 23);
            downlinkCapacityTextBox.TabIndex = 7;
            downlinkCapacityTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // readBufferSizeLabel
            // 
            readBufferSizeLabel.AutoSize = true;
            readBufferSizeLabel.Dock = DockStyle.Fill;
            readBufferSizeLabel.Location = new Point(3, 61);
            readBufferSizeLabel.Margin = new Padding(3);
            readBufferSizeLabel.Name = "readBufferSizeLabel";
            readBufferSizeLabel.Size = new Size(96, 23);
            readBufferSizeLabel.TabIndex = 8;
            readBufferSizeLabel.Text = "ReadBufferSize";
            readBufferSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // readBufferSizeTextBox
            // 
            readBufferSizeTextBox.Location = new Point(105, 61);
            readBufferSizeTextBox.Name = "readBufferSizeTextBox";
            readBufferSizeTextBox.Size = new Size(90, 23);
            readBufferSizeTextBox.TabIndex = 9;
            readBufferSizeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // writeBufferSizeLabel
            // 
            writeBufferSizeLabel.AutoSize = true;
            writeBufferSizeLabel.Dock = DockStyle.Fill;
            writeBufferSizeLabel.Location = new Point(201, 61);
            writeBufferSizeLabel.Margin = new Padding(3);
            writeBufferSizeLabel.Name = "writeBufferSizeLabel";
            writeBufferSizeLabel.Size = new Size(110, 23);
            writeBufferSizeLabel.TabIndex = 10;
            writeBufferSizeLabel.Text = "WriteBufferSize";
            writeBufferSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // writeBufferSizeTextBox
            // 
            writeBufferSizeTextBox.Location = new Point(317, 61);
            writeBufferSizeTextBox.Name = "writeBufferSizeTextBox";
            writeBufferSizeTextBox.Size = new Size(90, 23);
            writeBufferSizeTextBox.TabIndex = 11;
            writeBufferSizeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // congestionCheckBox
            // 
            congestionCheckBox.AutoSize = true;
            congestionCheckBox.Dock = DockStyle.Fill;
            congestionCheckBox.Location = new Point(3, 90);
            congestionCheckBox.Name = "congestionCheckBox";
            congestionCheckBox.Size = new Size(96, 21);
            congestionCheckBox.TabIndex = 12;
            congestionCheckBox.Text = "Congestion";
            congestionCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            congestionCheckBox.UseVisualStyleBackColor = true;
            // 
            // HysteriaTabPage
            // 
            HysteriaTabPage.Controls.Add(HysteriaBandwidthGroupBox);
            HysteriaTabPage.Location = new Point(4, 29);
            HysteriaTabPage.Name = "HysteriaTabPage";
            HysteriaTabPage.Padding = new Padding(3);
            HysteriaTabPage.Size = new Size(562, 290);
            HysteriaTabPage.TabIndex = 6;
            HysteriaTabPage.Text = "Hysteria";
            HysteriaTabPage.UseVisualStyleBackColor = true;
            // 
            // HysteriaBandwidthGroupBox
            // 
            HysteriaBandwidthGroupBox.Controls.Add(HysteriaDownMbpsTextBox);
            HysteriaBandwidthGroupBox.Controls.Add(HysteriaUpMbpsTextBox);
            HysteriaBandwidthGroupBox.Location = new Point(6, 6);
            HysteriaBandwidthGroupBox.Name = "HysteriaBandwidthGroupBox";
            HysteriaBandwidthGroupBox.Size = new Size(260, 69);
            HysteriaBandwidthGroupBox.TabIndex = 1;
            HysteriaBandwidthGroupBox.TabStop = false;
            HysteriaBandwidthGroupBox.Text = "Bande Passante Maximale (Up/Down)";
            // 
            // HysteriaDownMbpsTextBox
            // 
            HysteriaDownMbpsTextBox.Location = new Point(118, 22);
            HysteriaDownMbpsTextBox.Name = "HysteriaDownMbpsTextBox";
            HysteriaDownMbpsTextBox.Size = new Size(100, 23);
            HysteriaDownMbpsTextBox.TabIndex = 1;
            // 
            // HysteriaUpMbpsTextBox
            // 
            HysteriaUpMbpsTextBox.Location = new Point(12, 22);
            HysteriaUpMbpsTextBox.Name = "HysteriaUpMbpsTextBox";
            HysteriaUpMbpsTextBox.Size = new Size(100, 23);
            HysteriaUpMbpsTextBox.TabIndex = 0;
            // 
            // SingboxTabPage
            // 
            SingboxTabPage.Controls.Add(tableLayoutPanel2);
            SingboxTabPage.Location = new Point(4, 29);
            SingboxTabPage.Name = "SingboxTabPage";
            SingboxTabPage.Padding = new Padding(3);
            SingboxTabPage.Size = new Size(562, 290);
            SingboxTabPage.TabIndex = 7;
            SingboxTabPage.Text = "Singbox";
            SingboxTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(SingboxMuxProtocolComboBox, 1, 0);
            tableLayoutPanel2.Controls.Add(SingboxMuxProtocolLabel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(556, 284);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // SingboxMuxProtocolComboBox
            // 
            SingboxMuxProtocolComboBox.Dock = DockStyle.Fill;
            SingboxMuxProtocolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SingboxMuxProtocolComboBox.FormattingEnabled = true;
            SingboxMuxProtocolComboBox.Location = new Point(95, 3);
            SingboxMuxProtocolComboBox.Name = "SingboxMuxProtocolComboBox";
            SingboxMuxProtocolComboBox.Size = new Size(131, 25);
            SingboxMuxProtocolComboBox.TabIndex = 0;
            // 
            // SingboxMuxProtocolLabel
            // 
            SingboxMuxProtocolLabel.AutoSize = true;
            SingboxMuxProtocolLabel.Dock = DockStyle.Fill;
            SingboxMuxProtocolLabel.Location = new Point(3, 3);
            SingboxMuxProtocolLabel.Margin = new Padding(3);
            SingboxMuxProtocolLabel.Name = "SingboxMuxProtocolLabel";
            SingboxMuxProtocolLabel.Size = new Size(86, 25);
            SingboxMuxProtocolLabel.TabIndex = 1;
            SingboxMuxProtocolLabel.Text = "Mux Protocol";
            SingboxMuxProtocolLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OtherTabPage
            // 
            OtherTabPage.BackColor = SystemColors.ButtonFace;
            OtherTabPage.Controls.Add(tableLayoutPanel3);
            OtherTabPage.Location = new Point(4, 29);
            OtherTabPage.Name = "OtherTabPage";
            OtherTabPage.Padding = new Padding(3);
            OtherTabPage.Size = new Size(562, 290);
            OtherTabPage.TabIndex = 4;
            OtherTabPage.Text = "Others";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(UpdateServersWhenOpenedCheckBox, 0, 4);
            tableLayoutPanel3.Controls.Add(CheckBetaUpdateCheckBox, 1, 3);
            tableLayoutPanel3.Controls.Add(NoSupportDialogCheckBox, 0, 3);
            tableLayoutPanel3.Controls.Add(CheckUpdateWhenOpenedCheckBox, 1, 2);
            tableLayoutPanel3.Controls.Add(RunAtStartupCheckBox, 0, 2);
            tableLayoutPanel3.Controls.Add(MinimizeWhenStartedCheckBox, 1, 1);
            tableLayoutPanel3.Controls.Add(StartWhenOpenedCheckBox, 0, 1);
            tableLayoutPanel3.Controls.Add(StopWhenExitedCheckBox, 1, 0);
            tableLayoutPanel3.Controls.Add(ExitWhenClosedCheckBox, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(556, 284);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // UpdateServersWhenOpenedCheckBox
            // 
            UpdateServersWhenOpenedCheckBox.AutoSize = true;
            UpdateServersWhenOpenedCheckBox.Location = new Point(3, 111);
            UpdateServersWhenOpenedCheckBox.Name = "UpdateServersWhenOpenedCheckBox";
            UpdateServersWhenOpenedCheckBox.Padding = new Padding(17, 0, 0, 0);
            UpdateServersWhenOpenedCheckBox.Size = new Size(217, 21);
            UpdateServersWhenOpenedCheckBox.TabIndex = 8;
            UpdateServersWhenOpenedCheckBox.Text = "Update Servers when opened";
            UpdateServersWhenOpenedCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            UpdateServersWhenOpenedCheckBox.UseVisualStyleBackColor = true;
            // 
            // CheckBetaUpdateCheckBox
            // 
            CheckBetaUpdateCheckBox.AutoSize = true;
            CheckBetaUpdateCheckBox.Location = new Point(281, 84);
            CheckBetaUpdateCheckBox.Name = "CheckBetaUpdateCheckBox";
            CheckBetaUpdateCheckBox.Padding = new Padding(17, 0, 0, 0);
            CheckBetaUpdateCheckBox.Size = new Size(154, 21);
            CheckBetaUpdateCheckBox.TabIndex = 7;
            CheckBetaUpdateCheckBox.Text = "Check Beta update";
            CheckBetaUpdateCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            CheckBetaUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // NoSupportDialogCheckBox
            // 
            NoSupportDialogCheckBox.AutoSize = true;
            NoSupportDialogCheckBox.Location = new Point(3, 84);
            NoSupportDialogCheckBox.Name = "NoSupportDialogCheckBox";
            NoSupportDialogCheckBox.Padding = new Padding(17, 0, 0, 0);
            NoSupportDialogCheckBox.Size = new Size(191, 21);
            NoSupportDialogCheckBox.TabIndex = 6;
            NoSupportDialogCheckBox.Text = "Disable Support Warning";
            NoSupportDialogCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            NoSupportDialogCheckBox.UseVisualStyleBackColor = true;
            // 
            // CheckUpdateWhenOpenedCheckBox
            // 
            CheckUpdateWhenOpenedCheckBox.AutoSize = true;
            CheckUpdateWhenOpenedCheckBox.Location = new Point(281, 57);
            CheckUpdateWhenOpenedCheckBox.Name = "CheckUpdateWhenOpenedCheckBox";
            CheckUpdateWhenOpenedCheckBox.Padding = new Padding(17, 0, 0, 0);
            CheckUpdateWhenOpenedCheckBox.Size = new Size(207, 21);
            CheckUpdateWhenOpenedCheckBox.TabIndex = 5;
            CheckUpdateWhenOpenedCheckBox.Text = "Check update when opened";
            CheckUpdateWhenOpenedCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            CheckUpdateWhenOpenedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RunAtStartupCheckBox
            // 
            RunAtStartupCheckBox.AutoSize = true;
            RunAtStartupCheckBox.Location = new Point(3, 57);
            RunAtStartupCheckBox.Name = "RunAtStartupCheckBox";
            RunAtStartupCheckBox.Padding = new Padding(17, 0, 0, 0);
            RunAtStartupCheckBox.Size = new Size(126, 21);
            RunAtStartupCheckBox.TabIndex = 4;
            RunAtStartupCheckBox.Text = "Run at startup";
            RunAtStartupCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            RunAtStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinimizeWhenStartedCheckBox
            // 
            MinimizeWhenStartedCheckBox.AutoSize = true;
            MinimizeWhenStartedCheckBox.Location = new Point(281, 30);
            MinimizeWhenStartedCheckBox.Name = "MinimizeWhenStartedCheckBox";
            MinimizeWhenStartedCheckBox.Padding = new Padding(17, 0, 0, 0);
            MinimizeWhenStartedCheckBox.Size = new Size(175, 21);
            MinimizeWhenStartedCheckBox.TabIndex = 3;
            MinimizeWhenStartedCheckBox.Text = "Minimize when started";
            MinimizeWhenStartedCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            MinimizeWhenStartedCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartWhenOpenedCheckBox
            // 
            StartWhenOpenedCheckBox.AutoSize = true;
            StartWhenOpenedCheckBox.Location = new Point(3, 30);
            StartWhenOpenedCheckBox.Name = "StartWhenOpenedCheckBox";
            StartWhenOpenedCheckBox.Padding = new Padding(17, 0, 0, 0);
            StartWhenOpenedCheckBox.Size = new Size(154, 21);
            StartWhenOpenedCheckBox.TabIndex = 2;
            StartWhenOpenedCheckBox.Text = "Start when opened";
            StartWhenOpenedCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            StartWhenOpenedCheckBox.UseVisualStyleBackColor = true;
            // 
            // StopWhenExitedCheckBox
            // 
            StopWhenExitedCheckBox.AutoSize = true;
            StopWhenExitedCheckBox.Location = new Point(281, 3);
            StopWhenExitedCheckBox.Name = "StopWhenExitedCheckBox";
            StopWhenExitedCheckBox.Padding = new Padding(17, 0, 0, 0);
            StopWhenExitedCheckBox.Size = new Size(144, 21);
            StopWhenExitedCheckBox.TabIndex = 1;
            StopWhenExitedCheckBox.Text = "Stop when exited";
            StopWhenExitedCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            StopWhenExitedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExitWhenClosedCheckBox
            // 
            ExitWhenClosedCheckBox.AutoSize = true;
            ExitWhenClosedCheckBox.Location = new Point(3, 3);
            ExitWhenClosedCheckBox.Name = "ExitWhenClosedCheckBox";
            ExitWhenClosedCheckBox.Padding = new Padding(17, 0, 0, 0);
            ExitWhenClosedCheckBox.Size = new Size(140, 21);
            ExitWhenClosedCheckBox.TabIndex = 0;
            ExitWhenClosedCheckBox.Text = "Exit when closed";
            ExitWhenClosedCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            ExitWhenClosedCheckBox.UseVisualStyleBackColor = true;
            // 
            // AioDNSTabPage
            // 
            AioDNSTabPage.Controls.Add(ChinaDNSLabel);
            AioDNSTabPage.Controls.Add(ChinaDNSTextBox);
            AioDNSTabPage.Controls.Add(OtherDNSLabel);
            AioDNSTabPage.Controls.Add(OtherDNSTextBox);
            AioDNSTabPage.Location = new Point(4, 29);
            AioDNSTabPage.Name = "AioDNSTabPage";
            AioDNSTabPage.Padding = new Padding(3);
            AioDNSTabPage.Size = new Size(562, 290);
            AioDNSTabPage.TabIndex = 5;
            AioDNSTabPage.Text = "AioDNS";
            AioDNSTabPage.UseVisualStyleBackColor = true;
            // 
            // ChinaDNSLabel
            // 
            ChinaDNSLabel.AutoSize = true;
            ChinaDNSLabel.Location = new Point(15, 23);
            ChinaDNSLabel.Name = "ChinaDNSLabel";
            ChinaDNSLabel.Size = new Size(70, 17);
            ChinaDNSLabel.TabIndex = 0;
            ChinaDNSLabel.Text = "China DNS";
            // 
            // ChinaDNSTextBox
            // 
            ChinaDNSTextBox.Location = new Point(114, 20);
            ChinaDNSTextBox.Name = "ChinaDNSTextBox";
            ChinaDNSTextBox.Size = new Size(312, 23);
            ChinaDNSTextBox.TabIndex = 1;
            ChinaDNSTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // OtherDNSLabel
            // 
            OtherDNSLabel.AutoSize = true;
            OtherDNSLabel.Location = new Point(15, 63);
            OtherDNSLabel.Name = "OtherDNSLabel";
            OtherDNSLabel.Size = new Size(71, 17);
            OtherDNSLabel.TabIndex = 2;
            OtherDNSLabel.Text = "Other DNS";
            // 
            // OtherDNSTextBox
            // 
            OtherDNSTextBox.Location = new Point(114, 60);
            OtherDNSTextBox.Name = "OtherDNSTextBox";
            OtherDNSTextBox.Size = new Size(312, 23);
            OtherDNSTextBox.TabIndex = 3;
            OtherDNSTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ControlButton
            // 
            ControlButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ControlButton.Location = new Point(498, 332);
            ControlButton.Name = "ControlButton";
            ControlButton.Size = new Size(75, 23);
            ControlButton.TabIndex = 1;
            ControlButton.Text = "Save";
            ControlButton.UseVisualStyleBackColor = true;
            ControlButton.Click += ControlButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(TabControl);
            tableLayoutPanel1.Controls.Add(ControlButton);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.Size = new Size(576, 358);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(576, 358);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SettingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingForm_Load;
            TabControl.ResumeLayout(false);
            GeneralTabPage.ResumeLayout(false);
            GeneralTabPage.PerformLayout();
            OutboundDNSFlowLayoutPanel.ResumeLayout(false);
            OutboundDNSFlowLayoutPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)OutboundDNSAddCurrentPictureBox).EndInit();
            ((ISupportInitialize)OutboundDNSDeleteCurrentPictureBox).EndInit();
            ServerPingTypeGroupBox.ResumeLayout(false);
            ServerPingTableLayoutPanel.ResumeLayout(false);
            ServerPingTableLayoutPanel.PerformLayout();
            PortGroupBox.ResumeLayout(false);
            PortGroupBox.PerformLayout();
            NFTabPage.ResumeLayout(false);
            NFTabPage.PerformLayout();
            WinTUNTabPage.ResumeLayout(false);
            WinTUNGroupBox.ResumeLayout(false);
            WinTUNGroupBox.PerformLayout();
            v2rayTabPage.ResumeLayout(false);
            v2rayTabPage.PerformLayout();
            KCPGroupBox.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            HysteriaTabPage.ResumeLayout(false);
            HysteriaBandwidthGroupBox.ResumeLayout(false);
            HysteriaBandwidthGroupBox.PerformLayout();
            SingboxTabPage.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            OtherTabPage.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            AioDNSTabPage.ResumeLayout(false);
            AioDNSTabPage.PerformLayout();
            ((ISupportInitialize)errorProvider).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }
        private System.Windows.Forms.CheckBox EnableFragmentBox;
        private System.Windows.Forms.TextBox StartedPingIntervalTextBox;

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage NFTabPage;
        private System.Windows.Forms.TabPage WinTUNTabPage;
        private System.Windows.Forms.TabPage v2rayTabPage;
        private System.Windows.Forms.GroupBox PortGroupBox;
        private System.Windows.Forms.CheckBox AllowDevicesCheckBox;
        private System.Windows.Forms.Label Socks5PortLabel;
        private System.Windows.Forms.TextBox Socks5PortTextBox;
        private System.Windows.Forms.GroupBox WinTUNGroupBox;
        private System.Windows.Forms.CheckBox ProxyDNSCheckBox;
        private System.Windows.Forms.CheckBox UseCustomDNSCheckBox;
        private System.Windows.Forms.Label TUNTAPDNSLabel;
        private System.Windows.Forms.TextBox TUNTAPDNSTextBox;
        private System.Windows.Forms.Label TUNTAPGatewayLabel;
        private System.Windows.Forms.TextBox TUNTAPGatewayTextBox;
        private System.Windows.Forms.Label TUNTAPNetmaskLabel;
        private System.Windows.Forms.TextBox TUNTAPNetmaskTextBox;
        private System.Windows.Forms.Label TUNTAPAddressLabel;
        private System.Windows.Forms.TextBox TUNTAPAddressTextBox;
        private System.Windows.Forms.Button GlobalBypassIPsButton;
        private System.Windows.Forms.CheckBox FilterDNSCheckBox;
        private System.Windows.Forms.Button ControlButton;
        private System.Windows.Forms.TabPage OtherTabPage;
        private System.Windows.Forms.CheckBox UpdateServersWhenOpenedCheckBox;
        private System.Windows.Forms.CheckBox RunAtStartupCheckBox;
        private System.Windows.Forms.CheckBox MinimizeWhenStartedCheckBox;
        private System.Windows.Forms.CheckBox CheckBetaUpdateCheckBox;
        private System.Windows.Forms.CheckBox CheckUpdateWhenOpenedCheckBox;
        private System.Windows.Forms.CheckBox StartWhenOpenedCheckBox;
        private System.Windows.Forms.CheckBox StopWhenExitedCheckBox;
        private System.Windows.Forms.CheckBox ExitWhenClosedCheckBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label DetectionTickLabel;
        private System.Windows.Forms.TextBox DetectionTickTextBox;
        private System.Windows.Forms.Label StartedPingLabel;
        private System.Windows.Forms.Label STUNServerLabel;
        private System.Windows.Forms.ComboBox STUN_ServerComboBox;
        private System.Windows.Forms.Label ProfileCountLabel;
        private System.Windows.Forms.TextBox ProfileCountTextBox;
        private System.Windows.Forms.GroupBox KCPGroupBox;
        private System.Windows.Forms.CheckBox congestionCheckBox;
        private System.Windows.Forms.CheckBox TLSAllowInsecureCheckBox;
        private System.Windows.Forms.Label mtuLabel;
        private System.Windows.Forms.TextBox mtuTextBox;
        private System.Windows.Forms.Label writeBufferSizeLabel;
        private System.Windows.Forms.TextBox writeBufferSizeTextBox;
        private System.Windows.Forms.Label readBufferSizeLabel;
        private System.Windows.Forms.TextBox readBufferSizeTextBox;
        private System.Windows.Forms.Label downlinkCapacityLabel;
        private System.Windows.Forms.TextBox downlinkCapacityTextBox;
        private System.Windows.Forms.Label uplinkCapacityLabel;
        private System.Windows.Forms.TextBox uplinkCapacityTextBox;
        private System.Windows.Forms.Label ttiLabel;
        private System.Windows.Forms.TextBox ttiTextBox;
        private System.Windows.Forms.CheckBox UseMuxCheckBox;
        private System.Windows.Forms.TabPage AioDNSTabPage;
        private System.Windows.Forms.Label OtherDNSLabel;
        private System.Windows.Forms.Label ChinaDNSLabel;
        private System.Windows.Forms.TextBox OtherDNSTextBox;
        private System.Windows.Forms.TextBox ChinaDNSTextBox;
        private System.Windows.Forms.TextBox DNSHijackHostTextBox;
        private System.Windows.Forms.RadioButton TCPingRadioBtn;
        private System.Windows.Forms.RadioButton ICMPingRadioBtn;
        private System.Windows.Forms.CheckBox FilterICMPCheckBox;
        private System.Windows.Forms.CheckBox ChildProcessHandleCheckBox;
        private System.Windows.Forms.TextBox ICMPDelayTextBox;
        private System.Windows.Forms.Label ICMPDelayLabel;
        private System.Windows.Forms.CheckBox NoSupportDialogCheckBox;
        private System.Windows.Forms.Label DNSHijackLabel;
        private System.Windows.Forms.CheckBox HandleProcDNSCheckBox;
        private System.Windows.Forms.CheckBox FilterTCPCheckBox;
        private System.Windows.Forms.CheckBox FilterUDPCheckBox;
        private System.Windows.Forms.CheckBox DNSProxyCheckBox;
        private ErrorProvider errorProvider;
        private Label OutboundDNSLabel;
        private Label DefFingerprintLabel;
        private ComboBox DefFingerprintComboBox;
        private TabPage HysteriaTabPage;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox HysteriaBandwidthGroupBox;
        private TextBox HysteriaDownMbpsTextBox;
        private TextBox HysteriaUpMbpsTextBox;
        private TabPage SingboxTabPage;
        private Label SingboxMuxProtocolLabel;
        private ComboBox SingboxMuxProtocolComboBox;
        private TableLayoutPanel tableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox OutboundDNSComboBox;
        private PictureBox OutboundDNSDeleteCurrentPictureBox;
        private PictureBox OutboundDNSAddCurrentPictureBox;
        private CheckBox UseOutboundDNSCheckBox;
        private RadioButton UseResolvedIPRadioButton;
        private RadioButton UseDomainNameRadioButton;
        private TableLayoutPanel ServerPingTableLayoutPanel;
        private GroupBox ServerPingTypeGroupBox;
        private FlowLayoutPanel OutboundDNSFlowLayoutPanel;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}