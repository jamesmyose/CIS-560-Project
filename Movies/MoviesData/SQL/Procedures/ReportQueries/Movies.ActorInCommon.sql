CREATE OR ALTER PROCEDURE Movies.ActorInCommon
    @FirstName NVARCHAR(32),
    @LastName NVARCHAR(32)
AS

--For each actor, show all other actors that have been in a movie with them along with the movie they were in together
With BaseCase AS (
    Select A.FirstName, A.LastName, A.ActorID, MA.MovieID
    FROM Movies.Actors A
        INNER JOIN Movies.MovieActor MA ON MA.ActorID = A.ActorID
)
Select D.ActorID, A.FirstName, A.MiddleName, A.LastName, M.MovieName
    FROM BaseCase D
        INNER JOIN Movies.Movie M ON M.MovieID = D.MovieID
        INNER JOIN Movies.MovieActor MA ON MA.MovieID = M.MovieID
        INNER JOIN Movies.Actors A ON A.ActorID = MA.ActorID AND A.ActorID != D.ActorID
WHERE A.FirstName = @FirstName AND A.LastName = @LastName;
--Order BY D.ActorID;