using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class ActorMoviesDataDelegate : DataReaderDelegate<IReadOnlyList<Movie>>
    {
        private readonly string firstName;
        private readonly string lastName;

        public ActorMoviesDataDelegate(string firstName, string lastName)
           : base("Movies.ActorMovies")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("firstName", SqlDbType.NVarChar);
            var p2 = command.Parameters.Add("lastName", SqlDbType.NVarChar);
            p1.Value = firstName;
            p2.Value = lastName;
        }

        public override IReadOnlyList<Movie> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException((firstName + lastName).ToString());
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