using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class OrderedFurnitureMaterial
    {
        public int OrderedFurnitureId { get; set; }
        public int OrderedMaterialsId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
