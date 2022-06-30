namespace ProjektniZadatak;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnShow = new System.Windows.Forms.Button();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnAccGranted = new System.Windows.Forms.Button();
            this.BtnFinished = new System.Windows.Forms.Button();
            this.BtnClearTerminal = new System.Windows.Forms.Button();
            this.ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DropMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LblUser0 = new System.Windows.Forms.ToolStripTextBox();
            this.BtnLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(38, 34);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(105, 42);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = "Dodaj";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(38, 82);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(105, 42);
            this.BtnRemove.TabIndex = 1;
            this.BtnRemove.Text = "Obriši";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.Location = new System.Drawing.Point(38, 130);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(105, 42);
            this.BtnShow.TabIndex = 2;
            this.BtnShow.Text = "Prikaži";
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(38, 178);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(105, 42);
            this.BtnChange.TabIndex = 3;
            this.BtnChange.Text = "Izmeni";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnAccGranted
            // 
            this.BtnAccGranted.Location = new System.Drawing.Point(38, 274);
            this.BtnAccGranted.Name = "BtnAccGranted";
            this.BtnAccGranted.Size = new System.Drawing.Size(105, 42);
            this.BtnAccGranted.TabIndex = 4;
            this.BtnAccGranted.Text = "Dozvola";
            this.BtnAccGranted.UseVisualStyleBackColor = true;
            this.BtnAccGranted.Click += new System.EventHandler(this.BtnAccGranted_Click);
            // 
            // BtnFinished
            // 
            this.BtnFinished.Location = new System.Drawing.Point(38, 396);
            this.BtnFinished.Name = "BtnFinished";
            this.BtnFinished.Size = new System.Drawing.Size(163, 42);
            this.BtnFinished.TabIndex = 5;
            this.BtnFinished.Text = "Kraj";
            this.BtnFinished.UseVisualStyleBackColor = true;
            this.BtnFinished.Click += new System.EventHandler(this.BtnFinished_Click);
            // 
            // BtnClearTerminal
            // 
            this.BtnClearTerminal.Location = new System.Drawing.Point(207, 396);
            this.BtnClearTerminal.Name = "BtnClearTerminal";
            this.BtnClearTerminal.Size = new System.Drawing.Size(163, 42);
            this.BtnClearTerminal.TabIndex = 6;
            this.BtnClearTerminal.Text = "Obriši Prikaz";
            this.BtnClearTerminal.UseVisualStyleBackColor = true;
            this.BtnClearTerminal.Click += new System.EventHandler(this.BtnClearTerminal_Click);
            // 
            // ListView
            // 
            this.ListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ListView.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListView.FullRowSelect = true;
            this.ListView.Location = new System.Drawing.Point(207, 60);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(581, 330);
            this.ListView.TabIndex = 7;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.List;
            //this.ListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DropMenu
            // 
            this.DropMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblUser0,
            this.BtnLogin,
            this.BtnLogout});
            this.DropMenu.Name = "DropMenu";
            this.DropMenu.Size = new System.Drawing.Size(52, 24);
            this.DropMenu.Text = "User";
            //this.DropMenu.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // LblUser0
            // 
            this.LblUser0.Name = "LblUser0";
            this.LblUser0.Size = new System.Drawing.Size(100, 27);
            this.LblUser0.Text = "Not logged in!";
            //this.LblUser0.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(174, 26);
            this.BtnLogin.Text = "Login";
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click_1);
            // 
            // BtnLogout
            // 
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(174, 26);
            this.BtnLogout.Text = "Logout";
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.BtnClearTerminal);
            this.Controls.Add(this.BtnFinished);
            this.Controls.Add(this.BtnAccGranted);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Kontrola Pristupa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button BtnAdd;
    private Button BtnRemove;
    private Button BtnShow;
    private Button BtnChange;
    private Button BtnAccGranted;
    private Button BtnFinished;
    private Button BtnClearTerminal;
    public ListView ListView;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem DropMenu;
    private ToolStripTextBox LblUser0;
    private ToolStripMenuItem BtnLogin;
    private ToolStripMenuItem BtnLogout;
    private ColumnHeader columnHeader1;
}
