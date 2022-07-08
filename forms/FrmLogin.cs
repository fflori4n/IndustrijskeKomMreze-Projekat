using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektniZadatak.forms
{
    public partial class FrmLogin : Form
    {
        public string user = "";
        public string pass = "";
        public string tcpIpAddr = "";
        public string tcpPort = "";
        public string formType = "";
        public string comPort = "";
        public FrmLogin(string formType)
        {
            InitializeComponent();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                CbxComPort.Items.Add(ports[i]);
            }
            CbxComPort.SelectedIndex = 0;
            if (formType.CompareTo("change") == 0)
            {
                BtnExit.Enabled = false;
                BtnCancel.Enabled = true;
                BtnExit.Visible = false;
                BtnCancel.Visible = true;
            }
            else {
                BtnExit.Enabled = true;
                BtnCancel.Enabled = false;
                BtnExit.Visible = true;
                BtnCancel.Visible = false;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (formType.Equals("login")) {
                BtnCancel.Enabled = false;
            }
            else if (formType.Equals("change")){
                BtnExit.Enabled = false;
            }
        }

        /// From: https://stackoverflow.com/questions/11412956/what-is-the-best-way-of-validating-an-ip-address
        /// check if IP adress is valid
        public bool validateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("login pressd");
            if (String.IsNullOrWhiteSpace(TxbUser.Text)) {
                /// TODO: promt user
                return;
            }
            if (String.IsNullOrWhiteSpace(TxbPass.Text)) {
                /// TODO: promt user
                return;
            }
            if (!validateIPv4(TxbTcpIp.Text)) {
                /// IP adress not valid
                return;
            }
            int tcpPortInt;
            if (!int.TryParse(TxbTcpPort.Text, out tcpPortInt) || String.IsNullOrWhiteSpace(TxbTcpPort.Text)) { 
                /// port is not valid
                return;
            }
            user = TxbUser.Text;
            pass = TxbPass.Text;
            comPort = CbxComPort.Text;
            tcpIpAddr = TxbTcpIp.Text;
            tcpPort =  TxbTcpPort.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Console.WriteLine("exit pressd");
            this.DialogResult = DialogResult.Cancel;
            this.Close();


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("cancel pressd");
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void CbxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
