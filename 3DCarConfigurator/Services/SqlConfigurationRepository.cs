using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DCarConfigurator.Services
{
    public class SqlConfigurationRepository : IRepository<Configuration>
    {
        private ApplicationDbContext _context;

        public SqlConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Configuration item)
        {
            try
            {
                _context.Configurations.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(Configuration item)
        {
            try
            {
                Configuration configuration = Get(item.Id);
                if (configuration != null)
                {
                    _context.Remove(configuration);
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

        public bool Edit(Configuration item)
        {
            throw new NotImplementedException();
        }

        public Configuration Get(int id)
        {
            if (_context.Configurations.Count(x => x.Id == id) > 0)
            {
                return _context.Configurations.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Configuration> GetAll()
        {
            return _context.Configurations;
        }

        public void Update(Configuration  configuration)
        {
            _context.Entry(configuration).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
