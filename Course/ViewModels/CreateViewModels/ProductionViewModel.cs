using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class ProductionViewModel
    {
        public int? ProductionId { get; set; }
        public List<int> Employees { get; set; }
    }
}
