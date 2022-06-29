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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("login pressd");
            if (TxbUser.Text.CompareTo("") == 0) {
                /// TODO: promt user
                return;
            }
            if (TxbPass.Text.CompareTo("") == 0) {
                /// TODO: promt user
                return;
            }
            user = TxbUser.Text;
            pass = TxbPass.Text;
            comPort = CbxComPort.Text;

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
