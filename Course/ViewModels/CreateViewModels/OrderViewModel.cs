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
        public int FurnitureId { get; set; }
        public short FurnitureAmount { get; set; }
        public short FurnitureHeight { get; set; }
        public short FurnitureWidth { get; set; }
        public int MaterialId { get; set; }
        public short MaterialAmount { get; set; }
    }
}
