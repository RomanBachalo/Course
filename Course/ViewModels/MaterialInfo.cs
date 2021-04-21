using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class MaterialInfo
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public int MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal MaterialPrice { get; set; }
    }
}
