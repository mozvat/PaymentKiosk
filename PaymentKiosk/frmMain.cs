using System;
using System.Text;
using System.Windows.Forms;
using PaymentKiosk.Board;
using PaymentKiosk.Transactions;
using PaymentKiosk.Logging;
using PaymentKiosk.Configurations;
using PaymentKiosk.SerialPortCommunication;
using PaymentKiosk.Listener;
using PaymentKiosk.About;
using PaymentKiosk.Exceptions;
using System.ServiceModel;
using PaymentKiosk.Transaction.Utilities;

namespace PaymentKiosk
{
    public partial class frmMain : Form
    {
        private string _value = string.Empty;
        private bool _previousCharShift = false;
        private string _intValues = string.Empty;
        private KeyboardListener _listener = new KeyboardListener();
        private string _results = string.Empty;

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string start)
        {
            InitializeComponent();
            Start();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            creditSaleToolStripMenuItem.Enabled = false;
            tsBtnStart.Enabled = true;
            mnuItemFileStart.Enabled = true;
            tsBtnStop.Enabled = false;
            mnuItemFileStop.Enabled = false;
            tsStatus.Text = Status.STOPPED;

#if DEBUG
            debugStripMenuItem.Visible = true;       
#elif RELEASE
			debugStripMenuItem.Visible = false;
#else
			debugStripMenuItem.Visible = false;
#endif

        }
        //TODO: Break this out into its own class, then subscribe to the events via the form
        void listener_KeyUp(object sender, RawKeyEventArgs args)
        {
            try
            {
                string variable;
                variable = ((char)args.VKCode).ToString();
                _intValues += args.VKCode.ToString() + "| ";

                if (_previousCharShift)
                {
                    variable = variable.Replace("5", "%").Replace("6", "^");
                }

                if (args.VKCode == 191)
                {
                    if (_previousCharShift)
                    {
                        variable = "?";
                    }
                    else
                    {
                        variable = "/";
                    }
                }

                if (args.VKCode == 186)
                {
                    variable = ";";
                }

                if (args.VKCode == 220)
                {
                    variable = "|";
                }

                if (args.VKCode == 187)
                {
                    variable = "=";
                }

                if (args.VKCode != 160 && args.VKCode != 13 && args.VKCode != 10)
                {
                    _value += variable;
                }

                if (args.VKCode == 13)
                {
                    _listener.KeyUp -= new RawKeyEventHandler(listener_KeyUp);

                    this.richTextBox1.AppendText(System.Environment.NewLine + System.Environment.NewLine + "Generated XML>>>>>>>>>>>>>>>>>>>>>>>>>>" + System.Environment.NewLine);

                    StringBuilder builder = DSICreditSale.GenerateXML(_value);
                    _value = string.Empty;
                    this.richTextBox1.Focus();
                    this.richTextBox1.AppendText(builder.ToString());
                    this.tsStatus.Text = Status.GENERATINGXML;
                    ProcessCreditSale(builder.ToString());
                    NextTransaction();
                }

                if (args.VKCode == 160)
                {
                    this._previousCharShift = true;
                }
                else
                {
                    this._previousCharShift = false;
                }

            }
            catch (IndexOutOfRangeException)
            {
                Stop();
                Start();
            }
            catch (Exception ex)
            {
                ILogger log = new EventLogging();
                log.Error("Port Communication Error. \n" +
                    "Class: frmMain.cs \n" +
                    "Method: Keyboard EventListener\n" +
                    "Error Message: " + ex.Message);
                Stop();
                //Start();
            }
        }
        private void NextTransaction()
        {
            _listener.KeyUp += new RawKeyEventHandler(listener_KeyUp);
            this.richTextBox1.Focus();
            this.richTextBox1.AppendText("Transaction Completed at: " + System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString() + System.Environment.NewLine + System.Environment.NewLine + "Listening for TRACK DATA at: " + System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString() + System.Environment.NewLine);
            this.tsStatus.Text = Status.LISTENING;
        }
        private void ProcessCreditSale(string request)
        {
            try
            {
                ILogger cloudLog = new CloudLogging();
                string creditResult = string.Empty;
                this.richTextBox1.AppendText(System.Environment.NewLine + System.Environment.NewLine + "PROCESSING REQUEST DATA>>>>>>>>>>>>>>>>>>>>>>>>>>" + System.Environment.NewLine);
                this.tsStatus.Text = Status.PROCESSING;

                //throw new Exception(); // Testing that the application restarts

                this.Cursor = Cursors.WaitCursor;
                //If the board communication error's counter exceeds or is equal to the the configurable board threshold value, then do not process credit card
                if (BoardFailures.Instance.Count <= BoardFailures.Instance.Threshold)
                {
                    //Attempt to process credit card
                    creditResult = Credit.Process(request, PaymentPasswordConfig.GetConfig().ToString());
                    //If Approved then communicate to Board
                    if (Response.Approved(creditResult))
                    {
                        //Communicate to board, if fail then Process a Void Sale
                        if (true)
                        {
                            //Log to Cloud
                            this.tsStatus.Text = Status.PROCESSED;
                                cloudLog.Transaction(creditResult);
                        }
                        else
                        { 
                            ProcessVoidSale(creditResult);
                        }
                    }
                    else //If for any other reason there is not an approval i.e. decline, non-communication, etc then log it
                    {
                        ILogger log = new EventLogging();
                        log.Warn(creditResult);
                    }
                }
                else
                {
                    cloudLog.Error("Missed Processing: Board Failure exceeded threshold Limit");
                }
                this.Cursor = Cursors.Default;
                this.richTextBox1.AppendText(creditResult);
            }
            
            catch (EndpointNotFoundException ex)
            {
                ILogger eventLog = new EventLogging();
                eventLog.Warn("Unable to communicate with Cloud Kiosk, logging to Event LogTransaction Communication Error: " + ex.Message.ToString());
            }

            catch (CreditTransactionException ex)
            {
                ILogger eventLog = new EventLogging();
                eventLog.Error("Credit Transaction Communication Error", ex);
            }
            catch (Exception ex)
            {
                //TODO: This should be calling an out of process executable
                //TODO: What happens if there is an error in this catch and it cannot log?
                ILogger cloudLog = new CloudLogging();
                cloudLog.Error("Unknown/Unhandled Process Method Error. frmMain.cs line 176 " + ex.Message);
                //Used Namespace as it conflicts with PaymentKiosk Namespace.
                //TODO: need to ensure the serial port communication is still working fine after an automatic restart.
                System.Diagnostics.Process.Start(Application.ExecutablePath, "START"); // to start new instance of application
                this.Close(); //to turn off current app
            }
        }
        private void ProcessVoidSale(string result)
        {
            StringBuilder creditVoidSaleRequest = DSICreditVoid.GenerateXML(result);
            string creditResult = string.Empty;
            try
            {
                creditResult = Credit.Process(creditVoidSaleRequest.ToString(), PaymentPasswordConfig.GetConfig().ToString());
            }
            catch (CreditTransactionException ex)
            {
                ILogger eventLog = new EventLogging();
                eventLog.Error("Void Sale Transaction Communication Error", ex);
            }
            catch (Exception ex)
            {
                //TODO: What happens if there is an error in this catch and it cannot log?
                ILogger cloudLog = new CloudLogging();
                cloudLog.Error("Unknown/Unhandled Transaction Process Method Error. frmMain.cs line 242 " + ex.Message);
                System.Diagnostics.Process.Start(Application.ExecutablePath, "START"); // to start new instance of application
                this.Close(); //to turn off current app
            }

            ILogger log = new EventLogging();
            log.Warn(creditResult);

        }
        private void Start()
        {
            this.richTextBox1.AppendText("Listening for Track Data at: " + System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString()
                + System.Environment.NewLine +
                "Terminal ID: " + TerminalIDConfig.GetConfig().ToString() + System.Environment.NewLine +
                "WSP Password: " + PaymentPasswordConfig.GetConfig().ToString() + System.Environment.NewLine +
                "Processing Environment: " + ProcessingEnvironment.Instance.EndPoint.ToString() + System.Environment.NewLine +
                "Port Name: " + Port.Instance.KioskSerialPort.PortName.ToString() + System.Environment.NewLine +
                "Baud Rate: " + Port.Instance.KioskSerialPort.BaudRate.ToString() + System.Environment.NewLine +
                "Parity: " + Port.Instance.KioskSerialPort.Parity.ToString() + System.Environment.NewLine +
                "Data Bits: " + Port.Instance.KioskSerialPort.DataBits.ToString() + System.Environment.NewLine +
                "Stop Bits: " + Port.Instance.KioskSerialPort.StopBits.ToString() + System.Environment.NewLine +
                "HandShake: " + Port.Instance.KioskSerialPort.Handshake.ToString() + System.Environment.NewLine +
                "Pricing: " + PricingConfig.GetConfig().ToString() + System.Environment.NewLine
                );
            this.tsStatus.Text = Status.LISTENING;
            _listener.KeyUp += new RawKeyEventHandler(listener_KeyUp);
            tsBtnStart.Enabled = false;
            mnuItemFileStart.Enabled = false;
            tsBtnStop.Enabled = true;
            mnuItemFileStop.Enabled = true;
        }
        private void tsBtnStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void mnuItemFileStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void Stop()
        {
            this.richTextBox1.AppendText("Stopped Listening at: " + System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString() + System.Environment.NewLine);
            this.tsStatus.Text = Status.STOPPED;
            _listener.KeyUp -= new RawKeyEventHandler(listener_KeyUp);
            tsBtnStart.Enabled = true;
            mnuItemFileStart.Enabled = true;
            tsBtnStop.Enabled = false;
            mnuItemFileStop.Enabled = false;
        }
        private void tsBtnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void mnuItemFileStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void mnuItemConfigurationManager_Click(object sender, EventArgs e)
        {
            frmConfiguration config = new frmConfiguration();
            config.ShowDialog();
        }
        private void tsBtnConfigurationManager_Click(object sender, EventArgs e)
        {
            frmConfiguration config = new frmConfiguration();
            config.ShowDialog();
        }
        private void mnuItemFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsBtnAboutPaymentKiosk_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
        private void mnuItemAboutPaymentKiosk_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
        private void tsBtnLog_Click(object sender, EventArgs e)
        {

        }
        private void creditSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string trackData = string.Empty;

            if (ProcessingEnvironment.Instance.Debug)
            {
                trackData = @"%B5499000090006781^TEST/MPS^15120000000000000?;5499000090006781=15120000000000000000?|0600|FD98A2246FB8832F248C154AF246897F294D599686096C2347F727E7C4C63BE4A8D521896AA1DA94FD0D45C36D10C74C|EB12E09FBD4FD5AA1155E52D066166FF36DEC3D851451EF9BB15C25EA83209E859FA4C8DC363FFEE||61403000|4D432B02E3D7C1F169D5C09D1355E2770A1B737F2E806DD746499AF4A99AEB73F7BBE1A89BDD37384A8467A842307D3AE8401E400B6EF6D4|B02E8EA022311AA|845371FC8288170B|9012090B02E8EA000133|9CA2||0000";
            }
            else
            {
                trackData = @"%B5499000090006781^TEST/MPS^15120000000000000?;5499000090006781=15120000000000000000?|0600|F32B6E4C8320FF7B79603F85E8DF52F06FCB9FD335575841B56B019481483BFE8ECE01AE8A577BE36CB6A322D4F80247|037C08C5E3F50C12A42E9C1E17D6AE4B885767F79D67D978539E924D1B5AF7CA553580546260030E||61402200|FF2B98942F7FE516C0890DF8FD97DA9B53554F4434B9880B257FA7E5DCC68B636BA11ABCDA4EEC1AAD5D85972C851F2E2791A5A681206BEE|B024438090810AA|DAFBC974FC43B8E9|9012110B024438000015|7A88||0000";

            }

            StringBuilder builder = DSICreditSale.GenerateXML(trackData);
            this.ProcessCreditSale(builder.ToString());
        }
        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (debugStripMenuItem.Visible)
            {
                debugStripMenuItem.Visible = false;
                debugStripMenuItem.Checked = false;
                //Turn on Production Features
                mnuItemFileStart.Enabled = true;
                mnuItemFileStop.Enabled = true;
                mnuItemFileLog.Enabled = true;
                configurationToolStripMenuItem.Enabled = true;
                tsBtnStart.Enabled = true;
                //ProcessingEnvironment.Instance.Debug = false;
            }
            else
            {
                debugStripMenuItem.Visible = true;
                debugStripMenuItem.Checked = true;
                //Turn off Production Features
                mnuItemFileStart.Enabled = false;
                mnuItemFileStop.Enabled = false;
                mnuItemFileLog.Enabled = false;
                configurationToolStripMenuItem.Enabled = false;
                tsBtnStart.Enabled = false;
                //ProcessingEnvironment.Instance.Debug = true;
            }
        }
        private void certificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (certificationToolStripMenuItem.Checked)
            {
                certificationToolStripMenuItem.Checked = false;
                creditSaleToolStripMenuItem.Enabled = false;
            }
            else
            {
                ProcessingEnvironment.Instance.Debug = true;
                certificationToolStripMenuItem.Checked = true;
                productionToolStripMenuItem.Checked = false;
                creditSaleToolStripMenuItem.Enabled = true;
            }
        }
        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
            if (productionToolStripMenuItem.Checked)
            {
                productionToolStripMenuItem.Checked = false;
                creditSaleToolStripMenuItem.Enabled = false;
            }
            else
            {
                ProcessingEnvironment.Instance.Debug = false;
                certificationToolStripMenuItem.Checked = false;
                productionToolStripMenuItem.Checked = true;
                creditSaleToolStripMenuItem.Enabled = true;
            }
        }
        private void batchCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder builder = DSIBatchSummary.GenerateXML();
            this.ProcessCreditSale(builder.ToString());
        }
        private void sendSuccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoardCommunication.SendSuccess();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
