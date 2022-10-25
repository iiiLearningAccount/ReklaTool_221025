using ReklaTool.Utility;
using System.Text.Json;
using System.Xml.Serialization;

namespace ReklaTool.Models
{
    [XmlRoot(ElementName = "Request", Namespace = "")]
    public class RequestModel : XmlSerializerBase
    {
        [XmlElement(ElementName = "auftraggeber", IsNullable = true)]
        public string? Auftraggeber { get; set; }
        [XmlElement(ElementName = "kundennummer", IsNullable = true)]
        public string? Kundennummer { get; set; }
        [XmlElement(ElementName = "vorgangsnummer", IsNullable = true)]
        public string? Vorgangsnummer { get; set; }
        [XmlElement(ElementName = "dateiname", IsNullable = true)]
        public string? Dateiname { get; set; }
        [XmlElement(ElementName = "claimsGuard", IsNullable = true)]
        public ClaimsGuardTyp ClaimsGuard { get; set; }
        [XmlElement(ElementName = "schadennummer", IsNullable = true)]
        public string? Schadennummer { get; set; }
        public class ClaimsGuardTyp
        {
            [XmlElement(ElementName = "anwendbar")] public bool Anwendbar { get; set; } = false;
            [XmlElement(ElementName = "einzelpruefbericht")] public bool Einzelpruefbericht { get; set; } = false;
        }
        public RequestModel() => ClaimsGuard = new ClaimsGuardTyp();
        public override int GetHashCode()
        {
            string str = JsonSerializer.Serialize(this);
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length; i += 2)
            {
                hash1 = (hash1 << 5) + hash1 ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = (hash2 << 5) + hash2 ^ str[i + 1];
            }
            return hash1 + hash2 * 1566083941;
        }
    }
    
}
