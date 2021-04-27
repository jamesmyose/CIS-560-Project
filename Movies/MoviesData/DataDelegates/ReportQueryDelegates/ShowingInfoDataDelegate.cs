using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class ShowingInfoDataDelegate : DataReaderDelegate<int>
    {
        public override int Translate(SqlCommand command, IDataRowReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}