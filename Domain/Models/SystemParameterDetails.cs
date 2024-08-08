using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class SystemParameterDetails
    {
        public long Id {  get; set; }
        public long SystemParameterId {  get; set; }
        public string Description {  get; set; }
        public string Value { get; set; }

        [JsonIgnore] // Ignorar esta propiedad para evitar ciclos
        public SystemParameter SystemParameter { get; set; }

    }
}
