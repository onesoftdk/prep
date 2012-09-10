using System;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

    public override string ToString()
    {
      return title + ":" + production_studio + ":" + date_published;
    }

    public bool Equals(Movie other)
    {
      if (other == null) return false;

      return ReferenceEquals(this, other) || this.title.Equals(other.title);
    }

    public override bool Equals(object obj)
    {
      return this.Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      return title.GetHashCode();
    }
  }
}