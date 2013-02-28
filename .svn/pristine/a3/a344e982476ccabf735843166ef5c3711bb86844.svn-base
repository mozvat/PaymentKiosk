using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PaymentKiosk.Transaction.Utilities
{
    public static class Response
    {
        public static bool Approved(string xml)
        {
            //TODO: ensure the invoice num is incremented to avoid AP*
            bool approved = false;

            if (xml.Contains("Approved"))
            {
                approved = true;
            }
            return approved;
        }


        private static bool ContainsXMLNodes(XmlNodeList nodeList)
        {
            bool hasNodes = false;
            if (nodeList.Count > 0)
            {
                hasNodes = true;
            }
            return hasNodes;
        }

        public static string SanitizeXMLResults(string xml)
        {
            string sanitizedData = string.Empty;
            XmlDocument xmlResponse = new XmlDocument();
            XmlNode node;
            XmlNodeList nodelist;

            xmlResponse.LoadXml(xml);
            //RecordNo
            nodelist = xmlResponse.GetElementsByTagName("RecordNo");
            if (ContainsXMLNodes(nodelist))
            {
                node = xmlResponse.GetElementsByTagName("RecordNo")[0];
                node.ParentNode.RemoveChild(node);
            }
            //ExpDate
            nodelist = xmlResponse.GetElementsByTagName("ExpDate");
            if (nodelist.Count > 0)
            {
                node = xmlResponse.GetElementsByTagName("ExpDate")[0];
                node.ParentNode.RemoveChild(node);
            }
            //REFNO
            nodelist = xmlResponse.GetElementsByTagName("RefNo");
            if (nodelist.Count > 0)
            {
                node = xmlResponse.GetElementsByTagName("RefNo")[0];
                node.ParentNode.RemoveChild(node);
            }

            //AcqRefData
            nodelist = xmlResponse.GetElementsByTagName("AcqRefData");
            if (nodelist.Count > 0)
            {
                node = xmlResponse.GetElementsByTagName("AcqRefData")[0];
                node.ParentNode.RemoveChild(node);
            }

            //ProcessData
            nodelist = xmlResponse.GetElementsByTagName("ProcessData");
            if (nodelist.Count > 0)
            {
                node = xmlResponse.GetElementsByTagName("ProcessData")[0];
                node.ParentNode.RemoveChild(node);
            }

            return xmlResponse.InnerXml.ToString();

        }

        public static bool Sanitize(string xml)
        {
            //TODO: ensure the invoice num is incremented to avoid AP*
            bool approved = false;

            if (xml.Contains("Approved"))
            {
                approved = true;
            }
            return approved;
        }

        
    }
}
