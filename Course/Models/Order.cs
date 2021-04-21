using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderedFurnitures = new HashSet<OrderedFurniture>();
        }

        public int OrderId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderedFurniture> OrderedFurnitures { get; set; }
    }
}
