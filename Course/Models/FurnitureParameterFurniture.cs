using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class FurnitureParameterFurniture
    {
        public int FurnitureParameterValueId { get; set; }
        public int? FurnitureId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Furniture Furniture { get; set; }
        public virtual FurnitureParameterValue FurnitureParameterValue { get; set; }
    }
}
