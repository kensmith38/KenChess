namespace KenChessMain
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openGameDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSinglePGNGameFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.createNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTrainingGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingTrainingGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startTrainingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRecommendCreateFolders = new System.Windows.Forms.Panel();
            this.buttonCreateKenChessFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.versionNnnnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelRecommendCreateFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem,
            this.toolStripSeparator2,
            this.openGameDatabaseToolStripMenuItem,
            this.openSinglePGNGameFromClipboardToolStripMenuItem,
            this.toolStripSeparator3,
            this.createNewGameToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem
            // 
            this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem.Name = "definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem";
            this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem.Size = new System.Drawing.Size(475, 22);
            this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem.Text = "Definition: A Game Database is a PGN file containing 1 or more chess games";
            this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem.Click += new System.EventHandler(this.definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(472, 6);
            // 
            // openGameDatabaseToolStripMenuItem
            // 
            this.openGameDatabaseToolStripMenuItem.Name = "openGameDatabaseToolStripMenuItem";
            this.openGameDatabaseToolStripMenuItem.Size = new System.Drawing.Size(475, 22);
            this.openGameDatabaseToolStripMenuItem.Text = "Open database from file";
            this.openGameDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openGameDatabaseToolStripMenuItem_Click);
            // 
            // openSinglePGNGameFromClipboardToolStripMenuItem
            // 
            this.openSinglePGNGameFromClipboardToolStripMenuItem.Name = "openSinglePGNGameFromClipboardToolStripMenuItem";
            this.openSinglePGNGameFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(475, 22);
            this.openSinglePGNGameFromClipboardToolStripMenuItem.Text = "Paste single PGN game from clipboard";
            this.openSinglePGNGameFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.openSinglePGNGameFromClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(472, 6);
            // 
            // createNewGameToolStripMenuItem
            // 
            this.createNewGameToolStripMenuItem.Name = "createNewGameToolStripMenuItem";
            this.createNewGameToolStripMenuItem.Size = new System.Drawing.Size(475, 22);
            this.createNewGameToolStripMenuItem.Text = "Create new game";
            this.createNewGameToolStripMenuItem.Click += new System.EventHandler(this.createNewGameToolStripMenuItem_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTrainingGameToolStripMenuItem,
            this.editExistingTrainingGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.startTrainingSessionToolStripMenuItem});
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.trainingToolStripMenuItem.Text = "Training";
            // 
            // createTrainingGameToolStripMenuItem
            // 
            this.createTrainingGameToolStripMenuItem.Name = "createTrainingGameToolStripMenuItem";
            this.createTrainingGameToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.createTrainingGameToolStripMenuItem.Text = "Create training game";
            this.createTrainingGameToolStripMenuItem.Click += new System.EventHandler(this.createTrainingGameToolStripMenuItem_Click);
            // 
            // editExistingTrainingGameToolStripMenuItem
            // 
            this.editExistingTrainingGameToolStripMenuItem.Name = "editExistingTrainingGameToolStripMenuItem";
            this.editExistingTrainingGameToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.editExistingTrainingGameToolStripMenuItem.Text = "Edit existing training game";
            this.editExistingTrainingGameToolStripMenuItem.Click += new System.EventHandler(this.editExistingTrainingGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // startTrainingSessionToolStripMenuItem
            // 
            this.startTrainingSessionToolStripMenuItem.Name = "startTrainingSessionToolStripMenuItem";
            this.startTrainingSessionToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.startTrainingSessionToolStripMenuItem.Text = "Start training session";
            this.startTrainingSessionToolStripMenuItem.Click += new System.EventHandler(this.startTrainingSessionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionNnnnToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // panelRecommendCreateFolders
            // 
            this.panelRecommendCreateFolders.BackColor = System.Drawing.Color.White;
            this.panelRecommendCreateFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRecommendCreateFolders.Controls.Add(this.buttonCreateKenChessFolder);
            this.panelRecommendCreateFolders.Controls.Add(this.label1);
            this.panelRecommendCreateFolders.Location = new System.Drawing.Point(112, 34);
            this.panelRecommendCreateFolders.Name = "panelRecommendCreateFolders";
            this.panelRecommendCreateFolders.Size = new System.Drawing.Size(544, 57);
            this.panelRecommendCreateFolders.TabIndex = 2;
            // 
            // buttonCreateKenChessFolder
            // 
            this.buttonCreateKenChessFolder.Location = new System.Drawing.Point(393, 18);
            this.buttonCreateKenChessFolder.Name = "buttonCreateKenChessFolder";
            this.buttonCreateKenChessFolder.Size = new System.Drawing.Size(142, 23);
            this.buttonCreateKenChessFolder.TabIndex = 1;
            this.buttonCreateKenChessFolder.Text = "Create KenChess folder";
            this.buttonCreateKenChessFolder.UseVisualStyleBackColor = true;
            this.buttonCreateKenChessFolder.Click += new System.EventHandler(this.buttonCreateKenChessFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creating a KenChess folder in your documents folder\r\nwill improve usability of th" +
    "is application.";
            // 
            // versionNnnnToolStripMenuItem
            // 
            this.versionNnnnToolStripMenuItem.Name = "versionNnnnToolStripMenuItem";
            this.versionNnnnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.versionNnnnToolStripMenuItem.Text = "Version n.n.n.n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KenChessMain.Properties.Resources.KenChessSplashImage;
            this.pictureBox1.Location = new System.Drawing.Point(112, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(544, 544);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 681);
            this.Controls.Add(this.panelRecommendCreateFolders);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelRecommendCreateFolders.ResumeLayout(false);
            this.panelRecommendCreateFolders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.Panel panelRecommendCreateFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateKenChessFolder;
        private System.Windows.Forms.ToolStripMenuItem openGameDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTrainingGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingTrainingGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTrainingSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openSinglePGNGameFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem versionNnnnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}