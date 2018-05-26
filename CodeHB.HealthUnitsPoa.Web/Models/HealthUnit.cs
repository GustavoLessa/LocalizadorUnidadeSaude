using Newtonsoft.Json;

namespace CodeHB.HealthUnitsPoa.Web.Models
{
    public class HealthUnit
    {
        [JsonProperty(PropertyName = "help")]
        public string Help { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "result")]
        public Result Result { get; set; }
    }
}