namespace prep.collections
{
  public class IsInGenre : IMatchAMovie
  {
    Genre genre;

    public IsInGenre(Genre genre)
    {
      this.genre = genre;
    }

    public bool matches(Movie item)
    {
      return item.genre == genre;
    } 
  }
}