using KenChessPGNCoreLibrary;
using KenGenericNode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessBoardView
{
    public class RichTextViewer
    {
        public RichTextBox RichTextBox { get; set; }
        GameRepresentation GameRepresentation { get; set; }
        public List<MapItemForRichText> mapItems { get; set; }
        // The MapItemForCurrentlyHighlightedChessMove helps us highlight and un-highlight moves in the RichTextBox as current move changes.
        public MapItemForRichText MapItemForCurrentlyHighlightedChessMove { get; set; }
        public ContextMenu ContextMenuRichTextBox { get; set; }
        public ChessMoveNode ChessMoveNodeForRTBContextMenu { get; set; }
        public RichTextViewer(GameRepresentation gameRepresentation, RichTextBox rtb)
        {
            createContextMenuForRichTextBox();

            GameRepresentation = gameRepresentation;
            RichTextBox = rtb;
            mapItems = new List<MapItemForRichText>();
            generateRichText();
            RichTextBox.SelectionStart = 0;
            RichTextBox.SelectionLength = 0;
            RichTextBox.ScrollToCaret();
        }
        public void createContextMenuForRichTextBox()
        {
            MenuItem[] suffixes = new MenuItem[6];
            suffixes[0] = new MenuItem("!", AddSuffix_Click);
            suffixes[1] = new MenuItem("?", AddSuffix_Click);
            suffixes[2] = new MenuItem("!!", AddSuffix_Click);
            suffixes[3] = new MenuItem("!?", AddSuffix_Click);
            suffixes[4] = new MenuItem("?!", AddSuffix_Click);
            suffixes[5] = new MenuItem("??", AddSuffix_Click);
            MenuItem[] menuItems = new MenuItem[]{
                new MenuItem("Add commentary to move...", AddCommentary_Click),
                new MenuItem("!, ? ...", suffixes),
                new MenuItem("Exit")};
            ContextMenuRichTextBox = new ContextMenu(menuItems);

        }

        // This method is an event handler for adding commentary to move.
        private void AddCommentary_Click(Object sender, System.EventArgs e)
        {
            DlgInsertCommentary dlg = new DlgInsertCommentary(ChessMoveNodeForRTBContextMenu);
            dlg.ShowDialog();
            mapItems = new List<MapItemForRichText>();
            generateRichText();
            highlightCurrentMoveInRichText(ChessMoveNodeForRTBContextMenu);
            ChessMoveNodeForRTBContextMenu = null;
        }
        // This method is an event handler for adding suffix annotation for a move.
        private void AddSuffix_Click(Object sender, System.EventArgs e)
        {
            string suffix = ((MenuItem)sender).Text;
            // remove any existing suffix!
            ChessMoveNodeForRTBContextMenu.SANmove = ChessMoveNodeForRTBContextMenu.SANmove.Replace("!!", "");
            ChessMoveNodeForRTBContextMenu.SANmove = ChessMoveNodeForRTBContextMenu.SANmove.Replace("??", "");
            ChessMoveNodeForRTBContextMenu.SANmove = ChessMoveNodeForRTBContextMenu.SANmove.Replace("!?", "");
            ChessMoveNodeForRTBContextMenu.SANmove = ChessMoveNodeForRTBContextMenu.SANmove.Replace("?!", "");
            ChessMoveNodeForRTBContextMenu.SANmove = ChessMoveNodeForRTBContextMenu.SANmove.Replace("!", "");
            ChessMoveNodeForRTBContextMenu.SANmove = ChessMoveNodeForRTBContextMenu.SANmove.Replace("?", "");
            // add selected suffix
            ChessMoveNodeForRTBContextMenu.SANmove += suffix;
            mapItems = new List<MapItemForRichText>();
            generateRichText();
            highlightCurrentMoveInRichText(ChessMoveNodeForRTBContextMenu);
            ChessMoveNodeForRTBContextMenu = null;
        }
        public void generateRichText()
        {
            if (GameRepresentation.RootNode == null) { return; }
            Font boldFont = new Font(RichTextBox.Font, FontStyle.Bold);
            RichTextBox.Clear();
            int nextStartPosition = 0;
            int moveDepth = 0;

            KenNode lookaheadNode = null;
            KenNode priorNode = null;
            ChessMoveNode rootnode = GameRepresentation.RootNode;
            rootnode.NodeNeedsExpansion = true;
            List<KenNode> rootpath = new List<KenNode>
                {
                    rootnode
                };
            UtilitiesForNodes.ExpandCorePath(rootpath);
            // rootpath is now fully expanded!
            foreach (KenNode node in rootpath)
            {
                ChessMoveNode chessMoveNode = node.GetType() == typeof(ChessMoveNode) ? (ChessMoveNode)node : null;
                int indexOfNode = rootpath.IndexOf(node);
                lookaheadNode = indexOfNode + 1 < rootpath.Count ? rootpath[indexOfNode + 1] : null;
                MapItemForRichText mapItem = new MapItemForRichText();
                mapItem.ChessMove = chessMoveNode;
                if (node.IsLeftParenthesisNode())
                {
                    if (RichTextBox.Text.EndsWith("\n"))
                    {
                        RichTextBox.AppendText("(");
                    }
                    else
                    {
                        RichTextBox.AppendText("\n(");
                    }
                    moveDepth++;
                    RichTextBox.SelectionIndent = 20 * moveDepth;
                }

                if ((chessMoveNode != null) && (chessMoveNode.TextBeforeMove.Length > 0))
                {
                    RichTextBox.SelectionColor = Color.Blue;
                    RichTextBox.SelectionFont = RichTextBox.Font;
                    RichTextBox.AppendText(chessMoveNode.TextBeforeMove.Trim() + " ");
                }
                if ((chessMoveNode != null) && (chessMoveNode.FriendlyMoveNumber.Length > 0))
                {
                    RichTextBox.SelectionColor = Color.Black;
                    RichTextBox.SelectionFont = chessMoveNode.MoveVariationDepth == 0 ? boldFont : RichTextBox.Font;
                    string fenPositionAfterMove = ((ChessMoveNode)node).FENPositionAfterChessMove;
                    string activePlayer = UtilitiesFEN.GetActivePlayerFromFEN(fenPositionAfterMove).Equals("w") ? "b" : "w";
                    bool includeFriendlyMoveNumber = true;
                    if ((priorNode != null) &&
                        (!priorNode.IsLeftParenthesisNode()) &&
                        (activePlayer.Equals("b")))
                    {
                        includeFriendlyMoveNumber = false;
                    }
                    if (includeFriendlyMoveNumber)
                    {
                        RichTextBox.AppendText(chessMoveNode.FriendlyMoveNumber);
                        RichTextBox.AppendText(" ");
                    }
                }
                if ((chessMoveNode != null) && (chessMoveNode.SANmove != null))
                {

                    RichTextBox.SelectionColor = Color.Black;
                    RichTextBox.SelectionFont = (((ChessMoveNode)node).MoveVariationDepth == 0) ? boldFont : RichTextBox.Font;
                    RichTextBox.AppendText(((ChessMoveNode)node).SANmove);
                }
                RichTextBox.SelectionFont = RichTextBox.Font;
                if ((chessMoveNode != null) && (chessMoveNode.TextAfterMove.Length > 0))
                {
                    RichTextBox.SelectionColor = Color.Blue;
                    RichTextBox.SelectionFont = RichTextBox.Font;
                    RichTextBox.AppendText(" " + chessMoveNode.TextAfterMove.Trim());
                }
                if (node.IsRightParenthesisNode())
                {
                    moveDepth--;
                    if ((lookaheadNode != null) && (lookaheadNode.IsRightParenthesisNode()))
                    {
                        RichTextBox.AppendText(")");
                    }
                    else
                    {
                        RichTextBox.AppendText(")\n");
                        RichTextBox.SelectionIndent = 20 * moveDepth;
                    }
                }
                if (!RichTextBox.Text.EndsWith("\n"))
                {
                    RichTextBox.AppendText("  ");
                }
                mapItem.EndPosition = RichTextBox.Text.Length;
                if (chessMoveNode != null)
                {
                    mapItem.StartPosition = nextStartPosition;
                    mapItems.Add(mapItem);
                    nextStartPosition = mapItem.EndPosition;
                }
                priorNode = node;
            }
        }
        /// <summary>
        /// Gets the ChessMoveNode corresponding to mouse click coordinates in RichTextBox!
        /// </summary>
        public ChessMoveNode userMouseDownInRichTextBox(MouseEventArgs e)
        {
            ChessMoveNode chessMove = null;
            // @ken 6/23/2023 Restricting to left button prevented right mouse click context menu from setting current move and highlighting it.
            if (1 == 1) //(e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                if (GameRepresentation != null)
                {
                    // Obtain the character index where the user clicks on the control.
                    int clickedPosition = RichTextBox.GetCharIndexFromPosition(new Point(e.X, e.Y));
                    if (clickedPosition <= RichTextBox.Text.Length)
                    {
                        //char characterClicked = richTextBoxShowingMoves.Text.Length > clickedPosition ? richTextBoxShowingMoves.Text[clickedPosition] : '~';
                        //Constants.DisplayInfoMessage($"Clicked position {clickedPosition.ToString()}; char={characterClicked}");
                        chessMove = GetChessMove(clickedPosition);
                        //Constants.DisplayInfoMessage($"Clicked SAN: {chessMove.SANmove}");
                        if ((chessMove != null) && (chessMove.SANmove != null))
                        {
                            highlightCurrentMoveInRichText(chessMove);
                        }
                    }
                }
            }
            return chessMove;
        }
        // TODO highlightCurrentMoveInRichText may be getting called when not necessary (perhaps KenChessUserControl could do all highlighting exclusively)
        public void highlightCurrentMoveInRichText(ChessMoveNode chessMove)
        {
            MapItemForRichText mapItem = GetMapItem(chessMove);
            if (mapItem != null)
            {
                // Remove highlight from last move
                if (MapItemForCurrentlyHighlightedChessMove != null)
                {
                    RichTextBox.Select(MapItemForCurrentlyHighlightedChessMove.StartPosition,
                        (MapItemForCurrentlyHighlightedChessMove.EndPosition - MapItemForCurrentlyHighlightedChessMove.StartPosition));
                    RichTextBox.SelectionBackColor = Color.White;
                }
                // Tricky! We want to highlight SAN but not the comments before or after the SAN of the ChessMove
                if (chessMove.SANmove != null)
                {
                    int highlightStart = RichTextBox.Find(chessMove.SANmove, 
                        mapItem.StartPosition + chessMove.TextBeforeMove.Length, 
                        mapItem.EndPosition, RichTextBoxFinds.WholeWord);
                    if (highlightStart >= 0)
                    {
                        int highlightEnd = highlightStart + chessMove.SANmove.Length;
                        RichTextBox.Select(highlightStart, highlightEnd - highlightStart);
                        RichTextBox.SelectionBackColor = Color.PaleGreen;
                        MapItemForCurrentlyHighlightedChessMove = mapItem;
                        RichTextBox.Select(mapItem.StartPosition, 0);
                    }
                }
            }
            else
            {
                // Remove highlight from last move
                if (MapItemForCurrentlyHighlightedChessMove != null)
                {
                    RichTextBox.Select(MapItemForCurrentlyHighlightedChessMove.StartPosition,
                        (MapItemForCurrentlyHighlightedChessMove.EndPosition - MapItemForCurrentlyHighlightedChessMove.StartPosition));
                    RichTextBox.SelectionBackColor = Color.White;
                }
                RichTextBox.Select(0, 0);
                MapItemForCurrentlyHighlightedChessMove = null;
            }
        }
        /// <summary>
        /// Gets the ChessMove corresponding to the position specified in RichText.
        /// </summary>
        /// <param name="richtextPosition"></param>
        /// <returns></returns>
        public ChessMoveNode GetChessMove(int richtextPosition)
        {
            ChessMoveNode chessMove = null;
            foreach (MapItemForRichText mapItem in mapItems)
            {
                if ((mapItem.StartPosition <= richtextPosition) && (mapItem.EndPosition >= richtextPosition))
                {
                    chessMove = mapItem.ChessMove;
                    break;
                }
            }
            return chessMove;
        }
        /// <summary>
        /// Gets the MapItem corresponding to the specific chessMove.
        /// </summary>
        /// <param name="chessMove"></param>
        /// <returns></returns>
        public MapItemForRichText GetMapItem(ChessMoveNode chessMove)
        {
            MapItemForRichText desiredMapItem = null;
            foreach (MapItemForRichText mapItem in mapItems)
            {
                if (mapItem.ChessMove == chessMove)
                {
                    desiredMapItem = mapItem;
                    break;
                }
            }
            return desiredMapItem;
        }
    }
    public class MapItemForRichText
    {
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public ChessMoveNode ChessMove { get; set; }
        public MapItemForRichText()
        {
            StartPosition = 0;
            EndPosition = 0;
            ChessMove = null;
        }
        public override string ToString()
        {
            return $"{StartPosition}-{EndPosition} {ChessMove.SANmove}";
        }
    }
}
