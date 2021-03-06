CREATE TABLE Movies.MovieCinema
(
   MovieID INT Not Null FOREIGN KEY
        REFERENCES Movies.Movie(MovieID),
   CinemaID INT NOT NULL FOREIGN KEY
        REFERENCES Movies.Cinema(CinemaID),
   TicketPrice FLOAT NOT NULL,
   TicketsSold FLOAT NOT NULL,
   PlayingTime DATETIME2(0) NOT NULL,
   IsRemoved INT NOT NULL DEFAULT(0),
   CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
   UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())

   PRIMARY KEY(MovieID, CinemaID, PlayingTime)
);