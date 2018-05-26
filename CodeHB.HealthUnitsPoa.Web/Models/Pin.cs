namespace CodeHB.HealthUnitsPoa.Web.Models
{
    public class Pin
    {
        public Pin(Record unit)
        {
            Name = unit.Nome;
            Phone = unit.Telefone;
            Address = unit.Endereco;
            Latitude = unit.Latitude;
            Longitude = unit.Longitude;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}