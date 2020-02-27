using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using TestPOSAdapter.Logger;
using TestPOSAdapter.Model;

namespace TestPOSAdapter.Action
{
    class DataProcessing
    {
        /// <summary>
        /// UI Logger object.
        /// </summary>
        LoggerUI loggerUI = null;

        /// <summary>
        /// Initializes a new instance of DataProcessing class.
        /// </summary>
        public DataProcessing()
        {
            loggerUI = new LoggerUI();
        }

        /// <summary>
        /// Main method for processing Data
        /// </summary>
        /// <param name="Path">XML file path</param>
        public void Process(string Path)
        {
            if (!File.Exists(Path))
            {
                MessageBox.Show($"File {Path} does not exist.!", "DataProcessing");
                return;
            }

            string formattedString = FormatXml(@"C:\zadatak\zadatak.xml");
            if (formattedString == string.Empty) return;
            else loggerUI.LogMessage(formattedString, UIModelView.XML);

            OrderDataModel order = DeserializeXml(@"C:\zadatak\zadatak.xml");
            CalculateTotalValue(order);
            loggerUI.LogMessage(ToJSON(order), UIModelView.JSON);
            loggerUI.LogMessage(ToJSON(order, "Burger"), UIModelView.Filter);
        }

        /// <summary>
        /// Deserialize XML from patch to Order object.
        /// </summary>
        /// <param name="Path">XML file path for deserialize.</param>
        /// <returns>Order object</returns>
        private OrderDataModel DeserializeXml(string Path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OrderDataModel));
                StreamReader reader = new StreamReader(Path);
                return (OrderDataModel)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while deserializing XML file.", "DataProcessing");
                return new OrderDataModel();
            }
        }

        /// <summary>
        /// Formating XML file for UI preview
        /// </summary>
        /// <param name="Path">XML file path</param>
        /// <returns>Formatted XML string for UI preview</returns>
        private string FormatXml(string Path)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(Path);
                var stringBuilder = new StringBuilder();
                var xmlWriterSettings = new XmlWriterSettings
                { Indent = true, OmitXmlDeclaration = true };
                doc.Save(XmlWriter.Create(stringBuilder, xmlWriterSettings));
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while formating XML file.", "DataProcessing");
                return "";
            }
        }

        /// <summary>
        /// Method for calculating total Order value.
        /// </summary>
        /// <param name="order">Order object</param>
        private void CalculateTotalValue(OrderDataModel order)
        {
            if (order.Item == null) return;
            order.Total = (order.Item.Sum(x => Convert.ToDecimal(x.Price) * Convert.ToDecimal(x.Quantity)) 
                + order.Item.Select(x => x.Modifiers).Select(y => y.Sum(t => Convert.ToDecimal(t.Price) * Convert.ToDecimal(t.Quantity))).Sum()).ToString();
        }

        /// <summary>
        /// Serialize Order Object to Json format.
        /// </summary>
        /// <param name="order">Order object</param>
        /// <returns>Formatted Json string for UI preview</returns>
        private string ToJSON(OrderDataModel order)
        {
            try
            {
                string json = JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while serializing JSON object.", "DataProcessing");
                return "";
            }
        }

        /// <summary>
        /// Serialize filtered Order Object to Json format.
        /// </summary>
        /// <param name="order">Order object</param>
        /// <param name="filter">Filtered Name of Item</param>
        /// <returns></returns>
        private string ToJSON(OrderDataModel order, string filter)
        {
            try
            {
                string json = JsonConvert.SerializeObject(order.Item.Where(x => x.Name.Equals(filter)), Newtonsoft.Json.Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while serializing filtered JSON object.", "DataProcessing");
                return "";
            }
        }
    }
}
