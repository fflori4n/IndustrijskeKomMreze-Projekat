namespace ProjektniZadatak.forms
{
    partial class FrmLogin
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
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbUser = new System.Windows.Forms.TextBox();
            this.TxbPass = new System.Windows.Forms.TextBox();
            this.LblLoginPromt = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(275, 286);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(143, 43);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(275, 332);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(143, 43);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // TxbUser
            // 
            this.TxbUser.Location = new System.Drawing.Point(275, 167);
            this.TxbUser.Name = "TxbUser";
            this.TxbUser.Size = new System.Drawing.Size(289, 27);
            this.TxbUser.TabIndex = 4;
            // 
            // TxbPass
            // 
            this.TxbPass.Location = new System.Drawing.Point(275, 234);
            this.TxbPass.Name = "TxbPass";
            this.TxbPass.Size = new System.Drawing.Size(289, 27);
            this.TxbPass.TabIndex = 5;
            // 
            // LblLoginPromt
            // 
            this.LblLoginPromt.AutoSize = true;
            this.LblLoginPromt.Location = new System.Drawing.Point(275, 332);
            this.LblLoginPromt.Name = "LblLoginPromt";
            this.LblLoginPromt.Size = new System.Drawing.Size(0, 20);
            this.LblLoginPromt.TabIndex = 6;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(421, 286);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(143, 43);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LblLoginPromt);
            this.Controls.Add(this.TxbPass);
            this.Controls.Add(this.TxbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnLogin);
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnLogin;
        private Button BtnExit;
        private Label label1;
        private Label label2;
        private TextBox TxbUser;
        private TextBox TxbPass;
        private Label LblLoginPromt;
        private Button BtnCancel;
    }
}