using System.Xml.Serialization;

namespace TestForSmol.Models
{
    [XmlSchemaProvider("Item")]
    public class Item
    {
        [XmlAttribute("PartNumber")]
        public string PartNumber { get; set; }

        [XmlElement("ProductName")]
        public string ProductName { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        [XmlElement("Price")]
        public double Price { get; set; }
    }
}
