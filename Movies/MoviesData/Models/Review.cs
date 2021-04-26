using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class Review
    {
        public int ReviewID { get; }
        public int MovieID { get; }
        public int ReviewerID { get; }
        public int Rating { get; }
        public string ReviewText { get; }
        public string ReviewSite { get; }
        //public int IsRemoved { get; }
        //public DateTime CreatedOn { get; }
        //public DateTime UpdatedOn { get; }

        public Review(int ReviewID, int MovieID, int ReviewerID, int Rating, string ReviewText, string ReviewSite)
            //int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            this.ReviewID = ReviewID;
            this.MovieID = MovieID;
            this.ReviewerID = ReviewerID;
            this.Rating = Rating;
            this.ReviewText = ReviewText;
            this.ReviewSite = ReviewSite;
            //this.IsRemoved = isRemoved;
            //this.CreatedOn = createdOn;
            //this.UpdatedOn = updatedOn;
        }
    }
}
