namespace KenChessMain
{
    partial class FormListGames
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxCtrGames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewListGames = new System.Windows.Forms.DataGridView();
            this.Column_ListGames_GameNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_White = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Black = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_LoadGame = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameDatabaseName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListGames)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCtrGames
            // 
            this.textBoxCtrGames.Location = new System.Drawing.Point(609, 53);
            this.textBoxCtrGames.Name = "textBoxCtrGames";
            this.textBoxCtrGames.ReadOnly = true;
            this.textBoxCtrGames.Size = new System.Drawing.Size(75, 20);
            this.textBoxCtrGames.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Number of games:";
            // 
            // dataGridViewListGames
            // 
            this.dataGridViewListGames.AllowUserToAddRows = false;
            this.dataGridViewListGames.AllowUserToDeleteRows = false;
            this.dataGridViewListGames.AllowUserToResizeRows = false;
            this.dataGridViewListGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewListGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ListGames_GameNumber,
            this.Column_ListGames_Event,
            this.Column_ListGames_Date,
            this.Column_ListGames_White,
            this.Column_ListGames_Black,
            this.Column_ListGames_Result,
            this.Column_ListGames_LoadGame});
            this.dataGridViewListGames.Location = new System.Drawing.Point(12, 79);
            this.dataGridViewListGames.Name = "dataGridViewListGames";
            this.dataGridViewListGames.ReadOnly = true;
            this.dataGridViewListGames.RowHeadersVisible = false;
            this.dataGridViewListGames.Size = new System.Drawing.Size(685, 470);
            this.dataGridViewListGames.TabIndex = 31;
            this.dataGridViewListGames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListGames_CellContentClick);
            // 
            // Column_ListGames_GameNumber
            // 
            this.Column_ListGames_GameNumber.HeaderText = "Game #";
            this.Column_ListGames_GameNumber.Name = "Column_ListGames_GameNumber";
            this.Column_ListGames_GameNumber.ReadOnly = true;
            this.Column_ListGames_GameNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ListGames_GameNumber.Width = 60;
            // 
            // Column_ListGames_Event
            // 
            this.Column_ListGames_Event.HeaderText = "Event";
            this.Column_ListGames_Event.Name = "Column_ListGames_Event";
            this.Column_ListGames_Event.ReadOnly = true;
            // 
            // Column_ListGames_Date
            // 
            this.Column_ListGames_Date.HeaderText = "Date";
            this.Column_ListGames_Date.Name = "Column_ListGames_Date";
            this.Column_ListGames_Date.ReadOnly = true;
            // 
            // Column_ListGames_White
            // 
            this.Column_ListGames_White.HeaderText = "White";
            this.Column_ListGames_White.Name = "Column_ListGames_White";
            this.Column_ListGames_White.ReadOnly = true;
            // 
            // Column_ListGames_Black
            // 
            this.Column_ListGames_Black.HeaderText = "Black";
            this.Column_ListGames_Black.Name = "Column_ListGames_Black";
            this.Column_ListGames_Black.ReadOnly = true;
            // 
            // Column_ListGames_Result
            // 
            this.Column_ListGames_Result.HeaderText = "Result";
            this.Column_ListGames_Result.Name = "Column_ListGames_Result";
            this.Column_ListGames_Result.ReadOnly = true;
            // 
            // Column_ListGames_LoadGame
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Column_ListGames_LoadGame.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column_ListGames_LoadGame.HeaderText = "Load game...";
            this.Column_ListGames_LoadGame.Name = "Column_ListGames_LoadGame";
            this.Column_ListGames_LoadGame.ReadOnly = true;
            this.Column_ListGames_LoadGame.Text = "Load game...";
            this.Column_ListGames_LoadGame.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "List of games in PGN file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Game database:";
            // 
            // textBoxGameDatabaseName
            // 
            this.textBoxGameDatabaseName.Location = new System.Drawing.Point(402, 27);
            this.textBoxGameDatabaseName.Name = "textBoxGameDatabaseName";
            this.textBoxGameDatabaseName.ReadOnly = true;
            this.textBoxGameDatabaseName.Size = new System.Drawing.Size(282, 20);
            this.textBoxGameDatabaseName.TabIndex = 35;
            // 
            // FormListGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 561);
            this.Controls.Add(this.textBoxGameDatabaseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCtrGames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewListGames);
            this.Controls.Add(this.label1);
            this.Name = "FormListGames";
            this.Text = "FormListGames";
            this.Load += new System.EventHandler(this.FormListGames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCtrGames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewListGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_GameNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_White;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Black;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Result;
        private System.Windows.Forms.DataGridViewButtonColumn Column_ListGames_LoadGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameDatabaseName;
    }
}