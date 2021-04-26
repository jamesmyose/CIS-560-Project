CREATE OR ALTER PROCEDURE Movies.ActorGenreMovies
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32),
   @Genre NVARCHAR(64),
   @RatingMax INT,
   @RatingMin INT
AS

-- For a given actor, show all movies they were in that was a certain genre and in a given range of review scores along with 
DECLARE @ActorID INT = (Select A.ActorID FROM Movies.Actors A WHERE A.FirstName = @FirstName AND A.LastName = @LastName);
DECLARE @Genre NVARCHAR(64) = @Genre
DECLARE @HighScore INT = @RatingMax
DECLARE @LowScore INT = @RatingMin

SELECT M.MovieName, COUNT(DISTINCT R.Review) AS TotalReviews, R.Rating, R.ReviewSite
FROM Movies.Actors A
    INNER JOIN Movies.MovieActor MA on MA.ActorID = @ActorID
    INNER JOIN Movies.Movie M ON M.MovieID = MA.MovieID
    INNER JOIN Movies.Review R ON R.MovieID = M.MovieID
WHERE (M.Genre1 = @Genre OR M.Genre2 = @Genre OR M.Genre3 = @Genre) AND (R.Rating <= @HighScore AND R.Rating >= @LowScore)
GROUP BY M.MovieName, R.Rating, R.ReviewSite
ORDER BY M.MovieName, R.ReviewSite, R.Rating;