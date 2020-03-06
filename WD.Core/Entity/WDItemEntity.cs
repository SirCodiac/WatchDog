using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WD.Core.Extender;
using WD.Core.Util;

namespace WD.Core.Entity
{
  public class WDItemEntity
  {
    #region - ctor -    
    /// <summary>Initializes a new instance of the <see cref="WDItemEntity"/> class.</summary>
    [Obsolete("Do not use the default constructor.", true)]
    public WDItemEntity() { }
    /// <summary>Initializes a new instance of the <see cref="WDItemEntity"/> class.</summary>
    /// <param name="path">The path.</param>
    /// <param name="file">The file.</param>
    /// <param name="size">The size.</param>
    /// <param name="unit">The unit.</param>
    public WDItemEntity(string path, string file, int size, eUnit unit)
    {
      Path = path;
      File = file;
      Size = size;
      Unit = unit;
    }
    #endregion

    #region - private properties -
    private string m_Path { get; set; }
    private string m_File { get; set; }
    private int m_Size { get; set; }
    private eUnit m_Unit { get; set; }
    #endregion

    #region - public properties -

    #region [Path]    
    /// <summary>Gets or sets the path.</summary>
    /// <value>The path.</value>
    public string Path 
    {
      get => m_Path; 
      set
      {
        if (value.IsDirectory())
          m_Path = value;
      }
    }
    #endregion

    #region [File]    
    /// <summary>Gets or sets the file.</summary>
    /// <value>The file.</value>
    public string File { get => m_File; set => m_File = value; }
    #endregion

    #region [Size]    
    /// <summary>Gets or sets the size.</summary>
    /// <value>The size.</value>
    public int Size { get => m_Size; set => m_Size = value; }
    #endregion

    #region [Unit]    
    /// <summary>Gets or sets the unit.</summary>
    /// <value>The unit.</value>
    public eUnit Unit { get => m_Unit; set => m_Unit = value; }
    #endregion

    #endregion

    #region - overrides -    

    #region [ToString]
    /// <summary>Converts to string.</summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString() => $"{Path}\\{File}: {Size} {Unit}";
    #endregion

    #region [Equals]    
    /// <summary>Determines whether the specified <see cref="System.Object" />, is equal to this instance.</summary>
    /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
    /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
    public override bool Equals(object obj)
    {
      try
      {
        var o = (WDItemEntity)obj;
        return o.File == File && o.m_Path == Path;
      } catch(Exception ex)
      {
        return false;
      }
    }
    #endregion

    #region [GetHashCode]    
    /// <summary>Returns a hash code for this instance.</summary>
    /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. </returns>
    public override int GetHashCode() => ($"{Path}\\{File}").GetHashCode();
    #endregion

    #endregion
  }
}
