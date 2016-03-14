using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandScaping.Models
{
    public class Client
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int AreaCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserID { get; set; }
    }
}