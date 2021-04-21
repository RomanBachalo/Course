using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class OrderedFurniture
    {
        public OrderedFurniture()
        {
            OrderedMaterials = new HashSet<OrderedMaterial>();
            Productions = new HashSet<Production>();
        }

        public int OrderedFurnitureId { get; set; }
        public int OrderId { get; set; }
        public int FurnitureId { get; set; }
        public short Amount { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public decimal SizeSurchase { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Furniture Furniture { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<OrderedMaterial> OrderedMaterials { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
    }
}
