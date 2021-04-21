using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class ProductionInfo
    {
        public int ProductionId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; }
        public int FurnitureAmount { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int MaterialAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
