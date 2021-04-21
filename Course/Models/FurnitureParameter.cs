using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class FurnitureParameter
    {
        public FurnitureParameter()
        {
            FurnitureParameterValues = new HashSet<FurnitureParameterValue>();
        }

        public int FurnitureParameterId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<FurnitureParameterValue> FurnitureParameterValues { get; set; }
    }
}
