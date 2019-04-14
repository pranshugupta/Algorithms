using System;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlDealings
{
    public static class XmlFormatter
    {
        private static string DataSetName;
        private static string TableName = string.Empty;
        public static void ReadDatasetAndTableName(XmlDocument document)
        {
            if (document != null)
            {
                if (document.DocumentElement != null)
                    DataSetName = document.DocumentElement.Name;
                if (document.DocumentElement.FirstChild != null)
                    TableName = document.DocumentElement.FirstChild.Name;
            }
        }

        public static void FormatXml()
        {
            string xmlString = CreateXml();
            XDocument xdocument = RemoveEmptyNodes(xmlString);
            RenameNodes(xdocument);
            AddAttribute(xdocument);
        }

        public static string CreateXml()
        {
            StringBuilder str = new StringBuilder();
            str = str.Append("<?xml version=\"1.0\" encoding=\"utf - 8\" ?> ");
            str = str.Append("<Rows>");
            for (int i = 0; i < 200; i++)
            {
                str = str.Append("<Row>");
                for (int j = 0; j < 20; j++)
                {
                    if (j % 4 == 0)
                    {
                        str.Append(string.Format("<Column{0}/>", j));
                    }
                    else
                    {
                        str.Append(string.Format("<Column{0}>", j));
                        str.Append("Column Value" + j);
                        str.Append(string.Format("</Column{0}>", j));
                    }
                }
                str = str.Append("</Row>");
            }
            str = str.Append("</Rows>");

            return str.ToString();
        }

        public static XDocument RemoveEmptyNodes(string xmlString)
        {
            XDocument xdocument = XDocument.Parse(xmlString);
            xdocument.Descendants()
                    .Where(element => element.IsEmpty || String.IsNullOrWhiteSpace(element.Value))
                    .Remove();

            return xdocument;
        }

        public static void RenameNodes(XDocument xdocument)
        {
            xdocument.Descendants()
                   .Where(element => string.Equals(element.Name.LocalName, "Rows"))
                   .ToList()
                   .ForEach(element => element.Name = "DatasetName");

            xdocument.Descendants()
                    .Where(element => string.Equals(element.Name.LocalName, "Row"))
                    .ToList()
                    .ForEach(element => element.Name = "TableName");
        }

        private static void AddAttribute(XDocument xdocument)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xdocument.ToString());

            XmlDeclaration xmldecl;
            xmldecl = xmlDocument.CreateXmlDeclaration("1.0", null, "yes");
            XmlNode rootNode = xmlDocument.DocumentElement;
            if (rootNode != null)
            {
                xmlDocument.InsertBefore(xmldecl, rootNode);

                XmlAttribute attr = xmlDocument.CreateAttribute("xmlns");
                attr.Value = "http://www.w3.org/1999/XSL/Transform";

                rootNode.Attributes.SetNamedItem(attr);
            }
        }
    }
}
