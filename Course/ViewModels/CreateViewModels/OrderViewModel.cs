using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class OrderViewModel
    {
        public int? OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Dictionary<int, int> OrderedFurniture { get; set; }
        public Dictionary<int, int> OrderedMaterials { get; set; }
    }
}
