using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _3DCarConfigurator.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Car name must be provided")]
        public string Name { get; set; }
        public int CurrentConfigurationId { get; set; }
        public string PathToModel { get; set; }
        [DataType(DataType.Currency)]
        public float CarPrice { get; set; }
        public List<Configuration> AvailableForBuyingConfigs { get; set; }

        public string Description { get; set; }


        public bool AddConfig(Configuration configuration)
        {
            if (configuration != null && configuration.Id != CurrentConfigurationId)
            {
                CurrentConfigurationId = configuration.Id;
                return true;
            }
            return false;
        }

        public bool DeleteConfig(int? id)
        {
            if (id != null && id >= 0)
            {
                AvailableForBuyingConfigs = AvailableForBuyingConfigs.Where(x => x.Id != id).ToList();
                return true;
            }
            return false;
        }

    }
}
