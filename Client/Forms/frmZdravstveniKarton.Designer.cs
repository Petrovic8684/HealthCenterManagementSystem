namespace Client
{
    partial class FrmZdravstveniKarton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZdravstveniKarton));
            lblLekar = new Label();
            lblPacijent = new Label();
            lblSadrziDijagnozu = new Label();
            tbLekar = new TextBox();
            tbPacijent = new TextBox();
            lblOtvorenNakon = new Label();
            gbKriterijumi = new GroupBox();
            cbDijagnoze = new ComboBox();
            mcOtvorenNakon = new MonthCalendar();
            btnPretrazi = new Button();
            btnKreirajNovi = new Button();
            gbAkcije = new GroupBox();
            btnDetalji = new Button();
            dgvZdravstveniKartoni = new DataGridView();
            gbKriterijumi.SuspendLayout();
            gbAkcije.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvZdravstveniKartoni).BeginInit();
            SuspendLayout();
            // 
            // lblLekar
            // 
            lblLekar.AutoSize = true;
            lblLekar.Location = new Point(328, 40);
            lblLekar.Name = "lblLekar";
            lblLekar.Size = new Size(81, 20);
            lblLekar.TabIndex = 0;
            lblLekar.Text = "Ime lekara:";
            // 
            // lblPacijent
            // 
            lblPacijent.AutoSize = true;
            lblPacijent.Location = new Point(328, 124);
            lblPacijent.Name = "lblPacijent";
            lblPacijent.Size = new Size(102, 20);
            lblPacijent.TabIndex = 1;
            lblPacijent.Text = "Ime pacijenta:";
            // 
            // lblSadrziDijagnozu
            // 
            lblSadrziDijagnozu.AutoSize = true;
            lblSadrziDijagnozu.Location = new Point(328, 207);
            lblSadrziDijagnozu.Name = "lblSadrziDijagnozu";
            lblSadrziDijagnozu.Size = new Size(123, 20);
            lblSadrziDijagnozu.TabIndex = 2;
            lblSadrziDijagnozu.Text = "Sadrži dijagnozu:";
            // 
            // tbLekar
            // 
            tbLekar.Location = new Point(328, 63);
            tbLekar.Name = "tbLekar";
            tbLekar.Size = new Size(234, 27);
            tbLekar.TabIndex = 1;
            // 
            // tbPacijent
            // 
            tbPacijent.Location = new Point(328, 147);
            tbPacijent.Name = "tbPacijent";
            tbPacijent.Size = new Size(234, 27);
            tbPacijent.TabIndex = 2;
            // 
            // lblOtvorenNakon
            // 
            lblOtvorenNakon.AutoSize = true;
            lblOtvorenNakon.Location = new Point(31, 40);
            lblOtvorenNakon.Name = "lblOtvorenNakon";
            lblOtvorenNakon.Size = new Size(109, 20);
            lblOtvorenNakon.TabIndex = 15;
            lblOtvorenNakon.Text = "Otvoren nakon:";
            // 
            // gbKriterijumi
            // 
            gbKriterijumi.Controls.Add(cbDijagnoze);
            gbKriterijumi.Controls.Add(mcOtvorenNakon);
            gbKriterijumi.Controls.Add(tbPacijent);
            gbKriterijumi.Controls.Add(lblOtvorenNakon);
            gbKriterijumi.Controls.Add(lblLekar);
            gbKriterijumi.Controls.Add(lblPacijent);
            gbKriterijumi.Controls.Add(lblSadrziDijagnozu);
            gbKriterijumi.Controls.Add(tbLekar);
            gbKriterijumi.Location = new Point(79, 38);
            gbKriterijumi.Name = "gbKriterijumi";
            gbKriterijumi.Size = new Size(610, 299);
            gbKriterijumi.TabIndex = 0;
            gbKriterijumi.TabStop = false;
            gbKriterijumi.Text = "Kriterijumi pretrage";
            // 
            // cbDijagnoze
            // 
            cbDijagnoze.BackColor = Color.White;
            cbDijagnoze.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDijagnoze.FormattingEnabled = true;
            cbDijagnoze.Location = new Point(328, 230);
            cbDijagnoze.Name = "cbDijagnoze";
            cbDijagnoze.Size = new Size(234, 28);
            cbDijagnoze.TabIndex = 3;
            // 
            // mcOtvorenNakon
            // 
            mcOtvorenNakon.Location = new Point(31, 63);
            mcOtvorenNakon.Name = "mcOtvorenNakon";
            mcOtvorenNakon.TabIndex = 0;
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
            btnPretrazi.TabIndex = 4;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // btnKreirajNovi
            // 
            btnKreirajNovi.BackColor = Color.White;
            btnKreirajNovi.Cursor = Cursors.Hand;
            btnKreirajNovi.FlatAppearance.BorderSize = 0;
            btnKreirajNovi.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnKreirajNovi.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnKreirajNovi.FlatStyle = FlatStyle.Flat;
            btnKreirajNovi.ForeColor = SystemColors.ControlText;
            btnKreirajNovi.Location = new Point(79, 139);
            btnKreirajNovi.Name = "btnKreirajNovi";
            btnKreirajNovi.Size = new Size(113, 35);
            btnKreirajNovi.TabIndex = 5;
            btnKreirajNovi.Text = "Kreiraj novi";
            btnKreirajNovi.UseVisualStyleBackColor = false;
            // 
            // gbAkcije
            // 
            gbAkcije.Controls.Add(btnDetalji);
            gbAkcije.Controls.Add(btnPretrazi);
            gbAkcije.Controls.Add(btnKreirajNovi);
            gbAkcije.Location = new Point(733, 38);
            gbAkcije.Name = "gbAkcije";
            gbAkcije.Size = new Size(275, 299);
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
            btnDetalji.Location = new Point(79, 223);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(113, 35);
            btnDetalji.TabIndex = 6;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = false;
            // 
            // dgvZdravstveniKartoni
            // 
            dgvZdravstveniKartoni.AllowUserToAddRows = false;
            dgvZdravstveniKartoni.AllowUserToDeleteRows = false;
            dgvZdravstveniKartoni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvZdravstveniKartoni.BackgroundColor = Color.White;
            dgvZdravstveniKartoni.BorderStyle = BorderStyle.None;
            dgvZdravstveniKartoni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZdravstveniKartoni.Location = new Point(79, 366);
            dgvZdravstveniKartoni.MultiSelect = false;
            dgvZdravstveniKartoni.Name = "dgvZdravstveniKartoni";
            dgvZdravstveniKartoni.RowHeadersWidth = 51;
            dgvZdravstveniKartoni.Size = new Size(929, 272);
            dgvZdravstveniKartoni.TabIndex = 30;
            dgvZdravstveniKartoni.TabStop = false;
            // 
            // FrmZdravstveniKarton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 683);
            Controls.Add(dgvZdravstveniKartoni);
            Controls.Add(gbAkcije);
            Controls.Add(gbKriterijumi);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmZdravstveniKarton";
            Text = "Sistem za praćenje rada doma zdravlja | Zdravstveni karton";
            gbKriterijumi.ResumeLayout(false);
            gbKriterijumi.PerformLayout();
            gbAkcije.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvZdravstveniKartoni).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLekar;
        private Label lblPacijent;
        private Label lblSadrziDijagnozu;
        private Label lblOtvorenNakon;
        private GroupBox gbKriterijumi;
        private Button btnPretrazi;
        private Button btnKreirajNovi;
        private GroupBox gbAkcije;
        private Button btnDetalji;
        internal TextBox tbLekar;
        internal TextBox tbPacijent;
        internal MonthCalendar mcOtvorenNakon;
        internal DataGridView dgvZdravstveniKartoni;
        internal ComboBox cbDijagnoze;
    }
}