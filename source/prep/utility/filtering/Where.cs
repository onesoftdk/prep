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
      throw new NotImplementedException();
    }
  }
}