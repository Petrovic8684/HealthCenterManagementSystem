namespace Client
{
    partial class FrmMesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMesto));
            gbAkcije = new GroupBox();
            btnDetalji = new Button();
            btnPretrazi = new Button();
            btnKreirajNovo = new Button();
            gbKriterijumi = new GroupBox();
            tbNaziv = new TextBox();
            lblPostanskiBroj = new Label();
            tbPostanskiBroj = new TextBox();
            lblNaziv = new Label();
            dgvMesta = new DataGridView();
            gbAkcije.SuspendLayout();
            gbKriterijumi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesta).BeginInit();
            SuspendLayout();
            // 
            // gbAkcije
            // 
            gbAkcije.Controls.Add(btnDetalji);
            gbAkcije.Controls.Add(btnPretrazi);
            gbAkcije.Controls.Add(btnKreirajNovo);
            gbAkcije.Location = new Point(475, 30);
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
            btnKreirajNovo.TabIndex = 18;
            btnKreirajNovo.Text = "Kreiraj novo";
            btnKreirajNovo.UseVisualStyleBackColor = false;
            // 
            // gbKriterijumi
            // 
            gbKriterijumi.Controls.Add(tbNaziv);
            gbKriterijumi.Controls.Add(lblPostanskiBroj);
            gbKriterijumi.Controls.Add(tbPostanskiBroj);
            gbKriterijumi.Controls.Add(lblNaziv);
            gbKriterijumi.Location = new Point(59, 30);
            gbKriterijumi.Name = "gbKriterijumi";
            gbKriterijumi.Size = new Size(375, 258);
            gbKriterijumi.TabIndex = 26;
            gbKriterijumi.TabStop = false;
            gbKriterijumi.Text = "Kriterijumi pretrage";
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(55, 78);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(234, 27);
            tbNaziv.TabIndex = 15;
            // 
            // lblPostanskiBroj
            // 
            lblPostanskiBroj.AutoSize = true;
            lblPostanskiBroj.Location = new Point(55, 135);
            lblPostanskiBroj.Name = "lblPostanskiBroj";
            lblPostanskiBroj.Size = new Size(103, 20);
            lblPostanskiBroj.TabIndex = 14;
            lblPostanskiBroj.Text = "Poštanski broj:";
            // 
            // tbPostanskiBroj
            // 
            tbPostanskiBroj.Location = new Point(55, 158);
            tbPostanskiBroj.Name = "tbPostanskiBroj";
            tbPostanskiBroj.Size = new Size(234, 27);
            tbPostanskiBroj.TabIndex = 13;
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
            // dgvMesta
            // 
            dgvMesta.AllowUserToAddRows = false;
            dgvMesta.AllowUserToDeleteRows = false;
            dgvMesta.BackgroundColor = Color.White;
            dgvMesta.BorderStyle = BorderStyle.None;
            dgvMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesta.Location = new Point(59, 325);
            dgvMesta.MultiSelect = false;
            dgvMesta.Name = "dgvMesta";
            dgvMesta.RowHeadersWidth = 51;
            dgvMesta.Size = new Size(688, 272);
            dgvMesta.TabIndex = 30;
            // 
            // FrmMesto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(843, 620);
            Controls.Add(dgvMesta);
            Controls.Add(gbAkcije);
            Controls.Add(gbKriterijumi);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMesto";
            Text = "Sistem za praćenje rada doma zdravlja | Mesto";
            gbAkcije.ResumeLayout(false);
            gbKriterijumi.ResumeLayout(false);
            gbKriterijumi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbAkcije;
        private Button btnDetalji;
        private Button btnPretrazi;
        private Button btnKreirajNovo;
        private GroupBox gbKriterijumi;
        private GroupBox groupBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox cbMesto;
        private TextBox tbPacijent;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private TextBox tbNaziv;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Label lblMesto;
        private Label lblNaziv;
        private TextBox tbPostanskiBroj;
        private Label lblPostanskiBroj;
        internal DataGridView dgvMesta;
    }
}