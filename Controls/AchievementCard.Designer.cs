namespace RetroEncyclopedia.Controls {
    partial class AchievementCard {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            picBadge = new PictureBox();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)picBadge).BeginInit();
            SuspendLayout();
            // 
            // picBadge
            // 
            picBadge.Location = new Point(28, 16);
            picBadge.Name = "picBadge";
            picBadge.Size = new Size(64, 64);
            picBadge.SizeMode = PictureBoxSizeMode.StretchImage;
            picBadge.TabIndex = 0;
            picBadge.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoEllipsis = true;
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Bottom;
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 135);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AchievementCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(lblTitle);
            Controls.Add(picBadge);
            Name = "AchievementCard";
            Size = new Size(120, 150);
            ((System.ComponentModel.ISupportInitialize)picBadge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBadge;
        private Label lblTitle;
    }
}
