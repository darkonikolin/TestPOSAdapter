using System.Xml.Serialization;

namespace TestPOSAdapter.Model
{
    public class ModifiersDataModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }

        [XmlElement("Quantity")]
        public string Quantity { get; set; }
    }
}
