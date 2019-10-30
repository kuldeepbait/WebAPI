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
    public class UserController : ApiController
    {
        // GET api/<controller>
        TestEntities db = new TestEntities();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("api/GetUserList")]
        [HttpPost]
        public IHttpActionResult GetUserList(UserModel user)
        {
           var masssage = string.Empty;
           if(ModelState.IsValid)
            {
                var userExist = db.Users.Where(t => t.UserId.ToLower() == user.UserId.ToLower()).FirstOrDefault();
                if(userExist!=null)
                {
                    var passwordCheck = userExist.Password == user.Password;
                    if(passwordCheck)
                    {
                        masssage = "LOGIN_SUCCESS";
                    }
                    else
                    {
                        masssage = "INCORRECT_PASSWORD";
                    }
                }
                else
                {
                    masssage = "DOES_NOT_EXIST";
                }
            }
            return Json(masssage);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}