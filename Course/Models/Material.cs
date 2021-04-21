using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Material
    {
        public Material()
        {
            MaterialColors = new HashSet<MaterialColor>();
        }

        public int MaterialId { get; set; }
        public int? MaterialTypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual MaterialType MaterialType { get; set; }
        public virtual ICollection<MaterialColor> MaterialColors { get; set; }
    }
}
