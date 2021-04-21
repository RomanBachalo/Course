using System;
using System.Collections.Generic;

#nullable disable

namespace Course.Models
{
    public partial class Factory
    {
        public Factory()
        {
            Employees = new HashSet<Employee>();
            MaterialsAtFactories = new HashSet<MaterialsAtFactory>();
        }

        public int FactoryId { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<MaterialsAtFactory> MaterialsAtFactories { get; set; }
    }
}
