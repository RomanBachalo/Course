using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class SupplyRealization
    {
        public int SupplyRealizationId { get; set; }
        public int? SuppliedMaterialsId { get; set; }
        public int? MaterialsAtFactoryId { get; set; }
        public int? EmployeeId { get; set; }
        public short Count { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual MaterialsAtFactory MaterialsAtFactory { get; set; }
        public virtual SuppliedMaterial SuppliedMaterials { get; set; }
    }
}
