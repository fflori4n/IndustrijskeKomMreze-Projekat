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
    public partial class FrmEditUser : Form
    {
        public string oldFirstName;
        public string oldLastName;
        public string newFirstName;
        public string newLastName;
        public string cardID;
        public string cardType;
        public string validUntil;
        public bool isChecked = false;
  
        public FrmEditUser()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Form1.isUserInWhiteList(TxbOldFirstName.Text, TxbOldLastName.Text))
            {
                oldFirstName = TxbOldFirstName.Text;
                oldLastName = TxbOldLastName.Text;
                LblPromt.Text = $"Pritiskom na OK, menja se korisnik: {oldFirstName} {oldLastName}";
                isChecked = true;
            }
            else {
                LblPromt.Text = $"Ne postoji korisnik: {oldFirstName} {oldLastName}";
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!isChecked) {
                return;
            }
            if (TxbFirstName.Text.CompareTo("") == 0 || TxbLastName.Text.CompareTo("") == 0 || TxbCardID.Text.CompareTo("") == 0)
            {
                return;
            }
            if (CbxCardType.SelectedIndex == -1)
            {
                return;
            }
            newFirstName = TxbFirstName.Text;
            newLastName = TxbLastName.Text;
            cardID = TxbCardID.Text;
            cardType = CbxCardType.Text;
            validUntil = dateTimePicker1.Value.ToUniversalTime().ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
