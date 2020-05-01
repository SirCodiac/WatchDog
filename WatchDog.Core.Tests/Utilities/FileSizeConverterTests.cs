using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WatchDog.Core.Utilities;

namespace WatchDog.Core.Tests.Utilities
{
  public class FileSizeConverterTests
  {
    [Test]
    public void TestOfConvertBytes()
    {
      double actual = 1500000000000;
      Assert.AreEqual(1500000000, FileSizeConverter.Convert(actual, Enums.eUnit.Kilobytes));
      Assert.AreEqual(1500000, FileSizeConverter.Convert(actual, Enums.eUnit.Megabytes));
      Assert.AreEqual(1500, FileSizeConverter.Convert(actual, Enums.eUnit.Gigabytes));
      Assert.AreEqual(1.5, FileSizeConverter.Convert(actual, Enums.eUnit.Terabytes));
    }
    [Test]
    public void TestOfConvertKilobytes()
    {
      double actual = 1500000000;
      Assert.AreEqual(1500000000000, FileSizeConverter.Convert(actual, Enums.eUnit.Bytes, Enums.eUnit.Kilobytes));
      Assert.AreEqual(1500000, FileSizeConverter.Convert(actual, Enums.eUnit.Megabytes, Enums.eUnit.Kilobytes));
      Assert.AreEqual(1500, FileSizeConverter.Convert(actual, Enums.eUnit.Gigabytes, Enums.eUnit.Kilobytes));
      Assert.AreEqual(1.5, FileSizeConverter.Convert(actual, Enums.eUnit.Terabytes, Enums.eUnit.Kilobytes));
    }
    [Test]
    public void TestOfConvertMegabytes()
    {
      double actual = 1500000;
      Assert.AreEqual(1500000000000, FileSizeConverter.Convert(actual, Enums.eUnit.Bytes, Enums.eUnit.Megabytes));
      Assert.AreEqual(1500000000, FileSizeConverter.Convert(actual, Enums.eUnit.Kilobytes, Enums.eUnit.Megabytes));
      Assert.AreEqual(1500, FileSizeConverter.Convert(actual, Enums.eUnit.Gigabytes, Enums.eUnit.Megabytes));
      Assert.AreEqual(1.5, FileSizeConverter.Convert(actual, Enums.eUnit.Terabytes, Enums.eUnit.Megabytes));
    }
    [Test]
    public void TestOfConvertGigabytes()
    {
      double actual = 1500;
      Assert.AreEqual(1500000000000, FileSizeConverter.Convert(actual, Enums.eUnit.Bytes, Enums.eUnit.Gigabytes));
      Assert.AreEqual(1500000000, FileSizeConverter.Convert(actual, Enums.eUnit.Kilobytes, Enums.eUnit.Gigabytes));
      Assert.AreEqual(1500000, FileSizeConverter.Convert(actual, Enums.eUnit.Megabytes, Enums.eUnit.Gigabytes));
      Assert.AreEqual(1.5, FileSizeConverter.Convert(actual, Enums.eUnit.Terabytes, Enums.eUnit.Gigabytes));
    }
    [Test]
    public void TestOfConvertTerabytes()
    {
      double actual = 1.5;
      Assert.AreEqual(1500000000000, FileSizeConverter.Convert(actual, Enums.eUnit.Bytes, Enums.eUnit.Terabytes));
      Assert.AreEqual(1500000000, FileSizeConverter.Convert(actual, Enums.eUnit.Kilobytes, Enums.eUnit.Terabytes));
      Assert.AreEqual(1500000, FileSizeConverter.Convert(actual, Enums.eUnit.Megabytes, Enums.eUnit.Terabytes));
      Assert.AreEqual(1500, FileSizeConverter.Convert(actual, Enums.eUnit.Gigabytes, Enums.eUnit.Terabytes));
    }
  }
}
