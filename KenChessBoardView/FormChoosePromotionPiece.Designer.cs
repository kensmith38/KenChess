namespace KenChessBoardView
{
    partial class FormChoosePromotionPiece
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
            this.panelQueen = new System.Windows.Forms.Panel();
            this.panelRook = new System.Windows.Forms.Panel();
            this.panelKnight = new System.Windows.Forms.Panel();
            this.panelBishop = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxRook = new System.Windows.Forms.PictureBox();
            this.pictureBoxKnight = new System.Windows.Forms.PictureBox();
            this.pictureBoxBishop = new System.Windows.Forms.PictureBox();
            this.pictureBoxQueen = new System.Windows.Forms.PictureBox();
            this.panelQueen.SuspendLayout();
            this.panelRook.SuspendLayout();
            this.panelKnight.SuspendLayout();
            this.panelBishop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQueen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Promotion";
            // 
            // panelQueen
            // 
            this.panelQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQueen.Controls.Add(this.pictureBoxQueen);
            this.panelQueen.Location = new System.Drawing.Point(65, 48);
            this.panelQueen.Name = "panelQueen";
            this.panelQueen.Size = new System.Drawing.Size(66, 66);
            this.panelQueen.TabIndex = 43;
            // 
            // panelRook
            // 
            this.panelRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRook.Controls.Add(this.pictureBoxRook);
            this.panelRook.Location = new System.Drawing.Point(141, 48);
            this.panelRook.Name = "panelRook";
            this.panelRook.Size = new System.Drawing.Size(66, 66);
            this.panelRook.TabIndex = 44;
            // 
            // panelKnight
            // 
            this.panelKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKnight.Controls.Add(this.pictureBoxKnight);
            this.panelKnight.Location = new System.Drawing.Point(293, 48);
            this.panelKnight.Name = "panelKnight";
            this.panelKnight.Size = new System.Drawing.Size(66, 66);
            this.panelKnight.TabIndex = 44;
            // 
            // panelBishop
            // 
            this.panelBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBishop.Controls.Add(this.pictureBoxBishop);
            this.panelBishop.Location = new System.Drawing.Point(217, 48);
            this.panelBishop.Name = "panelBishop";
            this.panelBishop.Size = new System.Drawing.Size(66, 66);
            this.panelBishop.TabIndex = 44;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(271, 144);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 45;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Choose promotion piece and click OK:";
            // 
            // pictureBoxRook
            // 
            this.pictureBoxRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRook.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxRook.Name = "pictureBoxRook";
            this.pictureBoxRook.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRook.TabIndex = 40;
            this.pictureBoxRook.TabStop = false;
            this.pictureBoxRook.Click += new System.EventHandler(this.pictureBoxANY_Click);
            // 
            // pictureBoxKnight
            // 
            this.pictureBoxKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxKnight.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxKnight.Name = "pictureBoxKnight";
            this.pictureBoxKnight.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxKnight.TabIndex = 42;
            this.pictureBoxKnight.TabStop = false;
            this.pictureBoxKnight.Click += new System.EventHandler(this.pictureBoxANY_Click);
            // 
            // pictureBoxBishop
            // 
            this.pictureBoxBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBishop.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxBishop.Name = "pictureBoxBishop";
            this.pictureBoxBishop.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxBishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBishop.TabIndex = 41;
            this.pictureBoxBishop.TabStop = false;
            this.pictureBoxBishop.Click += new System.EventHandler(this.pictureBoxANY_Click);
            // 
            // pictureBoxQueen
            // 
            this.pictureBoxQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxQueen.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxQueen.Name = "pictureBoxQueen";
            this.pictureBoxQueen.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxQueen.TabIndex = 39;
            this.pictureBoxQueen.TabStop = false;
            this.pictureBoxQueen.Click += new System.EventHandler(this.pictureBoxANY_Click);
            // 
            // FormChoosePromotionPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 207);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panelRook);
            this.Controls.Add(this.panelKnight);
            this.Controls.Add(this.panelBishop);
            this.Controls.Add(this.panelQueen);
            this.Controls.Add(this.label1);
            this.Name = "FormChoosePromotionPiece";
            this.Text = "FormChoosePromotionPiece";
            this.Load += new System.EventHandler(this.FormChoosePromotionPiece_Load);
            this.panelQueen.ResumeLayout(false);
            this.panelRook.ResumeLayout(false);
            this.panelKnight.ResumeLayout(false);
            this.panelBishop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQueen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxQueen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxRook;
        private System.Windows.Forms.PictureBox pictureBoxBishop;
        private System.Windows.Forms.PictureBox pictureBoxKnight;
        private System.Windows.Forms.Panel panelQueen;
        private System.Windows.Forms.Panel panelRook;
        private System.Windows.Forms.Panel panelKnight;
        private System.Windows.Forms.Panel panelBishop;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
    }
}