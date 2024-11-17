namespace ChatOverlay
{
    public class Settings
    {
        #region Window Properties
        public Point WindowPosition { get; set; }
        public double WindowOpacity { get; set; } = 0.8;
        public int WindowWidth { get; set; } = 580;
        public int WindowHeight { get; set; } = 480;
        #endregion

        #region Chat Properties
        public string TwitchChannel { get; set; } = string.Empty;
        public string KickChannel { get; set; } = string.Empty;
        public ChatLayout ChatLayout { get; set; } = ChatLayout.SideBySide;
        public int RefreshRate { get; set; } = 30;
        #endregion

        #region Behavior Properties
        public bool IsTopMost { get; set; } = true;
        public bool IsTwitchEnabled { get; set; } = true;
        public bool IsKickEnabled { get; set; } = true;
        public bool IsHiddenFromCapture { get; set; } = false;
        #endregion
    }

    #region Enums
    public enum ChatLayout
    {
        SideBySide,
        Stacked
    }
    #endregion
}