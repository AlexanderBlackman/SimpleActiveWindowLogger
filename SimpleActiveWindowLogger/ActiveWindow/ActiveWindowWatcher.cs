using SimpleActiveWindowLogger.Helpers;

namespace SimpleActiveWindowLogger.ActiveWindow
{
    public class ActiveWindowWatcher
    {
        private System.Timers.Timer stateTimer;
        private ActiveWindowModel currentActiveWindow = ActiveWindowModel.CreateEmpty();
        public event EventHandler<ActiveWindowChangedEventArgs> ActiveWindowChanged;

        public ActiveWindowWatcher(TimeSpan interval)
        {
            stateTimer = new System.Timers.Timer(interval.TotalMilliseconds);
            stateTimer.Elapsed += (o, e) => GetActiveWindow();
        }

        public void Start() => stateTimer.Start(GetActiveWindow);
        public void Stop() => stateTimer.Stop();

        private void GetActiveWindow() =>
            WindowAPI
                .GetActiveWindowTitle()
                .Do(activeWindow =>
                    activeWindow.IsDifferentThan(currentActiveWindow, () =>
                    {
                        currentActiveWindow = ActiveWindowModel.CreateFrom(activeWindow);
                        ActiveWindowChanged?.Invoke(this, ActiveWindowChangedEventArgs.Create(activeWindow.WindowTitle));
                    }));
    }
}
