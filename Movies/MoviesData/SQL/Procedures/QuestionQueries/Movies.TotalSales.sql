CREATE OR ALTER PROCEDURE Movies.TotalSales
AS

-- Total Sales for each movie
Select M.MovieName, SUM(MC.TicketsSold * MC.TicketPrice) AS TotalSales
FROM Movies.Movie M
    INNER JOIN Movies.MovieCinema MC ON MC.MovieID = M.MovieID
GROUP BY M.MovieName;