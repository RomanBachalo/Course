using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class FactoryViewModel
    {
        public int? FactoryId { get; set; }
        public int CityId { get; set; }
        public string FactoryName { get; set; }
        public string Address { get; set; }
    }
}
