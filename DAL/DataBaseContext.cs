using Microsoft.EntityFrameworkCore;
using WebApi_Jueves_2024II.DAL.Entities;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace WebApi_Jueves_2024II.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }
        #endregion
    }
}
