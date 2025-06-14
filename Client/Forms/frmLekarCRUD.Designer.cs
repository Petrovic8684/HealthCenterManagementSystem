namespace Client
{
    partial class FrmLekarCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLekarCRUD));
            tbEmail = new TextBox();
            lblEmail = new Label();
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            lblPrezime = new Label();
            lblIme = new Label();
            btnMinus = new Button();
            btnPlus = new Button();
            lbSertifikati = new ListBox();
            cbSertifikati = new ComboBox();
            lblSertifikati = new Label();
            btnOdustani = new Button();
            btnZapamti = new Button();
            btnObrisi = new Button();
            lblLekarId = new Label();
            lblSifra = new Label();
            tbSifra = new TextBox();
            SuspendLayout();
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(76, 236);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(220, 27);
            tbEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(76, 213);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email:";
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(76, 160);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(220, 27);
            tbPrezime.TabIndex = 1;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(76, 82);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(220, 27);
            tbIme.TabIndex = 0;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(76, 137);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(65, 20);
            lblPrezime.TabIndex = 12;
            lblPrezime.Text = "Prezime:";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(76, 59);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(37, 20);
            lblIme.TabIndex = 11;
            lblIme.Text = "Ime:";
            // 
            // btnMinus
            // 
            btnMinus.BackColor = Color.White;
            btnMinus.Cursor = Cursors.Hand;
            btnMinus.FlatAppearance.BorderSize = 0;
            btnMinus.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnMinus.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinus.ForeColor = SystemColors.ControlText;
            btnMinus.Location = new Point(593, 116);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(28, 28);
            btnMinus.TabIndex = 6;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = false;
            // 
            // btnPlus
            // 
            btnPlus.BackColor = Color.White;
            btnPlus.Cursor = Cursors.Hand;
            btnPlus.FlatAppearance.BorderSize = 0;
            btnPlus.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnPlus.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnPlus.FlatStyle = FlatStyle.Flat;
            btnPlus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPlus.ForeColor = SystemColors.ControlText;
            btnPlus.Location = new Point(593, 82);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(28, 28);
            btnPlus.TabIndex = 5;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = false;
            // 
            // lbSertifikati
            // 
            lbSertifikati.FormattingEnabled = true;
            lbSertifikati.Location = new Point(361, 116);
            lbSertifikati.Name = "lbSertifikati";
            lbSertifikati.ScrollAlwaysVisible = true;
            lbSertifikati.Size = new Size(226, 224);
            lbSertifikati.TabIndex = 35;
            lbSertifikati.TabStop = false;
            // 
            // cbSertifikati
            // 
            cbSertifikati.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSertifikati.FormattingEnabled = true;
            cbSertifikati.Location = new Point(361, 82);
            cbSertifikati.Name = "cbSertifikati";
            cbSertifikati.Size = new Size(226, 28);
            cbSertifikati.TabIndex = 4;
            // 
            // lblSertifikati
            // 
            lblSertifikati.AutoSize = true;
            lblSertifikati.Location = new Point(361, 59);
            lblSertifikati.Name = "lblSertifikati";
            lblSertifikati.Size = new Size(75, 20);
            lblSertifikati.TabIndex = 33;
            lblSertifikati.Text = "Sertifikati:";
            // 
            // btnOdustani
            // 
            btnOdustani.BackColor = Color.White;
            btnOdustani.Cursor = Cursors.Hand;
            btnOdustani.FlatAppearance.BorderSize = 0;
            btnOdustani.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnOdustani.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnOdustani.FlatStyle = FlatStyle.Flat;
            btnOdustani.ForeColor = SystemColors.ControlText;
            btnOdustani.Location = new Point(474, 403);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(113, 38);
            btnOdustani.TabIndex = 9;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = false;
            // 
            // btnZapamti
            // 
            btnZapamti.BackColor = Color.White;
            btnZapamti.Cursor = Cursors.Hand;
            btnZapamti.FlatAppearance.BorderSize = 0;
            btnZapamti.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnZapamti.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnZapamti.FlatStyle = FlatStyle.Flat;
            btnZapamti.ForeColor = SystemColors.ControlText;
            btnZapamti.Location = new Point(76, 403);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(113, 38);
            btnZapamti.TabIndex = 7;
            btnZapamti.Text = "Zapamti";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // btnObrisi
            // 
            btnObrisi.BackColor = Color.White;
            btnObrisi.Cursor = Cursors.Hand;
            btnObrisi.Enabled = false;
            btnObrisi.FlatAppearance.BorderSize = 0;
            btnObrisi.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnObrisi.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnObrisi.FlatStyle = FlatStyle.Flat;
            btnObrisi.ForeColor = SystemColors.ControlText;
            btnObrisi.Location = new Point(207, 403);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(113, 38);
            btnObrisi.TabIndex = 8;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = false;
            // 
            // lblLekarId
            // 
            lblLekarId.AutoSize = true;
            lblLekarId.ForeColor = SystemColors.ControlDarkDark;
            lblLekarId.Location = new Point(12, 488);
            lblLekarId.Name = "lblLekarId";
            lblLekarId.Size = new Size(132, 20);
            lblLekarId.TabIndex = 50;
            lblLekarId.Text = "Unos novog lekara";
            // 
            // lblSifra
            // 
            lblSifra.AutoSize = true;
            lblSifra.Location = new Point(76, 290);
            lblSifra.Name = "lblSifra";
            lblSifra.Size = new Size(42, 20);
            lblSifra.TabIndex = 51;
            lblSifra.Text = "Sifra:";
            // 
            // tbSifra
            // 
            tbSifra.Location = new Point(76, 313);
            tbSifra.Name = "tbSifra";
            tbSifra.Size = new Size(220, 27);
            tbSifra.TabIndex = 3;
            tbSifra.UseSystemPasswordChar = true;
            // 
            // FrmLekarCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(669, 517);
            Controls.Add(tbSifra);
            Controls.Add(lblSifra);
            Controls.Add(lblLekarId);
            Controls.Add(btnObrisi);
            Controls.Add(btnOdustani);
            Controls.Add(btnZapamti);
            Controls.Add(btnMinus);
            Controls.Add(btnPlus);
            Controls.Add(lbSertifikati);
            Controls.Add(cbSertifikati);
            Controls.Add(lblSertifikati);
            Controls.Add(tbEmail);
            Controls.Add(lblEmail);
            Controls.Add(tbPrezime);
            Controls.Add(tbIme);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmLekarCRUD";
            Text = "Sistem za praćenje rada doma zdravlja | Lekar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblEmail;
        private Label lblPrezime;
        private Label lblIme;
        private Button btnMinus;
        private Button btnPlus;
        private Label lblSertifikati;
        private Button btnOdustani;
        private Button btnZapamti;
        private Button btnObrisi;
        private Label lblLekarId;
        private Label lblSifra;
        internal TextBox tbEmail;
        internal TextBox tbPrezime;
        internal TextBox tbIme;
        internal ListBox lbSertifikati;
        internal ComboBox cbSertifikati;
        internal TextBox tbSifra;
    }
}