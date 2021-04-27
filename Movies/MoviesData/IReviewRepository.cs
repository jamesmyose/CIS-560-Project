using System.Collections.Generic;
using MoviesData.Models;

namespace MoviesData
{
    public interface IReviewRepository
    {
        IReadOnlyList<Review> MovieReviews(string movieName);

        IReadOnlyList<Review> ScoreReviews(int score);
    }
}
