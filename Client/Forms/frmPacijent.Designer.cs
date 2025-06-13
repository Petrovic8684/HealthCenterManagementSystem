namespace Client
{
    partial class FrmPacijent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPacijent));
            gbKriterijumi = new GroupBox();
            tbPrezime = new TextBox();
            lblPrezime = new Label();
            lblMesto = new Label();
            tbIme = new TextBox();
            lblIme = new Label();
            gbAkcije = new GroupBox();
            btnDetalji = new Button();
            btnPretrazi = new Button();
            btnKreirajNovog = new Button();
            cbMesta = new ComboBox();
            dgvPacijenti = new DataGridView();
            gbKriterijumi.SuspendLayout();
            gbAkcije.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacijenti).BeginInit();
            SuspendLayout();
            // 
            // gbKriterijumi
            // 
            gbKriterijumi.Controls.Add(cbMesta);
            gbKriterijumi.Controls.Add(tbPrezime);
            gbKriterijumi.Controls.Add(lblPrezime);
            gbKriterijumi.Controls.Add(lblMesto);
            gbKriterijumi.Controls.Add(tbIme);
            gbKriterijumi.Controls.Add(lblIme);
            gbKriterijumi.Location = new Point(102, 48);
            gbKriterijumi.Name = "gbKriterijumi";
            gbKriterijumi.Size = new Size(375, 258);
            gbKriterijumi.TabIndex = 23;
            gbKriterijumi.TabStop = false;
            gbKriterijumi.Text = "Kriterijumi pretrage";
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(55, 127);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(234, 27);
            tbPrezime.TabIndex = 27;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(55, 104);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(65, 20);
            lblPrezime.TabIndex = 26;
            lblPrezime.Text = "Prezime:";
            // 
            // lblMesto
            // 
            lblMesto.AutoSize = true;
            lblMesto.Location = new Point(55, 168);
            lblMesto.Name = "lblMesto";
            lblMesto.Size = new Size(53, 20);
            lblMesto.TabIndex = 0;
            lblMesto.Text = "Mesto:";
            // 
            // tbIme
            // 
            tbIme.Location = new Point(55, 63);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(234, 27);
            tbIme.TabIndex = 25;
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(55, 40);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(37, 20);
            lblIme.TabIndex = 24;
            lblIme.Text = "Ime:";
            // 
            // gbAkcije
            // 
            gbAkcije.Controls.Add(btnDetalji);
            gbAkcije.Controls.Add(btnPretrazi);
            gbAkcije.Controls.Add(btnKreirajNovog);
            gbAkcije.Location = new Point(518, 48);
            gbAkcije.Name = "gbAkcije";
            gbAkcije.Size = new Size(272, 258);
            gbAkcije.TabIndex = 22;
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
            // cbMesta
            // 
            cbMesta.BackColor = Color.White;
            cbMesta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMesta.FormattingEnabled = true;
            cbMesta.Location = new Point(55, 191);
            cbMesta.Name = "cbMesta";
            cbMesta.Size = new Size(234, 28);
            cbMesta.TabIndex = 28;
            // 
            // dgvPacijenti
            // 
            dgvPacijenti.AllowUserToAddRows = false;
            dgvPacijenti.AllowUserToDeleteRows = false;
            dgvPacijenti.BackgroundColor = Color.White;
            dgvPacijenti.BorderStyle = BorderStyle.None;
            dgvPacijenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacijenti.Location = new Point(102, 332);
            dgvPacijenti.MultiSelect = false;
            dgvPacijenti.Name = "dgvPacijenti";
            dgvPacijenti.RowHeadersWidth = 51;
            dgvPacijenti.Size = new Size(688, 272);
            dgvPacijenti.TabIndex = 30;
            // 
            // FrmPacijent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(895, 633);
            Controls.Add(dgvPacijenti);
            Controls.Add(gbAkcije);
            Controls.Add(gbKriterijumi);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmPacijent";
            Text = "Sistem za praćenje rada doma zdravlja | Pacijent";
            gbKriterijumi.ResumeLayout(false);
            gbKriterijumi.PerformLayout();
            gbAkcije.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPacijenti).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbKriterijumi;
        private ComboBox comboBox1;
        private MonthCalendar mcOtvorenNakon;
        private Label lblOtvorenNakon;
        private Label lblMesto;
        private Label lblSadrziDijagnozu;
        private TextBox tbLekar;
        private GroupBox gbAkcije;
        private Button btnDetalji;
        private Button btnPretrazi;
        private Button btnKreirajNovog;
        private Label lblPrezime;
        private Label lblIme;
        internal TextBox tbPrezime;
        internal TextBox tbIme;
        internal DataGridView dgvPacijenti;
        internal ComboBox cbMesta;
    }
}