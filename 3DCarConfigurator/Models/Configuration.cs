﻿using System.Collections.Generic;

namespace _3DCarConfigurator.Models
{
    public class Configuration
    {
        public int Id { get; set; }

        //public Car CarModel { get; set; }
        //[Required(ErrorMessage ="Car Id must be provided")]
        public int CarId { get; set; }

        public string PathToPicture { get; set; }

        public List<Detail> Details { get; set; }
        public string DetailsString { get; set; }
    }
}