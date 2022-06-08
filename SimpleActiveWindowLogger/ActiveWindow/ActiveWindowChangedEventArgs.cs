namespace SimpleActiveWindowLogger.ActiveWindow
{
    public class ActiveWindowChangedEventArgs : EventArgs
    {
        public string ActiveWindow { get; set; } = string.Empty;

        public static ActiveWindowChangedEventArgs Create(string activeWindow) =>
            new ActiveWindowChangedEventArgs() { ActiveWindow = activeWindow };
    }
}
