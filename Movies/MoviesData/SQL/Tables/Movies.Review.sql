CREATE TABLE Movies.Review
(
   ReviewID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   MovieID INT NOT NULL FOREIGN KEY
      REFERENCES Movies.Movie(MovieID),
   ReviewerID INT NOT NULL FOREIGN KEY
      REFERENCES Movies.Reviewer(ReviewerID),
   Rating INT NOT NULL,
   Review NVARCHAR(1024) NOT NULL,
   ReviewSite NVARCHAR(32) NOT NULL,
   IsRemoved INT NOT NULL DEFAULT(0),
   CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
   UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);