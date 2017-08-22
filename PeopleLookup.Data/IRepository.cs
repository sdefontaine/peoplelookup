using System;
using System.Collections.Generic;

namespace PeopleLookup.Data
{
    public interface IRepository
    {
        List<Person> GetPeopleByFirstName(string name);
        List<Person> GetPeopleByLastName(string name);
        List<Person> GetPeopleByFirstLastName(string firstName,string lastName);
        void LoadPeople(string filename);
    }
}
