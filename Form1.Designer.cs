namespace GoveeControlApp
{
    partial class Form1
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

        private void InitializeComponent()
        {
            lstBluetoothDevices = new ListBox();
            lblStatus = new Label();
            btnTurnOnOff = new Button();
            trackBarBrightness = new TrackBar();
            btnDisconnect = new Button();
            btnScan = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).BeginInit();
            SuspendLayout();
            // 
            // lstBluetoothDevices
            // 
            lstBluetoothDevices.FormattingEnabled = true;
            lstBluetoothDevices.ItemHeight = 15;
            lstBluetoothDevices.Location = new Point(13, 13);
            lstBluetoothDevices.Name = "lstBluetoothDevices";
            lstBluetoothDevices.Size = new Size(200, 154);
            lstBluetoothDevices.TabIndex = 0;
            lstBluetoothDevices.SelectedIndexChanged += lstBluetoothDevices_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(13, 180);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(200, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status: Disconnected";
            // 
            // btnTurnOnOff
            // 
            btnTurnOnOff.Location = new Point(13, 220);
            btnTurnOnOff.Name = "btnTurnOnOff";
            btnTurnOnOff.Size = new Size(100, 23);
            btnTurnOnOff.TabIndex = 2;
            btnTurnOnOff.Text = "Turn On/Off";
            btnTurnOnOff.UseVisualStyleBackColor = true;
            btnTurnOnOff.Click += btnTurnOnOff_Click;
            // 
            // trackBarBrightness
            // 
            trackBarBrightness.Location = new Point(13, 250);
            trackBarBrightness.Name = "trackBarBrightness";
            trackBarBrightness.Size = new Size(200, 45);
            trackBarBrightness.TabIndex = 3;
            trackBarBrightness.Scroll += trackBarBrightness_Scroll;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(13, 300);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(100, 23);
            btnDisconnect.TabIndex = 4;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(168, 301);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(75, 23);
            btnScan.TabIndex = 5;
            btnScan.Text = "button1";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(284, 361);
            Controls.Add(btnScan);
            Controls.Add(btnDisconnect);
            Controls.Add(trackBarBrightness);
            Controls.Add(btnTurnOnOff);
            Controls.Add(lblStatus);
            Controls.Add(lstBluetoothDevices);
            Name = "Form1";
            Text = "Govee Control";
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lstBluetoothDevices;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTurnOnOff;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Button btnDisconnect;
        private Button btnScan;
    }
}
