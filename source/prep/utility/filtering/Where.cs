using System;
using System.Collections.Generic;
using prep.collections;

namespace prep.utility.filtering
{
  public delegate PropertyType PropertyAccessor<in Item, out PropertyType>(Item item);

  public class Where<Item>
  {
    public static MatchFactory<Item, PropertyType> has_a<PropertyType>(PropertyAccessor<Item, PropertyType> accessor)
    {
      return new MatchFactory<Item, PropertyType>(accessor);
    }
  }

  public class MatchFactory<Item, PropertyType>
  {
    PropertyAccessor<Item, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<Item, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<Item> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<Item> equal_to_any(params PropertyType[] values)
    {
      return new AnonymousMatch<Item>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<Item> not_equal_to(PropertyType value)
    {
      throw new NotImplementedException();
    }
  }
}