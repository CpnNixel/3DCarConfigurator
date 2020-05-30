using System.Collections.Generic;

namespace _3DCarConfigurator.Models
{
    public class CarConfigViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Configuration> Configs { get; set; }
    }
}
