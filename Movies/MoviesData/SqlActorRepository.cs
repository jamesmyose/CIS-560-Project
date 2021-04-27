using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlActorRepository : IActorRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlActorRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public float ActorTotalSalary(string firstName, string lastName)
        {
            var d = new ActorTotalSalaryDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

    }
}
