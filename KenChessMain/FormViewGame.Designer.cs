namespace KenChessMain
{
    partial class FormViewGame
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
            this.kenChessUserControl1 = new KenChessBoardView.KenChessUserControl();
            this.textBoxGameDatabaseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCopyPgn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCopyFEN = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // textBoxGameDatabaseName
            // 
            this.textBoxGameDatabaseName.Location = new System.Drawing.Point(124, 15);
            this.textBoxGameDatabaseName.Name = "textBoxGameDatabaseName";
            this.textBoxGameDatabaseName.ReadOnly = true;
            this.textBoxGameDatabaseName.Size = new System.Drawing.Size(481, 20);
            this.textBoxGameDatabaseName.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Game database:";
            // 
            // textBoxGameNumber
            // 
            this.textBoxGameNumber.Location = new System.Drawing.Point(124, 41);
            this.textBoxGameNumber.Name = "textBoxGameNumber";
            this.textBoxGameNumber.ReadOnly = true;
            this.textBoxGameNumber.Size = new System.Drawing.Size(75, 20);
            this.textBoxGameNumber.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Game number:";
            // 
            // buttonCopyPgn
            // 
            this.buttonCopyPgn.Location = new System.Drawing.Point(1059, 14);
            this.buttonCopyPgn.Name = "buttonCopyPgn";
            this.buttonCopyPgn.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyPgn.TabIndex = 45;
            this.buttonCopyPgn.Text = "Clone game";
            this.buttonCopyPgn.UseVisualStyleBackColor = true;
            this.buttonCopyPgn.Click += new System.EventHandler(this.buttonCloneGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(611, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "This game cannot be eited; use \'Clone game\' to create an editable game.";
            // 
            // buttonCopyFEN
            // 
            this.buttonCopyFEN.Location = new System.Drawing.Point(1059, 44);
            this.buttonCopyFEN.Name = "buttonCopyFEN";
            this.buttonCopyFEN.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyFEN.TabIndex = 47;
            this.buttonCopyFEN.Text = "Copy FEN";
            this.buttonCopyFEN.UseVisualStyleBackColor = true;
            this.buttonCopyFEN.Click += new System.EventHandler(this.buttonCopyFEN_Click);
            // 
            // FormViewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 781);
            this.Controls.Add(this.buttonCopyFEN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCopyPgn);
            this.Controls.Add(this.textBoxGameDatabaseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGameNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kenChessUserControl1);
            this.Name = "FormViewGame";
            this.Text = "FormViewGame";
            this.Load += new System.EventHandler(this.FormViewGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private KenChessBoardView.KenChessUserControl kenChessUserControl1;
        private System.Windows.Forms.TextBox textBoxGameDatabaseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCopyPgn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCopyFEN;
    }
}