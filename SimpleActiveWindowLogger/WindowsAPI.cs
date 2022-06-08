using SimpleActiveWindowLogger.ActiveWindow;
using SimpleActiveWindowLogger.Helpers;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleActiveWindowLogger
{
    public static class WindowAPI
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static Option<ActiveWindowModel> GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
                return Option<ActiveWindowModel>.Some(ActiveWindowModel.Create(handle, Buff.ToString()));

            return Option<ActiveWindowModel>.None();
        }
    }
}
