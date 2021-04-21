using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public int RegionId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
