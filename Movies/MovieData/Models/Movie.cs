using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData
{
    public class Movie
    {
        public int MovieID { get; }
        public string Genre1 { get; }
        public string Genre2 { get; }
        public string Genre3 { get; }
        public string ReleaseDate { get; }
        public float CostOfProduction { get; }
        public int IsRemoved { get; }
        public DateTime CreatedOn { get; }
        public DateTime UpdatedOn { get; }


        public Movie(int movieID, string genre1, string genre2, string genre3, string releaseDate, float costOfProduction, int isRemoved)
        {
            MovieID = movieID;
            Genre1 = genre1;
            Genre2 = genre2;
            Genre3 = genre3;
            ReleaseDate = releaseDate;
            CostOfProduction = costOfProduction;
            IsRemoved = isRemoved;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
    }
}
