using ProjektniZadatak;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

public class TCPClient
{
    private static TcpClient tCPclient;
    private static NetworkStream stream;
    private static Timer timer;

    public static void send(String msg) {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(msg + "\r\n");
            stream.Write(data, 0, data.Length);
        }
        catch (Exception ex)
        {
            Form1.print2list(ex.Message);
        }
    }
    public static void connect(string iP, string port) {
        try
        {
            tCPclient = new TcpClient();
            tCPclient.Connect(iP, int.Parse(port));

            stream = tCPclient.GetStream();
            timer = new Timer();
            timer.Tick += new EventHandler(timerCallback);
            timer.Interval = 100; // in miliseconds
            timer.Start();

            Form1.print2list("[ OK ] TCP client connected");
        }
        catch (Exception ex) {
            Form1.print2list(ex.Message);
        }
      



    }

    public static void dispose() {
        tCPclient.Close();
        tCPclient.Dispose();
    }

    private static void timerCallback(object sender, EventArgs e)
    {
        try
        {
            if (stream.DataAvailable)
            {
                byte[] recivedData = new byte[tCPclient.ReceiveBufferSize];
                stream.Read(recivedData, 0, recivedData.Length);

                string txt = Encoding.UTF8.GetString(recivedData);

                Form1.print2list("TCP>>" + txt);
            }
        }
        catch (Exception ex)
        {
            Form1.print2list(ex.Message);
        }

    }
}

/*
 * 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_klijent
{
    public partial class Form1 : Form
    {
        TcpClient tCPclient;
        NetworkStream stream;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tCPclient = new TcpClient();
                tCPclient.Connect(txtIP.Text, int.Parse(txtPort.Text));

                stream = tCPclient.GetStream();

                timer = new Timer();
                timer.Interval = 100;
                timer.Tick += Timer_Tick;
                timer.Start();

                print2list("Connected");

                panel1.Enabled = true;
                btnConnect.Enabled = false;
            }catch (Exception ex)
            {
                print2list(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (stream.DataAvailable)
                {
                    byte[] recivedData = new byte[tCPclient.ReceiveBufferSize];
                    stream.Read(recivedData, 0, recivedData.Length);

                    string txt = Encoding.UTF8.GetString(recivedData);

                    print2list(txt);
                }
            }
            catch (Exception ex)
            {
                print2list(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(txtMsg.Text + "\r\n");
                stream.Write(data, 0, data.Length);
            }catch (Exception ex)
            {
                print2list(ex.Message);
            }
        }

        private void print2list(string poruka)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke((MethodInvoker)(() =>
                {
                    listBox1.Items.Add("InvokeRequired");
                    listBox1.Items.Add(poruka);
                }));
            }
            else
            {
                listBox1.Items.Add(poruka);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

 
 */

