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
ORDER BY C.CinemaID, M.MovieID;


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
Order BY D.ActorID;

        

-- For each user that left a review, find all reviews that they left a 7 or higher on and gather a running total for each genre that was part of a movie they left a review on
SELECT RR.ReviewerID, M.MovieName, R.Rating, 
Count(CASE WHEN M.Genre1 = 'Drama' OR M.Genre2 = 'Drama' OR M.Genre3 = 'Drama' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS DramaCount,
Count(CASE WHEN M.Genre1 = 'Crime' OR M.Genre2 = 'Crime' OR M.Genre3 = 'Crime' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS CrimeCount,
Count(CASE WHEN M.Genre1 = 'Action' OR M.Genre2 = 'Action' OR M.Genre3 = 'Action' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS ActionCount,
Count(CASE WHEN M.Genre1 = 'Biography' OR M.Genre2 = 'Biography' OR M.Genre3 = 'Biography' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS BiographyCount,
Count(CASE WHEN M.Genre1 = 'History' OR M.Genre2 = 'History' OR M.Genre3 = 'History' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS HistoryCount,
Count(CASE WHEN M.Genre1 = 'Adventure' OR M.Genre2 = 'Adventure' OR M.Genre3 = 'Adventure' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS AdventureCount,
Count(CASE WHEN M.Genre1 = 'Western' OR M.Genre2 = 'Western' OR M.Genre3 = 'Western' THEN 1 END) OVER(Partition By RR.ReviewerID Order By R.ReviewID) AS WesternCount
FROM Movies.Reviewer RR
    INNER JOIN Movies.Review R ON R.ReviewerID = RR.ReviewerID
    INNER JOIN Movies.Movie M ON M.MovieID = R.MovieID
WHERE R.Rating >= 7
ORDER BY RR.ReviewerID
-- OR M.Genre2 = N'Drama' OR M.Genre3 = N'Drama
