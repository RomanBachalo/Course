using Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class FactoryInfo
    {
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
