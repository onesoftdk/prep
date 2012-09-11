using System;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<Item, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<Item, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<Item, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<Item> greater_than(PropertyType value)
    {
      return new AnonymousMatch<Item>(x => accessor(x).CompareTo(value) > 0);
    }
  }
}