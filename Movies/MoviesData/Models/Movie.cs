using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
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

        public Movie(int movieID, string genre1, string genre2, string genre3, string releaseDate, float costOfProduction,
            int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            MovieID = movieID;
            Genre1 = genre1;
            Genre2 = genre2;
            Genre3 = genre3;
            ReleaseDate = releaseDate;
            CostOfProduction = costOfProduction;
            IsRemoved = isRemoved;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
    }
}
