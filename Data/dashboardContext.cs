#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace dashboard.Data
{
    public class dashboardContext : DbContext
    {
        public dashboardContext (DbContextOptions<dashboardContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.dash> Movie { get; set; }
    }
}
