using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class MovieReviewsDataDelegate : DataReaderDelegate<IReadOnlyList<Review>>
    {
        private readonly string movieName;

        public MovieReviewsDataDelegate(string movieName)
           : base("Movies.MovieReviews")
        {
            this.movieName = movieName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("movieName", SqlDbType.NVarChar);
            p1.Value = movieName;
        }

        public override IReadOnlyList<Review> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException(movieName.ToString());
            }

            var reviews = new List<Review>();

            while (reader.Read())
            {
                Review addMovie = new Review(
                   reader.GetInt32("ReviewID"),
                   reader.GetInt32("MovieID"),
                   reader.GetInt32("ReviewerID"),
                   reader.GetInt32("Rating"),
                   reader.GetString("Review"),
                   reader.GetString("ReviewSite")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                reviews.Add(addMovie);
            }

            return reviews;
        }
    }
}