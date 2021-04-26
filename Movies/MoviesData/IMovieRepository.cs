using System;
using System.Collections.Generic;
using MoviesData.Models;



namespace MoviesData
{
    public interface IMovieRepository
    {
        IReadOnlyList<Movie> ActorMovie(string firstName, string lastName);

        IReadOnlyList<Movie> DirectorMovies(string firstName, string lastName);

        IReadOnlyList<Movie> GenreMovies(string Genre1, string Genre2, string Genre3);

        int TotalSales(string moviename);
    }
}
