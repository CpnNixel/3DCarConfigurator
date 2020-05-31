using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3DCarConfigurator.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        //public Car CarModel { get; set; }
        //[Required(ErrorMessage ="Car Id must be provided")]
        public int CarId { get; set; }
        public List<Detail> Details { get; set; }
        public string DetailsString { get; set; }

    }
}
