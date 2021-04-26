CREATE OR ALTER PROCEDURE Movies.GenreMovies
   @Genre1 NVARCHAR(64),
   @Genre2 NVARCHAR(64),
   @Genre3 NVARCHAR(64)
AS

-- All movies that share a given genre
SELECT M.MovieName
FROM Movies.Movie M
Where M.Genre1 = @Genre1 OR M.Genre2 = @Genre2 OR M.Genre3 = @Genre3;