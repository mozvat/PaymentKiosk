using System;

namespace PaymentKiosk.Exceptions
{
    //Custom Exception for Serial Port Comms to the Board.

    public class PortCommunicationException : KioskBaseException
    {
            public PortCommunicationException()
            {
            }

            public PortCommunicationException(int errorCode, string errorMessage, string additionalInformation, SeverityLevelOptions severity, Exception innerException)
                : base(errorCode, errorMessage, additionalInformation, severity, innerException)
            {

            }
        }
}
