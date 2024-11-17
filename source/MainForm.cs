using Microsoft.Web.WebView2.WinForms;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace ChatOverlay
{
    public partial class MainForm : Form
    {
        #region Fields
        private readonly Settings _settings;
        private bool _isDragging = false;
        private Point _dragStart;
        private readonly NotifyIcon _trayIcon;
        private readonly WebView2[] _chatViews;
        private const string SETTINGS_FILE = "settings.json";
        private Panel _controlPanel;
        #endregion

        #region Win32 Constants and Imports
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = -20;
        private const int HTCAPTION = 0x2;
        private const int WM_NCHITTEST = 0x84;
        private const uint WDA_NONE = 0x00000000;
        private const uint WDA_MONITOR = 0x00000001;
        private const uint WDA_EXCLUDEFROMCAPTURE = 0x00000011;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        [DllImport("user32.dll")]
        private static extern bool SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        #endregion

        #region Initialization
        public MainForm()
        {
            InitializeComponent();
            InitializeControlPanel();
            _settings = LoadSettings();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.TransparencyKey = Color.Wheat;
            this.BackColor = Color.Wheat;

            MakeClickThrough();

            if (_settings.WindowPosition != Point.Empty)
                this.Location = _settings.WindowPosition;

            this.Opacity = _settings.WindowOpacity;

            SetWindowDisplayAffinity(this.Handle, _settings.IsHiddenFromCapture ? WDA_EXCLUDEFROMCAPTURE : WDA_NONE);

            _chatViews = new WebView2[2];
            InitializeWebViews();

            _trayIcon = new NotifyIcon {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
                Visible = true,
                ContextMenuStrip = CreateTrayMenu()
            };
            _trayIcon.DoubleClick += (s, e) => ShowConfigDialog();

            this.ClientSize = new Size(_settings.WindowWidth, _settings.WindowHeight);
        }

        private void InitializeControlPanel()
        {
            _controlPanel = new Panel {
                Size = new Size(80, 20),
                Location = new Point(0, 0),
                BackColor = Color.DarkGray,
                Visible = false,
                Cursor = Cursors.SizeAll
            };

            _controlPanel.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left) {
                    _isDragging = true;
                    _dragStart = e.Location;
                }
            };

            _controlPanel.MouseMove += (s, e) => {
                if (_isDragging) {
                    Point difference = new Point(e.Location.X - _dragStart.X, e.Location.Y - _dragStart.Y);
                    this.Location = new Point(this.Location.X + difference.X, this.Location.Y + difference.Y);
                }
            };

            _controlPanel.MouseUp += (s, e) => {
                if (e.Button == MouseButtons.Left) {
                    _isDragging = false;
                    _settings.WindowPosition = this.Location;
                    SaveSettings();
                }
            };

            this.Controls.Add(_controlPanel);
        }
        #endregion

        #region Window Management
        private void MakeClickThrough()
        {
            int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            exStyle |= WS_EX_LAYERED | WS_EX_TRANSPARENT;
            SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle);
            _controlPanel.Visible = false;
        }

        private void MakeClickable()
        {
            int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            exStyle &= ~WS_EX_TRANSPARENT;
            SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle);
            _controlPanel.Visible = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST) {
                m.Result = (IntPtr)HTCAPTION;
                return;
            }
            base.WndProc(ref m);
        }

        private void ToggleClickThrough()
        {
            if ((GetWindowLong(this.Handle, GWL_EXSTYLE) & WS_EX_TRANSPARENT) != 0)
                MakeClickable();
            else
                MakeClickThrough();
        }
        #endregion

        #region WebView Management
        private async void InitializeWebViews()
        {
            try {
                for (int i = 0; i < 2; i++) {
                    _chatViews[i] = new WebView2();
                    _chatViews[i].CreationProperties = new CoreWebView2CreationProperties { UserDataFolder = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"ChatOverlay/WebView2_{i}") };

                    await _chatViews[i].EnsureCoreWebView2Async();

                    _chatViews[i].CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                    _chatViews[i].CoreWebView2.Settings.AreDevToolsEnabled = false;

                    this.Controls.Add(_chatViews[i]);
                }

                ArrangeChatViews();
                LoadChatFeeds();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChatFeeds()
        {
            _chatViews[0].Visible = _settings.IsTwitchEnabled;
            if (_settings.IsTwitchEnabled && !string.IsNullOrEmpty(_settings.TwitchChannel)) {
                string twitchUrl = $"https://www.twitch.tv/embed/{_settings.TwitchChannel}/chat?parent=localhost&darkpopout";
                _chatViews[0].CoreWebView2.Navigate(twitchUrl);
            }

            _chatViews[1].Visible = _settings.IsKickEnabled;
            if (_settings.IsKickEnabled && !string.IsNullOrEmpty(_settings.KickChannel)) {
                string kickUrl = $"https://kick.com/{_settings.KickChannel}/chatroom";
                _chatViews[1].CoreWebView2.Navigate(kickUrl);
            }
        }

        private void ArrangeChatViews()
        {
            int totalVisibleViews = (_settings.IsTwitchEnabled ? 1 : 0) + (_settings.IsKickEnabled ? 1 : 0);
            if (totalVisibleViews == 0) return;

            int width = this.ClientSize.Width / (totalVisibleViews == 2 && _settings.ChatLayout == ChatLayout.SideBySide ? 2 : 1);
            int height = _settings.ChatLayout == ChatLayout.SideBySide || totalVisibleViews == 1 ?
                this.ClientSize.Height : this.ClientSize.Height / 2;

            if (totalVisibleViews == 2)
                if (_settings.ChatLayout == ChatLayout.SideBySide) {
                    _chatViews[0].SetBounds(0, 0, width, height);
                    _chatViews[1].SetBounds(width, 0, width, height);
                }
                else {
                    _chatViews[0].SetBounds(0, 0, width, height);
                    _chatViews[1].SetBounds(0, height, width, height);
                }
            else {
                WebView2 visibleChat = _settings.IsTwitchEnabled ? _chatViews[0] : _chatViews[1];
                visibleChat.SetBounds(0, 0, width, height);
            }
        }
        #endregion

        #region Menu and Configuration
        private ContextMenuStrip CreateTrayMenu()
        {
            var menu = new ContextMenuStrip();

            menu.Items.Add("Configure", null, (s, e) => ShowConfigDialog());
            menu.Items.Add("Toggle Layout", null, (s, e) => ToggleChatLayout());
            menu.Items.Add("Toggle Click-Through", null, (s, e) => ToggleClickThrough());
            menu.Items.Add("Toggle Always on Top", null, (s, e) => ToggleTopMost());
            menu.Items.Add("Toggle Hide from Capture", null, (s, e) => ToggleHideFromCapture());
            menu.Items.Add("-");
            menu.Items.Add("Exit", null, (s, e) => Application.Exit());

            return menu;
        }

        private void ShowConfigDialog()
        {
            using (var dialog = new ConfigForm(_settings)) {
                dialog.SettingsChanged += (s, updatedSettings) => {
                    this.Opacity = updatedSettings.WindowOpacity;
                    this.TopMost = updatedSettings.IsTopMost;
                    SetWindowDisplayAffinity(this.Handle, updatedSettings.IsHiddenFromCapture ? WDA_EXCLUDEFROMCAPTURE : WDA_NONE);
                    ArrangeChatViews();
                    LoadChatFeeds();
                    this.ClientSize = new Size(updatedSettings.WindowWidth, updatedSettings.WindowHeight);
                    ArrangeChatViews();
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                    SaveSettings();
            }
        }

        private void ToggleChatLayout()
        {
            _settings.ChatLayout = _settings.ChatLayout == ChatLayout.SideBySide ? ChatLayout.Stacked : ChatLayout.SideBySide;
            ArrangeChatViews();
            SaveSettings();
        }

        private void ToggleTopMost()
        {
            _settings.IsTopMost = !_settings.IsTopMost;
            this.TopMost = _settings.IsTopMost;
            SaveSettings();
        }

        private void ToggleHideFromCapture()
        {
            _settings.IsHiddenFromCapture = !_settings.IsHiddenFromCapture;
            SetWindowDisplayAffinity(this.Handle, _settings.IsHiddenFromCapture ? WDA_EXCLUDEFROMCAPTURE : WDA_NONE);
            SaveSettings();
        }
        #endregion

        #region Settings Management
        private Settings LoadSettings()
        {
            try {
                if (File.Exists(SETTINGS_FILE)) {
                    string json = File.ReadAllText(SETTINGS_FILE);
                    return JsonSerializer.Deserialize<Settings>(json) ?? new Settings();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return new Settings();
        }

        private void SaveSettings()
        {
            try {
                string json = JsonSerializer.Serialize(_settings);
                File.WriteAllText(SETTINGS_FILE, json);
            }
            catch (Exception ex) {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            SaveSettings();
            _trayIcon.Dispose();
        }
        #endregion
    }
}