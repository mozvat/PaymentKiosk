using System;
using System.IO.Ports;
using System.Threading;
using PaymentKiosk.Exceptions;
using PaymentKiosk.Configurations;

namespace PaymentKiosk.SerialPortCommunication
{

    public sealed class Port
    {
        private static volatile Port instance;
        private static object syncRoot = new Object();
        private static SerialPort _serialPort;
        private static bool _continue;

        public SerialPort KioskSerialPort
        {
            get { return _serialPort; }
            set
            {
                _serialPort = value;
            }
        }

        private Port()
        {
            _serialPort = PortConfig.GetConfig();
            //TODO: Config file? Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

        }

        public static Port Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Port();
                    }
                }
                return instance;
            }
        }

        public void Write(string buffer)
        {
            try
            {
                //TODO: should use 'Using' to close connection if error
                Thread readThread = new Thread(Read);
                _serialPort.Open(); 
                _continue = true;
                readThread.Start();
                _serialPort.WriteLine(buffer);
                _continue = false;
                readThread.Join();
                _serialPort.Close();
            }
            catch (Exception ex)
            {
                //TODO: Need to create error number convention
                throw new PortCommunicationException(1, "Error While writing to Serial Port", string.Empty, SeverityLevelOptions.CriticalProcessingStopped, ex);
            }
        }

        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}