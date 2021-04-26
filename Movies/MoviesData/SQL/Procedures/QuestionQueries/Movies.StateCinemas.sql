CREATE OR ALTER PROCEDURE Movies.StateCinemas
   @State NVARCHAR(64)
AS

-- All Movie Theaters in a given state
SELECT * --C.City, C.[Address]
FROM Movies.Cinema C
WHere c.[State] = @State;