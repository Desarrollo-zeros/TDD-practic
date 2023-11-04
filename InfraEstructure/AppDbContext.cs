using Domain.Contract;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           //usuerio decir que username y email son unicos
            modelBuilder.Entity<User>()
                .HasIndex(user => user.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            modelBuilder.Entity<Person>()
                .HasIndex(person => new { person.DocumentType, person.Document })
                .IsUnique();


            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await base.SaveChangesAsync();
        }
    }
}
