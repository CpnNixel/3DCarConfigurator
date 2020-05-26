using System;
using System.ComponentModel.DataAnnotations;

namespace _3DCarConfigurator.Models
{
    public class Detail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Detail name must be provided")]
        public string Name { get; private set; }
        [Required(ErrorMessage = "Category must be provided")]
        public string Category { get; set; }
        public int Price { get ; set; }

        public bool ChangeName(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                Name = name;
                return true;
            }
            return false;
        }

        public bool ChangePrice(int? price)
        {
            if (price != null && price >= 0)
            {
                Price = (int)price;
                return true;
            }
            return false;
        }
    }
}