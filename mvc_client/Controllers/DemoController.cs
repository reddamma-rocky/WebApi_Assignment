using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvc_client.Controllers
{
    public class DemoController : ApiController
    {
        public string Get()
        {
            return "Welcome To Web API";
        }
        public List<string> Get(int Id)
        {
            return new List<string> {
                "Value1",
                "Value2"
            };
        }
    }
}

