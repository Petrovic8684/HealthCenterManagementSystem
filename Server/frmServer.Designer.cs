namespace Server
{
    partial class FrmServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            lblNaslov = new Label();
            lblStatus = new Label();
            btnTogglujStatus = new Button();
            pbServer = new PictureBox();
            lblBrojKlijenata = new Label();
            ((System.ComponentModel.ISupportInitialize)pbServer).BeginInit();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.BackColor = Color.White;
            lblNaslov.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblNaslov.Location = new Point(61, 45);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(500, 100);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Sistem za praćenje rada\r\ndoma zdravlja";
            lblNaslov.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = SystemColors.ControlDarkDark;
            lblStatus.ImageAlign = ContentAlignment.MiddleLeft;
            lblStatus.Location = new Point(421, 479);
            lblStatus.Name = "lblStatus";
            lblStatus.RightToLeft = RightToLeft.No;
            lblStatus.Size = new Size(187, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status servera - zaustavljen";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnTogglujStatus
            // 
            btnTogglujStatus.BackColor = Color.White;
            btnTogglujStatus.Cursor = Cursors.Hand;
            btnTogglujStatus.FlatAppearance.BorderSize = 0;
            btnTogglujStatus.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnTogglujStatus.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnTogglujStatus.FlatStyle = FlatStyle.Flat;
            btnTogglujStatus.ForeColor = SystemColors.ControlText;
            btnTogglujStatus.Location = new Point(246, 375);
            btnTogglujStatus.Name = "btnTogglujStatus";
            btnTogglujStatus.Size = new Size(120, 35);
            btnTogglujStatus.TabIndex = 6;
            btnTogglujStatus.Text = "Pokreni server";
            btnTogglujStatus.UseVisualStyleBackColor = false;
            // 
            // pbServer
            // 
            pbServer.BackColor = Color.White;
            pbServer.BackgroundImageLayout = ImageLayout.None;
            pbServer.Image = (Image)resources.GetObject("pbServer.Image");
            pbServer.Location = new Point(140, 157);
            pbServer.Margin = new Padding(0);
            pbServer.Name = "pbServer";
            pbServer.Size = new Size(331, 196);
            pbServer.SizeMode = PictureBoxSizeMode.Zoom;
            pbServer.TabIndex = 8;
            pbServer.TabStop = false;
            // 
            // lblBrojKlijenata
            // 
            lblBrojKlijenata.AutoSize = true;
            lblBrojKlijenata.ForeColor = SystemColors.ControlDarkDark;
            lblBrojKlijenata.Location = new Point(12, 479);
            lblBrojKlijenata.Name = "lblBrojKlijenata";
            lblBrojKlijenata.Size = new Size(154, 20);
            lblBrojKlijenata.TabIndex = 9;
            lblBrojKlijenata.Text = "Povezano klijenata - 0";
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(620, 508);
            Controls.Add(lblBrojKlijenata);
            Controls.Add(pbServer);
            Controls.Add(btnTogglujStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblNaslov);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistem za praćenje rada doma zdravlja";
            ((System.ComponentModel.ISupportInitialize)pbServer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Label lblStatus;
        private Button btnTogglujStatus;
        private PictureBox pbServer;
        private Label lblBrojKlijenata;
    }
}
