using Newtonsoft.Json;

namespace CodeHB.HealthUnitsPoa.Web.Models
{
    public class Links
    {
        [JsonProperty(PropertyName = "start")]
        public string Start { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }
    }
}