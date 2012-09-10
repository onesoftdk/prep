using System;
using System.Collections.Generic;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return this.movies;
    }


    private bool exist(Movie movie)
    {
        foreach (var movie1 in movies)
        {
            if (movie.title.Equals(movie1.title, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public void add(Movie movie)
    {
        if (this.movies.Contains(movie))
            return;
        
        if(exist(movie))
            return;

        this.movies.Add(movie);
      
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
        List<Movie> list = new List<Movie>(movies);

        list.Sort((movie, movie1) => System.String.CompareOrdinal(movie1.title, movie.title));

        return list;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        foreach (var movie in movies)
        {
            if (movie.production_studio == ProductionStudio.Pixar)
                yield return movie;
        }
      
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        IList<ProductionStudio> studios = new List<ProductionStudio>{ProductionStudio.Pixar, ProductionStudio.Disney};
        foreach (var movie in movies)
        {
            if (studios.Contains(movie.production_studio))
                yield return movie;
        }
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
        List<Movie> list = new List<Movie>(movies);

        list.Sort((movie, movie1) => System.String.CompareOrdinal(movie.title, movie1.title));

        return list;
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
        Dictionary<ProductionStudio, List<Movie>> list = new Dictionary<ProductionStudio, List<Movie>>();

        //MGM
        //Pixar
        //Dreamworks
        //Universal
        //Disney
        list.Add(ProductionStudio.MGM, new List<Movie>());
        list.Add(ProductionStudio.Pixar, new List<Movie>());
        list.Add(ProductionStudio.Dreamworks, new List<Movie>());
        list.Add(ProductionStudio.Universal, new List<Movie>());
        list.Add(ProductionStudio.Disney, new List<Movie>());
        
        //list.Add(ProductionStudio.Paramount, new List<Movie>());
               

        foreach (var movie in movies)
        {
            if(movie.production_studio == ProductionStudio.Paramount)
                continue;

            var aktuelleListe = list[movie.production_studio];
            aktuelleListe.Add(movie);
        }

        foreach (KeyValuePair<ProductionStudio, List<Movie>> keyValuePair in list)
        {
            keyValuePair.Value.Sort(delegate(Movie movie, Movie movie1)
                                        { return DateTime.Compare(movie.date_published, movie1.date_published); });

            foreach (Movie movie in keyValuePair.Value)
            {
                yield return movie;
            }
        }
 
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        IList<ProductionStudio> studios = new List<ProductionStudio> { ProductionStudio.Pixar };
        foreach (var movie in movies)
        {
            if (!studios.Contains(movie.production_studio))
                yield return movie;
        }
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        foreach (var movie in movies)
        {
            if (movie.date_published.Year > year)
                yield return movie;
        }

    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        foreach (var movie in movies)
        {
            if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                yield return movie;
        }
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        foreach (var movie in movies)
        {
            if (movie.genre == Genre.kids)
                yield return movie;
        }
    }

    public IEnumerable<Movie> all_action_movies()
    {
        foreach (var movie in movies)
        {
            if (movie.genre == Genre.action)
                yield return movie;
        }
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
        List<Movie> list = new List<Movie>(movies);

        list.Sort((movie, movie1) => DateTime.Compare(movie1.date_published, movie.date_published));

        return list;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
        List<Movie> list = new List<Movie>(movies);

        list.Sort((movie, movie1) => DateTime.Compare(movie.date_published, movie1.date_published));

        return list;
    }
  }
}