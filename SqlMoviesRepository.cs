using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlMoviesRepository: IMovieRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlMoviesRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public IReadOnlyList<Movie> ActorMovie(string firstName, string lastName)
        {
            var d = new ActorMoviesDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Movie> DirectorMovies(string firstName, string lastName)
        {
            var d = new DirectorMoviesDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Movie> GenreMovies(string Genre1, string Genre2, string Genre3)
        {
            var d = new GenreMoviesDataDelegate(Genre1, Genre2, Genre3);
            return executor.ExecuteReader(d);
        }

        public int TotalSales(string moviename)
        {
            var d = new TotalSalesDataDelegate(moviename);
            return executor.ExecuteReader(d);
        }
    }
}
