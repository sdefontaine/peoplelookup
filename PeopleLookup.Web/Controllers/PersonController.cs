using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PeopleLookup.Data;
using PeopleLookup_Web.Models;
using Newtonsoft.Json;
using PeopleLookup.BLL;

namespace PeopleLookup_Web.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IHostingEnvironment _env;
        private IPeopleLogic _bll;

        public PersonController(IPeopleLogic bll)
        {
            _bll = bll;
        }

        [HttpPost]
        [Route("search")]
        public string Search([FromBody] PersonSearchModel search)
        {
            var term = search.Name;
            var peopleModel = new List<PersonModel>();
            try
            {
                var people = _bll.GetPeopleByName(term);
                peopleModel = people.Select(i =>
                        new PersonModel { First = i.First, Last = i.Last, Address = i.Address, Age = i.Age, Interest = i.Interests, Picture = i.Picture }).ToList<PersonModel>(); ;

                return JsonConvert.SerializeObject(new Response
                {
                    State = RequestState.Success,
                    Msg = "",
                    Data = peopleModel
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new Response
                {
                    State = RequestState.Failed,
                    Msg = ex.Message,
                    Data = null
                });
            }
        }

    }
}
