namespace Client
{
    partial class FrmDijagnoza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDijagnoza));
            gbAkcije = new GroupBox();
            btnDetalji = new Button();
            btnPretrazi = new Button();
            btnKreirajNovu = new Button();
            gbKriterijumi = new GroupBox();
            tbOpis = new TextBox();
            tbNaziv = new TextBox();
            lblOpis = new Label();
            lblNaziv = new Label();
            dgvDijagnoze = new DataGridView();
            gbAkcije.SuspendLayout();
            gbKriterijumi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDijagnoze).BeginInit();
            SuspendLayout();
            // 
            // gbAkcije
            // 
            gbAkcije.Controls.Add(btnDetalji);
            gbAkcije.Controls.Add(btnPretrazi);
            gbAkcije.Controls.Add(btnKreirajNovu);
            gbAkcije.Location = new Point(520, 55);
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
            // btnKreirajNovu
            // 
            btnKreirajNovu.BackColor = Color.White;
            btnKreirajNovu.Cursor = Cursors.Hand;
            btnKreirajNovu.FlatAppearance.BorderSize = 0;
            btnKreirajNovu.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnKreirajNovu.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnKreirajNovu.FlatStyle = FlatStyle.Flat;
            btnKreirajNovu.ForeColor = SystemColors.ControlText;
            btnKreirajNovu.Location = new Point(79, 120);
            btnKreirajNovu.Name = "btnKreirajNovu";
            btnKreirajNovu.Size = new Size(113, 35);
            btnKreirajNovu.TabIndex = 18;
            btnKreirajNovu.Text = "Kreiraj novu";
            btnKreirajNovu.UseVisualStyleBackColor = false;
            // 
            // gbKriterijumi
            // 
            gbKriterijumi.Controls.Add(tbOpis);
            gbKriterijumi.Controls.Add(tbNaziv);
            gbKriterijumi.Controls.Add(lblOpis);
            gbKriterijumi.Controls.Add(lblNaziv);
            gbKriterijumi.Location = new Point(104, 55);
            gbKriterijumi.Name = "gbKriterijumi";
            gbKriterijumi.Size = new Size(375, 258);
            gbKriterijumi.TabIndex = 26;
            gbKriterijumi.TabStop = false;
            gbKriterijumi.Text = "Kriterijumi pretrage";
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(55, 158);
            tbOpis.Multiline = true;
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(263, 63);
            tbOpis.TabIndex = 24;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(55, 78);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(234, 27);
            tbNaziv.TabIndex = 12;
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Location = new Point(55, 135);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(42, 20);
            lblOpis.TabIndex = 0;
            lblOpis.Text = "Opis:";
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Location = new Point(55, 55);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(49, 20);
            lblNaziv.TabIndex = 1;
            lblNaziv.Text = "Naziv:";
            // 
            // dgvDijagnoze
            // 
            dgvDijagnoze.AllowUserToAddRows = false;
            dgvDijagnoze.AllowUserToDeleteRows = false;
            dgvDijagnoze.BackgroundColor = Color.White;
            dgvDijagnoze.BorderStyle = BorderStyle.None;
            dgvDijagnoze.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDijagnoze.Location = new Point(104, 339);
            dgvDijagnoze.MultiSelect = false;
            dgvDijagnoze.Name = "dgvDijagnoze";
            dgvDijagnoze.RowHeadersWidth = 51;
            dgvDijagnoze.Size = new Size(688, 272);
            dgvDijagnoze.TabIndex = 31;
            // 
            // FrmDijagnoza
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(907, 646);
            Controls.Add(dgvDijagnoze);
            Controls.Add(gbAkcije);
            Controls.Add(gbKriterijumi);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmDijagnoza";
            Text = "Sistem za praćenje rada doma zdravlja | Dijagnoza";
            gbAkcije.ResumeLayout(false);
            gbKriterijumi.ResumeLayout(false);
            gbKriterijumi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDijagnoze).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbAkcije;
        private Button btnDetalji;
        private Button btnPretrazi;
        private Button btnKreirajNovu;
        private GroupBox gbKriterijumi;
        private Label lblOpis;
        private Label lblNaziv;
        internal TextBox tbNaziv;
        internal TextBox tbOpis;
        internal DataGridView dgvDijagnoze;
    }
}