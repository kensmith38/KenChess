using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessBoardModel
{
    public class ChessPiece
    {
        public PieceType PieceType { get; set; }
        public char PieceColor { get; set; }
        public char UnicodeCharForPiece { get; set; }
        public char FENCharForPiece { get; set; }
        /// <summary>
        /// Creates a piece of type=None
        /// </summary>
        public ChessPiece()
        {
            PieceType = PieceType.None;
            PieceColor = ' ';
            UnicodeCharForPiece = ' ';
            FENCharForPiece = ' ';
        }
        /// <summary>
        /// Creates a new ChessPiece based on piece type and color
        /// </summary>
        public ChessPiece(PieceType pieceType, char pieceColor)
        {
            PieceType = pieceType;
            PieceColor = pieceColor;
            UnicodeCharForPiece = GetUnicodeCharForPiece(pieceType, pieceColor);
            FENCharForPiece = GetFENcharForPiece(pieceType, pieceColor);
        }
        /// <summary>
        /// Create a new ChessPiece based on FENchar (ex: 'K' creates a white King)
        /// </summary>
        public ChessPiece(char FENchar)
        {
            switch (FENchar)
            {
                case 'P': PieceType = PieceType.Pawn; break;
                case 'p': PieceType = PieceType.Pawn; break;
                case 'R': PieceType = PieceType.Rook; break;
                case 'r': PieceType = PieceType.Rook; break;
                case 'N': PieceType = PieceType.Knight; break;
                case 'n': PieceType = PieceType.Knight; break;
                case 'B': PieceType = PieceType.Bishop; break;
                case 'b': PieceType = PieceType.Bishop; break;
                case 'Q': PieceType = PieceType.Queen; break;
                case 'q': PieceType = PieceType.Queen; break;
                case 'K': PieceType = PieceType.King; break;
                case 'k': PieceType = PieceType.King; break;
                default:
                    PieceType = PieceType.None;
                    break;
            }
            PieceColor = "PRNBQK".Contains(FENchar.ToString()) ? 'w' : 'b';
            UnicodeCharForPiece = GetUnicodeCharForPiece(PieceType, PieceColor);
            FENCharForPiece = FENchar;
        }
        // Reference: https://symbl.cc/en/collections/chess-symbols/
        // 4/22/2023 Tricky! The referenced web page had a copy button so I could copy the unicode char and paste here.
        // Suggestions on the internet to use Alt+x did not work.
        private char GetUnicodeCharForPiece(PieceType pieceType, char pieceColor)
        {
            char pieceAsUnicodeChar = ' ';
            if (pieceColor == 'w')
            {
                switch (pieceType)
                {
                    case PieceType.Pawn: // Unicode 2659 
                        pieceAsUnicodeChar = '♙';
                        break;
                    case PieceType.Rook: // Unicode 2656
                        pieceAsUnicodeChar = '♖';
                        break;
                    case PieceType.Knight: // Unicode 2658
                        pieceAsUnicodeChar = '♘';
                        break;
                    case PieceType.Bishop: // Unicode 2657
                        pieceAsUnicodeChar = '♗';
                        break;
                    case PieceType.Queen: // Unicode 2655
                        pieceAsUnicodeChar = '♕';
                        break;
                    case PieceType.King: // Unicode 2654
                        pieceAsUnicodeChar = '♔';
                        break;
                    default:
                        break;
                }
            }
            if (pieceColor == 'b') // Unicode 265A-265F (black KQRBNP)
            {
                switch (pieceType)
                {
                    case PieceType.Pawn:
                        pieceAsUnicodeChar = '♟';
                        break;
                    case PieceType.Rook:
                        pieceAsUnicodeChar = '♜';
                        break;
                    case PieceType.Knight:
                        pieceAsUnicodeChar = '♞';
                        break;
                    case PieceType.Bishop:
                        pieceAsUnicodeChar = '♝';
                        break;
                    case PieceType.Queen:
                        pieceAsUnicodeChar = '♛';
                        break;
                    case PieceType.King:
                        pieceAsUnicodeChar = '♚';
                        break;
                    default:
                        break;
                }
            }
            return pieceAsUnicodeChar;
        }
        private char GetFENcharForPiece(PieceType pieceType, char pieceColor)
        {
            char FENchar = ' ';
            switch (pieceType)
            {
                case PieceType.Pawn:
                    FENchar = pieceColor == 'w' ? 'P' : 'p';
                    break;
                case PieceType.Rook:
                    FENchar = pieceColor == 'w' ? 'R' : 'r';
                    break;
                case PieceType.Bishop:
                    FENchar = pieceColor == 'w' ? 'B' : 'b';
                    break;
                case PieceType.Knight:
                    FENchar = pieceColor == 'w' ? 'N' : 'n';
                    break;
                case PieceType.Queen:
                    FENchar = pieceColor == 'w' ? 'Q' : 'q';
                    break;
                case PieceType.King:
                    FENchar = pieceColor == 'w' ? 'K' : 'k';
                    break;
            }
            return FENchar;
        }
        public override string ToString()
        {
            string friendlyName = PieceColor == 'w' ? "White" : "Black";
            friendlyName += PieceType.ToString();
            return friendlyName;
        }
    }
}

