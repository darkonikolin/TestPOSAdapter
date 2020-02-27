using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPOSAdapter.Model
{
    [Serializable()]
    [XmlRoot("Order")]
    public class OrderDataModel
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Total")]
        public string Total { get; set; }

        [XmlElement("Item")]
        public List<ItemDataModel> Item { get; set; }
    }
}
