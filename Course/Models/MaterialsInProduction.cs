using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class MaterialsInProduction
    {
        public int MaterialsInProductionId { get; set; }
        public int? ProductionId { get; set; }
        public int? MaterialsAtFactoryId { get; set; }
        public short Count { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual MaterialsAtFactory MaterialsAtFactory { get; set; }
        public virtual Production Production { get; set; }
    }
}
