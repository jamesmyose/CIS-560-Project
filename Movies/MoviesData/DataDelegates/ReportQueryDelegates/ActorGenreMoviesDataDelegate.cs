using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class ActorGenreMoviesDataDelegate : DataReaderDelegate<IReadOnlyList<(Movie, int, int, string)>>
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string genre;
        private readonly int ratingMin;
        private readonly int ratingMax;

        public ActorGenreMoviesDataDelegate(string firstName, string lastName, string genre, int ratingMin, int ratingMax)
           : base("Movies.ActorGenreMovies")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.genre = genre;
            this.ratingMin = ratingMin;
            this.ratingMax = ratingMax;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("firstName", SqlDbType.NVarChar);
            p1.Value = firstName;

            var p2 = command.Parameters.Add("lastName", SqlDbType.NVarChar);
            p2.Value = lastName;

            var p3 = command.Parameters.Add("genre", SqlDbType.NVarChar);
            p3.Value = genre;

            var p4 = command.Parameters.Add("ratingMin", SqlDbType.Int);
            p4.Value = ratingMin;

            var p5 = command.Parameters.Add("ratingMax", SqlDbType.Int);
            p5.Value = ratingMax;
        }

        public override IReadOnlyList<(Movie, int, int, string)> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException((lastName + ", " + firstName + " in " + genre + ", " + ratingMin + " to " + ratingMax).ToString());
            }
            var movies = new List<(Movie, int, int, string)>();
            while (reader.Read())
            {
                Movie addMovie = new Movie(
                   reader.GetInt32("MovieID"),
                   reader.GetString("MovieName"),
                   reader.GetString("Genre1"),
                   reader.GetString("Genre2"),
                   reader.GetString("Genre3"),
                   reader.GetDateTimeOffset("ReleaseDate"),
                   reader.GetValue<float>("CostOfProduction")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                int totalReviews = reader.GetInt32("TotalReviews");
                int rating = reader.GetInt32("Rating");
                string ratingSite = reader.GetString("RatingSite");
                movies.Add((addMovie, totalReviews, rating, ratingSite));
            }
            return movies;
        }
    }
}