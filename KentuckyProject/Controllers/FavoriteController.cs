using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KentuckyWebService.Controllers
{
    public class FavoriteController : ApiController
    {
        // GET: api/Favorite
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Favorite/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Favorite
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Favorite/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Favorite/5
        public void Delete(int id)
        {
        }
    }
}
