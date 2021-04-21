using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class SuppliedMaterial
    {
        public SuppliedMaterial()
        {
            SupplyRealizations = new HashSet<SupplyRealization>();
        }

        public int SuppliedMaterialsId { get; set; }
        public int? MaterialColorId { get; set; }
        public int? SupplyId { get; set; }
        public short Amount { get; set; }
        public decimal SupplierPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual MaterialColor MaterialColor { get; set; }
        public virtual Supply Supply { get; set; }
        public virtual ICollection<SupplyRealization> SupplyRealizations { get; set; }
    }
}
