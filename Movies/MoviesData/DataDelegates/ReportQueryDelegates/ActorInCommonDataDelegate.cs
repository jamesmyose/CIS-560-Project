using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class ActorInCommonDataDelegate : DataReaderDelegate<IReadOnlyList<(Actor, Actor, Movie)>>
    {
        private readonly string firstName;
        private readonly string lastName;

        public ActorInCommonDataDelegate(string firstName, string lastName)
           : base("Movies.ActorInCommon")
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

        public override IReadOnlyList<(Actor, Actor, Movie)> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException((lastName + ", " + firstName).ToString());
            }

            var actorMoviePair = new List<(Actor, Actor, Movie)>();

            while (reader.Read())
            {
                Actor addStartActor = new Actor(
                    reader.GetInt32("StartActorID"),
                    reader.GetString("StartFirstName"),
                    reader.GetString("StartMiddleName"),
                    reader.GetString("StartLastName")
                    );
                Actor addEndActor = new Actor(
                    reader.GetInt32("EndActorID"),
                    reader.GetString("EndFirstName"),
                    reader.GetString("EndMiddleName"),
                    reader.GetString("EndLastName")
                    );
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
                actorMoviePair.Add((addStartActor, addEndActor, addMovie));
            }

            return actorMoviePair;
        }
    }
}