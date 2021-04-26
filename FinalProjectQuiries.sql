/*
-----------------------
|  Question Queries   |
-----------------------
*/

-- Total Sales for each movie
Select M.MovieName, SUM(MC.TicketsSold * MC.TicketPrice) AS TotalSales
FROM Movies.Movie M
    INNER JOIN Movies.MovieCinema MC ON MC.MovieID = M.MovieID
GROUP BY M.MovieName;

-- each movie a certain actor has been in
Select M.MovieName
FROM Movies.Movie M
    INNER JOIN Movies.MovieActor MA ON MA.MovieID = M.MovieID
    INNER JOIN Movies.Actors A ON A.ActorID = MA.ActorID
WHERE A.FirstName = 'Tim' AND A.LastName = 'Robbins';

-- All movies that share a given genre
SELECT M.MovieName
FROM Movies.Movie M
Where M.Genre1 = N'Drama' OR M.Genre2 = N'Drama' OR M.Genre3 = N'Drama';

-- Total salary of a given actor
Select SUM(MA.Salary) AS TotalSalary
From Movies.Actors A
    INNER JOIN Movies.MovieActor MA ON MA.ActorID = A.ActorID
WHERE A.FirstName = 'Tim' AND A.LastName = 'Robbins';

-- All Reviews with a given score
Select r.Review, r.ReviewSite, M.MovieName
From Movies.Review R
    INNER JOIN Movies.Movie M ON M.MovieID = R.MovieID
Where R.Rating = 9;

-- All Movie Theaters in a given state
SELECT C.City, C.[Address]
FROM Movies.Cinema C
WHere c.[State] = N'Virginia'

-- Show all movies a given director worked on
SELECT M.MovieName
FROM Movies.Movie M
    INNER JOIN Movies.MovieDirectors MD ON M.MovieID = MD.MovieID
    INNER JOIN Movies.Directors D ON D.DirectorID = MD.DirectorID
WHERE D.FirstName = N'Sidney' AND D.LastName = N'Lumet'

-- All Reviews for a given movie
Select r.Rating, r.Review, r.ReviewSite, M.MovieID
From Movies.Review R
    INNER JOIN Movies.Movie M ON M.MovieID = R.MovieID
Where M.MovieName = N'Schindlers List';


/*
----------------------
|   Report Queries   |
----------------------
*/

-- For all movie showings, show the total income from all ticket sales of a showing and a running total of ticket sales for each Theather.
-- Also display data on the location of the showing and what movie is shown
With MovieSales AS (
    SELECT SUM(MC.TicketsSold * MC.TicketPrice) AS Sales, MC.MovieID, MC.CinemaID
    FROM Movies.MovieCinema MC
    GROUP BY MC.MovieID, MC.CinemaID
)
SELECT C.[State], C.City, C.Address, M.MovieName, MS.Sales,
        SUM(MS.Sales) OVER(Partition BY C.CinemaID ORDER BY C.CinemaID, M.MovieID) AS RunningSales
FROM MovieSales MS
    INNER JOIN Movies.Movie M ON M.MovieID = MS.MovieID
    INNER JOIN Movies.Cinema C ON C.CinemaID = MS.CinemaID
ORDER BY C.CinemaID, M.MovieID


-- For a given actor, show all movies they were in that was a certain genre and in a given range of review scores along with 
DECLARE @ActorID INT = (Select A.ActorID FROM Movies.Actors A WHERE A.FirstName = 'Tim' AND A.LastName = 'Robbins');
DECLARE @Genre NVARCHAR(64) = N'Drama'
DECLARE @HighScore INT = 10
DECLARE @LowScore INT = 7

SELECT M.MovieName, COUNT(DISTINCT R.Review) AS TotalReviews, R.Rating, R.ReviewSite
FROM Movies.Actors A
    INNER JOIN Movies.MovieActor MA on MA.ActorID = @ActorID
    INNER JOIN Movies.Movie M ON M.MovieID = MA.MovieID
    INNER JOIN Movies.Review R ON R.MovieID = M.MovieID
WHERE (M.Genre1 = @Genre OR M.Genre2 = @Genre OR M.Genre3 = @Genre) AND (R.Rating <= @HighScore AND R.Rating >= @LowScore)
GROUP BY M.MovieName, R.Rating, R.ReviewSite
ORDER BY M.MovieName, R.ReviewSite, R.Rating;


-- Given an actor, show the degrees of seperation between them and all other actors (Six Degrees of Kevin Bacon)
With DegreesOfSeperation AS (
    Select A.FirstName, A.MiddleName, A.LastName, -1 AS Seperation, A.ActorID, MA.MovieID
    FROM Movies.Actors A
        INNER JOIN Movies.MovieActor MA ON MA.ActorID = A.ActorID
    Where A.FirstName = 'Tim' AND A.LastName = 'Robbins'

    UNION ALL

    Select A.FirstName, A.MiddleName, A.LastName, D.Seperation + 1 AS Seperation, A.ActorID, MA.MovieID
    FROM DegreesOfSeperation D
        INNER JOIN Movies.MovieActor MA ON MA.MovieID = D.MovieID
        INNER JOIN Movies.Actors A ON A.ActorID = MA.ActorID AND A.ActorID != D.ActorID
        
    WHERE D.Seperation < 1
    -- DO not have heirarcal data on each actor. Must find way to bind actors that have already been picked so same list of actors is not infinitely picked. Capping Seperation level does not work
    -- THouhg could limit the amount of recursions which is a step in the right direction
)

SELECT D.FirstName, D.MiddleName, D.LastName, D.Seperation
FROM DegreesOfSeperation D
--GROUP BY D.FirstName, D.MiddleName, D.LastName, D.Seperation
ORDER BY D.FirstName, D.MiddleName, D.LastName

-- For each user that left a review, find all movies that they left a 7 or higher on and determine their most liked genre of movie.
