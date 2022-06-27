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
    public partial class FrmAddUser : Form
    {
        public string firstName;
        public string lastName;
        public string cardType;
        public string cardID;
        public string validUntil;
        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            /// TODO: Add testing for fields
            if (TxbFirstName.Text.CompareTo("") == 0 || TxbLastName.Text.CompareTo("") == 0 || TxbCardID.Text.CompareTo("") == 0 ){
                return;
            }
            if (CbxCardType.SelectedIndex == -1) {
                return; 
            }
            firstName = TxbFirstName.Text;
            lastName = TxbLastName.Text;
            cardID = TxbCardID.Text;
            cardType = CbxCardType.Text;
            validUntil = dateTimePicker1.Value.ToUniversalTime().ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
