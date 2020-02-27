using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPOSAdapter.Model
{
    public class ItemDataModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }

        [XmlElement("Quantity")]
        public string Quantity { get; set; }

        [XmlElement("Modifiers")]
        public List<ModifiersDataModel> Modifiers { get; set; }
    }
}
