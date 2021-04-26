CREATE OR ALTER PROCEDURE Movies.MovieReviews
   @MovieName NVARCHAR(64)
AS

-- All Reviews for a given movie
Select r.ReviewID, M.MovieID, r.ReviewerID, r.Rating, r.Review, r.ReviewSite --r.Rating, r.Review, r.ReviewSite, M.MovieID
From Movies.Review R
    INNER JOIN Movies.Movie M ON M.MovieID = R.MovieID
Where M.MovieName = @MovieName;