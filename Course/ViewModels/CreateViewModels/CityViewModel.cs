using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class CityViewModel
    {
        [JsonPropertyName("CityId")]
        public int? CityId { get; set; }
        [JsonPropertyName("CityName")]
        public string CityName { get; set; }
        [JsonPropertyName("RegionId")]
        public int RegionId { get; set; }
    }
}
