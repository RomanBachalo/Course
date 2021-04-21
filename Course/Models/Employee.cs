using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
            Supplies = new HashSet<Supply>();
            SupplyRealizations = new HashSet<SupplyRealization>();
        }

        public int EmployeeId { get; set; }
        public int? PositionId { get; set; }
        public int? FactoryId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
        public virtual ICollection<SupplyRealization> SupplyRealizations { get; set; }
    }
}
