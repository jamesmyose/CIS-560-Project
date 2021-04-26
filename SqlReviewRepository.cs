using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlReviewRepository: IReviewRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlReviewRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public IReadOnlyList<Review> MovieReviews(string movieName)
        {
            var d = new MovieReviewsDataDelegate(movieName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Review> ScoreReviews(int score)
        {
            var d = new ScoreReviewsDataDelegate(score);
            return executor.ExecuteReader(d);
        }
    }
}
