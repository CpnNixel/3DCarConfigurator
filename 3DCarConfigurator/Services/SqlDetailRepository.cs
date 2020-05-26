using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DCarConfigurator.Services
{
    public class SqlDetailRepository : IRepository<Detail>
    {
        private ApplicationDbContext _context;

        public SqlDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Detail GetDetail(int id)
        {
            return _context.Details.Find(id);
        }

        public bool Add(Detail item)
        {
            try
            {
                _context.Details.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Detail item)
        {
            try
            {
                Detail detail = Get(item.Id);
                if (detail != null)
                {
                    _context.Remove(detail);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Detail item)
        {
            throw new NotImplementedException();
        }

        public Detail Get(int id)
        {
            if (_context.Details.Count(x => x.Id == id) > 0)
            {
                return _context.Details.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public void Update(Car detail)
        {
            _context.Entry(detail).State = EntityState.Modified;
        }

        public IEnumerable<Detail> GetAll()
        {
            return _context.Details;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
