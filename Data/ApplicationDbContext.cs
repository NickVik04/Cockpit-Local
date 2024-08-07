using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cockpit_Local.Models;
using Microsoft.EntityFrameworkCore;

namespace Cockpit_Local.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Brands> Brands { get; set; }
    }
}