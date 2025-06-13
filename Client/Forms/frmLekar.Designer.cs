namespace Client
{
    partial class FrmLekar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLekar));
            gbAkcije = new GroupBox();
            btnDetalji = new Button();
            btnPretrazi = new Button();
            btnKreirajNovog = new Button();
            gbKriterijumi = new GroupBox();
            tbPrezime = new TextBox();
            lblPrezime = new Label();
            cbSertifikati = new ComboBox();
            tbIme = new TextBox();
            lblPosedujeSertifikat = new Label();
            lblIme = new Label();
            dgvLekari = new DataGridView();
            gbAkcije.SuspendLayout();
            gbKriterijumi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLekari).BeginInit();
            SuspendLayout();
            // 
            // gbAkcije
            // 
            gbAkcije.Controls.Add(btnDetalji);
            gbAkcije.Controls.Add(btnPretrazi);
            gbAkcije.Controls.Add(btnKreirajNovog);
            gbAkcije.Location = new Point(517, 45);
            gbAkcije.Name = "gbAkcije";
            gbAkcije.Size = new Size(272, 258);
            gbAkcije.TabIndex = 24;
            gbAkcije.TabStop = false;
            gbAkcije.Text = "Akcije";
            // 
            // btnDetalji
            // 
            btnDetalji.BackColor = Color.White;
            btnDetalji.Cursor = Cursors.Hand;
            btnDetalji.FlatAppearance.BorderSize = 0;
            btnDetalji.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnDetalji.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnDetalji.FlatStyle = FlatStyle.Flat;
            btnDetalji.ForeColor = SystemColors.ControlText;
            btnDetalji.Location = new Point(79, 184);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(113, 35);
            btnDetalji.TabIndex = 19;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = false;
            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.White;
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnPretrazi.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.ForeColor = SystemColors.ControlText;
            btnPretrazi.Location = new Point(79, 55);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(113, 35);
            btnPretrazi.TabIndex = 17;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // btnKreirajNovog
            // 
            btnKreirajNovog.BackColor = Color.White;
            btnKreirajNovog.Cursor = Cursors.Hand;
            btnKreirajNovog.FlatAppearance.BorderSize = 0;
            btnKreirajNovog.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnKreirajNovog.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnKreirajNovog.FlatStyle = FlatStyle.Flat;
            btnKreirajNovog.ForeColor = SystemColors.ControlText;
            btnKreirajNovog.Location = new Point(79, 120);
            btnKreirajNovog.Name = "btnKreirajNovog";
            btnKreirajNovog.Size = new Size(113, 35);
            btnKreirajNovog.TabIndex = 18;
            btnKreirajNovog.Text = "Kreiraj novog";
            btnKreirajNovog.UseVisualStyleBackColor = false;
            // 
            // gbKriterijumi
            // 
            gbKriterijumi.Controls.Add(tbPrezime);
            gbKriterijumi.Controls.Add(lblPrezime);
            gbKriterijumi.Controls.Add(cbSertifikati);
            gbKriterijumi.Controls.Add(tbIme);
            gbKriterijumi.Controls.Add(lblPosedujeSertifikat);
            gbKriterijumi.Controls.Add(lblIme);
            gbKriterijumi.Location = new Point(101, 45);
            gbKriterijumi.Name = "gbKriterijumi";
            gbKriterijumi.Size = new Size(375, 258);
            gbKriterijumi.TabIndex = 26;
            gbKriterijumi.TabStop = false;
            gbKriterijumi.Text = "Kriterijumi pretrage";
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(55, 129);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(234, 27);
            tbPrezime.TabIndex = 15;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(55, 106);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(65, 20);
            lblPrezime.TabIndex = 14;
            lblPrezime.Text = "Prezime:";
            // 
            // cbSertifikati
            // 
            cbSertifikati.BackColor = Color.White;
            cbSertifikati.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSertifikati.FormattingEnabled = true;
            cbSertifikati.Location = new Point(55, 197);
            cbSertifikati.Name = "cbSertifikati";
            cbSertifikati.Size = new Size(234, 28);
            cbSertifikati.TabIndex = 13;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(55, 65);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(234, 27);
            tbIme.TabIndex = 12;
            // 
            // lblPosedujeSertifikat
            // 
            lblPosedujeSertifikat.AutoSize = true;
            lblPosedujeSertifikat.Location = new Point(55, 174);
            lblPosedujeSertifikat.Name = "lblPosedujeSertifikat";
            lblPosedujeSertifikat.Size = new Size(132, 20);
            lblPosedujeSertifikat.TabIndex = 0;
            lblPosedujeSertifikat.Text = "Poseduje sertifikat:";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(55, 42);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(37, 20);
            lblIme.TabIndex = 1;
            lblIme.Text = "Ime:";
            // 
            // dgvLekari
            // 
            dgvLekari.AllowUserToAddRows = false;
            dgvLekari.AllowUserToDeleteRows = false;
            dgvLekari.BackgroundColor = Color.White;
            dgvLekari.BorderStyle = BorderStyle.None;
            dgvLekari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLekari.Location = new Point(101, 329);
            dgvLekari.MultiSelect = false;
            dgvLekari.Name = "dgvLekari";
            dgvLekari.RowHeadersWidth = 51;
            dgvLekari.Size = new Size(688, 272);
            dgvLekari.TabIndex = 29;
            // 
            // FrmLekar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(894, 632);
            Controls.Add(dgvLekari);
            Controls.Add(gbAkcije);
            Controls.Add(gbKriterijumi);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmLekar";
            Text = "Sistem za praćenje rada doma zdravlja | Lekar";
            gbAkcije.ResumeLayout(false);
            gbKriterijumi.ResumeLayout(false);
            gbKriterijumi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLekari).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbAkcije;
        private Button btnDetalji;
        private Button btnPretrazi;
        private Button btnKreirajNovog;
        private GroupBox gbKriterijumi;
        private Label lblPosedujeSertifikat;
        private Label lblIme;
        private Label lblPrezime;
        internal DataGridView dgvLekari;
        internal ComboBox cbSertifikati;
        internal TextBox tbIme;
        internal TextBox tbPrezime;
    }
}