namespace ChatOverlay
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            lblTwitch = new Label();
            lblKick = new Label();
            txtTwitchChannel = new TextBox();
            txtKickChannel = new TextBox();
            gBoxChannelSettings = new GroupBox();
            gBoxOverlaySettings = new GroupBox();
            numWindowHeight = new NumericUpDown();
            numWindowWidth = new NumericUpDown();
            lblWindowSize = new Label();
            chkHideFromCapture = new CheckBox();
            chkTopMost = new CheckBox();
            lblOpacityValue = new Label();
            numRefreshRate = new NumericUpDown();
            trackOpacity = new TrackBar();
            lblOpacity = new Label();
            lblRefresh = new Label();
            chkEnableTwitch = new CheckBox();
            chkEnableKick = new CheckBox();
            lblPlatforms = new Label();
            rdoStacked = new RadioButton();
            rdoSideBySide = new RadioButton();
            lblLayout = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            gBoxChannelSettings.SuspendLayout();
            gBoxOverlaySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numWindowHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWindowWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRefreshRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackOpacity).BeginInit();
            SuspendLayout();
            // 
            // lblTwitch
            // 
            lblTwitch.AutoSize = true;
            lblTwitch.Location = new Point(6, 33);
            lblTwitch.Name = "lblTwitch";
            lblTwitch.Size = new Size(91, 15);
            lblTwitch.TabIndex = 0;
            lblTwitch.Text = "Twitch Channel:";
            // 
            // lblKick
            // 
            lblKick.AutoSize = true;
            lblKick.Location = new Point(18, 69);
            lblKick.Name = "lblKick";
            lblKick.Size = new Size(79, 15);
            lblKick.TabIndex = 1;
            lblKick.Text = "Kick Channel:";
            // 
            // txtTwitchChannel
            // 
            txtTwitchChannel.Location = new Point(103, 30);
            txtTwitchChannel.Name = "txtTwitchChannel";
            txtTwitchChannel.Size = new Size(149, 23);
            txtTwitchChannel.TabIndex = 2;
            txtTwitchChannel.TextAlign = HorizontalAlignment.Center;
            // 
            // txtKickChannel
            // 
            txtKickChannel.Location = new Point(103, 66);
            txtKickChannel.Name = "txtKickChannel";
            txtKickChannel.Size = new Size(149, 23);
            txtKickChannel.TabIndex = 3;
            txtKickChannel.TextAlign = HorizontalAlignment.Center;
            // 
            // gBoxChannelSettings
            // 
            gBoxChannelSettings.BackColor = Color.FromArgb(60, 47, 47);
            gBoxChannelSettings.Controls.Add(lblTwitch);
            gBoxChannelSettings.Controls.Add(txtKickChannel);
            gBoxChannelSettings.Controls.Add(lblKick);
            gBoxChannelSettings.Controls.Add(txtTwitchChannel);
            gBoxChannelSettings.ForeColor = Color.White;
            gBoxChannelSettings.Location = new Point(12, 12);
            gBoxChannelSettings.Name = "gBoxChannelSettings";
            gBoxChannelSettings.Size = new Size(261, 102);
            gBoxChannelSettings.TabIndex = 4;
            gBoxChannelSettings.TabStop = false;
            gBoxChannelSettings.Text = "Channel Settings";
            // 
            // gBoxOverlaySettings
            // 
            gBoxOverlaySettings.BackColor = Color.FromArgb(60, 47, 47);
            gBoxOverlaySettings.Controls.Add(numWindowHeight);
            gBoxOverlaySettings.Controls.Add(numWindowWidth);
            gBoxOverlaySettings.Controls.Add(lblWindowSize);
            gBoxOverlaySettings.Controls.Add(chkHideFromCapture);
            gBoxOverlaySettings.Controls.Add(chkTopMost);
            gBoxOverlaySettings.Controls.Add(lblOpacityValue);
            gBoxOverlaySettings.Controls.Add(numRefreshRate);
            gBoxOverlaySettings.Controls.Add(trackOpacity);
            gBoxOverlaySettings.Controls.Add(lblOpacity);
            gBoxOverlaySettings.Controls.Add(lblRefresh);
            gBoxOverlaySettings.Controls.Add(chkEnableTwitch);
            gBoxOverlaySettings.Controls.Add(chkEnableKick);
            gBoxOverlaySettings.Controls.Add(lblPlatforms);
            gBoxOverlaySettings.Controls.Add(rdoStacked);
            gBoxOverlaySettings.Controls.Add(rdoSideBySide);
            gBoxOverlaySettings.Controls.Add(lblLayout);
            gBoxOverlaySettings.ForeColor = Color.White;
            gBoxOverlaySettings.Location = new Point(12, 120);
            gBoxOverlaySettings.Name = "gBoxOverlaySettings";
            gBoxOverlaySettings.Size = new Size(261, 210);
            gBoxOverlaySettings.TabIndex = 5;
            gBoxOverlaySettings.TabStop = false;
            gBoxOverlaySettings.Text = "Overlay Settings";
            // 
            // numWindowHeight
            // 
            numWindowHeight.Location = new Point(161, 178);
            numWindowHeight.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
            numWindowHeight.Minimum = new decimal(new int[] { 300, 0, 0, 0 });
            numWindowHeight.Name = "numWindowHeight";
            numWindowHeight.Size = new Size(58, 23);
            numWindowHeight.TabIndex = 20;
            numWindowHeight.TextAlign = HorizontalAlignment.Center;
            numWindowHeight.Value = new decimal(new int[] { 480, 0, 0, 0 });
            // 
            // numWindowWidth
            // 
            numWindowWidth.Location = new Point(97, 178);
            numWindowWidth.Maximum = new decimal(new int[] { 1920, 0, 0, 0 });
            numWindowWidth.Minimum = new decimal(new int[] { 400, 0, 0, 0 });
            numWindowWidth.Name = "numWindowWidth";
            numWindowWidth.Size = new Size(58, 23);
            numWindowWidth.TabIndex = 19;
            numWindowWidth.TextAlign = HorizontalAlignment.Center;
            numWindowWidth.Value = new decimal(new int[] { 580, 0, 0, 0 });
            // 
            // lblWindowSize
            // 
            lblWindowSize.AutoSize = true;
            lblWindowSize.Location = new Point(14, 181);
            lblWindowSize.Name = "lblWindowSize";
            lblWindowSize.Size = new Size(77, 15);
            lblWindowSize.TabIndex = 18;
            lblWindowSize.Text = "Window Size:";
            // 
            // chkHideFromCapture
            // 
            chkHideFromCapture.AutoSize = true;
            chkHideFromCapture.Location = new Point(9, 116);
            chkHideFromCapture.Name = "chkHideFromCapture";
            chkHideFromCapture.Size = new Size(163, 19);
            chkHideFromCapture.TabIndex = 17;
            chkHideFromCapture.Text = "Hide from Screen Capture";
            chkHideFromCapture.UseVisualStyleBackColor = true;
            // 
            // chkTopMost
            // 
            chkTopMost.AutoSize = true;
            chkTopMost.Location = new Point(9, 91);
            chkTopMost.Name = "chkTopMost";
            chkTopMost.Size = new Size(102, 19);
            chkTopMost.TabIndex = 16;
            chkTopMost.Text = "Always on Top";
            chkTopMost.UseVisualStyleBackColor = true;
            // 
            // lblOpacityValue
            // 
            lblOpacityValue.AutoSize = true;
            lblOpacityValue.Location = new Point(222, 149);
            lblOpacityValue.Name = "lblOpacityValue";
            lblOpacityValue.Size = new Size(35, 15);
            lblOpacityValue.TabIndex = 13;
            lblOpacityValue.Text = "100%";
            // 
            // numRefreshRate
            // 
            numRefreshRate.Location = new Point(101, 63);
            numRefreshRate.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numRefreshRate.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numRefreshRate.Name = "numRefreshRate";
            numRefreshRate.Size = new Size(71, 23);
            numRefreshRate.TabIndex = 15;
            numRefreshRate.TextAlign = HorizontalAlignment.Center;
            numRefreshRate.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // trackOpacity
            // 
            trackOpacity.AutoSize = false;
            trackOpacity.Location = new Point(66, 146);
            trackOpacity.Maximum = 100;
            trackOpacity.Minimum = 10;
            trackOpacity.Name = "trackOpacity";
            trackOpacity.Size = new Size(158, 29);
            trackOpacity.TabIndex = 12;
            trackOpacity.TickFrequency = 10;
            trackOpacity.TickStyle = TickStyle.None;
            trackOpacity.Value = 10;
            // 
            // lblOpacity
            // 
            lblOpacity.AutoSize = true;
            lblOpacity.Location = new Point(9, 149);
            lblOpacity.Name = "lblOpacity";
            lblOpacity.Size = new Size(51, 15);
            lblOpacity.TabIndex = 11;
            lblOpacity.Text = "Opacity:";
            // 
            // lblRefresh
            // 
            lblRefresh.AutoSize = true;
            lblRefresh.Location = new Point(7, 65);
            lblRefresh.Name = "lblRefresh";
            lblRefresh.Size = new Size(91, 15);
            lblRefresh.TabIndex = 14;
            lblRefresh.Text = "Refresh Rate (s):";
            // 
            // chkEnableTwitch
            // 
            chkEnableTwitch.AutoSize = true;
            chkEnableTwitch.Location = new Point(86, 40);
            chkEnableTwitch.Name = "chkEnableTwitch";
            chkEnableTwitch.Size = new Size(60, 19);
            chkEnableTwitch.TabIndex = 10;
            chkEnableTwitch.Text = "Twitch";
            chkEnableTwitch.UseVisualStyleBackColor = true;
            // 
            // chkEnableKick
            // 
            chkEnableKick.AutoSize = true;
            chkEnableKick.Location = new Point(152, 40);
            chkEnableKick.Name = "chkEnableKick";
            chkEnableKick.Size = new Size(48, 19);
            chkEnableKick.TabIndex = 9;
            chkEnableKick.Text = "Kick";
            chkEnableKick.UseVisualStyleBackColor = true;
            // 
            // lblPlatforms
            // 
            lblPlatforms.AutoSize = true;
            lblPlatforms.Location = new Point(19, 40);
            lblPlatforms.Name = "lblPlatforms";
            lblPlatforms.Size = new Size(61, 15);
            lblPlatforms.TabIndex = 7;
            lblPlatforms.Text = "Platforms:";
            // 
            // rdoStacked
            // 
            rdoStacked.AutoSize = true;
            rdoStacked.Location = new Point(180, 17);
            rdoStacked.Name = "rdoStacked";
            rdoStacked.Size = new Size(66, 19);
            rdoStacked.TabIndex = 6;
            rdoStacked.TabStop = true;
            rdoStacked.Text = "Stacked";
            rdoStacked.UseVisualStyleBackColor = true;
            // 
            // rdoSideBySide
            // 
            rdoSideBySide.AutoSize = true;
            rdoSideBySide.Location = new Point(86, 17);
            rdoSideBySide.Name = "rdoSideBySide";
            rdoSideBySide.Size = new Size(88, 19);
            rdoSideBySide.TabIndex = 5;
            rdoSideBySide.TabStop = true;
            rdoSideBySide.Text = "Side by Side";
            rdoSideBySide.UseVisualStyleBackColor = true;
            // 
            // lblLayout
            // 
            lblLayout.AutoSize = true;
            lblLayout.Location = new Point(8, 19);
            lblLayout.Name = "lblLayout";
            lblLayout.Size = new Size(74, 15);
            lblLayout.TabIndex = 4;
            lblLayout.Text = "Chat Layout:";
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(17, 336);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(149, 336);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 47, 47);
            ClientSize = new Size(281, 368);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(gBoxOverlaySettings);
            Controls.Add(gBoxChannelSettings);
            ForeColor = Color.FromArgb(255, 244, 230);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat Overlay Configuration";
            gBoxChannelSettings.ResumeLayout(false);
            gBoxChannelSettings.PerformLayout();
            gBoxOverlaySettings.ResumeLayout(false);
            gBoxOverlaySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numWindowHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWindowWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRefreshRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackOpacity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTwitch;
        private Label lblKick;
        private TextBox txtTwitchChannel;
        private TextBox txtKickChannel;
        private GroupBox gBoxChannelSettings;
        private GroupBox gBoxOverlaySettings;
        private Label lblLayout;
        private RadioButton rdoStacked;
        private RadioButton rdoSideBySide;
        private Label lblPlatforms;
        private CheckBox chkEnableKick;
        private CheckBox chkEnableTwitch;
        private Label lblOpacity;
        private TrackBar trackOpacity;
        private Label lblOpacityValue;
        private Label lblRefresh;
        private NumericUpDown numRefreshRate;
        private CheckBox chkHideFromCapture;
        private CheckBox chkTopMost;
        private Button btnSave;
        private Button btnCancel;
        private Label lblWindowSize;
        private NumericUpDown numWindowHeight;
        private NumericUpDown numWindowWidth;
    }
}