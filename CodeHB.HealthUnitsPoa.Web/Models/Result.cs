using System.Collections.Generic;

namespace CodeHB.HealthUnitsPoa.Web.Models
{
    public class Result
    {
        public string ResourceId { get; set; }
        public List<Field> Fields { get; set; }
        public List<Record> Records { get; set; }
        public Links Links { get; set; }
        public int Total { get; set; }
    }
}