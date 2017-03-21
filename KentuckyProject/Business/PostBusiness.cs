using KentuckyWebService.Models;
using KentuckyWebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Business
{
    public class PostBusiness
    {
        PostRepository postRepo = new PostRepository();

        public Post SelectPost(int id)
        {
            return postRepo.SelectOne(id);
        }

        public List<Post> GetPosts()
        {
            return postRepo.GetPosts();
        }

        public void CreatePost(Post post)
        {
            postRepo.CreatePost(post);
        }
    }
}