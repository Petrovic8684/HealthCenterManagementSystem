namespace Client
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lblEmail = new Label();
            lblSifra = new Label();
            tbEmail = new TextBox();
            tbSifra = new TextBox();
            btnPrijava = new Button();
            pbLogin = new PictureBox();
            menuStrip1 = new MenuStrip();
            podešavanjaSoftverskogSistemaToolStripMenuItem = new ToolStripMenuItem();
            oProgramuToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbLogin).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(89, 73);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // lblSifra
            // 
            lblSifra.AutoSize = true;
            lblSifra.Location = new Point(89, 148);
            lblSifra.Name = "lblSifra";
            lblSifra.Size = new Size(42, 20);
            lblSifra.TabIndex = 1;
            lblSifra.Text = "Sifra:";
            // 
            // tbEmail
            // 
            tbEmail.BackColor = SystemColors.Window;
            tbEmail.Location = new Point(89, 96);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(220, 27);
            tbEmail.TabIndex = 2;
            // 
            // tbSifra
            // 
            tbSifra.Location = new Point(89, 171);
            tbSifra.Name = "tbSifra";
            tbSifra.Size = new Size(220, 27);
            tbSifra.TabIndex = 3;
            tbSifra.UseSystemPasswordChar = true;
            // 
            // btnPrijava
            // 
            btnPrijava.BackColor = Color.White;
            btnPrijava.Cursor = Cursors.Hand;
            btnPrijava.FlatAppearance.BorderSize = 0;
            btnPrijava.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnPrijava.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnPrijava.FlatStyle = FlatStyle.Flat;
            btnPrijava.ForeColor = SystemColors.ControlText;
            btnPrijava.Location = new Point(89, 239);
            btnPrijava.Name = "btnPrijava";
            btnPrijava.Size = new Size(113, 35);
            btnPrijava.TabIndex = 5;
            btnPrijava.Text = "Prijavi se";
            btnPrijava.UseVisualStyleBackColor = false;
            // 
            // pbLogin
            // 
            pbLogin.BackColor = Color.White;
            pbLogin.BackgroundImageLayout = ImageLayout.None;
            pbLogin.Image = (Image)resources.GetObject("pbLogin.Image");
            pbLogin.Location = new Point(385, 46);
            pbLogin.Margin = new Padding(0);
            pbLogin.Name = "pbLogin";
            pbLogin.Size = new Size(361, 256);
            pbLogin.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogin.TabIndex = 6;
            pbLogin.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { podešavanjaSoftverskogSistemaToolStripMenuItem, oProgramuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(801, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // podešavanjaSoftverskogSistemaToolStripMenuItem
            // 
            podešavanjaSoftverskogSistemaToolStripMenuItem.Name = "podešavanjaSoftverskogSistemaToolStripMenuItem";
            podešavanjaSoftverskogSistemaToolStripMenuItem.Size = new Size(239, 24);
            podešavanjaSoftverskogSistemaToolStripMenuItem.Text = "Podešavanja softverskog sistema";
            // 
            // oProgramuToolStripMenuItem
            // 
            oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            oProgramuToolStripMenuItem.Size = new Size(104, 24);
            oProgramuToolStripMenuItem.Text = "O programu";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(801, 348);
            Controls.Add(pbLogin);
            Controls.Add(btnPrijava);
            Controls.Add(tbSifra);
            Controls.Add(tbEmail);
            Controls.Add(lblSifra);
            Controls.Add(lblEmail);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FrmLogin";
            Text = "Sistem za praćenje rada doma zdravlja | Prijava";
            ((System.ComponentModel.ISupportInitialize)pbLogin).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private Label lblSifra;
        private Button btnPrijava;
        private PictureBox pbLogin;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem podešavanjaSoftverskogSistemaToolStripMenuItem;
        private ToolStripMenuItem oProgramuToolStripMenuItem;
        internal TextBox tbEmail;
        internal TextBox tbSifra;
    }
}
