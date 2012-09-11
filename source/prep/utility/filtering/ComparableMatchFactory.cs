using System;
using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<Item, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<Item, PropertyType> accessor;
      private MatchFactory<Item, PropertyType> matchFactory;

    public ComparableMatchFactory(PropertyAccessor<Item, PropertyType> accessor)
    {
      this.accessor = accessor;
        this.matchFactory = new MatchFactory<Item, PropertyType>(accessor);
    }

    public IMatchAn<Item> greater_than(PropertyType value)
    {
      return new AnonymousMatch<Item>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<Item> equal_to(PropertyType value)
    {
        return matchFactory.equal_to_any(value);
    }

    public IMatchAn<Item> not_equal_to(PropertyType value)
    {
        return matchFactory.equal_to_any(value).not();
    }

    public IMatchAn<Item> equal_to_any(params PropertyType[] values)
    {
        return matchFactory.equal_to_any(values);
    }
  }
}