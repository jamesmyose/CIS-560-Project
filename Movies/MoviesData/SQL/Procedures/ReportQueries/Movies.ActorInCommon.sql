CREATE OR ALTER PROCEDURE Movies.ActorInCommon
    @FirstName NVARCHAR(32),
    @LastName NVARCHAR(32)
AS

--For an actor, show all other actors that have been in a movie with them along with the movie they were in together
With BaseCase AS (
    Select A.FirstName, A.LastName, A.ActorID, MA.MovieID
    FROM Movies.Actors A
        INNER JOIN Movies.MovieActor MA ON MA.ActorID = A.ActorID
)
Select 
    D.ActorID AS StartActorID,
    D.FirstName AS StartFirstName,
    D.MiddleName AS StartMiddleName,
    D.LastName AS StartLastName,
    A.ActorID AS EndActorID,
    A.FirstName AS EndFirstName,
    A.MiddleName AS EndMiddleName,
    A.LastName AS EndLastName,
    M.MovieID AS MovieID, 
    M.MovieName AS MovieName,
    M.Genre1 AS Genre1,
    M.Genre2 AS Genre2,
    M.Genre3 AS Genre3,
    M.ReleaseDate AS ReleaseDate,
    M.CostOfProduction AS CostOfProduction
    --D.ActorID,
    FROM BaseCase D
        INNER JOIN Movies.Movie M ON M.MovieID = D.MovieID
        INNER JOIN Movies.MovieActor MA ON MA.MovieID = M.MovieID
        INNER JOIN Movies.Actors A ON A.ActorID = MA.ActorID AND A.ActorID != D.ActorID
WHERE D.FirstName = @FirstName AND D.LastName = @LastName;
--Order BY D.ActorID;