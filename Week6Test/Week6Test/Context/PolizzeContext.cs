using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Test.Models;

namespace Week6Test.Context
{
    public class PolizzeContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }

        public PolizzeContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; 
                                    Integrated Security = true; 
                                    Initial Catalog = Polizze; 
                                    Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Policy>(new PolicyConfiguration());

        }
    }
}
