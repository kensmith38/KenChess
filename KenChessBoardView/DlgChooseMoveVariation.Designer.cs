namespace KenChessBoardView
{
    partial class DlgChooseMoveVariation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelGameFile = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_ChildMoveIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column_ABCetc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MoveChoiceInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGameFile
            // 
            this.labelGameFile.AutoSize = true;
            this.labelGameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameFile.Location = new System.Drawing.Point(12, 9);
            this.labelGameFile.Name = "labelGameFile";
            this.labelGameFile.Size = new System.Drawing.Size(190, 20);
            this.labelGameFile.TabIndex = 39;
            this.labelGameFile.Text = "Choose move variation";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ChildMoveIndex,
            this.Column_Select,
            this.Column_ABCetc,
            this.Column_MoveChoiceInfo});
            this.dataGridView1.Location = new System.Drawing.Point(30, 45);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(548, 235);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column_ChildMoveIndex
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Column_ChildMoveIndex.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_ChildMoveIndex.HeaderText = "Child move index";
            this.Column_ChildMoveIndex.Name = "Column_ChildMoveIndex";
            this.Column_ChildMoveIndex.ReadOnly = true;
            this.Column_ChildMoveIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ChildMoveIndex.Visible = false;
            this.Column_ChildMoveIndex.Width = 50;
            // 
            // Column_Select
            // 
            this.Column_Select.HeaderText = "Select";
            this.Column_Select.Name = "Column_Select";
            this.Column_Select.ReadOnly = true;
            this.Column_Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Select.Text = "Select";
            this.Column_Select.UseColumnTextForButtonValue = true;
            this.Column_Select.Width = 60;
            // 
            // Column_ABCetc
            // 
            this.Column_ABCetc.HeaderText = "ABC etc";
            this.Column_ABCetc.Name = "Column_ABCetc";
            this.Column_ABCetc.ReadOnly = true;
            this.Column_ABCetc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ABCetc.Width = 30;
            // 
            // Column_MoveChoiceInfo
            // 
            this.Column_MoveChoiceInfo.HeaderText = "Move choice info";
            this.Column_MoveChoiceInfo.Name = "Column_MoveChoiceInfo";
            this.Column_MoveChoiceInfo.ReadOnly = true;
            this.Column_MoveChoiceInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_MoveChoiceInfo.Width = 430;
            // 
            // DlgChooseMoveVariation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 292);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelGameFile);
            this.Name = "DlgChooseMoveVariation";
            this.Text = "DlgChooseMoveVariation";
            this.Load += new System.EventHandler(this.DlgChooseMoveVariation_Load);
            this.Shown += new System.EventHandler(this.DlgChooseMoveVariation_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGameFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ChildMoveIndex;
        private System.Windows.Forms.DataGridViewButtonColumn Column_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ABCetc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MoveChoiceInfo;
    }
}