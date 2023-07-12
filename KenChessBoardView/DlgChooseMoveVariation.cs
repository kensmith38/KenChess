using KenChessPGNCoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessBoardView
{
    public partial class DlgChooseMoveVariation : Form
    {
        public ChessMoveNode UserSelectedChessMoveNode { get; set; }
        ChessMoveNode CurrentChessMove { get; set; }
        public DlgChooseMoveVariation(ChessMoveNode currentChessMove)
        {
            InitializeComponent();
            CurrentChessMove = currentChessMove;
        }

        private void DlgChooseMoveVariation_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // in case user cancels the dialog!
                UserSelectedChessMoveNode = (ChessMoveNode)CurrentChessMove.ChildNodes[0];
                PopulateDatagrid();
            }
            catch (Exception exc)
            {
                Constants.DisplayExceptionMessage(exc);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
        private void PopulateDatagrid()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexNextMove = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnHeadersVisible = false;
            foreach (ChessMoveNode chessMoveNode in CurrentChessMove.ChildNodes)
            {
                DataGridViewRow dgvrow = dataGridView1.Rows[dataGridView1.Rows.Add()];
                dgvrow.Cells[Column_ABCetc.Index].Value = letters[indexNextMove] + ")";
                dgvrow.Cells[Column_ChildMoveIndex.Index].Value = indexNextMove;
                dgvrow.Cells[Column_MoveChoiceInfo.Index].Value = generateMoveChoiceInfoForMove(chessMoveNode);
                indexNextMove++;
            }
        }
        // Tricky! DataGridView ClearSelection won't work during load event!
        private void DlgChooseMoveVariation_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        /// <summary>
        /// Shows move path (up to 10 moves) for mainline moves starting at given move
        /// </summary>
        private string generateMoveChoiceInfoForMove(ChessMoveNode chessMoveNode)
        {
            int ctrMovesInPath = 0;
            ChessMoveNode nextMainlineMove = chessMoveNode.ChildNodes.Count > 0 ? (ChessMoveNode)chessMoveNode.ChildNodes[0] : null;
            string info = chessMoveNode.FriendlyMoveNumber + chessMoveNode.SANmove;
            while (nextMainlineMove != null)
            {
                ctrMovesInPath++;
                info += "  " + nextMainlineMove.FriendlyMoveNumber + nextMainlineMove.SANmove;
                nextMainlineMove = nextMainlineMove.ChildNodes.Count > 0 ? (ChessMoveNode)nextMainlineMove.ChildNodes[0] : null;
                if (ctrMovesInPath > 10)
                {
                    break;
                }
            }
            return info;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column_Select.Index)
            {
                UserSelectedChessMoveNode = (ChessMoveNode)CurrentChessMove.ChildNodes[e.RowIndex];
                Close();
            }
        }
    }
}
