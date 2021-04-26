using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class Director
    {
        public int DirectorID { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public int IsRemoved { get; }
        public DateTime CreatedOn { get; }
        public DateTime UpdatedOn { get; }

        public Director(int directorID, string firstName, string middleName,
            string lastName, int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            DirectorID = directorID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            IsRemoved = isRemoved;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
    }
}
