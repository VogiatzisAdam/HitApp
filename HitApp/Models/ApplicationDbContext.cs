using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HitApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(): base("DefaultConnection")
        {
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Country> Countries  { get; set; }
        public DbSet<KindsOfSupplier> KindsOfSuppliers  { get; set; }
    }
}