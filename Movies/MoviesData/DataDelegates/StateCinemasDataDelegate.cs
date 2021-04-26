using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates
{
    internal class StateCinemasDataDelegate : DataReaderDelegate<IReadOnlyList<Cinema>>
    {
        private readonly string state;

        public StateCinemasDataDelegate(string state)
           : base("Movies.StateCinemas")
        {
            this.state = state;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("state", SqlDbType.NVarChar);
            p1.Value = state;
        }

        public override IReadOnlyList<Cinema> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException(state.ToString());
            }

            var theaters = new List<Cinema>();

            while (reader.Read())
            {
                Cinema addMovie = new Cinema(
                   reader.GetInt32("CinemaID"),
                   reader.GetString("State"),
                   reader.GetString("City"),
                   reader.GetString("Address")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                theaters.Add(addMovie);
            }

            return theaters;
        }
    }
}