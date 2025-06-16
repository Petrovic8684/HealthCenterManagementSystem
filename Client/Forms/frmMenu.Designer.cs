namespace Client
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            menuStrip1 = new MenuStrip();
            dokumentiToolStripMenuItem = new ToolStripMenuItem();
            zdravstveniKartonToolStripMenuItem = new ToolStripMenuItem();
            pružalacUslugeToolStripMenuItem = new ToolStripMenuItem();
            lekarToolStripMenuItem = new ToolStripMenuItem();
            primalacUslugeToolStripMenuItem = new ToolStripMenuItem();
            pacijentToolStripMenuItem = new ToolStripMenuItem();
            šifarniciToolStripMenuItem = new ToolStripMenuItem();
            dijagnozaToolStripMenuItem = new ToolStripMenuItem();
            mestoToolStripMenuItem = new ToolStripMenuItem();
            sertifikatToolStripMenuItem = new ToolStripMenuItem();
            pbMenu = new PictureBox();
            lblDobrodosli = new Label();
            btnOdjava = new Button();
            lblZelje = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dokumentiToolStripMenuItem, pružalacUslugeToolStripMenuItem, primalacUslugeToolStripMenuItem, šifarniciToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(780, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dokumentiToolStripMenuItem
            // 
            dokumentiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zdravstveniKartonToolStripMenuItem });
            dokumentiToolStripMenuItem.Name = "dokumentiToolStripMenuItem";
            dokumentiToolStripMenuItem.Size = new Size(96, 24);
            dokumentiToolStripMenuItem.Text = "Dokumenti";
            // 
            // zdravstveniKartonToolStripMenuItem
            // 
            zdravstveniKartonToolStripMenuItem.Name = "zdravstveniKartonToolStripMenuItem";
            zdravstveniKartonToolStripMenuItem.Size = new Size(214, 26);
            zdravstveniKartonToolStripMenuItem.Text = "Zdravstveni karton";
            // 
            // pružalacUslugeToolStripMenuItem
            // 
            pružalacUslugeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lekarToolStripMenuItem });
            pružalacUslugeToolStripMenuItem.Name = "pružalacUslugeToolStripMenuItem";
            pružalacUslugeToolStripMenuItem.Size = new Size(125, 24);
            pružalacUslugeToolStripMenuItem.Text = "Pružalac usluge";
            // 
            // lekarToolStripMenuItem
            // 
            lekarToolStripMenuItem.Name = "lekarToolStripMenuItem";
            lekarToolStripMenuItem.Size = new Size(127, 26);
            lekarToolStripMenuItem.Text = "Lekar";
            // 
            // primalacUslugeToolStripMenuItem
            // 
            primalacUslugeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pacijentToolStripMenuItem });
            primalacUslugeToolStripMenuItem.Name = "primalacUslugeToolStripMenuItem";
            primalacUslugeToolStripMenuItem.Size = new Size(127, 24);
            primalacUslugeToolStripMenuItem.Text = "Primalac usluge";
            // 
            // pacijentToolStripMenuItem
            // 
            pacijentToolStripMenuItem.Name = "pacijentToolStripMenuItem";
            pacijentToolStripMenuItem.Size = new Size(143, 26);
            pacijentToolStripMenuItem.Text = "Pacijent";
            // 
            // šifarniciToolStripMenuItem
            // 
            šifarniciToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dijagnozaToolStripMenuItem, mestoToolStripMenuItem, sertifikatToolStripMenuItem });
            šifarniciToolStripMenuItem.Name = "šifarniciToolStripMenuItem";
            šifarniciToolStripMenuItem.Size = new Size(76, 24);
            šifarniciToolStripMenuItem.Text = "Šifarnici";
            // 
            // dijagnozaToolStripMenuItem
            // 
            dijagnozaToolStripMenuItem.Name = "dijagnozaToolStripMenuItem";
            dijagnozaToolStripMenuItem.Size = new Size(160, 26);
            dijagnozaToolStripMenuItem.Text = "Dijagnoza";
            // 
            // mestoToolStripMenuItem
            // 
            mestoToolStripMenuItem.Name = "mestoToolStripMenuItem";
            mestoToolStripMenuItem.Size = new Size(160, 26);
            mestoToolStripMenuItem.Text = "Mesto";
            // 
            // sertifikatToolStripMenuItem
            // 
            sertifikatToolStripMenuItem.Name = "sertifikatToolStripMenuItem";
            sertifikatToolStripMenuItem.Size = new Size(160, 26);
            sertifikatToolStripMenuItem.Text = "Sertifikat";
            // 
            // pbMenu
            // 
            pbMenu.BackColor = Color.White;
            pbMenu.BackgroundImageLayout = ImageLayout.None;
            pbMenu.Image = (Image)resources.GetObject("pbMenu.Image");
            pbMenu.Location = new Point(67, 94);
            pbMenu.Margin = new Padding(0);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(304, 239);
            pbMenu.SizeMode = PictureBoxSizeMode.Zoom;
            pbMenu.TabIndex = 9;
            pbMenu.TabStop = false;
            // 
            // lblDobrodosli
            // 
            lblDobrodosli.AutoSize = true;
            lblDobrodosli.BackColor = Color.White;
            lblDobrodosli.Font = new Font("Segoe UI", 14F);
            lblDobrodosli.ImageAlign = ContentAlignment.MiddleLeft;
            lblDobrodosli.Location = new Point(409, 107);
            lblDobrodosli.Name = "lblDobrodosli";
            lblDobrodosli.Size = new Size(211, 32);
            lblDobrodosli.TabIndex = 10;
            lblDobrodosli.Text = "Dobro došli, Jovan";
            lblDobrodosli.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOdjava
            // 
            btnOdjava.BackColor = Color.White;
            btnOdjava.Cursor = Cursors.Hand;
            btnOdjava.FlatAppearance.BorderSize = 0;
            btnOdjava.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnOdjava.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnOdjava.FlatStyle = FlatStyle.Flat;
            btnOdjava.ForeColor = SystemColors.ControlText;
            btnOdjava.Location = new Point(409, 278);
            btnOdjava.Name = "btnOdjava";
            btnOdjava.Size = new Size(120, 35);
            btnOdjava.TabIndex = 11;
            btnOdjava.Text = "Odjavi se";
            btnOdjava.UseVisualStyleBackColor = false;
            // 
            // lblZelje
            // 
            lblZelje.BackColor = Color.White;
            lblZelje.Font = new Font("Segoe UI", 11F);
            lblZelje.ForeColor = Color.FromArgb(64, 64, 64);
            lblZelje.Location = new Point(409, 155);
            lblZelje.Name = "lblZelje";
            lblZelje.Size = new Size(331, 99);
            lblZelje.TabIndex = 12;
            lblZelje.Text = "Želimo Vam uspešan i prijatan rad u sistemu. Vaši podaci su ažurirani, a pacijenti Vas očekuju.\r\n";
            lblZelje.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(780, 450);
            Controls.Add(lblZelje);
            Controls.Add(btnOdjava);
            Controls.Add(lblDobrodosli);
            Controls.Add(pbMenu);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FrmMenu";
            Text = "Sistem za praćenje rada doma zdravlja";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dokumentiToolStripMenuItem;
        private ToolStripMenuItem zdravstveniKartonToolStripMenuItem;
        private ToolStripMenuItem pružalacUslugeToolStripMenuItem;
        private ToolStripMenuItem lekarToolStripMenuItem;
        private ToolStripMenuItem primalacUslugeToolStripMenuItem;
        private ToolStripMenuItem pacijentToolStripMenuItem;
        private ToolStripMenuItem šifarniciToolStripMenuItem;
        private ToolStripMenuItem dijagnozaToolStripMenuItem;
        private ToolStripMenuItem mestoToolStripMenuItem;
        private ToolStripMenuItem sertifikatToolStripMenuItem;
        private PictureBox pbMenu;
        private Label lblDobrodosli;
        private Button btnOdjava;
        private Label lblZelje;
    }
}