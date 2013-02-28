using System;
using PaymentKiosk.Exceptions;
using PaymentKiosk.Logging;
using PaymentKiosk.SerialPortCommunication;

namespace PaymentKiosk.Board
{

    public static class BoardCommunication
    {
        public static bool SendSuccess()
        {
            bool success = false;
            try
            {
                Port.Instance.Write(BoardMessages.Success);
                success = true;
            }
            catch (PortCommunicationException ex)
            {
                //Log error
                ILogger log = new CloudLogging(); 
                log.Error("Port Communication Error. \n" + 
                    "Class: " + ex.ModuleName + "\n" +  
                    "Method: " + ex.ProcedureName + "\n"  +
                    "Error Message: " + ex.Message + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                ILogger cloudLog = new CloudLogging();
                cloudLog.Error("Port Communication Error. " + ex.Message);
            }

            if (success)
                BoardFailures.Instance.Count = 0;
            else
                BoardFailures.Instance.Count += 1;

            return success;
        }
    }
}
