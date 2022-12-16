using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestForSmol.Models
{
    [XmlRoot("PurchaseOrders")]
    public class AllPurchaseOrders
    {
        [XmlElement("PurchaseOrder")]
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
