using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WatchDog.Core.Utilities;

namespace WatchDog.Core.Tests.Utilities
{
  public class ItemCollectionHelperTests
  {
    [Test]
    public void TestOfTryAdd_Succeed()
    {
      List<int> liste = new List<int> { 1, 4, 16, 32 };
      Assert.True(liste.TryAdd(2));
      Assert.False(liste.TryAdd(1));
    }
  }
}
