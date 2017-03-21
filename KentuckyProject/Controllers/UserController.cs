using KentuckyWebService.Business;
using KentuckyWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KentuckyWebService.Controllers
{
    public class UserController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public User Post(User user)
        {
            return userBusiness.CreateUser(user);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
