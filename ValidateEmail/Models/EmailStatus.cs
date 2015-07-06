using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidateEmail.Models
{
    public class EmailStatus
    {
        public string address { get; set;}
        public string account { get; set;}
        public string domain { get; set;}
        public string status { get; set;}
        public string error_code { get; set;}
        public string error { get; set;}
        public bool disposable { get; set;}
        public bool role_address { get; set;}
        public decimal duration { get; set;}
    }
}