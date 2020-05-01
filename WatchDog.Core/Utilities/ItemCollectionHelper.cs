using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WatchDog.Core.Utilities
{
  public static class ItemCollectionHelper
  {
    public static bool TryAdd<T>(this IList<T> collection, T item)
    {
      if (collection != null && !collection.Any(x => x.Equals(item)))
      {
        collection.Add(item);
        return true;
      }
      else
        return false;
    }
  }
}
