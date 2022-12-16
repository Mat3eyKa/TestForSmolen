using System.Xml.Serialization;

namespace TestForSmol.Models
{
    [XmlSchemaProvider("Address")]
    public class Address
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Country")]
        public string Country { get; set; }

        [XmlElement("Region")]
        public string Region { get; set; }

        [XmlElement("Street")]
        public string Street { get; set; }

        [XmlElement("Zip")]
        public int Zip { get; set; }
    }
}
