CREATE OR ALTER PROCEDURE Movies.DirectorMovies
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32)
AS

-- Show all movies a given director worked on
SELECT M.MovieName
FROM Movies.Movie M
    INNER JOIN Movies.MovieDirectors MD ON M.MovieID = MD.MovieID
    INNER JOIN Movies.Directors D ON D.DirectorID = MD.DirectorID
WHERE D.FirstName = @FirstName AND D.LastName = @LastName;