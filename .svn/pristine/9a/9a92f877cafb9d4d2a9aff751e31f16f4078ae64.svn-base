using System;
using System.Windows.Forms;
using System.IO.Ports;
using PaymentKiosk.Configurations;
using PaymentKiosk.SerialPortCommunication;

namespace PaymentKiosk.Configurations
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }
        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            //TODO: Does this load seem to be doing a bit too much?

            SerialPort serialPort = PortConfig.GetConfig();

            //PORT NAME
            foreach (string s in SerialPort.GetPortNames())
            {
                cboPortName.Items.Add(s);
            }
            cboPortName.SelectedIndex = cboPortName.FindStringExact(serialPort.PortName.ToString());
            //BAUDRATES
            cboBaudRates.Items.AddRange(new object[] {1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600});
            cboBaudRates.SelectedIndex = cboBaudRates.FindStringExact(serialPort.BaudRate.ToString());
            //PARITY
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                cboParity.Items.Add(s);
            }
            cboParity.SelectedIndex = cboParity.FindStringExact(serialPort.Parity.ToString());
            //DATABITS
            cboDataBits.Items.AddRange(new object[] { 5,6,7,8,9 });
            cboDataBits.SelectedIndex = cboDataBits.FindStringExact(serialPort.DataBits.ToString());
            //HANDSHAKE
            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                cboHandShake.Items.Add(s);
            }
            cboHandShake.SelectedIndex = cboHandShake.FindStringExact(serialPort.Handshake.ToString());

            nudStopBits.Value = (decimal)serialPort.StopBits;
            //Price Per Swipe
            txtPricePerSwipe.Text = PricingConfig.GetConfig();
            //Payment Password
            txtPassword.Text = PaymentPasswordConfig.GetConfig().ToString();
            //Payment Terminal ID
            txtTerminalID.Text = TerminalIDConfig.GetConfig().ToString();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: All this 'Save Config' functionality should probably be broken out into another class, it seems like too much crap for this form.
            //i.e    Configuration.Save(PortName, BaudRate,DataBits, Parity...) etc

            //TODO: I cannot remember why I decided to create a Singleton Port class, what are the advantages
            Port.Instance.KioskSerialPort.PortName = cboPortName.Text.ToString();
            Port.Instance.KioskSerialPort.BaudRate = int.Parse(cboBaudRates.Text.ToString());
            Port.Instance.KioskSerialPort.DataBits = int.Parse(cboDataBits.Text.ToString());
            Port.Instance.KioskSerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text.ToString());
            Port.Instance.KioskSerialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShake.Text.ToString());
            Port.Instance.KioskSerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), nudStopBits.Value.ToString());

            PortConfig.SetConfig(Port.Instance.KioskSerialPort);
            //Port.Instance.Save();
            double value = 0;
            if (double.TryParse(txtPricePerSwipe.Text, out value))
            {
                PricingConfig.SetConfig(txtPricePerSwipe.Text);
                System.Windows.Forms.DialogResult result = MessageBox.Show("Successfully Saved", "Save Configurations", MessageBoxButtons.OK);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect pricing value", "Pricing Error", MessageBoxButtons.OK);

            }
            //Save Password
            PaymentPasswordConfig.SetConfig(txtPassword.Text);
            //Save TerminalID
            TerminalIDConfig.SetConfig(txtTerminalID.Text);
        }
    }
}
