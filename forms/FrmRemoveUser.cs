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
    public partial class FrmRemoveUser : Form
    {
        public List<CardData> cardDatas = new List<CardData>();
        public FrmRemoveUser()
        {
            InitializeComponent();
           // ListBox1.Items.Add("hello world!");
        }

        public void BtnSearch_Click(object sender, EventArgs e)
        {
            cardDatas = PostgreSQL.searchBySingleParam(CbxKey.Text.ToUpper(), TxbValue.Text.ToUpper());
            ListBox1.Items.Clear();
            foreach (CardData cardData in cardDatas) { 
                ListBox1.Items.Add($"{cardData.firstName} {cardData.lastName}\t\t {cardData.cardID}\t {cardData.cardType}");
            }
           // ListBox1.Items.Add("fasz2");
            ///select * from korisnici where first_name like '%FASZ%'
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //ListBox1.Items.Add("fasz2");
            //ListBox1.ClearSelected();
            string delCardID = cardDatas.ElementAt(ListBox1.SelectedIndex).cardID;
            PostgreSQL.removeUserByCardID(delCardID);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
