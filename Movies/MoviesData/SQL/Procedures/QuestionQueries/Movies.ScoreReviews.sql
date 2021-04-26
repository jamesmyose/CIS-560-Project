CREATE OR ALTER PROCEDURE Movies.ScoreReviews
   @Score INT
AS

-- All Reviews with a given score or higher
Select r.ReviewID, M.MovieID, r.ReviewerID, r.Rating, r.Review, r.ReviewSite, M.MovieName --moviename unused? --r.Review, r.ReviewSite, M.MovieName
From Movies.Review R
    INNER JOIN Movies.Movie M ON M.MovieID = R.MovieID
Where R.Rating >= @Score;