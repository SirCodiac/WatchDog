using System;
using System.Collections.Generic;
using System.Text;
using WatchDog.Core.Enums;
using IOPath = System.IO.Path;

namespace WatchDog.Core.Entities
{
  public class Item
  {
    public Item(string path, string file, double size, eUnit unit)
    {
      Path = path;
      File = file;
      Size = size;
      Unit = unit;
    }
    #region - ctor -

    #endregion

    #region - private properties -
    private string m_Path { get; set; }
    private string m_File { get; set; }
    private double m_Size { get; set; }
    private eUnit m_Unit { get; set; }
    #endregion

    #region - public properties -    

    #region [Path]
    /// <summary>
    /// Gets the path.
    /// </summary>
    /// <value>
    /// The path.
    /// </value>
    public string Path { get => m_Path; private set => m_Path = value; }
    #endregion

    #region [File]    
    /// <summary>
    /// Gets the file.
    /// </summary>
    /// <value>
    /// The file.
    /// </value>
    public string File { get => m_File; private set => m_File = value; }
    #endregion

    #region [Filepath]    
    /// <summary>
    /// Gets the filepath.
    /// </summary>
    /// <value>
    /// The filepath.
    /// </value>
    public string Filepath { get => IOPath.Combine(new string[] { Path, File }); }
    #endregion

    #region [Size]    
    /// <summary>
    /// Gets the size.
    /// </summary>
    /// <value>
    /// The size.
    /// </value>
    public double Size { get => m_Size; private set => m_Size = value; }
    #endregion

    #region [Unit]    
    /// <summary>
    /// Gets the unit.
    /// </summary>
    /// <value>
    /// The unit.
    /// </value>
    public eUnit Unit { get => m_Unit; private set => m_Unit = value; }
    #endregion

    #endregion

    #region - public methods -

    #endregion

    #region - private methods -

    #endregion

    #region - helper -

    #region [ToString]
    public override string ToString() => $"{Filepath}: {Size} {Unit.ToString()}";
    #endregion

    #endregion
  }
}
