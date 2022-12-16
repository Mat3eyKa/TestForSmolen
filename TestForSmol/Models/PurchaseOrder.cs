using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string OrderDate { get; set; }

        [XmlElement("Address")]
        public Address OrderAddress { get; set; }

        [XmlElement("DeliveryNotes")]
        public string DeliveryNotes { get; set; }

        [XmlElement("EstimatedDeliveryDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string EstimatedDeliveryDate { get; set; }

        [XmlArray("Items")]
        public List<Item> Items { get; set; }
    }
}