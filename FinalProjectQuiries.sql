/*
-----------------------
|  Question Queries   |
-----------------------
*/

-- Total Sales for each movie
Select M.MovieName, SUM((MC.TicketsSold * MC.TicketPrice)) AS TotalSales
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

-- For all movie showings, show the total income from all ticket sales and a running total of ticket sales for each movie.


/*

For a given actor, show all movies they were in over the last year that was a certain genre and in a given range of review scores. Also show total number of reviews and the actors salary for that movie.
Implement the degrees of separation for any two actors(Six Degrees of Kevin Bacon)
For each user that left a review, find all movies that they left a 7 or higher on and determine their most liked genre of movie.
*/