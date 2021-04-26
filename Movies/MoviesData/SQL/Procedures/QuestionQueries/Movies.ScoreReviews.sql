CREATE OR ALTER PROCEDURE Movies.ScoreReviews
   @Score INT
AS

-- All Reviews with a given score
Select r.Review, r.ReviewSite, M.MovieName
From Movies.Review R
    INNER JOIN Movies.Movie M ON M.MovieID = R.MovieID
Where R.Rating = @Score;