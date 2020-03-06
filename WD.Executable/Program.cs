using System;
using System.IO;
using WD.Core.Extender;
using WD.Core.Util;

namespace WD.Executable
{
  class Program
  {
    #region [Statics]
    private static readonly string LOGPATH = $@"C:\Users\{Environment.UserName}\Documents\WatchDog";
    private static readonly string LOGFILE = $@"{LOGPATH}\WatchDog.log";
    #endregion

    #region [Main]
    static void Main(string[] args)
    {
      var exit = true;
      Console.Title = "WatchDog Executable";

      var items = WDStorager.GetList();
      if (items.IsEmptyCollection())
      {
        Log("There is not item to watch.");
        Environment.Exit(0);
      }
      foreach (var item in items)
      {
        var fileInfo = new FileInfo(item.Path + "\\" + item.File);
        var size = fileInfo.Length;
        switch (item.Unit)
        {
          case eUnit.Megabyte:
            size /= 1000000;
            break;
          case eUnit.Gigabyte:
            size /= 1000000000;
            break;
          case eUnit.Terabyte:
            size /= 1000000000000;
            break;
        }
        if (item.Size < size)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("WARNING");
          Console.WriteLine($"{item.Path}\\{item.File} with {size} {item.Unit} of {item.Size} {item.Unit} allowed.");
          Console.ForegroundColor = ConsoleColor.White;
          Log($"{item.Path}\\{item.File} with {size} {item.Unit}");
          exit = false;
        }
        if (!exit)
        {
          Console.WriteLine("Press any key to exit...");
          Console.ReadKey();
        }
        Environment.Exit(0);
      }
    }
    #endregion

    #region [Log]
    private static void Log(string m)
    {
      if (!Directory.Exists(LOGPATH))
        Directory.CreateDirectory(LOGPATH);
      if (!File.Exists(LOGFILE))
        File.Create(LOGFILE).Close();

      File.AppendAllText(LOGFILE, $"{DateTime.Now.ToString()} | {m}");
    }
    #endregion
  }
}
