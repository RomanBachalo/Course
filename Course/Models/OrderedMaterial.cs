using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class OrderedMaterial
    {
        public int OrderedMaterialsId { get; set; }
        public int MaterialColorId { get; set; }
        public int? OrderedFurnitureId { get; set; }
        public short Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual MaterialColor MaterialColor { get; set; }
        public virtual OrderedFurniture OrderedFurniture { get; set; }
    }
}
