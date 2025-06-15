namespace Client.Forms
{
    partial class FrmPodesavanja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPodesavanja));
            btnPoveziSe = new Button();
            tbBrojPorta = new TextBox();
            tbIpAdresa = new TextBox();
            lblBrojPorta = new Label();
            lblIpAdresa = new Label();
            pbPodesavanja = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbPodesavanja).BeginInit();
            SuspendLayout();
            // 
            // btnPoveziSe
            // 
            btnPoveziSe.BackColor = Color.White;
            btnPoveziSe.Cursor = Cursors.Hand;
            btnPoveziSe.FlatAppearance.BorderSize = 0;
            btnPoveziSe.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnPoveziSe.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnPoveziSe.FlatStyle = FlatStyle.Flat;
            btnPoveziSe.ForeColor = SystemColors.ControlText;
            btnPoveziSe.Location = new Point(86, 230);
            btnPoveziSe.Name = "btnPoveziSe";
            btnPoveziSe.Size = new Size(113, 35);
            btnPoveziSe.TabIndex = 6;
            btnPoveziSe.Text = "Poveži se";
            btnPoveziSe.UseVisualStyleBackColor = false;
            // 
            // tbBrojPorta
            // 
            tbBrojPorta.Location = new Point(86, 162);
            tbBrojPorta.Name = "tbBrojPorta";
            tbBrojPorta.Size = new Size(220, 27);
            tbBrojPorta.TabIndex = 10;
            // 
            // tbIpAdresa
            // 
            tbIpAdresa.BackColor = SystemColors.Window;
            tbIpAdresa.Location = new Point(86, 87);
            tbIpAdresa.Name = "tbIpAdresa";
            tbIpAdresa.Size = new Size(220, 27);
            tbIpAdresa.TabIndex = 9;
            // 
            // lblBrojPorta
            // 
            lblBrojPorta.AutoSize = true;
            lblBrojPorta.Location = new Point(86, 139);
            lblBrojPorta.Name = "lblBrojPorta";
            lblBrojPorta.Size = new Size(130, 20);
            lblBrojPorta.TabIndex = 8;
            lblBrojPorta.Text = "Broj porta servera:";
            // 
            // lblIpAdresa
            // 
            lblIpAdresa.AutoSize = true;
            lblIpAdresa.Location = new Point(86, 64);
            lblIpAdresa.Name = "lblIpAdresa";
            lblIpAdresa.Size = new Size(123, 20);
            lblIpAdresa.TabIndex = 7;
            lblIpAdresa.Text = "IP adresa servera:";
            // 
            // pbPodesavanja
            // 
            pbPodesavanja.BackColor = Color.White;
            pbPodesavanja.BackgroundImageLayout = ImageLayout.None;
            pbPodesavanja.Image = (Image)resources.GetObject("pbPodesavanja.Image");
            pbPodesavanja.Location = new Point(379, 43);
            pbPodesavanja.Margin = new Padding(0);
            pbPodesavanja.Name = "pbPodesavanja";
            pbPodesavanja.Size = new Size(361, 256);
            pbPodesavanja.SizeMode = PictureBoxSizeMode.Zoom;
            pbPodesavanja.TabIndex = 11;
            pbPodesavanja.TabStop = false;
            // 
            // FrmPodesavanja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(767, 347);
            Controls.Add(pbPodesavanja);
            Controls.Add(tbBrojPorta);
            Controls.Add(tbIpAdresa);
            Controls.Add(lblBrojPorta);
            Controls.Add(lblIpAdresa);
            Controls.Add(btnPoveziSe);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPodesavanja";
            Text = "Sistem za praćenje rada doma zdravlja | Podešavanja softverskog sistema";
            ((System.ComponentModel.ISupportInitialize)pbPodesavanja).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPoveziSe;
        internal TextBox tbBrojPorta;
        internal TextBox tbIpAdresa;
        private Label lblBrojPorta;
        private Label lblIpAdresa;
        private PictureBox pbPodesavanja;
    }
}