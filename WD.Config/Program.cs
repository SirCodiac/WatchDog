using Microsoft.Win32.TaskScheduler;
using System;
using System.Linq;
using WD.Core.Extender;
using WD.Core.Util;

namespace WD.Config
{
  class Program
  {
    #region [Main]
    static void Main(string[] args)
    {
      var end = false;
      Console.Title = "WatchDog Configuration Tool";

      Console.WriteLine("Welcome to the configuration tool of WatchDog.");
      while (!end)
      {
        Console.WriteLine("Please choose between the following actions:");
        int input = 0;
        do
        {
          Console.WriteLine("1.) Display current items on the WatchDog\n2.) Add item to WatchDog\n3.) Remove item from WatchDog");
          if (Properties.Settings.Default.TaskActivated)
            Console.WriteLine("4.) Deactivate task");
          else
            Console.WriteLine("4.) Activate task");
          Console.Write("Please enter the number of the option: ");
          try
          {
            input = Convert.ToInt32(Console.ReadLine());
          }
          catch (Exception ex)
          {
            Console.WriteLine("The performed action was illegal.\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
          }
        } while (input < 1 || input > 4);
        switch (input)
        {
          case 1:
            DisplayCurrentItems();
            break;
          case 2:
            AddItem();
            break;
          case 3:
            RemoveItem();
            break;
          case 4:
            if (Properties.Settings.Default.TaskActivated)
              DeactivateTaskScheduler();
            else
              ActivateTaskScheduler();
            break;
        }
        Console.Clear();
        Console.Write("Do you want to do any other action? Y/N: ");
        var ch = Console.ReadKey();
        if (ch.Key == ConsoleKey.N)
          end = true;
        else
          Console.WriteLine("\n\n");
      }
    }
    #endregion

    #region [AddItem]
    private static void AddItem()
    {
      var path = "";
      var file = "";
      var size = 0;
      var unit = eUnit.Megabyte;
      var valid = true;
      do
      {
        valid = !valid ? true : valid;
        Console.Clear();
        Console.Write("Please enter the path to the file: ");
        path = Console.ReadLine();
        Console.Write("\nPlease enter the file including the file extension: ");
        file = Console.ReadLine();
        Console.Write("\nPlease enter the limit size without the unit: ");
        size = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nPlease choose between the following units:\n1.) Megabyte\n2.) Gigabyte\n3.) Terabyte\nEnter the number: ");
        var temp = Convert.ToInt32(Console.ReadLine());
        switch (temp)
        {
          case 1:
            unit = eUnit.Megabyte;
            break;
          case 2:
            unit = eUnit.Gigabyte;
            break;
          case 3:
            unit = eUnit.Terabyte;
            break;
          default:
            valid = false;
            break;
        }
      } while (!(path.IsDirectory() && file.Contains('.') && size > 0 && valid));

      WDStorager.Add(new Core.Entity.WDItemEntity(path, file, size, unit));
    }
    #endregion

    #region [RemoveItem]
    private static void RemoveItem()
    {
      var path = "";
      var file = "";
      var valid = true;
      do
      {
        valid = !valid ? true : valid;
        Console.Clear();
        Console.Write("Please enter the path to the file: ");
        path = Console.ReadLine();
        Console.Write("\nPlease enter the file including the file extension: ");
        file = Console.ReadLine();
      } while (!(path.IsDirectory() && file.Contains('.')));

      WDStorager.Remove(new Core.Entity.WDItemEntity(path, file, 0, eUnit.Megabyte));
    }
    #endregion

    #region [DisplayCurrentItems]
    private static void DisplayCurrentItems()
    {
      Console.Clear();
      Console.WriteLine(WDStorager.Print());
      Console.WriteLine("\nPress any key to continue...\n");
      Console.ReadKey();
    }
    #endregion

    #region [ActivateTaskScheduler]
    private static void ActivateTaskScheduler()
    {
      using (TaskService ts = new TaskService())
      {
        TaskDefinition td = ts.NewTask();
        td.RegistrationInfo.Author = $"{Environment.UserName} with the WatchDog of SirCodiac";
        td.RegistrationInfo.Date = DateTime.Now;
        td.RegistrationInfo.Source = "Application";
        td.RegistrationInfo.Version = new Version(1, 0);
        td.RegistrationInfo.Description = "Executes the WatchDog executable.";

        td.Triggers.Add(new DailyTrigger { Enabled = true, DaysInterval = 1 });
        td.Actions.Add(new ExecAction($"{Environment.CurrentDirectory}\\WD.Executable.exe"));

        ts.RootFolder.RegisterTaskDefinition(@"WatchDog", td);

        Properties.Settings.Default.TaskActivated = true;
      }
    }
    #endregion

    #region [DeactivateTaskScheduler]
    private static void DeactivateTaskScheduler()
    {
      using (TaskService ts = new TaskService())
      {
        ts.RootFolder.DeleteTask(@"WatchDog");
      }
      Properties.Settings.Default.TaskActivated = false;
    }
    #endregion
  }
}
