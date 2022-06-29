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

namespace ProjektniZadatak;
public class RS232
{
    public SerialPort serial;
    public string portName;
    public string msgRcvd = "";


    public RS232(string portName) {
        
        this.portName = portName;
        serial = new SerialPort(this.portName);    /// TODO: selection of port!
        serial.Open();
        serial.DataReceived += SerialDataReceived;
        Form1.print2list($"Connceted to serial: {this.portName}");
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
            Form1.print2list(" > " + msgRcvd);
            Form1.reactToCardSwipe(msgRcvd);
        }
    }
}