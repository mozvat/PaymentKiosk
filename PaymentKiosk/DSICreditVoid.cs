using System;
using System.Text;
using PaymentKiosk.Configurations;
using System.Xml; 

namespace PaymentKiosk.Transactions
{
    public static class DSICreditVoid
    {
        public static StringBuilder GenerateXML(string response)
        {
            XmlDocument xmlResponse = new XmlDocument();
            xmlResponse.LoadXml(response);
            //AUTHCODE
            XmlNodeList elemList = xmlResponse.GetElementsByTagName("AuthCode");
            string authCode = elemList[0].InnerText;
            //INVOICENO
            elemList = xmlResponse.GetElementsByTagName("InvoiceNo");
            string invoiceNo = elemList[0].InnerText;
            //REFNO
            elemList = xmlResponse.GetElementsByTagName("RefNo");
            string refNo = elemList[0].InnerText;
            //TRUNCATEDACCTNO
            elemList = xmlResponse.GetElementsByTagName("AcctNo");
            string truncatedAcctNo = elemList[0].InnerText; ;
            //TruncatedExpDate
            elemList = xmlResponse.GetElementsByTagName("ExpDate");
            string truncatedExpDate = elemList[0].InnerText; 
            //TOKEN
            elemList = xmlResponse.GetElementsByTagName("RecordNo");
            string token = elemList[0].InnerText;
            //AMOUNT
            elemList = xmlResponse.GetElementsByTagName("Purchase");
            string purchase = elemList[0].InnerText;
            //MerchantID
            elemList = xmlResponse.GetElementsByTagName("MerchantID");
            string merchantID = elemList[0].InnerText;

            StringBuilder builder = new StringBuilder();
 
            builder.Append("<?xml version=\"" + "1.0\"?>");
            builder.Append("<TStream>");
            builder.Append("<Transaction>");
            builder.Append("<MerchantID>" + merchantID + "</MerchantID>");
            builder.Append("<TranType>Credit</TranType>");
            builder.Append("<TranCode>VoidSaleByRecordNo</TranCode>");
            builder.Append("<InvoiceNo>" + invoiceNo + "</InvoiceNo>"); //sequential receipt number, check number, or other unique transaction identifier 
            builder.Append("<RefNo>" + refNo + "</RefNo>"); //value returned in the original Sale transaction response.
            builder.Append("<RecordNo>" + token + "</RecordNo>");  //value returned in any of the following:the original credit Sale; PreAuth or Adjust by Record transaction. The Token...
            builder.Append("<Account>");
            builder.Append("<AcctNo>" + truncatedAcctNo + "</AcctNo>");
            builder.Append("<ExpDate>" + truncatedExpDate + "</ExpDate>");
            builder.Append("<Frequency>OneTime</Frequency>");
            builder.Append("</Account>");
            builder.Append("<Amount>");
            builder.Append("<Purchase>" + purchase + "</Purchase>"); 
            builder.Append("</Amount>");
            builder.Append("<TranInfo>");
            builder.Append("<AuthCode>" + authCode + "</AuthCode>");  //AUTHCODE value returned in the original Sale transaction response
            builder.Append("</TranInfo>");
            builder.Append("</Transaction>");
            builder.Append("</TStream>");
            return builder;
        }
    }
}
