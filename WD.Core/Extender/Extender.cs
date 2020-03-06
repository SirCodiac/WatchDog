using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WD.Core.Extender
{
  public static class Extender
  {
    #region [IsNullOrEmptyOrWhitespace]
    /// <summary>Determines whether [is null or empty or whitespace].</summary>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if [is null or empty or whitespace] [the specified value]; otherwise, <c>false</c>.</returns>
    public static bool IsNullOrEmptyOrWhitespace(this string value) => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value); 
    #endregion

    #region [IsDirectory]
    /// <summary>Determines whether this instance is directory.</summary>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if the specified value is directory; otherwise, <c>false</c>.</returns>
    public static bool IsDirectory(this string value)
    {
      if (value.IsNullOrEmptyOrWhitespace() || !value.Contains('\\') && value.Count(x => x.Equals(':')) != 1)
        return false;
      if (!Directory.Exists(value))
        return false;
      return true;
    } 
    #endregion

    #region [IsEmptyCollection]
    /// <summary>Determines whether [is empty collection].</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if [is empty collection] [the specified value]; otherwise, <c>false</c>.</returns>
    public static bool IsEmptyCollection<T>(this ICollection<T> value) => value == null || value.Count == 0; 
    #endregion
  }
}
