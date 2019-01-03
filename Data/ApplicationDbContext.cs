using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dietcore.Models;

namespace Dietcore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dietcore.Models.Dietitian> Dietitian { get; set; }
        public DbSet<Dietcore.Models.Customer> Customer { get; set; }
    }
}
