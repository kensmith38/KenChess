namespace KenChessMain
{
    partial class FormTrainingSession
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
            this.components = new System.ComponentModel.Container();
            KenChessBoardView.DragChessPiece dragChessPiece1 = new KenChessBoardView.DragChessPiece();
            this.labelGameFile = new System.Windows.Forms.Label();
            this.timerMoveAnimation = new System.Windows.Forms.Timer(this.components);
            this.kenChessUserControl1 = new KenChessBoardView.KenChessUserControl();
            this.SuspendLayout();
            // 
            // labelGameFile
            // 
            this.labelGameFile.AutoSize = true;
            this.labelGameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameFile.Location = new System.Drawing.Point(59, 47);
            this.labelGameFile.Name = "labelGameFile";
            this.labelGameFile.Size = new System.Drawing.Size(139, 20);
            this.labelGameFile.TabIndex = 39;
            this.labelGameFile.Text = "Training session";
            // 
            // timerMoveAnimation
            // 
            this.timerMoveAnimation.Tick += new System.EventHandler(this.timerMoveAnimation_Tick);
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
            this.kenChessUserControl1.Size = new System.Drawing.Size(1170, 700);
            this.kenChessUserControl1.TabIndex = 40;
            this.kenChessUserControl1.UseImagesForPieces = true;
            this.kenChessUserControl1.UserCanMoveChessPieces = false;
            this.kenChessUserControl1.UserNavigationEnabled = true;
            // 
            // FormTrainingSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 781);
            this.Controls.Add(this.kenChessUserControl1);
            this.Controls.Add(this.labelGameFile);
            this.Name = "FormTrainingSession";
            this.Text = "FormTrainingSession";
            this.Load += new System.EventHandler(this.FormTrainingSession_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelGameFile;
        private System.Windows.Forms.Timer timerMoveAnimation;
        private KenChessBoardView.KenChessUserControl kenChessUserControl1;
    }
}