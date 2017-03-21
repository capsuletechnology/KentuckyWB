using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Models
{
    public class Post
    {
        public int PostID { get; set; }        
        public string Text { get; set; }
        public string Color { get; set; }
        public User User { get; set; }
        public List<Report> Reports { get; set; }
        public List<Like> Likes { get; set; }
        public List<Favorite> Favorites { get; set; }

    }
}