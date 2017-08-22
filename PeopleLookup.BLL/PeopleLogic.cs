using PeopleLookup.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleLookup.BLL
{
    public class PeopleLogic : IPeopleLogic
    {
        private IRepository _repository;

        public PeopleLogic(IRepository repository)
        {
            _repository = repository;
        }
        public List<Person> GetPeopleByName(string name)
        {
            var people = new List<Person>();
            if (!String.IsNullOrEmpty(name))
            {
                // split first and last (last can containt spaces)
                // Note: we are assuming first name contains only one word and last can contain 2 or more words: ex "Stephan de Fontaine"
                // If we wanted to get more granular we would have to expect the input to be delimited by another character {eg. ',') but this project is not asking for that
                // If we were just assuming one word for each then this could all be put in one query (Repository method)
                string[] terms = name.Split(new char[] { ' ' }, 2);
                //string[] terms = term.Split(' ');
                if (terms.Length == 1)
                {
                    //if only one name - could be first name or last name
                    var firstNameResults = _repository.GetPeopleByFirstName(terms[0]).ToList();
                    people.AddRange(firstNameResults);
                    var lastNameResults = _repository.GetPeopleByLastName(terms[0]).ToList();
                    people.AddRange(lastNameResults);

                }
                else if (terms.Length == 2)
                {
                    // if two or more names - assume first and last or just last
                    // check last first
                    var lastNameResults = _repository.GetPeopleByLastName(name).ToList(); ;
                    people.AddRange(lastNameResults);
                    // check first and last
                    var firstLastnameResults = _repository.GetPeopleByFirstLastName(terms[0], terms[1]).ToList();
                    people.AddRange(firstLastnameResults);
                }
                people = people.GroupBy(i => i.ID).Select(group => group.First()).OrderBy(i => i.Last).ToList();

            }
            return people;
        }
    }
}
