using System.Xml.Serialization;

namespace TestForSmol.Models
{
    [XmlSchemaProvider("Address")]
    public class Address
    {
        [XmlAttribute("Type")]
        public string Type { get; set; } = string.Empty;

        [XmlElement("Name")]
        public string Name { get; set; } = string.Empty;

        [XmlElement("Country")]
        public string Country { get; set; } = string.Empty;

        [XmlElement("Region")]
        public string Region { get; set; } = string.Empty;

        [XmlElement("Street")]
        public string Street { get; set; } = string.Empty;

        [XmlElement("Zip")]
        public int Zip { get; set; }
    }
}
