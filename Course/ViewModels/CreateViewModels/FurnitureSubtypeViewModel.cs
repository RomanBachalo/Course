using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class FurnitureSubtypeViewModel
    {
        public int? FurnitureSubtypeId { get; set; }
        public int FurnitureTypeId { get; set; }
        public string FurnitureSubtypeName { get; set; }
    }
}
