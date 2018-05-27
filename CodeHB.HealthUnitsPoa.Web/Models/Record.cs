using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CodeHB.HealthUnitsPoa.Web.Models
{
    public class Record
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Emergência")]
        [JsonProperty(PropertyName = "Tipo Emergкncia")]
        public string TipoEmergencia { get; set; }

        [Display(Name = "Tipo Instituição")]
        [JsonProperty(PropertyName = "Tipo Instituiзгo")]
        public string TipoInstitucao { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Endereço")]
        [JsonProperty(PropertyName = "Endereзo")]
        public string Endereco { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [Display(Name = "Site")]
        [JsonProperty(PropertyName = "Link pt")]
        public string LinkPt { get; set; }

        [JsonProperty(PropertyName = "Link en")]
        public string LinkEn { get; set; }

        [JsonProperty(PropertyName = "Link es")]
        public string LinkEs { get; set; }

        [Display(Name = "Especialidades")]
        [JsonProperty(PropertyName = "Especialidades pt")]
        public string EspecialidadePt { get; set; }

        [JsonProperty(PropertyName = "Especialidades en")]
        public string EspecialidadeEn { get; set; }

        [JsonProperty(PropertyName = "Especialidades es")]
        public string EspecialidadesEs { get; set; }

        [JsonIgnore]
        [Display(Name = "Distância")]
        public double Distance { get; set; }
    }

}