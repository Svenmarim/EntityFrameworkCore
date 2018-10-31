using EntityFrameworkCore.Data;
using EntityFrameworkCore.Data.Entities;
using EntityFrameworkCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected ApplicationDbContext _context;

        public Service(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void TestDb()
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
