using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Models
{
    public class Favorite
    {
        public int Favoriteid { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
        public int postUserid { get; set; }
    }
}