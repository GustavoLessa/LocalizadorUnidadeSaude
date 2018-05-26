namespace CodeHB.HealthUnitsPoa.Web.Models
{
    public class Route
    {
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }

        public double StartLat { get; set; }
        public double StartLong { get; set; }

        public double EndLat { get; set; }
        public double EndLong { get; set; }

    }
}
