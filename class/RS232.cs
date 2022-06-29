using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjektniZadatak;

public class RS232
{
    public SerialPort serial;
    public string portName;
    public string msgRcvd = "";
    private ListView listView;

    public RS232(string portName, ListView listView) {
        
        this.portName = portName;
        this.listView = listView;
        serial = new SerialPort(this.portName);    /// TODO: selection of port!
        serial.Open();
        serial.DataReceived += SerialDataReceived;
        print($"Connceted to serial: {this.portName}");
    }

    private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        msgRcvd = "";
        //string msg = serialPort.ReadLine();
        if (serial.BytesToRead > 0)
        {
            byte[] podaci = new byte[serial.BytesToRead];

            for (int i = 0; i < podaci.Length; i++)
            {
                podaci[i] = Convert.ToByte(serial.ReadByte());
            }
            // msgRcvd = String.Join(",", podaci);
            msgRcvd = System.Text.ASCIIEncoding.Default.GetString(podaci);
            print(">" + msgRcvd);
        }
    }

    public void print(string msg) {
        if (listView.InvokeRequired)
        {
            listView.Invoke((MethodInvoker)(() =>
            {
                listView.Items.Add("InvokeRequired");
                listView.Items.Add(msg);
            }));
        }
        else
        {
            listView.Items.Add(msg);
        }
    }

    /*namespace R232_chat
    {
        public partial class Form1 : Form
        {
            SerialPort serialPort;
            string korisnik;

            public Form1()
            {
                InitializeComponent();

                initSerialPort();
            }

            private void initSerialPort()
            {
                Login frmLogin = new Login();
                frmLogin.ShowDialog();
                serialPort = new SerialPort(frmLogin.Port);
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;
                korisnik = frmLogin.Ime;
            }

            private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                //string msg = serialPort.ReadLine();
                if (serialPort.BytesToRead > 0)
                {
                    int[] podaci = new int[serialPort.BytesToRead];

                    for (int i = 0; i < podaci.Length; i++)
                    {
                        podaci[i] = serialPort.ReadByte();
                    }
                    print2list(String.Join(",", podaci));
                }
                //print2list(msg);

            }

            private void print2list(string poruka)
            {
                if (listBox1.InvokeRequired)
                {
                    listBox1.Invoke((MethodInvoker)(() =>
                    {
                        //listBox1.Items.Add("InvokeRequired");
                        listBox1.Items.Add(poruka);
                    }));
                }
                else
                {
                    listBox1.Items.Add(poruka);
                }


            }

            private void btnSend_Click(object sender, EventArgs e)
            {
                sendMsg();
            }



            private void txtMsg_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    sendMsg();
                }
            }

            private void sendMsg()
            {
                if (!serialPort.IsOpen) serialPort.Open();
                serialPort.Write(korisnik + "," + txtMsg.Text);
                print2list(korisnik + "," + txtMsg.Text);
                txtMsg.Text = "";
                txtMsg.Focus();
            }
        }
    }*/

}