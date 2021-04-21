using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class ProductionEmployee
    {
        public int? ProductionId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Production Production { get; set; }
    }
}
