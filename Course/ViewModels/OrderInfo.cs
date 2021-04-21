using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; }
        public double FurnitureHeight { get; set; }
        public double FurnitureWidth { get; set; }
        public decimal SizeSurchase { get; set; }
        public int FurnitureAmount { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int MaterialAmount { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime EndDate { get; set; }
    }
}
