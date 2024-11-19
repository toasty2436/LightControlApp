using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net;

namespace GoveeControlApp
{
    public partial class Form1 : Form
    {
        private BluetoothClient bluetoothClient;

        // Specific MAC addresses of the Govee devices
        private readonly string[] goveeMacAddresses = { "A4:C1:38:D4:89:08", "A4:C1:38:D7:16:97" };

        public Form1()
        {
            InitializeComponent();
        }

        // Button click event handler to start the scanning process
        private async void btnScan_Click(object sender, EventArgs e)
        {
            await DiscoverGoveeDevicesAsync();
        }

        // Discover Govee devices using Bluetooth
        private async Task DiscoverGoveeDevicesAsync()
        {
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices(255, true, true, true);

            lstBluetoothDevices.Items.Clear();
            foreach (var device in devices)
            {
                // Add all discovered devices to the list for debugging
                lstBluetoothDevices.Items.Add(device.DeviceName + " - " + device.DeviceAddress.ToString());

                // Check if the device matches one of the known Govee MAC addresses
                if (goveeMacAddresses.Contains(device.DeviceAddress.ToString()))
                {
                    lblStatus.Text = "Found Govee device: " + device.DeviceName;
                }
            }

            if (lstBluetoothDevices.Items.Count == 0)
            {
                lblStatus.Text = "No devices found!";
            }
            else
            {
                lblStatus.Text = "Devices discovered!";
            }
        }

        // Button click event to connect to the selected device
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (lstBluetoothDevices.SelectedItem != null)
            {
                string selectedDeviceInfo = lstBluetoothDevices.SelectedItem.ToString();
                string macAddress = selectedDeviceInfo.Split('-')[1].Trim(); // Extract MAC address from the selected item

                ConnectToDevice(macAddress);
            }
            else
            {
                lblStatus.Text = "No device selected!";
            }
        }

        // Connect to the Govee device using its MAC address
        private void ConnectToDevice(string macAddress)
        {
            BluetoothAddress address = BluetoothAddress.Parse(macAddress);
            bluetoothClient = new BluetoothClient();

            try
            {
                bluetoothClient.Connect(address, BluetoothService.SerialPort);
                lblStatus.Text = $"Connected to {macAddress}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Failed to connect: {ex.Message}";
            }
        }

        // Button click event to turn on/off the device
        private void btnTurnOnOff_Click(object sender, EventArgs e)
        {
            if (bluetoothClient != null)
            {
                // Send ON/OFF command (you need to replace with actual command)
                NetworkStream stream = bluetoothClient.GetStream();
                byte[] turnOnCommand = new byte[] { 0x01 };  // Replace with actual ON/OFF command
                stream.Write(turnOnCommand, 0, turnOnCommand.Length);

                lblStatus.Text = "LED Lights toggled!";
            }
            else
            {
                lblStatus.Text = "No device connected!";
            }
        }

        // Handle brightness change through trackBar
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (bluetoothClient != null)
            {
                int brightness = trackBarBrightness.Value;
                byte[] brightnessCommand = new byte[] { (byte)brightness };  // Replace with actual brightness command
                SendCommandToLed(brightnessCommand);
            }
        }

        // Send command to the selected LED light
        private void SendCommandToLed(byte[] command)
        {
            if (bluetoothClient != null)
            {
                NetworkStream stream = bluetoothClient.GetStream();
                stream.Write(command, 0, command.Length);
            }
        }

        // Button click event to disconnect from the device
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (bluetoothClient != null)
            {
                bluetoothClient.Close();
                bluetoothClient = null;
                lblStatus.Text = "Disconnected from device.";
            }
            else
            {
                lblStatus.Text = "No device connected!";
            }
        }

        // Event handler for the selected index change in the ListBox
        private void lstBluetoothDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBluetoothDevices.SelectedItem != null)
            {
                string selectedDeviceInfo = lstBluetoothDevices.SelectedItem.ToString();
                string macAddress = selectedDeviceInfo.Split('-')[1].Trim(); // Extract MAC address from the selected item
                lblStatus.Text = $"Selected device: {macAddress}";
            }
        }
    }
}