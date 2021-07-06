using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<User> Users  { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Supplier>()

                .Property(c => c.CountryId)

                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            modelBuilder.Entity<Country>()

                .Property(c=>c.CountryId)

                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<KindsOfSupplier>()

                .Property(k=>k.KindsOfSupplierId)

                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<User>()

                .Property(c => c.UserId)

                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}