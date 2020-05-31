using _3DCarConfigurator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace _3DCarConfigurator.Models
{
    public class CarConfigViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Configuration> Configs { get; set; }

        public List<Detail> Details { get; set; }

        public List<int> PickedDetails { get; set; }
       
    }
}
