using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class FurnitureType
    {
        public FurnitureType()
        {
            FurnitureSubtypes = new HashSet<FurnitureSubtype>();
        }

        public int FurnitureTypeId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<FurnitureSubtype> FurnitureSubtypes { get; set; }
    }
}
