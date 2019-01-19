using EntityFrameworkCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<MachineEntity> Machines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here you can add foreign key and all other stuff to columns
            modelBuilder.Entity<AccountEntity>().ToTable("account");

            modelBuilder.Entity<MachineEntity>().ToTable("machine");

            base.OnModelCreating(modelBuilder);
        }
    }
}
