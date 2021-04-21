using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class FurnitureParameterValue
    {
        public int FurnitureParameterValueId { get; set; }
        public int? FurnitureParameterId { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual FurnitureParameter FurnitureParameter { get; set; }
    }
}
