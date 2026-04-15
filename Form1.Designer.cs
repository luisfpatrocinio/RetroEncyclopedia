namespace RetroEncyclopedia {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            pnlHeader = new Panel();
            cbSort = new ComboBox();
            cbConsole = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            pnlGameInfo = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            lblDeveloper = new Label();
            picBoxArt = new PictureBox();
            flpAchievements = new FlowLayoutPanel();
            txtFilterAchievements = new TextBox();
            pnlHeader.SuspendLayout();
            pnlGameInfo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArt).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(txtFilterAchievements);
            pnlHeader.Controls.Add(cbSort);
            pnlHeader.Controls.Add(cbConsole);
            pnlHeader.Controls.Add(btnSearch);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(984, 80);
            pnlHeader.TabIndex = 0;
            // 
            // cbSort
            // 
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.FormattingEnabled = true;
            cbSort.Items.AddRange(new object[] { "Padrão da API", "Menos Pontos", "Mais Pontos", "Ordem Alfabética (A-Z)" });
            cbSort.Location = new Point(755, 34);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(121, 23);
            cbSort.TabIndex = 3;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // cbConsole
            // 
            cbConsole.FormattingEnabled = true;
            cbConsole.Location = new Point(583, 24);
            cbConsole.Name = "cbConsole";
            cbConsole.Size = new Size(121, 23);
            cbConsole.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(433, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(150, 24);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 0;
            // 
            // pnlGameInfo
            // 
            pnlGameInfo.Controls.Add(tableLayoutPanel1);
            pnlGameInfo.Dock = DockStyle.Left;
            pnlGameInfo.Location = new Point(0, 80);
            pnlGameInfo.Name = "pnlGameInfo";
            pnlGameInfo.Size = new Size(250, 581);
            pnlGameInfo.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 1);
            tableLayoutPanel1.Controls.Add(lblDeveloper, 0, 2);
            tableLayoutPanel1.Controls.Add(picBoxArt, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(250, 581);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(3, 536);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Game Title";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Dock = DockStyle.Fill;
            lblDeveloper.Location = new Point(3, 566);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(244, 15);
            lblDeveloper.TabIndex = 2;
            lblDeveloper.Text = "Developer";
            lblDeveloper.TextAlign = ContentAlignment.TopCenter;
            // 
            // picBoxArt
            // 
            picBoxArt.Dock = DockStyle.Fill;
            picBoxArt.Location = new Point(10, 10);
            picBoxArt.Margin = new Padding(10);
            picBoxArt.Name = "picBoxArt";
            picBoxArt.Size = new Size(230, 516);
            picBoxArt.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxArt.TabIndex = 0;
            picBoxArt.TabStop = false;
            // 
            // flpAchievements
            // 
            flpAchievements.AutoScroll = true;
            flpAchievements.Dock = DockStyle.Fill;
            flpAchievements.Location = new Point(250, 80);
            flpAchievements.Name = "flpAchievements";
            flpAchievements.Padding = new Padding(10);
            flpAchievements.Size = new Size(734, 581);
            flpAchievements.TabIndex = 2;
            // 
            // txtFilterAchievements
            // 
            txtFilterAchievements.Location = new Point(280, 12);
            txtFilterAchievements.Name = "txtFilterAchievements";
            txtFilterAchievements.PlaceholderText = "Filtrar conquistas...";
            txtFilterAchievements.Size = new Size(100, 23);
            txtFilterAchievements.TabIndex = 4;
            txtFilterAchievements.TextChanged += txtFilterAchievements_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(984, 661);
            Controls.Add(flpAchievements);
            Controls.Add(pnlGameInfo);
            Controls.Add(pnlHeader);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RetroEncyclopedia - Game Archive";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlGameInfo.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArt).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlGameInfo;
        private FlowLayoutPanel flpAchievements;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblDeveloper;
        private Label lblTitle;
        private PictureBox picBoxArt;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbConsole;
        private ComboBox cbSort;
        private TextBox txtFilterAchievements;
    }
}
