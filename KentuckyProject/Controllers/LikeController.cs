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
    public class LikeController : ApiController
    {
        LikeBusiness likeBusiness = new LikeBusiness();

        // GET: api/Like
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Like/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Like
        public void Post(Like like)
        {
        }

        // PUT: api/Like/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Like/5
        public void Delete(int id)
        {
        }
    }
}
