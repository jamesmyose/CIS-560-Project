using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class GenreMoviesDataDelegate : DataReaderDelegate<IReadOnlyList<Movie>>
    {
        private readonly string genre1;
        private readonly string genre2;
        private readonly string genre3;

        public GenreMoviesDataDelegate(string genre1, string genre2, string genre3)
           : base("Movies.GenreMovies")
        {
            this.genre1 = genre1;
            this.genre2 = genre2;
            this.genre3 = genre3;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("genre1", SqlDbType.NVarChar);
            var p2 = command.Parameters.Add("genre2", SqlDbType.NVarChar);
            var p3 = command.Parameters.Add("genre3", SqlDbType.NVarChar);
            p1.Value = genre1;
            p2.Value = genre2;
            p3.Value = genre3;
        }

        public override IReadOnlyList<Movie> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException((genre1 + ", " + genre2 + ", " + genre3).ToString());
            }

            var movies = new List<Movie>();

            while (reader.Read())
            {
                Movie addMovie = new Movie(reader.GetInt32("MovieID"),
                   reader.GetString("Genre1"),
                   reader.GetString("Genre2"),
                   reader.GetString("Genre3"),
                   reader.GetString("ReleaseDate"),
                   reader.GetValue<float>("CostOfProduction")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                movies.Add(addMovie);
            }

            return movies;

            /*
            return new Movie(reader.GetInt32("MovieID"),
               reader.GetString("Genre1"),
               reader.GetString("Genre2"),
               reader.GetString("Genre3"),
               reader.GetString("ReleaseDate"),
               reader.GetValue<float>("CostOfProduction")
               //reader.GetString("IsRemoved"),
               //reader.GetString("CreatedOn"),
               //reader.GetString("UpdatedOn")
               );
            */
        }
    }
}