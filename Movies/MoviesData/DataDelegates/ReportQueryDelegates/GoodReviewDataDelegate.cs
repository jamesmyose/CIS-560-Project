using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class GoodReviewDataDelegate : DataReaderDelegate<IReadOnlyList<(Review, Movie)>>
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly int rating;

        public GoodReviewDataDelegate(string firstName, string lastName, int rating)
           : base("Movies.GoodReview")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.rating = rating;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("firstName", SqlDbType.NVarChar);
            var p2 = command.Parameters.Add("lastName", SqlDbType.NVarChar);
            var p3 = command.Parameters.Add("rating", SqlDbType.Int);
            p1.Value = firstName;
            p2.Value = lastName;
            p3.Value = rating;
        }

        public override IReadOnlyList<(Review, Movie)> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException((lastName + ", " + firstName + ", " + rating).ToString());
            }

            var reviewMoviePair = new List<(Review, Movie)>();

            while (reader.Read())
            {
                Review addReview = new Review(
                    reader.GetInt32("ReviewID"),
                    reader.GetInt32("MovieID"),
                    reader.GetInt32("ReviewerID"),
                    reader.GetInt32("Rating"),
                    reader.GetString("Review"),
                    reader.GetString("ReviewSite")
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
                reviewMoviePair.Add((addReview, addMovie));
            }

            return reviewMoviePair;
        }
    }
}