using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Supplies = new HashSet<Supply>();
        }

        public int SupplierId { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
