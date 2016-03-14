using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LandScaping.Models
{
    public class LandScapingDBContext : DbContext
    {
        public LandScapingDBContext() : base("DefaultConnection")
        {
        }
        public DbSet<Client> client { get; set; }
        public DbSet<Services> services { get; set; }

        public DbSet<ProjectSheet> projects { get; set; }
    }
}
