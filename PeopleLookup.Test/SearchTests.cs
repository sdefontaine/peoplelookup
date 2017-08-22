using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleLookup.Data;
using PeopleLookup.BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.IO;

namespace PeopleLookup.Tests
{
    [TestClass]
    public class SearchTests
    {
        private PeopleLogic _bll;

        public SearchTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<PeopleContext>();

            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=People;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .UseInternalServiceProvider(serviceProvider);

            var context = new PeopleContext(builder.Options);
            context.Database.Migrate();
            var repo = new SqlRepository(context);
            _bll = new PeopleLogic(repo);
            if (!context.People.Any())
            {
                var basepath = System.AppContext.BaseDirectory;
                var filepath = Path.Combine(basepath, "..\\..\\..\\..\\PeopleLookup.Web\\wwwroot\\data\\People.csv");
                repo.LoadPeople(filepath);
            }



        }
        [TestMethod]
        public void GetFirstName()
        {
            var result = _bll.GetPeopleByName("Step");
            Assert.AreEqual(result.Single().First, "Stephan");
        }

        [TestMethod]
        public void GetLastName()
        {
            var result = _bll.GetPeopleByName("de Fon");
            Assert.AreEqual(result.Single().Last, "de Fontaine");
        }

        [TestMethod]
        public void GetFirstLastName()
        {
            var result = _bll.GetPeopleByName("Step de Fon");
            Assert.AreEqual(result.Single().First, "Stephan");
            Assert.AreEqual(result.Single().Last, "de Fontaine");
        }

        [TestMethod]
        public void GetEmptyResults()
        {
            var result = _bll.GetPeopleByName("xxx");
            Assert.AreEqual(result.Count, 0);
        }
    }
}
