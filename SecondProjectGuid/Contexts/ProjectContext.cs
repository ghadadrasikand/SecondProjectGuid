using Microsoft.EntityFrameworkCore;
using SecondProjectGuid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.Contexts
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<History> History { get; set; }
    }
}
