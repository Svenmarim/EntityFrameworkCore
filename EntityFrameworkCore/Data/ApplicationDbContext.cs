using EntityFrameworkCore.Data.Entities;
using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MachineEntity> Machine { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineEntity>().ToTable("machine");

            base.OnModelCreating(modelBuilder);
        }
    }
}
