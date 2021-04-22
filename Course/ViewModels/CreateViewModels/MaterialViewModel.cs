using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class MaterialViewModel
    {
        public int? MaterialId { get; set; }
        public int MaterialTypeId { get; set; }
        public int ColorId { get; set; }
        public string MaterialName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
