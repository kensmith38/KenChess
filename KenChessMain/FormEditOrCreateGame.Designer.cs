namespace KenChessMain
{
    partial class FormEditOrCreateGame
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
            KenChessBoardView.DragChessPiece dragChessPiece1 = new KenChessBoardView.DragChessPiece();
            this.labelGameFile = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kenChessUserControl1 = new KenChessBoardView.KenChessUserControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGameFile
            // 
            this.labelGameFile.AutoSize = true;
            this.labelGameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameFile.Location = new System.Drawing.Point(47, 42);
            this.labelGameFile.Name = "labelGameFile";
            this.labelGameFile.Size = new System.Drawing.Size(157, 20);
            this.labelGameFile.TabIndex = 38;
            this.labelGameFile.Text = "New training game";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // kenChessUserControl1
            // 
            this.kenChessUserControl1.AnimatedChessPiece = null;
            this.kenChessUserControl1.DarkSquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(148)))), ((int)(((byte)(186)))));
            this.kenChessUserControl1.DarkSquareHighlightColor = System.Drawing.Color.LightSkyBlue;
            dragChessPiece1.DestinationChessSquare = null;
            dragChessPiece1.DragInProgess = false;
            dragChessPiece1.OriginChessSquare = null;
            dragChessPiece1.PieceBeingDragged = null;
            dragChessPiece1.XOffsetFromTopLeft = 0;
            dragChessPiece1.YOffsetFromTopLeft = 0;
            this.kenChessUserControl1.DragChessPiece = dragChessPiece1;
            this.kenChessUserControl1.FontForCoordinates = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.kenChessUserControl1.FontForPieces = new System.Drawing.Font("Microsoft Sans Serif", 34F);
            this.kenChessUserControl1.LightSquareColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.kenChessUserControl1.LightSquareHighlightColor = System.Drawing.Color.LightGoldenrodYellow;
            this.kenChessUserControl1.Location = new System.Drawing.Point(12, 70);
            this.kenChessUserControl1.Name = "kenChessUserControl1";
            this.kenChessUserControl1.Size = new System.Drawing.Size(1170, 699);
            this.kenChessUserControl1.TabIndex = 40;
            this.kenChessUserControl1.UseImagesForPieces = true;
            this.kenChessUserControl1.UserCanMoveChessPieces = false;
            this.kenChessUserControl1.UserNavigationEnabled = true;
            // 
            // FormEditOrCreateGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 781);
            this.Controls.Add(this.kenChessUserControl1);
            this.Controls.Add(this.labelGameFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormEditOrCreateGame";
            this.Text = "KenChess";
            this.Load += new System.EventHandler(this.FormEditOrCreateGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGameFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private KenChessBoardView.KenChessUserControl kenChessUserControl1;
    }
}