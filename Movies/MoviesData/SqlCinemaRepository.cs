using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlCinemaRepository: ICinemaRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlCinemaRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public IReadOnlyList<Cinema> StateCinemas(string state)
        {
            var d = new StateCinemasDataDelegate(state);
            return executor.ExecuteReader(d);
        }
    }
}
