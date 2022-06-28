namespace ProjektniZadatak.forms
{
    partial class FrmEditUser
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCheck = new System.Windows.Forms.Button();
            this.Ime = new System.Windows.Forms.Label();
            this.TxbOldFirstName = new System.Windows.Forms.TextBox();
            this.TxbOldLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CbxCardType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxbCardID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.LblPromt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCheck
            // 
            this.BtnCheck.Location = new System.Drawing.Point(164, 154);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(195, 29);
            this.BtnCheck.TabIndex = 0;
            this.BtnCheck.Text = "Nađi";
            this.BtnCheck.UseVisualStyleBackColor = true;
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // Ime
            // 
            this.Ime.AutoSize = true;
            this.Ime.Location = new System.Drawing.Point(67, 88);
            this.Ime.Name = "Ime";
            this.Ime.Size = new System.Drawing.Size(34, 20);
            this.Ime.TabIndex = 1;
            this.Ime.Text = "Ime";
            // 
            // TxbOldFirstName
            // 
            this.TxbOldFirstName.Location = new System.Drawing.Point(164, 88);
            this.TxbOldFirstName.Name = "TxbOldFirstName";
            this.TxbOldFirstName.Size = new System.Drawing.Size(195, 27);
            this.TxbOldFirstName.TabIndex = 2;
            // 
            // TxbOldLastName
            // 
            this.TxbOldLastName.Location = new System.Drawing.Point(164, 121);
            this.TxbOldLastName.Name = "TxbOldLastName";
            this.TxbOldLastName.Size = new System.Drawing.Size(195, 27);
            this.TxbOldLastName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Prezime";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.Location = new System.Drawing.Point(440, 253);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 27);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.Value = new System.DateTime(2022, 6, 26, 15, 4, 29, 0);
            // 
            // CbxCardType
            // 
            this.CbxCardType.FormattingEnabled = true;
            this.CbxCardType.Items.AddRange(new object[] {
            "Obična",
            "Povlašćena"});
            this.CbxCardType.Location = new System.Drawing.Point(544, 187);
            this.CbxCardType.Name = "CbxCardType";
            this.CbxCardType.Size = new System.Drawing.Size(160, 28);
            this.CbxCardType.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Vazi do:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tip kartice";
            // 
            // TxbCardID
            // 
            this.TxbCardID.Location = new System.Drawing.Point(544, 154);
            this.TxbCardID.Name = "TxbCardID";
            this.TxbCardID.Size = new System.Drawing.Size(160, 27);
            this.TxbCardID.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "ID kartice";
            // 
            // TxbLastName
            // 
            this.TxbLastName.Location = new System.Drawing.Point(544, 121);
            this.TxbLastName.Name = "TxbLastName";
            this.TxbLastName.Size = new System.Drawing.Size(160, 27);
            this.TxbLastName.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Prezime";
            // 
            // TxbFirstName
            // 
            this.TxbFirstName.Location = new System.Drawing.Point(544, 88);
            this.TxbFirstName.Name = "TxbFirstName";
            this.TxbFirstName.Size = new System.Drawing.Size(160, 27);
            this.TxbFirstName.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ime";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(610, 343);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(94, 29);
            this.BtnCancel.TabIndex = 14;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(510, 343);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(94, 29);
            this.BtnOk.TabIndex = 13;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblPromt
            // 
            this.LblPromt.AutoSize = true;
            this.LblPromt.Location = new System.Drawing.Point(67, 45);
            this.LblPromt.Name = "LblPromt";
            this.LblPromt.Size = new System.Drawing.Size(125, 20);
            this.LblPromt.TabIndex = 25;
            this.LblPromt.Text = "Izaberite korisnik!";
            // 
            // FrmEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblPromt);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.CbxCardType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxbCardID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxbLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxbFirstName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxbOldLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbOldFirstName);
            this.Controls.Add(this.Ime);
            this.Controls.Add(this.BtnCheck);
            this.Name = "FrmEditUser";
            this.Text = "EditUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnCheck;
        private Label Ime;
        private TextBox TxbOldFirstName;
        private TextBox TxbOldLastName;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private ComboBox CbxCardType;
        private Label label5;
        private Label label4;
        private TextBox TxbCardID;
        private Label label3;
        private TextBox TxbLastName;
        private Label label2;
        private TextBox TxbFirstName;
        private Label label6;
        private Button BtnCancel;
        private Button BtnOk;
        private Label LblPromt;
    }
}