using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.IO;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using FastMember;

namespace PeopleLookup.Data
{
    
    public class SqlRepository : IRepository
    {
        private readonly PeopleContext db;
        public SqlRepository(PeopleContext context)
        {
                db = context;
        }

        public List<Person> GetPeopleByFirstName(string name)
        {
            var people = (from a in db.People
                          where a.First.Contains(name)
                          select a).ToList();
            return people;
        }

        public List<Person> GetPeopleByLastName(string name)
        {
            var people = (from a in db.People
                          where a.Last.Contains(name)
                          select a).ToList();
            return people;
        }

        public List<Person> GetPeopleByFirstLastName(string firstname, string lastname)
        {
            var people = (from a in db.People
                          where a.First.Contains(firstname)
                          && a.Last.Contains(lastname)
                          select a).ToList();
            return people;
        }

        public void LoadPeople(string filepath)
        {
            //Populate Customer with csv import file
            List<Person> people = File.ReadAllLines(filepath)
                   .Skip(1)
                   .Select(v => Person.FromCsv(v))
                   .ToList();

            //Return filtered Customers
            using (var sqlCopy = new SqlBulkCopy(db.Database.GetDbConnection().ConnectionString))
            {
                sqlCopy.DestinationTableName = "Person";

                using (var reader = ObjectReader.Create(people, Person.StorageParameters))
                {
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ID","ID"));
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("First", "First"));
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Last", "Last"));
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Address", "Address"));
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Age", "Age"));
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Interests", "Interests"));
                    sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Picture", "Picture"));
                    sqlCopy.WriteToServer(reader);


                }
            }


        }
    }
}

