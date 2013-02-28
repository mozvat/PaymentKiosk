using System;
using System.IO.Ports;
using System.Configuration;

//TODO: Break out all these classes into their own files.

//These Classes/Methods are basically the interaction between writing and reading to the config file

namespace PaymentKiosk.Configurations
{

    public static class PaymentPasswordConfig
    {
        public static string GetConfig()
        {
            string value = string.Empty;
            value = ConfigurationManager.AppSettings["Password"].ToString();
            return value;
        }


        //Unused until we implement this field in the UI...
        public static void SetConfig(string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Password");
            config.AppSettings.Settings.Add("Password", value.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public static class TerminalIDConfig
    {
        public static string GetConfig()
        {
            string value = string.Empty;
            value = ConfigurationManager.AppSettings["TerminalID"].ToString();
            return value;
        }


        //Unused until we implement this field in the UI...
        public static void SetConfig(string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("TerminalID");
            config.AppSettings.Settings.Add("TerminalID", value.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public static class PricingConfig
    {
        public static string GetConfig()
        {
            string value = string.Empty;
            value = ConfigurationManager.AppSettings["Pricing"].ToString();
            return value;
        }
        public static void SetConfig(string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Pricing");
            config.AppSettings.Settings.Add("Pricing", value.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public static class PortConfig
    {
        public static SerialPort GetConfig()
        {
            SerialPort serialPort = new SerialPort();
            //The port with which we're communicating through, i.e; COM1, COM2, etc.
            serialPort.PortName = ConfigurationManager.AppSettings["PortName"].ToString();
            //A measure of the speed of serial communication, roughly equivalent to bits per second.
            serialPort.BaudRate = int.Parse(ConfigurationManager.AppSettings["BaudRate"].ToString());
            //The even or odd quality of the number of 1's or 0's in a binary code, often used to determine the integrity of data especially after transmission.
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), ConfigurationManager.AppSettings["Parity"].ToString());
            //The number of bits used to represent one character of data.
            serialPort.DataBits = int.Parse(ConfigurationManager.AppSettings["DataBits"].ToString());
            //A bit that signals the end of a transmission unit
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigurationManager.AppSettings["StopBits"].ToString());
            serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), ConfigurationManager.AppSettings["HandShake"].ToString());

            return serialPort;
        }

        public static void SetConfig(SerialPort serialPort)
        {
            // Open App.Config 
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("PortName");
            config.AppSettings.Settings.Add("PortName", serialPort.PortName.ToString());
            config.AppSettings.Settings.Remove("BaudRate");
            config.AppSettings.Settings.Add("BaudRate", serialPort.BaudRate.ToString());
            config.AppSettings.Settings.Remove("Parity");
            config.AppSettings.Settings.Add("Parity", serialPort.Parity.ToString());
            config.AppSettings.Settings.Remove("DataBits");
            config.AppSettings.Settings.Add("DataBits", serialPort.DataBits.ToString());
            config.AppSettings.Settings.Remove("StopBits");
            config.AppSettings.Settings.Add("StopBits", serialPort.StopBits.ToString());
            config.AppSettings.Settings.Remove("HandShake");
            config.AppSettings.Settings.Add("HandShake", serialPort.Handshake.ToString());
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public static class BoardFailuresCount
    {
        public static string GetConfig()
        {
            string value = string.Empty;
            value = ConfigurationManager.AppSettings["BoardFailureCount"].ToString();
            return value;
        }
        public static void SetConfig(string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("BoardFailureCount");
            config.AppSettings.Settings.Add("BoardFailureCount", value.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public static class BoardFailureThresholdConfig
    {
        public static string GetConfig()
        {
            string value = string.Empty;
            value = ConfigurationManager.AppSettings["BoardFailureThreshold"].ToString();
            return value;
        }
        public static void SetConfig(string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("BoardFailureThreshold");
            config.AppSettings.Settings.Add("BoardFailureThreshold", value.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

}