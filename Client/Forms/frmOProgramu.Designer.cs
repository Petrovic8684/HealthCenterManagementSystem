namespace Client
{
    partial class FrmOProgramu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOProgramu));
            pbOProgramu = new PictureBox();
            lblDetalji = new Label();
            lblOProgramu = new Label();
            linkLblUndraw = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pbOProgramu).BeginInit();
            SuspendLayout();
            // 
            // pbOProgramu
            // 
            pbOProgramu.BackColor = Color.White;
            pbOProgramu.BackgroundImageLayout = ImageLayout.None;
            pbOProgramu.Image = (Image)resources.GetObject("pbOProgramu.Image");
            pbOProgramu.Location = new Point(565, 75);
            pbOProgramu.Margin = new Padding(0);
            pbOProgramu.Name = "pbOProgramu";
            pbOProgramu.Size = new Size(403, 297);
            pbOProgramu.SizeMode = PictureBoxSizeMode.Zoom;
            pbOProgramu.TabIndex = 7;
            pbOProgramu.TabStop = false;
            // 
            // lblDetalji
            // 
            lblDetalji.BackColor = Color.White;
            lblDetalji.Font = new Font("Segoe UI", 10F);
            lblDetalji.ForeColor = Color.FromArgb(64, 64, 64);
            lblDetalji.Location = new Point(41, 118);
            lblDetalji.Name = "lblDetalji";
            lblDetalji.Size = new Size(508, 228);
            lblDetalji.TabIndex = 14;
            lblDetalji.Text = resources.GetString("lblDetalji.Text");
            lblDetalji.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOProgramu
            // 
            lblOProgramu.AutoSize = true;
            lblOProgramu.BackColor = Color.White;
            lblOProgramu.Font = new Font("Segoe UI", 14F);
            lblOProgramu.ImageAlign = ContentAlignment.MiddleLeft;
            lblOProgramu.Location = new Point(41, 67);
            lblOProgramu.Name = "lblOProgramu";
            lblOProgramu.Size = new Size(144, 32);
            lblOProgramu.TabIndex = 13;
            lblOProgramu.Text = "O programu";
            lblOProgramu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // linkLblUndraw
            // 
            linkLblUndraw.AutoSize = true;
            linkLblUndraw.Font = new Font("Segoe UI", 10F);
            linkLblUndraw.Location = new Point(434, 290);
            linkLblUndraw.Name = "linkLblUndraw";
            linkLblUndraw.Size = new Size(69, 23);
            linkLblUndraw.TabIndex = 0;
            linkLblUndraw.TabStop = true;
            linkLblUndraw.Text = "unDraw";
            // 
            // FrmOProgramu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(995, 442);
            Controls.Add(linkLblUndraw);
            Controls.Add(lblDetalji);
            Controls.Add(lblOProgramu);
            Controls.Add(pbOProgramu);
            MaximizeBox = false;
            Name = "FrmOProgramu";
            Text = "Sistem za praćenje rada doma zdravlja | O programu";
            ((System.ComponentModel.ISupportInitialize)pbOProgramu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbOProgramu;
        private Label lblDetalji;
        private Label lblOProgramu;
        private LinkLabel linkLblUndraw;
    }
}