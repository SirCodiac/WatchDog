using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WatchDog.Core.Utilities;

namespace WatchDog.Core.Entities
{
  public static class ItemCollection
  {
    private static readonly string WORKDIR = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WatchDog";
    private static readonly string FILENAME = $"storage.watchdogstorage";
    private static readonly string FILEPATH = Path.Combine(WORKDIR, FILENAME);
    private static List<Item> ITEMS;

    static ItemCollection()
    {
      if(!Directory.Exists(WORKDIR))
        Directory.CreateDirectory(WORKDIR);
      if (!File.Exists(FILEPATH))
        File.Create(FILEPATH).Close();
      ITEMS = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(FILEPATH));
      if (ITEMS == null)
        ITEMS = new List<Item>();

    }
    public static void __Add(Item item) => ITEMS.TryAdd(item);
    private static void __Save_Collection() => File.WriteAllText(FILEPATH, JsonConvert.SerializeObject(ITEMS, Formatting.Indented));



  }
}
