using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class SupplyViewModel
    {
        public int? SupplyId { get; set; }
        public int SupplierId { get; set; }
        public int EmployeeId { get; set; }
        public Dictionary<int, int> SuppliedMaterials { get; set; }
    }
}
