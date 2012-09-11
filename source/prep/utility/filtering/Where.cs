using System;

namespace prep.utility.filtering
{
  public delegate PropertyType PropertyAccessor<in Item, out PropertyType>(Item item);

  public class Where<Item>
  {
    public static PropertyAccessor<Item, PropertyType> has_a<PropertyType>(PropertyAccessor<Item, PropertyType> accessor)
    {
      return accessor;
    }
  }

  public static class SimpleMatching
  {
    public static IMatchAn<Item> equal_to<Item, PropertyType>(this PropertyAccessor<Item, PropertyType> accessor,
                                                              PropertyType value_to_equal)
    {
       return new AnonymousMatch<Item>(item => accessor.Invoke(item).Equals(value_to_equal));
    }
  }
  public class AnonymousMatch<Item> : IMatchAn<Item>
  {
      Condition<Item> condition;

      public AnonymousMatch(Condition<Item> condition)
      {
          this.condition = condition;
      }

      public bool matches(Item item)
      {
          return condition(item);
      }
  }
}