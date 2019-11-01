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
    public class UserManagementAPIController : ApiController
    {
        TestEntities db = new TestEntities();
        [Route("api/GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            return Json(db.Users.ToList());
        }
        [Route("api/GetUserById")]
        [HttpGet]
        public IHttpActionResult GetUserById(int Id)
        {
            return Json(db.Users.Where(t=>t.Id== Id).ToList());
        }
        [Route("api/UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser(UserModel user)
        {
            var resultBool = false;
            var masssage = string.Empty;
            if (ModelState.IsValid)
            {
                var userDetails = db.Users.Where(t => t.Id == user.Id).FirstOrDefault();
                userDetails.FullName = user.FullName;
                userDetails.UserId = user.UserId;
                userDetails.Email = user.Email;
                userDetails.Password = user.Password;
                resultBool = true;
            }
            return Json(resultBool);
        }
        [Route("api/DeleteUser")]
        [HttpPost]
        public IHttpActionResult DeleteUser(int id)
        {
            var resultBool = false;
            var userDetails = db.Users.Where(t => t.Id == id).FirstOrDefault();
            if (userDetails != null)
            {
                db.Users.Remove(userDetails);
                db.SaveChanges();
                resultBool = true;
            }
            return Json(resultBool);
        }
    }
}