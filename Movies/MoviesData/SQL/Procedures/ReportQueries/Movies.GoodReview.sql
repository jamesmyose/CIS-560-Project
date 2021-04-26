CREATE OR ALTER PROCEDURE Movies.GoodReview
    @FirstName NVARCHAR(32),
    @LastName NVARCHAR(32),
    @Rating INT
AS

-- For the given reviewer, find all reviews that they left the given rating or higher on and gather a running total for each genre that was part of a movie they left a review on
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
WHERE R.Rating >= @Rating
ORDER BY RR.ReviewerID
-- OR M.Genre2 = N'Drama' OR M.Genre3 = N'Drama