using System;
using System.Diagnostics;

namespace PaymentKiosk.Exceptions
{
    public enum SeverityLevelOptions { CriticalProcessingStopped, ModerateBusinessInconvenience, OnlyInformational }

    public class KioskBaseException : Exception
    {
        #region Properties
        public int ErrorCode { get; set; }
        public SeverityLevelOptions SeverityLevel { get; set; }
        public string ErrorMessage { get; set; }
        public string ModuleName { get; set; }
        public string ProcedureName { get; set; }
        public string AdditionalInformation { get; set; }
        #endregion

        #region Constructors

        public KioskBaseException()
        { }

        public KioskBaseException(int errorCode, string errorMessage, string additionalInformation, SeverityLevelOptions severity, Exception ex)
            : base(errorMessage, ex)
        {

            StackTrace stackTrace = new StackTrace();
            ModuleName = stackTrace.GetFrame(2).GetMethod().DeclaringType.Name;
            ProcedureName = stackTrace.GetFrame(2).GetMethod().Name;
            SeverityLevel = severity;
            AdditionalInformation = additionalInformation;
            ErrorMessage = "Error Message:" + errorMessage + "\n\nException Details:" + ex.ToString();
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Used to log when you don't have an exception object
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="additionalInformation"></param>
        public KioskBaseException(int errorCode, string errorMessage, string additionalInformation, SeverityLevelOptions severity)
        {
            StackTrace stackTrace = new StackTrace();
            ModuleName = stackTrace.GetFrame(2).GetMethod().DeclaringType.Name;
            ProcedureName = stackTrace.GetFrame(2).GetMethod().Name;
            SeverityLevel = severity;
            AdditionalInformation = additionalInformation;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        #endregion

    }
}
