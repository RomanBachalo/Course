using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class City
    {
        public City()
        {
            Factories = new HashSet<Factory>();
            Suppliers = new HashSet<Supplier>();
        }

        public int CityId { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Factory> Factories { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
