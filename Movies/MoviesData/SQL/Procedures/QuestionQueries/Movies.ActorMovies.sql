CREATE OR ALTER PROCEDURE Movies.ActorMovies
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32)
AS

-- each movie a certain actor has been in
Select M.MovieName
FROM Movies.Movie M
    INNER JOIN Movies.MovieActor MA ON MA.MovieID = M.MovieID
    INNER JOIN Movies.Actors A ON A.ActorID = MA.ActorID
WHERE A.FirstName = @FirstName AND A.LastName = @LastName;