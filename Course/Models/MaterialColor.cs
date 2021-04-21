using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class MaterialColor
    {
        public MaterialColor()
        {
            MaterialsAtFactories = new HashSet<MaterialsAtFactory>();
            OrderedMaterials = new HashSet<OrderedMaterial>();
            SuppliedMaterials = new HashSet<SuppliedMaterial>();
        }

        public int MaterialColorId { get; set; }
        public int? MaterialId { get; set; }
        public int? ColorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Color Color { get; set; }
        public virtual Material Material { get; set; }
        public virtual ICollection<MaterialsAtFactory> MaterialsAtFactories { get; set; }
        public virtual ICollection<OrderedMaterial> OrderedMaterials { get; set; }
        public virtual ICollection<SuppliedMaterial> SuppliedMaterials { get; set; }
    }
}
