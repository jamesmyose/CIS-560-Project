using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class Reviewer
    {
        public int ReviewerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        //public int isremoved { get; }
        //public DateTime createdon { get; }
        //public DateTime updatedon { get; }

        public Reviewer(int ReviwerID, string FirstName, string LastName)
        //int IsRemoved, DateTime createdon, DateTime updatedon)
        {
            this.ReviewerID = ReviwerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            //IsRemoved = isRemoved;
            //CreatedOn = createdOn;
            //UpdatedOn = updatedOn;
        }
    }
}
