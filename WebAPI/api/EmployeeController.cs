using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.DLL;
using WebAPI.Models;

namespace WebAPI.api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {

        TestEntities db = new TestEntities();
        [Route("api/GetEmployeeList")]
        public IHttpActionResult GetEmployeeList()
        {

            return Json(db.Employees.ToList());
        }
        [Route("api/GetCityList")]
        public IHttpActionResult GetCityList()
        {
            return Json(db.Cities.ToList());
        }
        [Route("api/SaveEmployee")]
        [HttpPost]
        public IHttpActionResult SaveEmployee([FromBody]EmployeeModel emp)
        {
            return Json("success");
        }
    }
}