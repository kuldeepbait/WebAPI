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
        TestEntities db = new TestEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult login(LoginModel user)
        {
            var masssage = string.Empty;
            if (ModelState.IsValid)
            {
                var userExist = db.Users.Where(t => t.UserId.ToLower() == user.UserId.ToLower()).FirstOrDefault();
                if (userExist != null)
                {
                    var passwordCheck = userExist.Password == user.Password;
                    if (passwordCheck)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("api/UserRegistration")]
        [HttpPost]
        public IHttpActionResult UserRegistration(UserModel user)
        {
            var masssage = string.Empty;
            if (ModelState.IsValid)
            {
                var userExist = db.Users.Where(t => t.UserId.ToLower() == user.UserId.ToLower()).FirstOrDefault();
                if (userExist != null)
                {
                    masssage = "USER_EXIST";
                    return Json(masssage);
                }
                User objUser = new DLL.User();
                objUser.UserId = user.UserId;
                objUser.Password = user.Password;
                objUser.Email = user.Email;
                objUser.FullName = user.FullName;
                db.Users.Add(objUser);
                db.SaveChanges();
                masssage = "SUCCESS";
            }
            return Json(masssage);
        }
    }
}