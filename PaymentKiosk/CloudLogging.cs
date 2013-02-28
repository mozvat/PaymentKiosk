using System.Diagnostics;
using System;
using PaymentKiosk.Configurations;
using System.ServiceModel;
using PaymentKiosk.Exceptions;

namespace PaymentKiosk.Logging
{
    /// <summary>
    /// EventLogging to the Windows EventLog for Errors, Warnings and Debug Statements for troubleshooting.
    /// </summary>
    public class CloudLogging : ILogger
    {
        #region ILogger Members

        public void Debug(string text)
        {
            //CloudKioskSoapClient cloudProxy = new CloudKioskSoapClient();
            //string terminalID = TerminalIDConfig.GetConfig().ToString();
            //string result = cloudProxy.Warning(text);
            //EventLog.WriteEntry(EventLogData.SOURCE, "CloudKiosk Communication: " + result + " Debug Statement: " + text, EventLogEntryType.Information, 234);
        }

        public void Warn(string text)
        {
            //CloudKioskSoapClient cloudProxy = new CloudKioskSoapClient();
            //string terminalID = TerminalIDConfig.GetConfig().ToString();
            //string result = cloudProxy.Warning(text);
            //EventLog.WriteEntry(EventLogData.SOURCE, "CloudKiosk Communication: " + result + " Warning Statement: " + text, EventLogEntryType.Warning, 234);

        }

        public void Error(string text)
        {
           // CloudKioskSoapClient cloudProxy = new CloudKioskSoapClient();
            //string terminalID = TerminalIDConfig.GetConfig().ToString();
            //string result = cloudProxy.Error(text);
            //EventLog.WriteEntry(EventLogData.SOURCE, "CloudKiosk Communication: " + result + " Error Statement: " + text, EventLogEntryType.Error, 234);
        }

        public void Error(string text, Exception ex)
        {
            Error(text);
            Error(ex.StackTrace);
        }

        public void Transaction(string text)
        {
            try
            {
                //DSIResponse data = new DSIResponse(text);
                //CloudKioskSoapClient cloudProxy = new CloudKioskSoapClient();
                //string result = cloudProxy.Transaction(data.InvoiceNo, data.MerchantID, data.Amount, string.Empty,data.AcctNo,data.CmdStatus);
                //cloudProxy.TransactionDataTest(text);
            }
            catch (EndpointNotFoundException ex)
            {
                throw new CloudLoggingException(2, "No IP Connection", string.Empty, SeverityLevelOptions.ModerateBusinessInconvenience, ex);
            }
            catch 
            {
                throw;
            }
        }
        #endregion
    }
}
