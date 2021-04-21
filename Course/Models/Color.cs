using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Color
    {
        public Color()
        {
            MaterialColors = new HashSet<MaterialColor>();
        }

        public int ColorId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<MaterialColor> MaterialColors { get; set; }
    }
}
