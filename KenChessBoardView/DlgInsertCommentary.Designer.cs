namespace KenChessBoardView
{
    partial class DlgInsertCommentary
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMoveBeingUpdated = new System.Windows.Forms.TextBox();
            this.textBoxTextBeforeMove = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTextAfterMove = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Insert commentary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Move being updated:";
            // 
            // textBoxMoveBeingUpdated
            // 
            this.textBoxMoveBeingUpdated.Location = new System.Drawing.Point(150, 54);
            this.textBoxMoveBeingUpdated.Name = "textBoxMoveBeingUpdated";
            this.textBoxMoveBeingUpdated.ReadOnly = true;
            this.textBoxMoveBeingUpdated.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoveBeingUpdated.TabIndex = 41;
            // 
            // textBoxTextBeforeMove
            // 
            this.textBoxTextBeforeMove.Location = new System.Drawing.Point(150, 104);
            this.textBoxTextBeforeMove.Multiline = true;
            this.textBoxTextBeforeMove.Name = "textBoxTextBeforeMove";
            this.textBoxTextBeforeMove.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTextBeforeMove.Size = new System.Drawing.Size(501, 54);
            this.textBoxTextBeforeMove.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Text before move:";
            // 
            // textBoxTextAfterMove
            // 
            this.textBoxTextAfterMove.Location = new System.Drawing.Point(150, 168);
            this.textBoxTextAfterMove.Multiline = true;
            this.textBoxTextAfterMove.Name = "textBoxTextAfterMove";
            this.textBoxTextAfterMove.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTextAfterMove.Size = new System.Drawing.Size(501, 54);
            this.textBoxTextAfterMove.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Text after move:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(468, 248);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 51;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(576, 248);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 52;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // DlgInsertCommentary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxTextAfterMove);
            this.Controls.Add(this.textBoxTextBeforeMove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMoveBeingUpdated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DlgInsertCommentary";
            this.Text = "DlgInsertCommentary";
            this.Load += new System.EventHandler(this.DlgInsertCommentary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMoveBeingUpdated;
        private System.Windows.Forms.TextBox textBoxTextBeforeMove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTextAfterMove;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}