using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class FurnitureInfo
    {
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; }
        public int FurnitureTypeId { get; set; }
        public string FurnitureTypeName { get; set; }
        public int FurnitureSubtypeId { get; set; }
        public string FurnitureSubtypeName { get; set; }
        public string FurnitureDescription { get; set; }
        public decimal FurnitureBasePrice { get; set; }
        public string FurnitureParameterName { get; set; }
        public string FurnitureParameterValue { get; set; }
    }
}
