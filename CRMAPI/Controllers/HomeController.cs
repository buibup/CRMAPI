using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMAPI.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult GetHospitalSite()
        {
            return Ok("");
        }
    }
}
