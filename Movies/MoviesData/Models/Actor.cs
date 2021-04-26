using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class Actor
    {
        public int ActorID { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        //public int IsRemoved { get; }
        //public DateTime CreatedOn { get; }
        //public DateTime UpdatedOn { get; }

        public Actor(int actorID, string firstName, string middleName, string lastName)
            //int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            ActorID = actorID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            //IsRemoved = isRemoved;
            //CreatedOn = createdOn;
            //UpdatedOn = updatedOn;
        }
    }
}
