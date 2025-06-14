namespace Client
{
    partial class FrmSertifikat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSertifikat));
            gbAkcije = new GroupBox();
            btnDetalji = new Button();
            btnPretrazi = new Button();
            btnKreirajNovo = new Button();
            gbKriterijumi = new GroupBox();
            tbOpis = new TextBox();
            lblOpis = new Label();
            dgvSertifikati = new DataGridView();
            gbAkcije.SuspendLayout();
            gbKriterijumi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSertifikati).BeginInit();
            SuspendLayout();
            // 
            // gbAkcije
            // 
            gbAkcije.Controls.Add(btnDetalji);
            gbAkcije.Controls.Add(btnPretrazi);
            gbAkcije.Controls.Add(btnKreirajNovo);
            gbAkcije.Location = new Point(508, 60);
            gbAkcije.Name = "gbAkcije";
            gbAkcije.Size = new Size(272, 258);
            gbAkcije.TabIndex = 1;
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
            btnDetalji.TabIndex = 3;
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
            btnPretrazi.TabIndex = 1;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // btnKreirajNovo
            // 
            btnKreirajNovo.BackColor = Color.White;
            btnKreirajNovo.Cursor = Cursors.Hand;
            btnKreirajNovo.FlatAppearance.BorderSize = 0;
            btnKreirajNovo.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnKreirajNovo.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnKreirajNovo.FlatStyle = FlatStyle.Flat;
            btnKreirajNovo.ForeColor = SystemColors.ControlText;
            btnKreirajNovo.Location = new Point(79, 120);
            btnKreirajNovo.Name = "btnKreirajNovo";
            btnKreirajNovo.Size = new Size(113, 35);
            btnKreirajNovo.TabIndex = 2;
            btnKreirajNovo.Text = "Kreiraj novo";
            btnKreirajNovo.UseVisualStyleBackColor = false;
            // 
            // gbKriterijumi
            // 
            gbKriterijumi.Controls.Add(tbOpis);
            gbKriterijumi.Controls.Add(lblOpis);
            gbKriterijumi.Location = new Point(92, 60);
            gbKriterijumi.Name = "gbKriterijumi";
            gbKriterijumi.Size = new Size(375, 258);
            gbKriterijumi.TabIndex = 0;
            gbKriterijumi.TabStop = false;
            gbKriterijumi.Text = "Kriterijumi pretrage";
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(55, 78);
            tbOpis.Multiline = true;
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(263, 138);
            tbOpis.TabIndex = 0;
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Location = new Point(55, 55);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(42, 20);
            lblOpis.TabIndex = 1;
            lblOpis.Text = "Opis:";
            // 
            // dgvSertifikati
            // 
            dgvSertifikati.AllowUserToAddRows = false;
            dgvSertifikati.AllowUserToDeleteRows = false;
            dgvSertifikati.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSertifikati.BackgroundColor = Color.White;
            dgvSertifikati.BorderStyle = BorderStyle.None;
            dgvSertifikati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSertifikati.Location = new Point(92, 338);
            dgvSertifikati.MultiSelect = false;
            dgvSertifikati.Name = "dgvSertifikati";
            dgvSertifikati.RowHeadersWidth = 51;
            dgvSertifikati.Size = new Size(688, 272);
            dgvSertifikati.TabIndex = 28;
            dgvSertifikati.TabStop = false;
            // 
            // FrmSertifikat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(888, 649);
            Controls.Add(gbAkcije);
            Controls.Add(gbKriterijumi);
            Controls.Add(dgvSertifikati);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmSertifikat";
            Text = "Sistem za praćenje rada doma zdravlja | Sertifikat";
            gbAkcije.ResumeLayout(false);
            gbKriterijumi.ResumeLayout(false);
            gbKriterijumi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSertifikati).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbAkcije;
        private Button btnDetalji;
        private Button btnPretrazi;
        private Button btnKreirajNovo;
        private GroupBox gbKriterijumi;
        private TextBox tbNaziv;
        private Label lblPostanskiBroj;
        private TextBox tbPostanskiBroj;
        private Label lblOpis;
        private TextBox tbOpis;
        internal DataGridView dgvSertifikati;
    }
}