using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Furniture
    {
        public Furniture()
        {
            OrderedFurnitures = new HashSet<OrderedFurniture>();
        }

        public int FurnitureId { get; set; }
        public int? FurnitureSubtypeId { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual FurnitureSubtype FurnitureSubtype { get; set; }
        public virtual ICollection<OrderedFurniture> OrderedFurnitures { get; set; }
    }
}
