CREATE OR ALTER PROCEDURE Movies.ActorTotalSalary
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32)
AS

-- Total salary of a given actor
Select SUM(MA.Salary) AS TotalSalary
From Movies.Actors A
    INNER JOIN Movies.MovieActor MA ON MA.ActorID = A.ActorID
WHERE A.FirstName = @FirstName AND A.LastName = @LastName;