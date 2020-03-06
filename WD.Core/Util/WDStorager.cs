using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WD.Core.Entity;
using WD.Core.Extender;

namespace WD.Core.Util
{
  public static class WDStorager
  {
    #region [needs]
    private static readonly string STORAGEPATH = $@"C:\Users\{Environment.UserName}\Documents\WatchDog";
    private static readonly string STORAGEFILE = $@"{STORAGEPATH}\WatchDogItems.storage";
    private static List<WDItemEntity> m_Items { get; set; } 
    #endregion

    #region [ctor]
    static WDStorager()
    {
      CreateDataStructure();
      Read();
      if (m_Items.IsEmptyCollection())
        m_Items = new List<WDItemEntity>();
    } 
    #endregion

    #region [Add]
    public static void Add(WDItemEntity item)
    {
      if (m_Items.Any(x => x.Equals(item)))
        return;
      m_Items.Add(item);
      Write();
    } 
    #endregion

    #region [Remove]
    public static void Remove(WDItemEntity item)
    {
      if (m_Items.Any(x => x.Equals(item)))
        m_Items.RemoveAll(x => x.Equals(item));
      Write();
    } 
    #endregion

    #region [GetList]
    public static List<WDItemEntity> GetList() => m_Items; 
    #endregion

    #region [Print]
    public static string Print()
    {
      StringBuilder sb = new StringBuilder();
      if (m_Items.IsEmptyCollection())
        return "There is no item on the WatchDog.";
      m_Items.ForEach(x => sb.AppendLine(x.ToString()));
      return sb.ToString();
    } 
    #endregion

    #region [Write]
    private static void Write()
    {
      File.WriteAllText(STORAGEFILE, JsonConvert.SerializeObject(m_Items, Formatting.Indented));
    } 
    #endregion

    #region [Read]
    private static void Read()
    {
      m_Items = JsonConvert.DeserializeObject<List<WDItemEntity>>(File.ReadAllText(STORAGEFILE));
    } 
    #endregion

    #region [CreateDataStructure]
    private static void CreateDataStructure()
    {
      if (!Directory.Exists(STORAGEPATH))
        Directory.CreateDirectory(STORAGEPATH);
      if (!File.Exists(STORAGEFILE))
        File.Create(STORAGEFILE).Close();
    } 
    #endregion
  }
}
