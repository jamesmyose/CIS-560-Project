using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData
{
    public class Reviewer
    {
        public int ReviewerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int IsRemoved { get; }
        public DateTime CreatedOn { get; }
        public DateTime UpdatedOn { get; }

        public Reviewer(int ReviwerID, string firstName, string lastName,
            int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            this.ReviewerID = ReviwerID;
            FirstName = firstName;
            LastName = lastName;
            IsRemoved = isRemoved;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
    }
}
