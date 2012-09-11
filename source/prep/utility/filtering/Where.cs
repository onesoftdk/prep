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
      return new ComparableMatchFactory<Item, PropertyType>(accessor);
    }
  }

  public class ComparableMatchFactory<Item, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<Item, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<Item, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<Item> greater_than(PropertyType value)
    {
      throw new NotImplementedException();
    }
  }
}