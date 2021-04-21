using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Production
    {
        public Production()
        {
            MaterialsInProductions = new HashSet<MaterialsInProduction>();
        }

        public int ProductionId { get; set; }
        public int? OrderedFurnitureId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual OrderedFurniture OrderedFurniture { get; set; }
        public virtual ICollection<MaterialsInProduction> MaterialsInProductions { get; set; }
    }
}
