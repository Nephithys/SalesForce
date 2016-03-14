using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandScaping.Models
{
    public class ProjectSheet
    {
        public int ID { get; set; }
        public virtual Client client { get; set; }
        public virtual Services service { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public string Comments { get; set; }
    }
}