namespace ProjektniZadatak.forms
{
    partial class FrmRemoveUser
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
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.CbxKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxbValue = new System.Windows.Forms.TextBox();
            this.LblPromt = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(425, 42);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(94, 29);
            this.BtnSearch.TabIndex = 0;
            this.BtnSearch.Text = "Pretraga";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(121, 409);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(94, 29);
            this.BtnDelete.TabIndex = 1;
            this.BtnDelete.Text = "Briši";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // CbxKey
            // 
            this.CbxKey.FormattingEnabled = true;
            this.CbxKey.Items.AddRange(new object[] {
            "card_id",
            "first_name",
            "last_name"});
            this.CbxKey.Location = new System.Drawing.Point(21, 42);
            this.CbxKey.Name = "CbxKey";
            this.CbxKey.Size = new System.Drawing.Size(176, 28);
            this.CbxKey.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "=";
            // 
            // TxbValue
            // 
            this.TxbValue.Location = new System.Drawing.Point(228, 42);
            this.TxbValue.Name = "TxbValue";
            this.TxbValue.Size = new System.Drawing.Size(175, 27);
            this.TxbValue.TabIndex = 4;
            // 
            // LblPromt
            // 
            this.LblPromt.AutoSize = true;
            this.LblPromt.Location = new System.Drawing.Point(21, 88);
            this.LblPromt.Name = "LblPromt";
            this.LblPromt.Size = new System.Drawing.Size(173, 20);
            this.LblPromt.TabIndex = 5;
            this.LblPromt.Text = "Izaberite vrstu za brisaje!";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(21, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Odustani";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 20;
            this.ListBox1.Location = new System.Drawing.Point(21, 120);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(498, 284);
            this.ListBox1.TabIndex = 7;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // FrmRemoveUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.LblPromt);
            this.Controls.Add(this.TxbValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbxKey);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnSearch);
            this.Name = "FrmRemoveUser";
            this.Text = "Obriši korisnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnSearch;
        private Button BtnDelete;
        private ComboBox CbxKey;
        private Label label1;
        private TextBox TxbValue;
        private Label LblPromt;
        private Button btnCancel;
        private ListBox ListBox1;
    }
}