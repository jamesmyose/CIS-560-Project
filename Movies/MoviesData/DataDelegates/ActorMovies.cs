using DataAccess;
using MoviesData.Models;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates
{
    internal class FetchPersonDataDelegate : DataReaderDelegate<Movie>
    {
        private readonly int movieID;

        public FetchPersonDataDelegate(int movieID)
           : base("Person.FetchPerson")
        {
            this.movieID = movieID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("movieID", SqlDbType.Int);
            p.Value = movieID;
        }

        public override Movie Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(movieID.ToString());

            return new Movie(movieID,
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
        }
    }
}