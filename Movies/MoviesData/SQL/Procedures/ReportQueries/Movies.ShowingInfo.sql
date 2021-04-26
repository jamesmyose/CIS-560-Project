CREATE OR ALTER PROCEDURE Movies.ShowingInfo
AS

-- For all movie showings, show the total income from all ticket sales of a showing and a running total of ticket sales for each Theather.
-- Also display data on the location of the showing and what movie is shown
With MovieSales AS (
    SELECT SUM(MC.TicketsSold * MC.TicketPrice) AS Sales, MC.MovieID, MC.CinemaID
    FROM Movies.MovieCinema MC
    GROUP BY MC.MovieID, MC.CinemaID
)
SELECT C.CinemaID, C.[State], C.City, C.Address, M.MovieName, MS.Sales,
        SUM(MS.Sales) OVER(Partition BY C.CinemaID ORDER BY C.CinemaID, M.MovieID) AS RunningSales
FROM MovieSales MS
    INNER JOIN Movies.Movie M ON M.MovieID = MS.MovieID
    INNER JOIN Movies.Cinema C ON C.CinemaID = MS.CinemaID
ORDER BY C.CinemaID, M.MovieID;