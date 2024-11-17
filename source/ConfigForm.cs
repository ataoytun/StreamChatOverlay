namespace ChatOverlay
{
    public partial class ConfigForm : Form
    {
        #region Fields and Events
        private readonly Settings _settings;
        public event EventHandler<Settings> SettingsChanged;
        #endregion

        #region Initialization
        public ConfigForm(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            LoadSettings();
            trackOpacity.ValueChanged += (s, e) => { lblOpacityValue.Text = $"{trackOpacity.Value}%"; };
            numWindowWidth.Maximum = Screen.PrimaryScreen.Bounds.Width;
            numWindowHeight.Maximum = Screen.PrimaryScreen.Bounds.Height;
        }

        private void LoadSettings()
        {
            txtTwitchChannel.Text = _settings.TwitchChannel;
            txtKickChannel.Text = _settings.KickChannel;
            trackOpacity.Value = (int)(_settings.WindowOpacity * 100);
            lblOpacityValue.Text = $"{trackOpacity.Value}%";
            numRefreshRate.Value = _settings.RefreshRate;
            rdoSideBySide.Checked = _settings.ChatLayout == ChatLayout.SideBySide;
            rdoStacked.Checked = _settings.ChatLayout == ChatLayout.Stacked;
            chkTopMost.Checked = _settings.IsTopMost;
            chkEnableTwitch.Checked = _settings.IsTwitchEnabled;
            chkEnableKick.Checked = _settings.IsKickEnabled;
            chkHideFromCapture.Checked = _settings.IsHiddenFromCapture;
            numWindowWidth.Value = _settings.WindowWidth;
            numWindowHeight.Value = _settings.WindowHeight;
        }
        #endregion

        #region Event Handlers
        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.TwitchChannel = txtTwitchChannel.Text.Trim();
            _settings.KickChannel = txtKickChannel.Text.Trim();
            _settings.WindowOpacity = trackOpacity.Value / 100.0;
            _settings.RefreshRate = (int)numRefreshRate.Value;
            _settings.ChatLayout = rdoSideBySide.Checked ? ChatLayout.SideBySide : ChatLayout.Stacked;
            _settings.IsTopMost = chkTopMost.Checked;
            _settings.IsTwitchEnabled = chkEnableTwitch.Checked;
            _settings.IsKickEnabled = chkEnableKick.Checked;
            _settings.IsHiddenFromCapture = chkHideFromCapture.Checked;
            _settings.WindowWidth = (int)numWindowWidth.Value;
            _settings.WindowHeight = (int)numWindowHeight.Value;

            SettingsChanged?.Invoke(this, _settings);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}