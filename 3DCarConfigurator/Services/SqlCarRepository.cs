using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool Edit(Car car)
        {
         var temp = _context.Cars
                        .Where(x => x.Id == car.Id)
                        .FirstOrDefault();
            if(temp == null)
            {
                return false;
            }
            temp.Name = car.Name;
            temp.CarPrice = car.CarPrice;
            temp.CurrentConfigurationId = car.CurrentConfigurationId;
            temp.PathToModel = car.PathToModel;
            temp.AvailableForBuyingConfigs = car.AvailableForBuyingConfigs;

            _context.SaveChanges();
            return true;
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
        
        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
        }

        public bool UpdateFull(Car car)
        {
            var temp = _context.Cars
                        .Where(x => x.Id == car.Id)
                        .FirstOrDefault();
            if(temp == null)
            {
                return false;
            }
            temp.Name = car.Name;
            temp.CarPrice = car.CarPrice;
            temp.CurrentConfigurationId = car.CurrentConfigurationId;
            temp.PathToModel = car.PathToModel;
            temp.AvailableForBuyingConfigs = car.AvailableForBuyingConfigs;

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
