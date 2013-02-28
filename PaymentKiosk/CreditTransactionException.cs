using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentKiosk.Exceptions
{
    public class CreditTransactionException : KioskBaseException
    {
        public CreditTransactionException()
        {
        }

        public CreditTransactionException(int errorCode, string errorMessage, string additionalInformation, SeverityLevelOptions severity, Exception innerException)
            : base(errorCode, errorMessage, additionalInformation, severity, innerException)
        {

        }
    }
}
