using System;
using System.ComponentModel.DataAnnotations;

namespace _3DCarConfigurator.Models
{
    public class Detail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Detail name must be provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category must be provided")]
        public string Category { get; set; }

        [DataType(DataType.Currency)]
        public float DetailPrice { get; set; }

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
                DetailPrice = (int)price;
                return true;
            }
            return false;
        }
    }
}