using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Supply
    {
        public Supply()
        {
            SuppliedMaterials = new HashSet<SuppliedMaterial>();
        }

        public int SupplyId { get; set; }
        public int? SupplierId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<SuppliedMaterial> SuppliedMaterials { get; set; }
    }
}
