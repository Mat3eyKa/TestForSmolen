using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;

namespace TestForSmol.Models
{
    [XmlSchemaProvider("PurchaseOrder")]
    public class PurchaseOrder
    {
        [XmlAttribute("PurchaseOrderNumber")]
        public int PurchaseOrderNumber { get; set; }

        [XmlAttribute("OrderDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string OrderDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        [XmlElement("Address")]
        public Address OrderAddress { get; set; } = new Address();

        [XmlElement("DeliveryNotes")]
        public string DeliveryNotes { get; set; } = string.Empty;

        [XmlElement("EstimatedDeliveryDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string EstimatedDeliveryDate { get; set; } =  DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        [XmlArray("Items")]
        public List<Item> Items { get; set; } = new List<Item>();
    }
}