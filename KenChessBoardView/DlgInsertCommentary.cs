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
    public partial class DlgInsertCommentary : Form
    {
        ChessMoveNode MoveBeingUpdated;
        
        public DlgInsertCommentary(ChessMoveNode moveBeingUpdated)
        {
            InitializeComponent();
            MoveBeingUpdated = moveBeingUpdated;
        }

        private void DlgInsertCommentary_Load(object sender, EventArgs e)
        {
            textBoxMoveBeingUpdated.Text = MoveBeingUpdated.SANmove;
            textBoxTextBeforeMove.Text = MoveBeingUpdated.TextBeforeMove;
            textBoxTextAfterMove.Text = MoveBeingUpdated.TextAfterMove;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // {{ is how you code a left brace
            MoveBeingUpdated.TextBeforeMove = textBoxTextBeforeMove.Text.Trim().Length > 0 ?
                $"{textBoxTextBeforeMove.Text}" : "";
            MoveBeingUpdated.TextAfterMove = textBoxTextAfterMove.Text.Trim().Length > 0 ?
                $"{textBoxTextAfterMove.Text}" : "";
            DialogResult = DialogResult.OK;
            Close();
        }
        
    }
}
