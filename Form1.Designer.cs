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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlHeader = new Panel();
            txtFilterAchievements = new TextBox();
            cbSort = new ComboBox();
            cbConsole = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            menuStrip1 = new MenuStrip();
            languageToolStripMenuItem = new ToolStripMenuItem();
            menuLangEnglish = new ToolStripMenuItem();
            menuLangPortuguese = new ToolStripMenuItem();
            pnlGameInfo = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            lblDeveloper = new Label();
            picBoxArt = new PictureBox();
            flpAchievements = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            menuStrip1.SuspendLayout();
            pnlGameInfo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArt).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            resources.ApplyResources(pnlHeader, "pnlHeader");
            pnlHeader.Controls.Add(txtFilterAchievements);
            pnlHeader.Controls.Add(cbSort);
            pnlHeader.Controls.Add(cbConsole);
            pnlHeader.Controls.Add(btnSearch);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Controls.Add(menuStrip1);
            pnlHeader.Name = "pnlHeader";
            // 
            // txtFilterAchievements
            // 
            resources.ApplyResources(txtFilterAchievements, "txtFilterAchievements");
            txtFilterAchievements.BackColor = Color.FromArgb(22, 33, 62);
            txtFilterAchievements.BorderStyle = BorderStyle.FixedSingle;
            txtFilterAchievements.ForeColor = Color.FromArgb(230, 230, 230);
            txtFilterAchievements.Name = "txtFilterAchievements";
            // 
            // cbSort
            // 
            resources.ApplyResources(cbSort, "cbSort");
            cbSort.BackColor = Color.FromArgb(22, 33, 62);
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.ForeColor = Color.FromArgb(230, 230, 230);
            cbSort.FormattingEnabled = true;
            cbSort.Items.AddRange(new object[] { resources.GetString("cbSort.Items"), resources.GetString("cbSort.Items1"), resources.GetString("cbSort.Items2"), resources.GetString("cbSort.Items3") });
            cbSort.Name = "cbSort";
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // cbConsole
            // 
            resources.ApplyResources(cbConsole, "cbConsole");
            cbConsole.BackColor = Color.FromArgb(22, 33, 62);
            cbConsole.ForeColor = Color.FromArgb(230, 230, 230);
            cbConsole.FormattingEnabled = true;
            cbConsole.Name = "cbConsole";
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.BackColor = Color.FromArgb(233, 69, 96);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderColor = Color.MediumSlateBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.ForeColor = Color.FromArgb(230, 230, 230);
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.BackColor = Color.FromArgb(22, 33, 62);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.ForeColor = Color.FromArgb(230, 230, 230);
            txtSearch.Name = "txtSearch";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { languageToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuLangEnglish, menuLangPortuguese });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // menuLangEnglish
            // 
            resources.ApplyResources(menuLangEnglish, "menuLangEnglish");
            menuLangEnglish.Name = "menuLangEnglish";
            menuLangEnglish.Click += menuLangEnglish_Click;
            // 
            // menuLangPortuguese
            // 
            resources.ApplyResources(menuLangPortuguese, "menuLangPortuguese");
            menuLangPortuguese.Name = "menuLangPortuguese";
            menuLangPortuguese.Click += menuLangPortuguese_Click;
            // 
            // pnlGameInfo
            // 
            resources.ApplyResources(pnlGameInfo, "pnlGameInfo");
            pnlGameInfo.Controls.Add(tableLayoutPanel1);
            pnlGameInfo.Name = "pnlGameInfo";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 1);
            tableLayoutPanel1.Controls.Add(lblDeveloper, 0, 2);
            tableLayoutPanel1.Controls.Add(picBoxArt, 0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.ForeColor = Color.FromArgb(0, 229, 255);
            lblTitle.Name = "lblTitle";
            // 
            // lblDeveloper
            // 
            resources.ApplyResources(lblDeveloper, "lblDeveloper");
            lblDeveloper.ForeColor = Color.FromArgb(230, 230, 230);
            lblDeveloper.Name = "lblDeveloper";
            // 
            // picBoxArt
            // 
            resources.ApplyResources(picBoxArt, "picBoxArt");
            picBoxArt.Name = "picBoxArt";
            picBoxArt.TabStop = false;
            // 
            // flpAchievements
            // 
            resources.ApplyResources(flpAchievements, "flpAchievements");
            flpAchievements.Name = "flpAchievements";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 46);
            Controls.Add(flpAchievements);
            Controls.Add(pnlGameInfo);
            Controls.Add(pnlHeader);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem menuLangEnglish;
        private ToolStripMenuItem menuLangPortuguese;
    }
}
