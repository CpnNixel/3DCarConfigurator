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

        public ApplicationDbContext context { get; set; }
        public string configLine { get; set; }
        public static List<int> elems = new List<int>() { 1, 2 };
        [BindProperty]
        public int selected { get; set; }
        public SelectList listSel = new SelectList(elems);
    }
}
