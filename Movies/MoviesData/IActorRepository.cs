using System;
using System.Collections.Generic;
using MoviesData.Models;

namespace MoviesData
{
    public interface IActorRepository
    {
        float ActorTotalSalary(string firstName, string lastName);
    }
}
