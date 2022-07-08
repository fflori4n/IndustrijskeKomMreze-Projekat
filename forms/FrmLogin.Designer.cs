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
            this.CbxComPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxbTcpIp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxbTcpPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(275, 318);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(143, 43);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(275, 367);
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
            this.label1.Location = new System.Drawing.Point(275, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // TxbUser
            // 
            this.TxbUser.Location = new System.Drawing.Point(275, 94);
            this.TxbUser.Name = "TxbUser";
            this.TxbUser.Size = new System.Drawing.Size(289, 27);
            this.TxbUser.TabIndex = 4;
            // 
            // TxbPass
            // 
            this.TxbPass.Location = new System.Drawing.Point(275, 147);
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
            this.BtnCancel.Location = new System.Drawing.Point(421, 318);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(143, 43);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CbxComPort
            // 
            this.CbxComPort.FormattingEnabled = true;
            this.CbxComPort.Location = new System.Drawing.Point(275, 200);
            this.CbxComPort.Name = "CbxComPort";
            this.CbxComPort.Size = new System.Drawing.Size(122, 28);
            this.CbxComPort.TabIndex = 8;
            this.CbxComPort.SelectedIndexChanged += new System.EventHandler(this.CbxComPort_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Serial connection to NFC reader : Com Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "TCP connection to gate RTU ";
            // 
            // TxbTcpIp
            // 
            this.TxbTcpIp.Location = new System.Drawing.Point(275, 264);
            this.TxbTcpIp.Name = "TxbTcpIp";
            this.TxbTcpIp.Size = new System.Drawing.Size(158, 27);
            this.TxbTcpIp.TabIndex = 11;
            this.TxbTcpIp.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = ":";
            // 
            // TxbTcpPort
            // 
            this.TxbTcpPort.Location = new System.Drawing.Point(457, 264);
            this.TxbTcpPort.Name = "TxbTcpPort";
            this.TxbTcpPort.Size = new System.Drawing.Size(158, 27);
            this.TxbTcpPort.TabIndex = 13;
            this.TxbTcpPort.Text = "7000";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxbTcpPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxbTcpIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbxComPort);
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
        private ComboBox CbxComPort;
        private Label label3;
        private Label label4;
        private TextBox TxbTcpIp;
        private Label label5;
        private TextBox TxbTcpPort;
    }
}