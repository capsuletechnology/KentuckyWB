﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
        public int PostUserID { get; set; }
    }
}