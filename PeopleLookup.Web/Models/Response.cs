using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleLookup_Web.Models
{

        public class Response
        {
            public RequestState State { get; set; }
            public string Msg { get; set; }
            public Object Data { get; set; }
        }

        public enum RequestState
        {
            Failed = -1,
            NotAuth = 0,
            Success = 1
        }
    
}
