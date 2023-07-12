using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChessBoardModel;
using KenChessPGNCoreLibrary;

namespace KenChessBoardView
{
    /// <summary>
    /// An AnimatedChessPiece is used to slowly move a piece from one square to another so it is seen by the user.
    /// </summary>
    
    public class AnimatedChessPiece
    {
        // The image (or unicode char) for the piece being animated is determined by the piece on the SquareFrom
        public string SquareFromUciName { get; set; }
        public string SquareToUciName { get; set; }
        public float PercentComplete { get; set; }
        public ChessMoveNode JumpToChessMoveNodeAfterAnimation { get; set; }

        public AnimatedChessPiece(string squareFromUciName, string squareToUciName, ChessMoveNode jumpToChessMoveNodeAfterAnimation)
        {
            SquareFromUciName = squareFromUciName;
            SquareToUciName = squareToUciName;
            JumpToChessMoveNodeAfterAnimation = jumpToChessMoveNodeAfterAnimation;

            PercentComplete = 0;
        }
        
        public RectangleF getRectForPercentComplete(PictureBox pictureBoxChessBoard, bool boardIsFlipped)
        {
            RectangleF rect = new RectangleF();
            int squareFromFileIndex = "abcdefgh".IndexOf(SquareFromUciName.Substring(0, 1));
            int squareFromRankIndex = int.Parse(SquareFromUciName.Substring(1, 1)) - 1;
            int squareToFileIndex = "abcdefgh".IndexOf(SquareToUciName.Substring(0, 1));
            int squareToRankIndex = int.Parse(SquareToUciName.Substring(1, 1)) - 1;

            int squareFromAdjustedFileIndex = boardIsFlipped ? 7 - squareFromFileIndex : squareFromFileIndex;
            int squareFromAdjustedRankIndex = boardIsFlipped ? 7 - squareFromRankIndex : squareFromRankIndex;
            int squareToAdjustedFileIndex = boardIsFlipped ? 7 - squareToFileIndex : squareToFileIndex;
            int squareToAdjustedRankIndex = boardIsFlipped ? 7 - squareToRankIndex : squareToRankIndex;

            float startCornerX = (squareFromAdjustedFileIndex) * ((float)pictureBoxChessBoard.Width / 8);
            float startCornerY = (float)pictureBoxChessBoard.Height - (squareFromAdjustedRankIndex + 1) * ((float)pictureBoxChessBoard.Height / 8);
            float endCornerX = (squareToAdjustedFileIndex) * ((float)pictureBoxChessBoard.Width / 8);
            float endCornerY = (float)pictureBoxChessBoard.Height - (squareToAdjustedRankIndex + 1) * ((float)pictureBoxChessBoard.Height / 8);
            float xDistance = endCornerX - startCornerX;
            float yDistance = endCornerY - startCornerY;

            rect.X = startCornerX + (PercentComplete / 100 * xDistance);
            rect.Y = startCornerY + (PercentComplete / 100 * yDistance);
            rect.Width = pictureBoxChessBoard.Width / 8;
            rect.Height = pictureBoxChessBoard.Height / 8;
            return rect;
        }
    }
}
