using System;
using System.Xml;
using System.ServiceModel;
using PaymentKiosk.Exceptions;
using PaymentKiosk.Transaction.Utilities;

namespace PaymentKiosk.Transactions
{
    public static class Credit
    {
        public static string Process(string dsiCreditRequest, string transactionPassword)
        {
            string rawResult = string.Empty;
            string sanitizedResult = string.Empty;
            WebServices.wsSoapClient proxy = new WebServices.wsSoapClient();
            try
            {
                proxy.Endpoint.Address = new EndpointAddress(ProcessingEnvironment.Instance.EndPoint);
                rawResult = proxy.CreditTransaction(dsiCreditRequest.Trim(), transactionPassword);
                if (Response.Approved(rawResult))
                {
                    sanitizedResult = Response.SanitizeXMLResults(rawResult);
                }
                else //This will return a reason of the non-approval
                {
                    sanitizedResult = rawResult;
                }
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
            return sanitizedResult;
        }
    }
}
