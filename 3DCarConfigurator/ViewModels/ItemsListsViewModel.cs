using _3DCarConfigurator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace _3DCarConfigurator.ViewModels
{
    public class ItemsListsViewModel
    {
/*
        public IEnumerable<Car> CarList { get; set; }
        public IEnumerable<Detail> DetailsList { get; set; }
        public IEnumerable<Configuration> ConfigurationsList { get; set; }
*//*
        public SelectList carList { get;set;}
        public SelectList detailsList { get;set;}
        public SelectList configurationsList { get;set;}
*/
        public int CarSelected { get; set; }
        public int DetailSelected { get; set; }
        public int ConfigurationSelected { get; set; }
}
}