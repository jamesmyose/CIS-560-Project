using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData
{
    public class Cinema
    {
        public int CinemaID { get; }
        public string State { get; }
        public string City { get; }
        public string Address { get; }
        public int IsRemoved { get; }
        public DateTime CreatedOn { get; }
        public DateTime UpdatedOn { get; }

        public Cinema(int CinemaID, string State, string City,
            string Address, int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            this.CinemaID = CinemaID;
            this.State = State;
            this.City = City;
            this.Address = Address;
            this.IsRemoved = isRemoved;
            this.CreatedOn = createdOn;
            this.UpdatedOn = updatedOn;
        }
    }
}
