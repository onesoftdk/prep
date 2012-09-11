using System;

namespace prep.utility.filtering
{
  public delegate PropertyType PropertyAccessor<in Item, out PropertyType>(Item item);

  public class Where<Item>
  {
    public static MatchFactory<Item, PropertyType> has_a<PropertyType>(PropertyAccessor<Item, PropertyType> accessor)
    {
      return new MatchFactory<Item, PropertyType>(accessor);
    }

    public static ComparableMatchFactory<Item, PropertyType> has_an<PropertyType>(
      PropertyAccessor<Item, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new ComparableMatchFactory<Item, PropertyType>(accessor,has_a(accessor));
    }
  }
}