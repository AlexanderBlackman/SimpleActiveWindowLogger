using SimpleActiveWindowLogger.ActiveWindow;

var watcher = new ActiveWindowWatcher(TimeSpan.FromMilliseconds(500));
string logLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ActiveWindowLog.txt";
Console.WriteLine("Press any key to stop watching.");


using (var log = new StreamWriter(logLocation, true))
{
    watcher.ActiveWindowChanged += (o, e) => log.WriteLine($"{DateTime.Now.ToShortTimeString()}: {e.ActiveWindow}");
    watcher.Start();
    Console.ReadLine();
}




