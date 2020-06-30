using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Binder.Application.Entities.DbEntities
{
    public class BinderDbContext : DbContext
    {
        public BinderDbContext(DbContextOptions<BinderDbContext> options) : base(options)
        {
            
        }

        public BinderDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Binder;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbEntity>().HasIndex(x => x.NickName).IsUnique();
            modelBuilder.Entity<UserDbEntity>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<UserDbEntity>().HasIndex(x => x.UserName).IsUnique();

        }

        public DbSet<UserDbEntity> Users { get; set; }
        public DbSet<CountryDbEntity> Countries { get; set; }
        public DbSet<CitiesDbEntity> Cities { get; set; }
        public DbSet<StatesDbEntity> States { get; set; }
    }
}
