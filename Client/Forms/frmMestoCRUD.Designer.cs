namespace Client
{
    partial class FrmMestoCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMestoCRUD));
            tbNaziv = new TextBox();
            lblPostanskiBroj = new Label();
            tbPostanskiBroj = new TextBox();
            lblNaziv = new Label();
            btnObrisi = new Button();
            btnOdustani = new Button();
            btnZapamti = new Button();
            lblMestoId = new Label();
            SuspendLayout();
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(70, 79);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(234, 27);
            tbNaziv.TabIndex = 0;
            // 
            // lblPostanskiBroj
            // 
            lblPostanskiBroj.AutoSize = true;
            lblPostanskiBroj.Location = new Point(70, 136);
            lblPostanskiBroj.Name = "lblPostanskiBroj";
            lblPostanskiBroj.Size = new Size(103, 20);
            lblPostanskiBroj.TabIndex = 18;
            lblPostanskiBroj.Text = "Poštanski broj:";
            // 
            // tbPostanskiBroj
            // 
            tbPostanskiBroj.Location = new Point(70, 159);
            tbPostanskiBroj.Name = "tbPostanskiBroj";
            tbPostanskiBroj.Size = new Size(234, 27);
            tbPostanskiBroj.TabIndex = 1;
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Location = new Point(70, 56);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(49, 20);
            lblNaziv.TabIndex = 16;
            lblNaziv.Text = "Naziv:";
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
            btnObrisi.Location = new Point(355, 117);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(113, 35);
            btnObrisi.TabIndex = 3;
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
            btnOdustani.Location = new Point(355, 174);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(113, 35);
            btnOdustani.TabIndex = 4;
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
            btnZapamti.Location = new Point(355, 56);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(113, 35);
            btnZapamti.TabIndex = 2;
            btnZapamti.Text = "Zapamti";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // lblMestoId
            // 
            lblMestoId.AutoSize = true;
            lblMestoId.ForeColor = SystemColors.ControlDarkDark;
            lblMestoId.Location = new Point(12, 260);
            lblMestoId.Name = "lblMestoId";
            lblMestoId.Size = new Size(132, 20);
            lblMestoId.TabIndex = 50;
            lblMestoId.Text = "Unos novog mesta";
            // 
            // FrmMestoCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(517, 289);
            ControlBox = false;
            Controls.Add(lblMestoId);
            Controls.Add(btnObrisi);
            Controls.Add(btnOdustani);
            Controls.Add(btnZapamti);
            Controls.Add(tbNaziv);
            Controls.Add(lblPostanskiBroj);
            Controls.Add(tbPostanskiBroj);
            Controls.Add(lblNaziv);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMestoCRUD";
            Text = "Sistem za praćenje rada doma zdravlja | Mesto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPostanskiBroj;
        private Label lblNaziv;
        private Button btnObrisi;
        private Button btnOdustani;
        private Button btnZapamti;
        private Label lblMestoId;
        internal TextBox tbNaziv;
        internal TextBox tbPostanskiBroj;
    }
}