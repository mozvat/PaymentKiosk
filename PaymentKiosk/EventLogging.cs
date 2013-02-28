using System.Diagnostics;
using System;

namespace PaymentKiosk.Logging
{
    /// <summary>
    /// EventLogging to the Windows EventLog for Errors, Warnings and Debug Statements for troubleshooting.
    /// </summary>
    public class EventLogging : ILogger
    {
        #region ILogger Members

        public void Debug(string text)
        {
            EventLog.WriteEntry(EventLogData.SOURCE, text, EventLogEntryType.Information, 234);
        }

        public void Warn(string text)
        {
            EventLog.WriteEntry(EventLogData.SOURCE, text, EventLogEntryType.Warning, 234);
        }

        public void Error(string text)
        {
            EventLog.WriteEntry(EventLogData.SOURCE, text, EventLogEntryType.Error, 234);
        }

        public void Error(string text, Exception ex)
        {
            Error(text); 
            Error(ex.StackTrace); 
        }

        public void Transaction(string text)
        {
            EventLog.WriteEntry(EventLogData.SOURCE, text, EventLogEntryType.Information, 234);
        }

        #endregion
    }
}
