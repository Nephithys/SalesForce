using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandScaping.Models
{
    public class Jobs
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public virtual Client client { get; set; }
        public string Service { get; set; }
        public double Rate { get; set; }
        public double Acre { get; set; }
        public double TotalCost { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public string Comments { get; set; }
    }
}