using KenChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreLibrary
{
    public class UtilitiesFEN
    {
        // Reference: https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
        public static string GetActivePlayerFromFEN(string fenPosition)
        {
            string[] FENparts = fenPosition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string FENPiecePlacement = FENparts[0];
            string FENActivePlayer = FENparts[1];
            //string FENCastlingAvailability = FENparts[2];
            //string FENEnpassantTargetSquare = FENparts[3];
            //string FENHalfmoveClock = FENparts[4];
            //string FENFullMoveNumber = FENparts[5];
            return FENActivePlayer;
        }
        /// <summary>
        /// Gets EnPassant Square name from FEN.  Result may be "-" if there is no enpassant square.
        /// </summary>
        public static string GetEnPassantSquareFromFEN(string fenPosition)
        {
            string[] FENparts = fenPosition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string FENPiecePlacement = FENparts[0];
            //string FENActivePlayer = FENparts[1];
            //string FENCastlingAvailability = FENparts[2];
            string FENEnpassantTargetSquare = FENparts[3];
            //string FENHalfmoveClock = FENparts[4];
            //string FENFullMoveNumber = FENparts[5];
            return FENEnpassantTargetSquare;
        }
        /// <summary>
        /// Gets fullmove number from FEN. 
        /// </summary>
        public static int GetFullMoveNumberFromFEN(string fenPosition)
        {
            string[] FENparts = fenPosition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string FENPiecePlacement = FENparts[0];
            //string FENActivePlayer = FENparts[1];
            //string FENCastlingAvailability = FENparts[2];
            //string FENEnpassantTargetSquare = FENparts[3];
            //string FENHalfmoveClock = FENparts[4];
            string FENFullMoveNumber = FENparts[5];
            if (int.TryParse(FENFullMoveNumber, out int fullmoveNumber) == false)
            {
                fullmoveNumber = 999;
            }
            return fullmoveNumber;
        }
        /// <summary>
        /// Gets FEN string from GameTags (dictionary of PGN tag pairs).  Default FEN setup is returned if GameTags has no FEN tag.
        /// </summary>
        public static string GetInitialFENSetupFromGameTags(Dictionary<string, string> GameTags)
        {
            // Default is the standard initial setup for a chess game
            string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            if (GameTags.ContainsKey("SetUp") && GameTags.ContainsKey("FEN"))
            {
                if (GameTags["SetUp"].Equals("1"))
                {
                    fen = GameTags["FEN"];
                }
            }
            return fen;
        }
        public static string GetFENPositionAfterChessMove(string fenPositionBeforeChessMove, string uciMove)
        {
            string fenAfterMove;
            ChessBoard chessBoard = new ChessBoard(fenPositionBeforeChessMove);
            chessBoard.PerformUciMove(uciMove);
            fenAfterMove = chessBoard.FEN;
            return fenAfterMove;
        }
    }
}
