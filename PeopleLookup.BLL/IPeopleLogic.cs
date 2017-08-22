using PeopleLookup.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleLookup.BLL
{
    public interface IPeopleLogic
    {
        List<Person> GetPeopleByName(string name);
    }
}
