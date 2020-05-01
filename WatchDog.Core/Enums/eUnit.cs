using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WatchDog.Core.Enums
{
  public enum eUnit
  {
    [Description("Bytes")]
    Bytes = 0,
    [Description("Kilobytes")]
    Kilobytes = 1,
    [Description("Megabytes")]
    Megabytes = 2,
    [Description("Gigabytes")]
    Gigabytes = 3,
    [Description("Terabytes")]
    Terabytes = 4
  }
}
