namespace ProjektniZadatak.forms
{
    partial class FrmAddUser
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
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxbFirstName = new System.Windows.Forms.TextBox();
            this.TxbLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbCardID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CbxCardType = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(311, 354);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(94, 29);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(411, 354);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(94, 29);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ime";
            // 
            // TxbFirstName
            // 
            this.TxbFirstName.Location = new System.Drawing.Point(345, 99);
            this.TxbFirstName.Name = "TxbFirstName";
            this.TxbFirstName.Size = new System.Drawing.Size(160, 27);
            this.TxbFirstName.TabIndex = 3;
            // 
            // TxbLastName
            // 
            this.TxbLastName.Location = new System.Drawing.Point(345, 132);
            this.TxbLastName.Name = "TxbLastName";
            this.TxbLastName.Size = new System.Drawing.Size(160, 27);
            this.TxbLastName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prezime";
            // 
            // TxbCardID
            // 
            this.TxbCardID.Location = new System.Drawing.Point(345, 165);
            this.TxbCardID.Name = "TxbCardID";
            this.TxbCardID.Size = new System.Drawing.Size(160, 27);
            this.TxbCardID.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID kartice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tip kartice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Vazi do:";
            // 
            // CbxCardType
            // 
            this.CbxCardType.FormattingEnabled = true;
            this.CbxCardType.Items.AddRange(new object[] {
            "Obična",
            "Povlašćena"});
            this.CbxCardType.Location = new System.Drawing.Point(345, 198);
            this.CbxCardType.Name = "CbxCardType";
            this.CbxCardType.Size = new System.Drawing.Size(160, 28);
            this.CbxCardType.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.Location = new System.Drawing.Point(241, 264);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 27);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.Value = new System.DateTime(2022, 6, 26, 15, 4, 29, 0);
            // 
            // FrmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.CbxCardType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxbCardID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxbLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxbFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Name = "FrmAddUser";
            this.Text = "Dodaj korisnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnOk;
        private Button BtnCancel;
        private Label label1;
        private TextBox TxbFirstName;
        private TextBox TxbLastName;
        private Label label2;
        private TextBox TxbCardID;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox CbxCardType;
        private DateTimePicker dateTimePicker1;
    }
}