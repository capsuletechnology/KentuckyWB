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
    public class PostController : ApiController
    {
        PostBusiness postBusiness = new PostBusiness();

        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return postBusiness.GetPosts();
        }

        // GET: api/Post/5
        [HttpGet]
        public Post Get(int id)
        {   
            return postBusiness.SelectPost(id);
        }
        
        [HttpPost]
        public void Post(Post post)
        {
            postBusiness.CreatePost(post);
        }

        // PUT: api/Post/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Post/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
