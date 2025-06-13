namespace Client
{
    partial class FrmSertifikatCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSertifikatCRUD));
            tbOpis = new TextBox();
            lblOpis = new Label();
            btnObrisi = new Button();
            btnOdustani = new Button();
            btnZapamti = new Button();
            lblSertifikatId = new Label();
            SuspendLayout();
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(68, 84);
            tbOpis.Multiline = true;
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(263, 142);
            tbOpis.TabIndex = 26;
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Location = new Point(68, 61);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(42, 20);
            lblOpis.TabIndex = 25;
            lblOpis.Text = "Opis:";
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
            btnObrisi.Location = new Point(365, 134);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(113, 35);
            btnObrisi.TabIndex = 48;
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
            btnOdustani.Location = new Point(365, 191);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(113, 35);
            btnOdustani.TabIndex = 47;
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
            btnZapamti.Location = new Point(365, 73);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(113, 35);
            btnZapamti.TabIndex = 46;
            btnZapamti.Text = "Zapamti";
            btnZapamti.UseVisualStyleBackColor = false;
            // 
            // lblSertifikatId
            // 
            lblSertifikatId.AutoSize = true;
            lblSertifikatId.ForeColor = SystemColors.ControlDarkDark;
            lblSertifikatId.Location = new Point(12, 283);
            lblSertifikatId.Name = "lblSertifikatId";
            lblSertifikatId.Size = new Size(157, 20);
            lblSertifikatId.TabIndex = 49;
            lblSertifikatId.Text = "Unos novog sertifikata";
            // 
            // FrmSertifikatCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(538, 312);
            Controls.Add(lblSertifikatId);
            Controls.Add(btnObrisi);
            Controls.Add(btnOdustani);
            Controls.Add(btnZapamti);
            Controls.Add(tbOpis);
            Controls.Add(lblOpis);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmSertifikatCRUD";
            Text = "Sistem za praćenje rada doma zdravlja | Sertifikat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblOpis;
        private Button btnObrisi;
        private Button btnOdustani;
        private Button btnZapamti;
        internal TextBox tbOpis;
        private Label lblSertifikatId;
    }
}