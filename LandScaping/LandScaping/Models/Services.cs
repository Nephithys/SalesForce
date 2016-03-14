using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandScaping.Models
{
    public class Services
    {
        public int ID { get; set; }

        public string Service { get; set; }
        public double Rate { get; set; }
        public double Acre { get; set; }
        public double TotalCost { get; set; }
    }
}