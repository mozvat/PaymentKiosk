using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentKiosk.Exceptions
{
    public class BoardException : KioskBaseException
    {
        public BoardException()
        {
        }

        public BoardException(int errorCode, string errorMessage, string additionalInformation, SeverityLevelOptions severity, Exception innerException)
            : base(errorCode, errorMessage, additionalInformation, severity, innerException)
        {

        }
    }
}
