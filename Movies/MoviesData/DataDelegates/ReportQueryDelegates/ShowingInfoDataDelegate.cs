using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class ShowingInfoDataDelegate : DataReaderDelegate<IReadOnlyList<(Cinema, string, float, float)>>
    {

        public ShowingInfoDataDelegate()
           : base("Movies.ShowingInfo")
        {
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<(Cinema, string, float, float)> Translate(SqlCommand command, IDataRowReader reader)
        {
            var showingInfo = new List<(Cinema, string, float, float)>();
            while (reader.Read())
            {
                Cinema addCinema = new Cinema(
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
                string movieName = reader.GetString("MovieName");
                float sales = reader.GetValue<float>("Sales");
                float runningSales = reader.GetValue<float>("RunningSales");
                showingInfo.Add((addCinema, movieName, sales,runningSales));
            }
            return showingInfo;
        }
    }
}