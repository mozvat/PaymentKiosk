using System;

using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PaymentKiosk.Logging
{
    public class DSIResponse
    {
        public string InvoiceNo { get; set; }
        public string MerchantID { get; set; }
        public string Amount { get; set; }
        public string AcctNo { get; set; }
        public string CmdStatus { get; set; }            
        public string RawData { get; set; }

        public DSIResponse(string rawData)
        {
            Parse(rawData);
        }

        private void Parse(string data)
        {
            XmlDocument xmlResponse = new XmlDocument();
            xmlResponse.LoadXml(data);
            XmlNodeList elemList;

            //RawData
            RawData = data;

            //MerchantID
            elemList = xmlResponse.GetElementsByTagName("MerchantID");
            MerchantID = elemList[0].InnerText;
            //INVOICENO
            elemList = xmlResponse.GetElementsByTagName("InvoiceNo");
            InvoiceNo = elemList[0].InnerText;
            //Amount
            elemList = xmlResponse.GetElementsByTagName("Purchase");
            Amount = elemList[0].InnerText;
            //TRUNCATEDACCTNO
            elemList = xmlResponse.GetElementsByTagName("AcctNo");
            AcctNo =  elemList[0].InnerText; ;
            //CmdStatus
            elemList = xmlResponse.GetElementsByTagName("CmdStatus");
            CmdStatus = elemList[0].InnerText; ;
        }
    }
}
