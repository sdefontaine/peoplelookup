using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PeopleLookup.Data
{
    public partial class Person
    {
        public static Person FromCsv(string csvLine)
        {

            string[] values = Regex.Split(csvLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            Person person = new Person();
            person.ID = Convert.ToInt64(values[0]);
            person.First = values[1];
            person.Last = values[2].Trim('"'); ;
            person.Address = values[3].Trim('"');
            person.Age = Convert.ToInt32(values[4]);
            person.Interests = values[5].Trim('"'); ;
            person.Picture = values[6];

            return person;
        }

        //Defines mapping of Customer object to Customer table for SQLBulkCopy using ObjectReader(FastMember)
        public static string[] StorageParameters = new[]
        {
            nameof(Person.ID),
            nameof(Person.First),
            nameof(Person.Last),
            nameof(Person.Address),
            nameof(Person.Age),
            nameof(Person.Interests),
            nameof(Person.Picture)
        };


    }
}
