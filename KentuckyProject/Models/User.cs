using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Rating { get; set; }
        public Login Login { get; set; }


    }
}