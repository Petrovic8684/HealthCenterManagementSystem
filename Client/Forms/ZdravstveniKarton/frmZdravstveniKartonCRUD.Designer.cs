namespace Client
{
    partial class FrmZdravstveniKartonCRUD
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
            btnZapamti = new Button();
            btnOdustani = new Button();
            lblNapomena = new Label();
            tbNapomena = new TextBox();
            lblLekar = new Label();
            lblPacijent = new Label();
            lblDijagnoze = new Label();
            lbStavke = new ListBox();
            btnPlus = new Button();
            btnMinus = new Button();
            tbPonder = new TextBox();
            lblPonder = new Label();
            cbLekari = new ComboBox();
            cbPacijenti = new ComboBox();
            cbDijagnoze = new ComboBox();
            lblZdravstveniKartonId = new Label();
            btnObrisi = new Button();
            SuspendLayout();
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
            btnZapamti.Location = new Point(116, 391);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(113, 38);
            btnZapamti.TabIndex = 7;
            btnZapamti.Text = "Zapamti";
            btnZapamti.UseVisualStyleBackColor = false;
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
            btnOdustani.Location = new Point(522, 391);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(113, 38);
            btnOdustani.TabIndex = 8;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = false;
            // 
            // lblNapomena
            // 
            lblNapomena.AutoSize = true;
            lblNapomena.Location = new Point(116, 148);
            lblNapomena.Name = "lblNapomena";
            lblNapomena.Size = new Size(86, 20);
            lblNapomena.TabIndex = 22;
            lblNapomena.Text = "Napomena:";
            // 
            // tbNapomena
            // 
            tbNapomena.Location = new Point(116, 171);
            tbNapomena.Multiline = true;
            tbNapomena.Name = "tbNapomena";
            tbNapomena.Size = new Size(263, 170);
            tbNapomena.TabIndex = 1;
            // 
            // lblLekar
            // 
            lblLekar.AutoSize = true;
            lblLekar.Location = new Point(116, 75);
            lblLekar.Name = "lblLekar";
            lblLekar.Size = new Size(47, 20);
            lblLekar.TabIndex = 24;
            lblLekar.Text = "Lekar:";
            // 
            // lblPacijent
            // 
            lblPacijent.AutoSize = true;
            lblPacijent.Location = new Point(409, 75);
            lblPacijent.Name = "lblPacijent";
            lblPacijent.Size = new Size(63, 20);
            lblPacijent.TabIndex = 25;
            lblPacijent.Text = "Pacijent:";
            // 
            // lblDijagnoze
            // 
            lblDijagnoze.AutoSize = true;
            lblDijagnoze.Location = new Point(409, 148);
            lblDijagnoze.Name = "lblDijagnoze";
            lblDijagnoze.Size = new Size(80, 20);
            lblDijagnoze.TabIndex = 26;
            lblDijagnoze.Text = "Dijagnoze:";
            // 
            // lbStavke
            // 
            lbStavke.FormattingEnabled = true;
            lbStavke.Location = new Point(409, 237);
            lbStavke.Name = "lbStavke";
            lbStavke.ScrollAlwaysVisible = true;
            lbStavke.Size = new Size(226, 104);
            lbStavke.TabIndex = 30;
            lbStavke.TabStop = false;
            // 
            // btnPlus
            // 
            btnPlus.BackColor = Color.White;
            btnPlus.Cursor = Cursors.Hand;
            btnPlus.FlatAppearance.BorderSize = 0;
            btnPlus.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnPlus.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnPlus.FlatStyle = FlatStyle.Flat;
            btnPlus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPlus.ForeColor = SystemColors.ControlText;
            btnPlus.Location = new Point(641, 199);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(28, 28);
            btnPlus.TabIndex = 5;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = false;
            // 
            // btnMinus
            // 
            btnMinus.BackColor = Color.White;
            btnMinus.Cursor = Cursors.Hand;
            btnMinus.FlatAppearance.BorderSize = 0;
            btnMinus.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnMinus.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinus.ForeColor = SystemColors.ControlText;
            btnMinus.Location = new Point(641, 237);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(28, 28);
            btnMinus.TabIndex = 6;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = false;
            // 
            // tbPonder
            // 
            tbPonder.Location = new Point(473, 204);
            tbPonder.Name = "tbPonder";
            tbPonder.Size = new Size(162, 27);
            tbPonder.TabIndex = 4;
            // 
            // lblPonder
            // 
            lblPonder.AutoSize = true;
            lblPonder.Location = new Point(409, 207);
            lblPonder.Name = "lblPonder";
            lblPonder.Size = new Size(58, 20);
            lblPonder.TabIndex = 34;
            lblPonder.Text = "Ponder:";
            // 
            // cbLekari
            // 
            cbLekari.BackColor = Color.White;
            cbLekari.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLekari.FormattingEnabled = true;
            cbLekari.Location = new Point(116, 98);
            cbLekari.Name = "cbLekari";
            cbLekari.Size = new Size(234, 28);
            cbLekari.TabIndex = 0;
            // 
            // cbPacijenti
            // 
            cbPacijenti.BackColor = Color.White;
            cbPacijenti.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPacijenti.FormattingEnabled = true;
            cbPacijenti.Location = new Point(409, 98);
            cbPacijenti.Name = "cbPacijenti";
            cbPacijenti.Size = new Size(226, 28);
            cbPacijenti.TabIndex = 2;
            // 
            // cbDijagnoze
            // 
            cbDijagnoze.BackColor = Color.White;
            cbDijagnoze.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDijagnoze.FormattingEnabled = true;
            cbDijagnoze.Location = new Point(409, 171);
            cbDijagnoze.Name = "cbDijagnoze";
            cbDijagnoze.Size = new Size(226, 28);
            cbDijagnoze.TabIndex = 3;
            // 
            // lblZdravstveniKartonId
            // 
            lblZdravstveniKartonId.AutoSize = true;
            lblZdravstveniKartonId.ForeColor = SystemColors.ControlDarkDark;
            lblZdravstveniKartonId.Location = new Point(12, 461);
            lblZdravstveniKartonId.Name = "lblZdravstveniKartonId";
            lblZdravstveniKartonId.Size = new Size(234, 20);
            lblZdravstveniKartonId.TabIndex = 51;
            lblZdravstveniKartonId.Text = "Unos novog zdravstvenog kartona";
            // 
            // btnObrisi
            // 
            btnObrisi.BackColor = Color.White;
            btnObrisi.Cursor = Cursors.Hand;
            btnObrisi.Enabled = false;
            btnObrisi.FlatAppearance.BorderSize = 0;
            btnObrisi.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnObrisi.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnObrisi.FlatStyle = FlatStyle.Flat;
            btnObrisi.ForeColor = SystemColors.ControlText;
            btnObrisi.Location = new Point(246, 391);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(113, 38);
            btnObrisi.TabIndex = 52;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = false;
            // 
            // FrmZdravstveniKartonCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(763, 490);
            ControlBox = false;
            Controls.Add(btnObrisi);
            Controls.Add(lblZdravstveniKartonId);
            Controls.Add(cbDijagnoze);
            Controls.Add(cbPacijenti);
            Controls.Add(cbLekari);
            Controls.Add(lblPonder);
            Controls.Add(tbPonder);
            Controls.Add(btnMinus);
            Controls.Add(btnPlus);
            Controls.Add(lbStavke);
            Controls.Add(lblDijagnoze);
            Controls.Add(lblPacijent);
            Controls.Add(lblLekar);
            Controls.Add(tbNapomena);
            Controls.Add(lblNapomena);
            Controls.Add(btnOdustani);
            Controls.Add(btnZapamti);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmZdravstveniKartonCRUD";
            Text = "Sistem za praćenje rada doma zdravlja | Zdravstveni karton";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnZapamti;
        private Button btnOdustani;
        private Label lblNapomena;
        private Label lblLekar;
        private Label lblPacijent;
        private Label lblDijagnoze;
        private Button btnPlus;
        private Button btnMinus;
        private Label lblPonder;
        internal TextBox tbNapomena;
        internal ListBox lbStavke;
        internal TextBox tbPonder;
        internal ComboBox cbLekari;
        internal ComboBox cbPacijenti;
        internal ComboBox cbDijagnoze;
        private Label lblZdravstveniKartonId;
        internal Button btnObrisi;
    }
}