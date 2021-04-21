using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class MaterialsAtFactory
    {
        public MaterialsAtFactory()
        {
            MaterialsInProductions = new HashSet<MaterialsInProduction>();
            SupplyRealizations = new HashSet<SupplyRealization>();
        }

        public int MaterialsAtFactoryId { get; set; }
        public int? FactoryId { get; set; }
        public int? MaterialColorId { get; set; }
        public short Count { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual MaterialColor MaterialColor { get; set; }
        public virtual ICollection<MaterialsInProduction> MaterialsInProductions { get; set; }
        public virtual ICollection<SupplyRealization> SupplyRealizations { get; set; }
    }
}
