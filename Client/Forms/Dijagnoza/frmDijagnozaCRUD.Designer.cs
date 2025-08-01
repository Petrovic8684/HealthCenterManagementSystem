namespace Client
{
    partial class FrmDijagnozaCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDijagnozaCRUD));
            tbOpis = new TextBox();
            tbNaziv = new TextBox();
            lblOpis = new Label();
            lblNaziv = new Label();
            tbBazniSkor = new TextBox();
            lblBazniSkor = new Label();
            btnObrisi = new Button();
            btnOdustani = new Button();
            btnZapamti = new Button();
            lblDijagnozaId = new Label();
            SuspendLayout();
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(75, 153);
            tbOpis.Multiline = true;
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(263, 63);
            tbOpis.TabIndex = 1;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(75, 73);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(234, 27);
            tbNaziv.TabIndex = 0;
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Location = new Point(75, 130);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(42, 20);
            lblOpis.TabIndex = 25;
            lblOpis.Text = "Opis:";
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Location = new Point(75, 50);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(49, 20);
            lblNaziv.TabIndex = 26;
            lblNaziv.Text = "Naziv:";
            // 
            // tbBazniSkor
            // 
            tbBazniSkor.Location = new Point(75, 276);
            tbBazniSkor.Name = "tbBazniSkor";
            tbBazniSkor.Size = new Size(234, 27);
            tbBazniSkor.TabIndex = 2;
            // 
            // lblBazniSkor
            // 
            lblBazniSkor.AutoSize = true;
            lblBazniSkor.Location = new Point(75, 253);
            lblBazniSkor.Name = "lblBazniSkor";
            lblBazniSkor.Size = new Size(79, 20);
            lblBazniSkor.TabIndex = 29;
            lblBazniSkor.Text = "Bazni skor:";
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
            btnObrisi.Location = new Point(417, 123);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(113, 35);
            btnObrisi.TabIndex = 4;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = false;
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
            btnOdustani.Location = new Point(417, 272);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(113, 35);
            btnOdustani.TabIndex = 5;
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
            btnZapamti.Location = new Point(417, 69);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(113, 35);
            btnZapamti.TabIndex = 3;
            btnZapamti.Text = "Zapamti";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // lblDijagnozaId
            // 
            lblDijagnozaId.AutoSize = true;
            lblDijagnozaId.ForeColor = SystemColors.ControlDarkDark;
            lblDijagnozaId.Location = new Point(12, 345);
            lblDijagnozaId.Name = "lblDijagnozaId";
            lblDijagnozaId.Size = new Size(148, 20);
            lblDijagnozaId.TabIndex = 51;
            lblDijagnozaId.Text = "Unos nove dijagnoze";
            // 
            // FrmDijagnozaCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(610, 374);
            ControlBox = false;
            Controls.Add(lblDijagnozaId);
            Controls.Add(btnObrisi);
            Controls.Add(btnOdustani);
            Controls.Add(btnZapamti);
            Controls.Add(tbBazniSkor);
            Controls.Add(lblBazniSkor);
            Controls.Add(tbOpis);
            Controls.Add(tbNaziv);
            Controls.Add(lblOpis);
            Controls.Add(lblNaziv);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmDijagnozaCRUD";
            Text = "Sistem za praćenje rada doma zdravlja | Dijagnoza";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblOpis;
        private Label lblNaziv;
        private Label lblBazniSkor;
        private Button btnObrisi;
        private Button btnOdustani;
        private Button btnZapamti;
        private Label lblDijagnozaId;
        internal TextBox tbOpis;
        internal TextBox tbNaziv;
        internal TextBox tbBazniSkor;
    }
}