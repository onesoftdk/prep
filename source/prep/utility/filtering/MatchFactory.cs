using System.Collections.Generic;

namespace prep.utility.filtering
{
        public class FactoryFactory<Item>
        {
                public static IMatchAn<Item> CreateAnonymousMatch(Condition<Item> condition)
            {
                return new AnonymousMatch<Item>(condition);
            }
        }

  public class MatchFactory<Item, PropertyType> : ICreateMatchers<Item, PropertyType>
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
        return FactoryFactory<Item>.CreateAnonymousMatch(x => new List<PropertyType>(values).Contains(accessor(x)));
      //return new AnonymousMatch<Item>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<Item> not_equal_to(PropertyType value)
    {
      return equal_to_any(value).not();
    }
  }
}