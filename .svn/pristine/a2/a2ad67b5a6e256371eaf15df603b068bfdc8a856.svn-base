using System;
using System.ServiceModel;
using PaymentKiosk.Exceptions;
using System.Xml;
using PaymentKiosk.Transactions;

namespace PaymentKiosk.Transactions
{
    public static class Admin
    {
        public static string Process(string dsiAdminRequest, string transactionPassword)
        {
            string rawResult = string.Empty;
            string sanitizedResult = string.Empty;
            WebServices.wsSoapClient proxy = new WebServices.wsSoapClient();
            try
            {
                proxy.Endpoint.Address = new EndpointAddress(ProcessingEnvironment.Instance.EndPoint);
                rawResult = proxy.CreditTransaction(dsiAdminRequest.Trim(), transactionPassword);
            }
            catch (EndpointNotFoundException ex) //This means there is no IP connection
            {
                throw new CreditTransactionException(2, "No IP Connection", string.Empty, SeverityLevelOptions.CriticalProcessingStopped, ex);
            }
            catch (ArgumentNullException ex) //A null value was in the XML
            {
                throw new CreditTransactionException(3, "Null value in XML Credit Response ", string.Empty, SeverityLevelOptions.CriticalProcessingStopped, ex);
            }
            catch (ArgumentException ex) //Could not sanitize a remove field
            {
                throw new CreditTransactionException(3, "Xml sanitize error when remove a tag from the XML Credit Response ", string.Empty, SeverityLevelOptions.CriticalProcessingStopped, ex);
            }
            catch (XmlException ex) //A null value was in the XML
            {
                throw new CreditTransactionException(4, "XmlException during Sanitization of Data ", string.Empty, SeverityLevelOptions.CriticalProcessingStopped, ex);
            }
            catch
            {
                throw;
            }
            return string.Empty;

        }
    }
}