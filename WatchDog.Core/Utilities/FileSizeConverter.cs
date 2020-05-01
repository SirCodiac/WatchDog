using System;
using System.Collections.Generic;
using System.Text;
using WatchDog.Core.Enums;

namespace WatchDog.Core.Utilities
{
  public static class FileSizeConverter
  {
    /// <summary>
    /// Converts the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="targetUnit">The target unit.</param>
    /// <param name="sourceUnit">The source unit.</param>
    /// <returns></returns>
    public static double Convert(double value, eUnit targetUnit, eUnit sourceUnit = eUnit.Bytes)
    {
      switch(sourceUnit)
      {
        case eUnit.Bytes:
          return __ConvertBytes(value, targetUnit);
        case eUnit.Kilobytes:
          return __ConvertKilobytes(value, targetUnit); 
        case eUnit.Megabytes:
          return __ConvertMegabytes(value, targetUnit);
        case eUnit.Gigabytes:
          return __ConvertGigabytes(value, targetUnit);
        case eUnit.Terabytes:
          return __ConvertTerabytes(value, targetUnit);
        default:
          return value;
      }
    }

    #region [__ConvertBytes]

    private static double __ConvertBytes(double value, eUnit targetUnit)
    {
      switch(targetUnit)
      {
        case eUnit.Kilobytes:
          return __ConvertBytesToKilobytes(value);
        case eUnit.Megabytes:
          return __ConvertBytesToMegabytes(value);
        case eUnit.Gigabytes:
          return __ConvertBytesToGigabytes(value);
        case eUnit.Terabytes:
          return __ConvertBytesToTerabytes(value);
        default:
          return value;
      }
    }

    #region [__ConvertBytesToKilobytes]
    /// <summary>
    /// __Converts the bytes to kilobytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertBytesToKilobytes(double value) => value / 1000;
    #endregion

    #region [__ConvertBytesToMegabytes]
    /// <summary>
    /// __Converts the bytes to megabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertBytesToMegabytes(double value) => value / 1000000;
    #endregion

    #region [__ConvertBytesToGigabytes]
    /// <summary>
    /// __Converts the bytes to gigabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertBytesToGigabytes(double value) => value / 1000000000;
    #endregion

    #region [__ConvertBytesToTerabytes]
    /// <summary>
    /// __Converts the bytes to terabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertBytesToTerabytes(double value) => value / 1000000000000;
    #endregion

    #endregion

    #region [__ConvertKilobytes]    
    /// <summary>
    /// __Converts the kilobytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="targetUnit">The target unit.</param>
    /// <returns></returns>
    private static double __ConvertKilobytes(double value, eUnit targetUnit)
    {
      switch(targetUnit)
      {
        case eUnit.Bytes:
          return __ConvertKilobytesToBytes(value);
        case eUnit.Megabytes:
          return __ConvertKilobytesToMegabytes(value);
        case eUnit.Gigabytes:
          return __ConvertKilobytesToGigabytes(value);
        case eUnit.Terabytes:
          return __ConvertKilobytesToTerabytes(value);
        default:
          return value;
      }
    }

    #region [__ConvertKilobytesToBytes]    
    /// <summary>
    /// __Converts the kilobytes to bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertKilobytesToBytes(double value) => value * 1000;
    #endregion

    #region [__ConvertKilobytesToMegabytes]    
    /// <summary>
    /// __Converts the kilobytes to megabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertKilobytesToMegabytes(double value) => value / 1000;
    #endregion

    #region [__ConvertKilobytesToGigabytes]    
    /// <summary>
    /// __Converts the kilobytes to gigabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertKilobytesToGigabytes(double value) => value / 1000000;
    #endregion

    #region [__ConvertKilobytesToTerabytes]    
    /// <summary>
    /// __Converts the kilobytes to terabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertKilobytesToTerabytes(double value) => value / 1000000000;
    #endregion

    #endregion

    #region [__ConvertMegabytes]    
    /// <summary>
    /// __Converts the megabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="targetUnit">The target unit.</param>
    /// <returns></returns>
    private static double __ConvertMegabytes(double value, eUnit targetUnit)
    {
      switch(targetUnit)
      {
        case eUnit.Bytes:
          return __ConvertMegabytesToBytes(value);
        case eUnit.Kilobytes:
          return __ConvertMegabytesToKilobytes(value);
        case eUnit.Gigabytes:
          return __ConvertMegabytesToGigabytes(value);
        case eUnit.Terabytes:
          return __ConvertMegabytesToTerabytes(value);
        default:
          return value;
      }
    }

    #region [__ConvertMegabytesToBytes]    
    /// <summary>
    /// __Converts the megabytes to bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertMegabytesToBytes(double value) => value * 1000000;
    #endregion

    #region [__ConvertMegabytesToKilobytes]    
    /// <summary>
    /// __Converts the megabytes to kilobytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertMegabytesToKilobytes(double value) => value * 1000;
    #endregion

    #region [__ConvertMegabytesToGigabytes]    
    /// <summary>
    /// __Converts the megabytes to gigabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertMegabytesToGigabytes(double value) => value / 1000;
    #endregion

    #region [__ConvertMegabytesToTerabytes]    
    /// <summary>
    /// __Converts the megabytes to terabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertMegabytesToTerabytes(double value) => value / 1000000;
    #endregion

    #endregion

    #region [__ConvertGigabytes]    
    /// <summary>
    /// __Converts the gigabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="targetUnit">The target unit.</param>
    /// <returns></returns>
    private static double __ConvertGigabytes(double value, eUnit targetUnit)
    {
      switch(targetUnit)
      {
        case eUnit.Bytes:
          return __ConvertGigabytesToBytes(value);
        case eUnit.Kilobytes:
          return __ConvertGigabytesToKilobytes(value);
        case eUnit.Megabytes:
          return __ConvertGigabytesToMegabytes(value);
        case eUnit.Terabytes:
          return __ConvertGigabytesToTerabytes(value);
        default:
          return value;
      }
    }

    #region [__ConvertGigabytesToBytes]    
    /// <summary>
    /// __Converts the gigabytes to bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertGigabytesToBytes(double value) => value * 1000000000;
    #endregion

    #region [__ConvertGigabytesToKilobytes]    
    /// <summary>
    /// __Converts the gigabytes to kilobytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertGigabytesToKilobytes(double value) => value * 1000000;
    #endregion

    #region [__ConvertGigabytesToMegabytes]    
    /// <summary>
    /// __Converts the gigabytes to megabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertGigabytesToMegabytes(double value) => value * 1000;
    #endregion

    #region [__ConvertGigabytesToTerabytes]    
    /// <summary>
    /// __Converts the gigabytes to terabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertGigabytesToTerabytes(double value) => value / 1000;
    #endregion

    #endregion

    #region [__ConvertTerabytes]    
    /// <summary>
    /// __Converts the terabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="targetUnit">The target unit.</param>
    /// <returns></returns>
    private static double __ConvertTerabytes(double value, eUnit targetUnit)
    {
      switch(targetUnit)
      {
        case eUnit.Bytes:
          return __ConvertTerabytesToBytes(value);
        case eUnit.Kilobytes:
          return __ConvertTerabytesToKilobytes(value);
        case eUnit.Megabytes:
          return __ConvertTerabytesToMegabytes(value);
        case eUnit.Gigabytes:
          return __ConvertTerabytesToGigabytes(value);
        default:
          return value;
      }
    }

    #region [__ConvertTerabytesToBytes]    
    /// <summary>
    /// __Converts the terabytes to bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertTerabytesToBytes(double value) => value * 1000000000000;
    #endregion

    #region [__ConvertTerabytesToKilobytes]    
    /// <summary>
    /// __Converts the terabytes to kilobytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertTerabytesToKilobytes(double value) => value * 1000000000;
    #endregion

    #region [__ConvertTerabytesToMegabytes]    
    /// <summary>
    /// __Converts the terabytes to megabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertTerabytesToMegabytes(double value) => value * 1000000;
    #endregion

    #region [__ConvertTerabytesToGigabytes]    
    /// <summary>
    /// __Converts the terabytes to gigabytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    private static double __ConvertTerabytesToGigabytes(double value) => value * 1000;
    #endregion

    #endregion
  }
}
