namespace PaymentKiosk.Configurations
{
    partial class frmConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            this.tcConfigurations = new System.Windows.Forms.TabControl();
            this.tpSerialPort = new System.Windows.Forms.TabPage();
            this.cboHandShake = new System.Windows.Forms.ComboBox();
            this.nudStopBits = new System.Windows.Forms.NumericUpDown();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboBaudRates = new System.Windows.Forms.ComboBox();
            this.cboPortName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPricing = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPricePerSwipe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tpMerchant = new System.Windows.Forms.TabPage();
            this.txtTerminalID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tcConfigurations.SuspendLayout();
            this.tpSerialPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopBits)).BeginInit();
            this.tbPricing.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpMerchant.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcConfigurations
            // 
            this.tcConfigurations.Controls.Add(this.tpSerialPort);
            this.tcConfigurations.Controls.Add(this.tbPricing);
            this.tcConfigurations.Controls.Add(this.tpMerchant);
            this.tcConfigurations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcConfigurations.Location = new System.Drawing.Point(0, 0);
            this.tcConfigurations.Name = "tcConfigurations";
            this.tcConfigurations.SelectedIndex = 0;
            this.tcConfigurations.Size = new System.Drawing.Size(212, 275);
            this.tcConfigurations.TabIndex = 0;
            // 
            // tpSerialPort
            // 
            this.tpSerialPort.Controls.Add(this.cboHandShake);
            this.tpSerialPort.Controls.Add(this.nudStopBits);
            this.tpSerialPort.Controls.Add(this.cboDataBits);
            this.tpSerialPort.Controls.Add(this.cboParity);
            this.tpSerialPort.Controls.Add(this.cboBaudRates);
            this.tpSerialPort.Controls.Add(this.cboPortName);
            this.tpSerialPort.Controls.Add(this.label6);
            this.tpSerialPort.Controls.Add(this.label5);
            this.tpSerialPort.Controls.Add(this.label4);
            this.tpSerialPort.Controls.Add(this.label3);
            this.tpSerialPort.Controls.Add(this.label2);
            this.tpSerialPort.Controls.Add(this.label1);
            this.tpSerialPort.Location = new System.Drawing.Point(4, 22);
            this.tpSerialPort.Name = "tpSerialPort";
            this.tpSerialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tpSerialPort.Size = new System.Drawing.Size(204, 249);
            this.tpSerialPort.TabIndex = 0;
            this.tpSerialPort.Text = "Serial Port";
            this.tpSerialPort.UseVisualStyleBackColor = true;
            // 
            // cboHandShake
            // 
            this.cboHandShake.FormattingEnabled = true;
            this.cboHandShake.Location = new System.Drawing.Point(95, 161);
            this.cboHandShake.Name = "cboHandShake";
            this.cboHandShake.Size = new System.Drawing.Size(97, 21);
            this.cboHandShake.TabIndex = 11;
            // 
            // nudStopBits
            // 
            this.nudStopBits.Location = new System.Drawing.Point(95, 134);
            this.nudStopBits.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudStopBits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStopBits.Name = "nudStopBits";
            this.nudStopBits.Size = new System.Drawing.Size(97, 20);
            this.nudStopBits.TabIndex = 10;
            this.nudStopBits.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(95, 108);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(97, 21);
            this.cboDataBits.TabIndex = 9;
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(95, 80);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(97, 21);
            this.cboParity.TabIndex = 8;
            // 
            // cboBaudRates
            // 
            this.cboBaudRates.FormattingEnabled = true;
            this.cboBaudRates.Location = new System.Drawing.Point(95, 52);
            this.cboBaudRates.Name = "cboBaudRates";
            this.cboBaudRates.Size = new System.Drawing.Size(97, 21);
            this.cboBaudRates.TabIndex = 7;
            // 
            // cboPortName
            // 
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.Location = new System.Drawing.Point(95, 24);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.Size = new System.Drawing.Size(97, 21);
            this.cboPortName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hand Shake";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stop Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Bits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Name";
            // 
            // tbPricing
            // 
            this.tbPricing.Controls.Add(this.label8);
            this.tbPricing.Controls.Add(this.txtPricePerSwipe);
            this.tbPricing.Controls.Add(this.label7);
            this.tbPricing.Location = new System.Drawing.Point(4, 22);
            this.tbPricing.Name = "tbPricing";
            this.tbPricing.Padding = new System.Windows.Forms.Padding(3);
            this.tbPricing.Size = new System.Drawing.Size(204, 249);
            this.tbPricing.TabIndex = 1;
            this.tbPricing.Text = "Pricing";
            this.tbPricing.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "USD";
            // 
            // txtPricePerSwipe
            // 
            this.txtPricePerSwipe.Location = new System.Drawing.Point(89, 33);
            this.txtPricePerSwipe.Name = "txtPricePerSwipe";
            this.txtPricePerSwipe.Size = new System.Drawing.Size(72, 20);
            this.txtPricePerSwipe.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Price Per Swipe";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tpMerchant
            // 
            this.tpMerchant.Controls.Add(this.txtPassword);
            this.tpMerchant.Controls.Add(this.label10);
            this.tpMerchant.Controls.Add(this.txtTerminalID);
            this.tpMerchant.Controls.Add(this.label9);
            this.tpMerchant.Location = new System.Drawing.Point(4, 22);
            this.tpMerchant.Name = "tpMerchant";
            this.tpMerchant.Size = new System.Drawing.Size(204, 249);
            this.tpMerchant.TabIndex = 2;
            this.tpMerchant.Text = "Merchant";
            this.tpMerchant.UseVisualStyleBackColor = true;
            // 
            // txtTerminalID
            // 
            this.txtTerminalID.Location = new System.Drawing.Point(108, 13);
            this.txtTerminalID.Name = "txtTerminalID";
            this.txtTerminalID.Size = new System.Drawing.Size(88, 20);
            this.txtTerminalID.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Terminal ID";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(88, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Password";
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(212, 275);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcConfigurations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Manager";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.tcConfigurations.ResumeLayout(false);
            this.tpSerialPort.ResumeLayout(false);
            this.tpSerialPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopBits)).EndInit();
            this.tbPricing.ResumeLayout(false);
            this.tbPricing.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tpMerchant.ResumeLayout(false);
            this.tpMerchant.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcConfigurations;
        private System.Windows.Forms.TabPage tpSerialPort;
        private System.Windows.Forms.TabPage tbPricing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPortName;
        private System.Windows.Forms.ComboBox cboBaudRates;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.ComboBox cboHandShake;
        private System.Windows.Forms.NumericUpDown nudStopBits;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPricePerSwipe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tpMerchant;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTerminalID;
        private System.Windows.Forms.Label label9;
    }
}