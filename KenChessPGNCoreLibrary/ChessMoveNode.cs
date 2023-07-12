using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KenChessBoardModel;
using KenGenericNode;

namespace KenChessPGNCoreLibrary
{
    // A ChessMove is more than the Standard Alagebraic Notation (SAN); it is also the move color and text commentary and much more.
    public class ChessMoveNode : KenNode
    {
        // FriendlyMoveNumber is the digits and periods for a move (ex: 1. e4  or  (20... Qxc2)
        public string FriendlyMoveNumber { get; set; }
        // Moves at variation depth=0 are the mainline moves.
        public int MoveVariationDepth { get; set; }
        // Standard Algebraic Notation move (ex: Nf3 exf4 Red1)
        public string SANmove { get; set; }
        // Tricky! UCImove is initially null.  It is set when a GameRepresentation is instantiated.
        public string UCImove { get; set; }
        // Numeric Annotation Glyph
        // For values whose text meaning is only 1 or 2 characters, that text is appended to SANmove; otherwise the text is comment after move.
        // ex: value=3 changes SANmove from Qxd1 to Qxd1!!
        //..public int NAGvalue { get; set; }
        public string TextBeforeMove { get; set; }
        public string TextAfterMove { get; set; }

        // Tricky! FENPositionAfterChessMove is initially null; it set when a GameRepresentation is instantiated.
        public string FENPositionAfterChessMove { get; set; }
        // Design: ChessMoveNode inherits from KenNode so ChildNodes and ParentNode are properties in KenNode
        public ChessMoveNode()
        {
            FriendlyMoveNumber = "";
            MoveVariationDepth = 0;
            SANmove = null;
            //..NAGvalue = -1;
            TextBeforeMove = "";
            TextAfterMove = "";
        }
        
        /// <summary>
        /// Convert a ChessMoveNode into ASCII PGN text for that node (parm determines if Friendly Move number should be included.)
        /// </summary>
        /// <param name="inludeFriendlyMoveNumber"></param>
        /// <returns></returns>
        public string FormatAsPgnMovetext(bool includeFriendlyMoveNumber)
        {
            string pgnMoveText = string.Empty;
            string asciiMoveNumber = string.IsNullOrWhiteSpace(FriendlyMoveNumber) ? string.Empty : FriendlyMoveNumber + " ";
            if (!includeFriendlyMoveNumber) { asciiMoveNumber = string.Empty; }
            // Tricky! This will return empty string if SANmove is null or empty (which occurs for game termination node)
            if (!string.IsNullOrWhiteSpace(SANmove))
            {
                pgnMoveText = (string.IsNullOrWhiteSpace(TextBeforeMove) ? string.Empty : "{" + TextBeforeMove + "} ")
                        + asciiMoveNumber
                        + SANmove + " "
                        + (string.IsNullOrWhiteSpace(TextAfterMove) ? string.Empty : "{" + TextAfterMove + "} ");
            }
            return pgnMoveText;
        }
        /// <summary>
        /// gets the mainline path starting at a specific node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<ChessMoveNode> GetMainlinePath(ChessMoveNode specificNode)
        {
            List<ChessMoveNode> mainlinePath = new List<ChessMoveNode>();
            ChessMoveNode nextnode = specificNode;
            while (nextnode != null)
            {
                mainlinePath.Add(nextnode);
                nextnode = nextnode.ChildNodes.Count > 0 ? (ChessMoveNode)nextnode.ChildNodes[0] : null;
            }
            return mainlinePath;
        }
        
        /// <summary>
        /// It only makes sense to determine stalemate/checkmate if the node has no mainline child.
        /// </summary>
        public GameResult GameResultAfterMove()
        {
            GameResult gameResult = GameResult.Unknown;
            if ((ChildNodes.Count == 0) || ((ChessMoveNode)ChildNodes[0]).SANmove == null)
            {
                ChessBoard chessBoard = new ChessBoard(FENPositionAfterChessMove);
                List<string> listLegalUciMoves = UtilitiesLegalUCIMoves.getAllLegalUciMovesForActivePlayer(chessBoard, '*');
                if (listLegalUciMoves.Count == 0)
                {
                    gameResult = (UtilitiesActivePlayerInCheck.isActivePlayerInCheck(chessBoard)) ? GameResult.Checkmate : GameResult.Stalemate;
                }
            }
            return gameResult;
        }
        public override string ToString()
        {
            return FriendlyMoveNumber + SANmove + (NodeNeedsExpansion ? "x" : "");
        }
    }
}
