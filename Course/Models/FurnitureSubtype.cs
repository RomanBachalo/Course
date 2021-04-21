using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class FurnitureSubtype
    {
        public FurnitureSubtype()
        {
            Furnitures = new HashSet<Furniture>();
        }

        public int FurnitureSubtypeId { get; set; }
        public int? FurnitureTypeId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual FurnitureType FurnitureType { get; set; }
        public virtual ICollection<Furniture> Furnitures { get; set; }
    }
}
