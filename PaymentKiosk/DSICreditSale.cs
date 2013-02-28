using System;
using System.Text;
using PaymentKiosk.Configurations;
using PaymentKiosk.Transactions.Utilities;
using System.Xml;

namespace PaymentKiosk.Transactions 
{
    public static class DSIBatchSummary
    {
        public static StringBuilder GenerateXML()
        {
            string terminalID = TerminalIDConfig.GetConfig().ToString();
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"" + "1.0\"?>");
            builder.Append("<TStream>");
            builder.Append("<Admin>");
            builder.Append("<MerchantID>334160</MerchantID>");
            builder.Append("<TranCode>BatchSummary</TranCode>");
            builder.Append("</Admin>");
            builder.Append("</TStream>");
            return builder;
        }
    }
    public static class DSIBatchClose
    {
        public static StringBuilder GenerateXML(string trackData)
        {
            string amount = PricingConfig.GetConfig();
            string terminalID = TerminalIDConfig.GetConfig().ToString();
            string[] valueArray = trackData.Split('|');
            StringBuilder builder = new StringBuilder();



            builder.Append("<?xml version=\"" + "1.0\"?>");
            builder.Append("<TStream>");
            builder.Append("<Admin>");
            builder.Append("<MerchantID>494901</MerchantID>");
            builder.Append("<TranCode>BatchClose</TranCode>");

            builder.Append("<BatchNo>1973</BatchNo>");
            builder.Append("<BatchItemCount>2</BatchItemCount>");
            builder.Append("<NetBatchTotal>2</NetBatchTotal>");
            builder.Append("<CreditPurchaseCount>2</CreditPurchaseCount>");
//<CreditPurchaseAmount>CreditPurchaseAmount</CreditPurchaseAmount>
//<CreditReturnCount>CreditReturnCount</CreditReturnCount>
//<CreditReturnAmount>CreditReturnAmount</CreditReturnAmount>
//<DebitPurchaseCount>DebitPurchaseCount</DebitPurchaseCount>
//<DebitPurchaseAmount>DebitPurchaseAmount</DebitPurchaseAmount>
//<DebitReturnCount>DebitReturnCount</DebitReturnCount>
//<DebitReturnAmount>DebitReturnAmount</DebitReturnAmount>
//<TerminalName>TerminalName</TerminalName>
//<ShiftID>ShiftID</ShiftID>
//<Signature>Signature</Signature>
//</Admin>
//</TStream>



            return builder;
        }
    }

    public static class DSICreditSale
    {




        public static StringBuilder GenerateXML(string trackData)
        {
            string amount = PricingConfig.GetConfig();
            string invoiceNumber = InvoiceNumber.New(DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year);
            string terminalID = TerminalIDConfig.GetConfig().ToString();
            string[] valueArray = trackData.Split('|');
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"" + "1.0\"?>");
            builder.Append("<TStream>");
            builder.Append("<Transaction>");
            builder.Append("<MerchantID>" + terminalID + "</MerchantID>");
            builder.Append("<TranType>Credit</TranType>");
            builder.Append("<TranCode>Sale</TranCode>");
            //TODO: ensure the invoice num is incremented to avoid AP*
            builder.Append("<InvoiceNo>" + invoiceNumber + "</InvoiceNo>");
            builder.Append("<RefNo>" + invoiceNumber + "</RefNo>");
            //Memo should include product name and store identity
            builder.Append("<Memo>PaymentKiosk</Memo>");
            builder.Append("<RecordNo>RecordNumberRequested</RecordNo>");
            builder.Append("<Frequency>OneTime</Frequency>");
            builder.Append("<Account>");
            builder.Append("<EncryptedFormat>MagneSafe</EncryptedFormat>");
            builder.Append("<AccountSource>Swiped</AccountSource>");
            builder.AppendFormat("<EncryptedBlock>{0}</EncryptedBlock>", valueArray[3]);
            builder.AppendFormat("<EncryptedKey>{0}</EncryptedKey>", valueArray[9]);
            builder.Append("</Account>");
            builder.Append("<Amount>");
            //Need to read from config
            builder.Append("<Purchase>" + amount + "</Purchase>");
            builder.Append("</Amount>");
            builder.Append("</Transaction>");
            builder.Append("</TStream>");
            return builder;
        }
    }
}
