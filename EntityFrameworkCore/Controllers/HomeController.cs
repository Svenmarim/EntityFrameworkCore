using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Data.Entities;

namespace EntityFrameworkCore.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Make sure the database exists
            _context.Database.EnsureCreated();

            // If no sparters exists
            if (!_context.Machine.Any())
            {
                _context.Machine.Add(new MachineEntity
                {
                    Id = "machinenummer",
                    Active = true
                });

                // Should be 1, because we just added a Sparter locally
                int numberOfSpartersLocally = _context.Machine.Local.Count();

                // Should be 0, because we didn't commit to the DB yet
                int numberOfSpartersDatabase = _context.Machine.Count();

                // Commit to database
                _context.SaveChanges();

                // Should be 1, because it is still locally
                numberOfSpartersLocally = _context.Machine.Local.Count();

                // Should be 1, because we just committed
                numberOfSpartersDatabase = _context.Machine.Count();
            }

            return View();
        }
    }
}
