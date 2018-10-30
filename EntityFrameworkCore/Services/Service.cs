using EntityFrameworkCore.Data;
using EntityFrameworkCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Services
{
    public class Service : IService
    {
        protected ApplicationDbContext _context;

        public Service(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DoDbStuff()
        {
            // Make sure the database exists
            _context.Database.EnsureCreated();

            // If no sparters exists
            if (!_context.Machines.Any())
            {
                _context.Machines.Add(new MachineEntity
                {
                    Id = "machinenummer",
                    Active = true
                });

                // Should be 1, because we just added a Sparter locally
                int numberOfSpartersLocally = _context.Machines.Local.Count();

                // Should be 0, because we didn't commit to the DB yet
                int numberOfSpartersDatabase = _context.Machines.Count();

                // Commit to database
                _context.SaveChanges();

                // Should be 1, because it is still locally
                numberOfSpartersLocally = _context.Machines.Local.Count();

                // Should be 1, because we just committed
                numberOfSpartersDatabase = _context.Machines.Count();
            }
        }
    }
}
