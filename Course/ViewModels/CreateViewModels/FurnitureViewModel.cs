using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class FurnitureViewModel
    {
        public int? FurnitureId { get; set; }
        public int FurnitureSubtype { get; set; }
        public string FurnitureName { get; set; }
        public decimal BasePrice { get; set; }
        public string Description { get; set; }
        public Dictionary<int,int> Parameters { get; set; }
    }
}
