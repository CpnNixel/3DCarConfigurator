using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DCarConfigurator.Models
{
    public class ConfigurationDetail
    {
        public Configuration Configuration { get; set; }
        public int ConfigurationId { get; set; }

        public int DetailId { get; set; }
        public Detail Detail { get; set; }
    }
}
