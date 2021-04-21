using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class SupplyInfo
    {
        public int SupplyId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }
        public int MaterialAmount { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime EndDate { get; set; }
    }
}
