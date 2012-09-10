namespace prep.utility
{
  public class OrMatch<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatchAn<ItemToMatch> left;
    IMatchAn<ItemToMatch> right;

    public OrMatch(IMatchAn<ItemToMatch> left, IMatchAn<ItemToMatch> right)
    {
      this.left = left;
      this.right = right;
    }

    public bool matches(ItemToMatch item)
    {
      return left.matches(item) || right.matches(item);
    }
  }
}