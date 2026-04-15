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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlHeader = new Panel();
            txtFilterAchievements = new TextBox();
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
            resources.ApplyResources(pnlHeader, "pnlHeader");
            pnlHeader.Name = "pnlHeader";
            // 
            // txtFilterAchievements
            // 
            resources.ApplyResources(txtFilterAchievements, "txtFilterAchievements");
            txtFilterAchievements.Name = "txtFilterAchievements";
            txtFilterAchievements.TextChanged += txtFilterAchievements_TextChanged;
            // 
            // cbSort
            // 
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.FormattingEnabled = true;
            cbSort.Items.AddRange(new object[] { resources.GetString("cbSort.Items"), resources.GetString("cbSort.Items1"), resources.GetString("cbSort.Items2"), resources.GetString("cbSort.Items3") });
            resources.ApplyResources(cbSort, "cbSort");
            cbSort.Name = "cbSort";
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            // 
            // cbConsole
            // 
            cbConsole.FormattingEnabled = true;
            resources.ApplyResources(cbConsole, "cbConsole");
            cbConsole.Name = "cbConsole";
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            // 
            // pnlGameInfo
            // 
            pnlGameInfo.Controls.Add(tableLayoutPanel1);
            resources.ApplyResources(pnlGameInfo, "pnlGameInfo");
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
            lblTitle.Name = "lblTitle";
            // 
            // lblDeveloper
            // 
            resources.ApplyResources(lblDeveloper, "lblDeveloper");
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
            BackColor = Color.DarkSlateBlue;
            Controls.Add(flpAchievements);
            Controls.Add(pnlGameInfo);
            Controls.Add(pnlHeader);
            Name = "Form1";
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
