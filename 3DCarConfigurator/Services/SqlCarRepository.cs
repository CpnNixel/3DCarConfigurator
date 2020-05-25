using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace _3DCarConfigurator.Services
{
    public class SqlCarRepository : IRepository<Car>
    {
        private ApplicationDbContext _context;

        public SqlCarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Car item)
        {
            try
            {
                _context.Cars.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Car item)
        {
            try
            {
                Car car = Get(item.Id);
                if (car != null)
                {
                    _context.Remove(car);
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

        public bool Edit(Car item)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            if(_context.Cars.Count(x=> x.Id == id) > 0)
            {
                return _context.Cars.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars;
        }
    }
}
