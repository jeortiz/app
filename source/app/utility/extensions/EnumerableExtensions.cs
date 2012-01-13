using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.extensions
{
  public static class EnumerableExtensions
  {
    public static void visit_all_items_with<T>(this IEnumerable<T> items, IProcessAnItem<T> action)
    {
      items.visit_all_items_with(action.process);
    }

    public static void visit_all_items_with<T>(this IEnumerable<T> items, Action<T> action)
    {
      foreach (var item in items) action(item);
    }

    public static ReturnType get_result_of_visiting_all_items_with<ItemToProcess, ReturnType>(
      this IEnumerable<ItemToProcess> items,
      IProcessAndItemAndReturnState<ItemToProcess, ReturnType> visitor)
    {
      items.visit_all_items_with(visitor);
      return visitor.get_result();
    }

    public static IEnumerable<T> each<T>(this IEnumerable<T> items)
    {
      return items.Select(x => x);
    }
  }
}