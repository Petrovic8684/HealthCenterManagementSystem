namespace Client
{
    partial class FrmPacijentCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPacijentCRUD));
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            lblPrezime = new Label();
            lblIme = new Label();
            tbEmail = new TextBox();
            lblMesto = new Label();
            lblEmail = new Label();
            btnOdustani = new Button();
            btnZapamti = new Button();
            btnObrisi = new Button();
            cbMesta = new ComboBox();
            lblPacijentId = new Label();
            SuspendLayout();
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(77, 148);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(220, 27);
            tbPrezime.TabIndex = 7;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(77, 73);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(220, 27);
            tbIme.TabIndex = 6;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(77, 125);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(65, 20);
            lblPrezime.TabIndex = 5;
            lblPrezime.Text = "Prezime:";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(77, 50);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(37, 20);
            lblIme.TabIndex = 4;
            lblIme.Text = "Ime:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(77, 224);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(220, 27);
            tbEmail.TabIndex = 10;
            // 
            // lblMesto
            // 
            lblMesto.AutoSize = true;
            lblMesto.Location = new Point(77, 276);
            lblMesto.Name = "lblMesto";
            lblMesto.Size = new Size(53, 20);
            lblMesto.TabIndex = 9;
            lblMesto.Text = "Mesto:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(77, 201);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
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
            btnOdustani.Location = new Point(357, 295);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(113, 35);
            btnOdustani.TabIndex = 35;
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
            btnZapamti.Location = new Point(357, 69);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(113, 35);
            btnZapamti.TabIndex = 34;
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
            btnObrisi.Location = new Point(357, 118);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(113, 35);
            btnObrisi.TabIndex = 37;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = false;
            // 
            // cbMesta
            // 
            cbMesta.BackColor = Color.White;
            cbMesta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMesta.FormattingEnabled = true;
            cbMesta.Location = new Point(77, 299);
            cbMesta.Name = "cbMesta";
            cbMesta.Size = new Size(220, 28);
            cbMesta.TabIndex = 38;
            // 
            // lblPacijentId
            // 
            lblPacijentId.AutoSize = true;
            lblPacijentId.ForeColor = SystemColors.ControlDarkDark;
            lblPacijentId.Location = new Point(12, 396);
            lblPacijentId.Name = "lblPacijentId";
            lblPacijentId.Size = new Size(153, 20);
            lblPacijentId.TabIndex = 51;
            lblPacijentId.Text = "Unos novog pacijenta";
            // 
            // FrmPacijentCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(554, 425);
            Controls.Add(lblPacijentId);
            Controls.Add(cbMesta);
            Controls.Add(btnObrisi);
            Controls.Add(btnOdustani);
            Controls.Add(btnZapamti);
            Controls.Add(tbEmail);
            Controls.Add(lblMesto);
            Controls.Add(lblEmail);
            Controls.Add(tbPrezime);
            Controls.Add(tbIme);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmPacijentCRUD";
            Text = "Sistem za praćenje rada doma zdravlja | Pacijent";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPrezime;
        private Label lblIme;
        private Label lblMesto;
        private Label lblEmail;
        private Button btnOdustani;
        private Button btnZapamti;
        private Button btnObrisi;
        private Label lblPacijentId;
        internal ComboBox cbMesta;
        internal TextBox tbPrezime;
        internal TextBox tbIme;
        internal TextBox tbEmail;
    }
}