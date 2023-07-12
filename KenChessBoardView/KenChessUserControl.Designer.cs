namespace KenChessBoardView
{
    partial class KenChessUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBoxHideRichTextBox = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoChooseMainlineMove = new System.Windows.Forms.CheckBox();
            this.buttonSetupPosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarAnimationSpeed = new System.Windows.Forms.TrackBar();
            this.richTextBoxShowingMoves = new System.Windows.Forms.RichTextBox();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.buttonGoToEnd = new System.Windows.Forms.Button();
            this.buttonBackOneMove = new System.Windows.Forms.Button();
            this.buttonForwardOneMove = new System.Windows.Forms.Button();
            this.buttonGoToStart = new System.Windows.Forms.Button();
            this.checkBoxUseImagesForPieces = new System.Windows.Forms.CheckBox();
            this.panelLeftCoordinates = new System.Windows.Forms.Panel();
            this.panelBottomCoordinates = new System.Windows.Forms.Panel();
            this.checkBoxFlipBoard = new System.Windows.Forms.CheckBox();
            this.panelGameTags = new System.Windows.Forms.Panel();
            this.textBoxGameTagSite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxGameTagRound = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGameTagResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGameTagDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGameTagBlack = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGameTagWhite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameTagEvent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxChessBoard = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimationSpeed)).BeginInit();
            this.panelNavigation.SuspendLayout();
            this.panelGameTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChessBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxHideRichTextBox
            // 
            this.checkBoxHideRichTextBox.AutoSize = true;
            this.checkBoxHideRichTextBox.Location = new System.Drawing.Point(602, 565);
            this.checkBoxHideRichTextBox.Name = "checkBoxHideRichTextBox";
            this.checkBoxHideRichTextBox.Size = new System.Drawing.Size(161, 17);
            this.checkBoxHideRichTextBox.TabIndex = 77;
            this.checkBoxHideRichTextBox.Text = "Hide textbox showing moves";
            this.checkBoxHideRichTextBox.UseVisualStyleBackColor = true;
            this.checkBoxHideRichTextBox.CheckedChanged += new System.EventHandler(this.checkBoxHideRichTextBox_CheckedChanged);
            // 
            // checkBoxAutoChooseMainlineMove
            // 
            this.checkBoxAutoChooseMainlineMove.AutoSize = true;
            this.checkBoxAutoChooseMainlineMove.Location = new System.Drawing.Point(575, 617);
            this.checkBoxAutoChooseMainlineMove.Name = "checkBoxAutoChooseMainlineMove";
            this.checkBoxAutoChooseMainlineMove.Size = new System.Drawing.Size(206, 30);
            this.checkBoxAutoChooseMainlineMove.TabIndex = 76;
            this.checkBoxAutoChooseMainlineMove.Text = "Auto-choose main line move.\r\n(No prompt to choose move variation.)";
            this.checkBoxAutoChooseMainlineMove.UseVisualStyleBackColor = true;
            // 
            // buttonSetupPosition
            // 
            this.buttonSetupPosition.Location = new System.Drawing.Point(21, 665);
            this.buttonSetupPosition.Name = "buttonSetupPosition";
            this.buttonSetupPosition.Size = new System.Drawing.Size(96, 23);
            this.buttonSetupPosition.TabIndex = 75;
            this.buttonSetupPosition.Text = "Set-up position";
            this.buttonSetupPosition.UseVisualStyleBackColor = true;
            this.buttonSetupPosition.Click += new System.EventHandler(this.buttonSetupPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(806, 653);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Animation Speed (move piece)";
            // 
            // trackBarAnimationSpeed
            // 
            this.trackBarAnimationSpeed.LargeChange = 1;
            this.trackBarAnimationSpeed.Location = new System.Drawing.Point(797, 606);
            this.trackBarAnimationSpeed.Name = "trackBarAnimationSpeed";
            this.trackBarAnimationSpeed.Size = new System.Drawing.Size(160, 45);
            this.trackBarAnimationSpeed.TabIndex = 73;
            this.trackBarAnimationSpeed.Value = 5;
            // 
            // richTextBoxShowingMoves
            // 
            this.richTextBoxShowingMoves.BackColor = System.Drawing.Color.White;
            this.richTextBoxShowingMoves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxShowingMoves.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBoxShowingMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxShowingMoves.Location = new System.Drawing.Point(602, 209);
            this.richTextBoxShowingMoves.Name = "richTextBoxShowingMoves";
            this.richTextBoxShowingMoves.ReadOnly = true;
            this.richTextBoxShowingMoves.Size = new System.Drawing.Size(544, 350);
            this.richTextBoxShowingMoves.TabIndex = 72;
            this.richTextBoxShowingMoves.Text = "";
            this.richTextBoxShowingMoves.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBoxShowingMoves_MouseDown);
            // 
            // panelNavigation
            // 
            this.panelNavigation.Controls.Add(this.buttonGoToEnd);
            this.panelNavigation.Controls.Add(this.buttonBackOneMove);
            this.panelNavigation.Controls.Add(this.buttonForwardOneMove);
            this.panelNavigation.Controls.Add(this.buttonGoToStart);
            this.panelNavigation.Location = new System.Drawing.Point(162, 597);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(391, 73);
            this.panelNavigation.TabIndex = 71;
            // 
            // buttonGoToEnd
            // 
            this.buttonGoToEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonGoToEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoToEnd.Image = global::KenChessBoardView.Properties.Resources.Nav_GoToEnd;
            this.buttonGoToEnd.Location = new System.Drawing.Point(291, 9);
            this.buttonGoToEnd.Name = "buttonGoToEnd";
            this.buttonGoToEnd.Size = new System.Drawing.Size(84, 54);
            this.buttonGoToEnd.TabIndex = 32;
            this.buttonGoToEnd.UseVisualStyleBackColor = true;
            this.buttonGoToEnd.Click += new System.EventHandler(this.buttonGoToEnd_Click);
            // 
            // buttonBackOneMove
            // 
            this.buttonBackOneMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonBackOneMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackOneMove.Image = global::KenChessBoardView.Properties.Resources.Nav_GoBackOneMove;
            this.buttonBackOneMove.Location = new System.Drawing.Point(132, 9);
            this.buttonBackOneMove.Name = "buttonBackOneMove";
            this.buttonBackOneMove.Size = new System.Drawing.Size(54, 54);
            this.buttonBackOneMove.TabIndex = 31;
            this.buttonBackOneMove.UseVisualStyleBackColor = true;
            this.buttonBackOneMove.Click += new System.EventHandler(this.buttonBackOneMove_Click);
            // 
            // buttonForwardOneMove
            // 
            this.buttonForwardOneMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonForwardOneMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForwardOneMove.Image = global::KenChessBoardView.Properties.Resources.Nav_GoForwardOneMove;
            this.buttonForwardOneMove.Location = new System.Drawing.Point(215, 9);
            this.buttonForwardOneMove.Name = "buttonForwardOneMove";
            this.buttonForwardOneMove.Size = new System.Drawing.Size(54, 54);
            this.buttonForwardOneMove.TabIndex = 30;
            this.buttonForwardOneMove.UseVisualStyleBackColor = true;
            this.buttonForwardOneMove.Click += new System.EventHandler(this.buttonForwardOneMove_Click);
            // 
            // buttonGoToStart
            // 
            this.buttonGoToStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonGoToStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoToStart.Image = global::KenChessBoardView.Properties.Resources.Nav_GoToStart;
            this.buttonGoToStart.Location = new System.Drawing.Point(20, 9);
            this.buttonGoToStart.Name = "buttonGoToStart";
            this.buttonGoToStart.Size = new System.Drawing.Size(84, 54);
            this.buttonGoToStart.TabIndex = 29;
            this.buttonGoToStart.UseVisualStyleBackColor = true;
            this.buttonGoToStart.Click += new System.EventHandler(this.buttonGoToStart_Click);
            // 
            // checkBoxUseImagesForPieces
            // 
            this.checkBoxUseImagesForPieces.AutoSize = true;
            this.checkBoxUseImagesForPieces.Checked = true;
            this.checkBoxUseImagesForPieces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseImagesForPieces.Location = new System.Drawing.Point(21, 617);
            this.checkBoxUseImagesForPieces.Name = "checkBoxUseImagesForPieces";
            this.checkBoxUseImagesForPieces.Size = new System.Drawing.Size(130, 17);
            this.checkBoxUseImagesForPieces.TabIndex = 70;
            this.checkBoxUseImagesForPieces.Text = "Use images for pieces";
            this.checkBoxUseImagesForPieces.UseVisualStyleBackColor = true;
            this.checkBoxUseImagesForPieces.Click += new System.EventHandler(this.checkBoxUseImagesForPieces_CheckedChanged);
            // 
            // panelLeftCoordinates
            // 
            this.panelLeftCoordinates.Location = new System.Drawing.Point(5, 15);
            this.panelLeftCoordinates.Name = "panelLeftCoordinates";
            this.panelLeftCoordinates.Size = new System.Drawing.Size(26, 544);
            this.panelLeftCoordinates.TabIndex = 69;
            this.panelLeftCoordinates.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeftCoordinates_Paint);
            // 
            // panelBottomCoordinates
            // 
            this.panelBottomCoordinates.Location = new System.Drawing.Point(37, 565);
            this.panelBottomCoordinates.Name = "panelBottomCoordinates";
            this.panelBottomCoordinates.Size = new System.Drawing.Size(544, 26);
            this.panelBottomCoordinates.TabIndex = 68;
            this.panelBottomCoordinates.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottomCoordinates_Paint);
            // 
            // checkBoxFlipBoard
            // 
            this.checkBoxFlipBoard.AutoSize = true;
            this.checkBoxFlipBoard.Location = new System.Drawing.Point(21, 640);
            this.checkBoxFlipBoard.Name = "checkBoxFlipBoard";
            this.checkBoxFlipBoard.Size = new System.Drawing.Size(72, 17);
            this.checkBoxFlipBoard.TabIndex = 67;
            this.checkBoxFlipBoard.Text = "Flip board";
            this.checkBoxFlipBoard.UseVisualStyleBackColor = true;
            this.checkBoxFlipBoard.CheckedChanged += new System.EventHandler(this.checkBoxFlipBoard_CheckedChanged);
            // 
            // panelGameTags
            // 
            this.panelGameTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGameTags.Controls.Add(this.textBoxGameTagSite);
            this.panelGameTags.Controls.Add(this.label8);
            this.panelGameTags.Controls.Add(this.textBoxGameTagRound);
            this.panelGameTags.Controls.Add(this.label7);
            this.panelGameTags.Controls.Add(this.textBoxGameTagResult);
            this.panelGameTags.Controls.Add(this.label6);
            this.panelGameTags.Controls.Add(this.textBoxGameTagDate);
            this.panelGameTags.Controls.Add(this.label5);
            this.panelGameTags.Controls.Add(this.textBoxGameTagBlack);
            this.panelGameTags.Controls.Add(this.label4);
            this.panelGameTags.Controls.Add(this.textBoxGameTagWhite);
            this.panelGameTags.Controls.Add(this.label3);
            this.panelGameTags.Controls.Add(this.textBoxGameTagEvent);
            this.panelGameTags.Controls.Add(this.label2);
            this.panelGameTags.Location = new System.Drawing.Point(602, 15);
            this.panelGameTags.Name = "panelGameTags";
            this.panelGameTags.Size = new System.Drawing.Size(416, 188);
            this.panelGameTags.TabIndex = 78;
            // 
            // textBoxGameTagSite
            // 
            this.textBoxGameTagSite.Location = new System.Drawing.Point(74, 45);
            this.textBoxGameTagSite.Name = "textBoxGameTagSite";
            this.textBoxGameTagSite.ReadOnly = true;
            this.textBoxGameTagSite.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagSite.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Site:";
            // 
            // textBoxGameTagRound
            // 
            this.textBoxGameTagRound.Location = new System.Drawing.Point(304, 19);
            this.textBoxGameTagRound.Name = "textBoxGameTagRound";
            this.textBoxGameTagRound.ReadOnly = true;
            this.textBoxGameTagRound.Size = new System.Drawing.Size(70, 20);
            this.textBoxGameTagRound.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Round:";
            // 
            // textBoxGameTagResult
            // 
            this.textBoxGameTagResult.Location = new System.Drawing.Point(74, 149);
            this.textBoxGameTagResult.Name = "textBoxGameTagResult";
            this.textBoxGameTagResult.ReadOnly = true;
            this.textBoxGameTagResult.Size = new System.Drawing.Size(191, 20);
            this.textBoxGameTagResult.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Result";
            // 
            // textBoxGameTagDate
            // 
            this.textBoxGameTagDate.Location = new System.Drawing.Point(74, 19);
            this.textBoxGameTagDate.Name = "textBoxGameTagDate";
            this.textBoxGameTagDate.ReadOnly = true;
            this.textBoxGameTagDate.Size = new System.Drawing.Size(132, 20);
            this.textBoxGameTagDate.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date:";
            // 
            // textBoxGameTagBlack
            // 
            this.textBoxGameTagBlack.Location = new System.Drawing.Point(74, 123);
            this.textBoxGameTagBlack.Name = "textBoxGameTagBlack";
            this.textBoxGameTagBlack.ReadOnly = true;
            this.textBoxGameTagBlack.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagBlack.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Black:";
            // 
            // textBoxGameTagWhite
            // 
            this.textBoxGameTagWhite.Location = new System.Drawing.Point(74, 97);
            this.textBoxGameTagWhite.Name = "textBoxGameTagWhite";
            this.textBoxGameTagWhite.ReadOnly = true;
            this.textBoxGameTagWhite.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagWhite.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "White:";
            // 
            // textBoxGameTagEvent
            // 
            this.textBoxGameTagEvent.Location = new System.Drawing.Point(74, 71);
            this.textBoxGameTagEvent.Name = "textBoxGameTagEvent";
            this.textBoxGameTagEvent.ReadOnly = true;
            this.textBoxGameTagEvent.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagEvent.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Event:";
            // 
            // pictureBoxChessBoard
            // 
            this.pictureBoxChessBoard.Location = new System.Drawing.Point(37, 15);
            this.pictureBoxChessBoard.Name = "pictureBoxChessBoard";
            this.pictureBoxChessBoard.Size = new System.Drawing.Size(544, 544);
            this.pictureBoxChessBoard.TabIndex = 79;
            this.pictureBoxChessBoard.TabStop = false;
            this.pictureBoxChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxChessBoard_Paint);
            this.pictureBoxChessBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxChessBoard_MouseDown);
            this.pictureBoxChessBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxChessBoard_MouseMove);
            this.pictureBoxChessBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxChessBoard_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // KenChessUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxChessBoard);
            this.Controls.Add(this.panelGameTags);
            this.Controls.Add(this.checkBoxHideRichTextBox);
            this.Controls.Add(this.checkBoxAutoChooseMainlineMove);
            this.Controls.Add(this.buttonSetupPosition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarAnimationSpeed);
            this.Controls.Add(this.richTextBoxShowingMoves);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.checkBoxUseImagesForPieces);
            this.Controls.Add(this.panelLeftCoordinates);
            this.Controls.Add(this.panelBottomCoordinates);
            this.Controls.Add(this.checkBoxFlipBoard);
            this.Name = "KenChessUserControl";
            this.Size = new System.Drawing.Size(1170, 700);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimationSpeed)).EndInit();
            this.panelNavigation.ResumeLayout(false);
            this.panelGameTags.ResumeLayout(false);
            this.panelGameTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChessBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxHideRichTextBox;
        private System.Windows.Forms.CheckBox checkBoxAutoChooseMainlineMove;
        private System.Windows.Forms.Button buttonSetupPosition;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TrackBar trackBarAnimationSpeed;
        public System.Windows.Forms.RichTextBox richTextBoxShowingMoves;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button buttonGoToEnd;
        private System.Windows.Forms.Button buttonBackOneMove;
        private System.Windows.Forms.Button buttonForwardOneMove;
        private System.Windows.Forms.Button buttonGoToStart;
        private System.Windows.Forms.CheckBox checkBoxUseImagesForPieces;
        private System.Windows.Forms.Panel panelLeftCoordinates;
        private System.Windows.Forms.Panel panelBottomCoordinates;
        public System.Windows.Forms.CheckBox checkBoxFlipBoard;
        private System.Windows.Forms.Panel panelGameTags;
        private System.Windows.Forms.TextBox textBoxGameTagSite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxGameTagRound;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxGameTagResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGameTagDate;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxGameTagBlack;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxGameTagWhite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameTagEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxChessBoard;
        private System.Windows.Forms.Timer timer1;
    }
}
