using KenChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessBoardView
{
    // TODO DragChessPiece logic makes more sense if the properties for origin and destination squares were the UCI square names instead
    public class DragChessPiece
    {
        public bool DragInProgess { get; set; }
        public ChessPiece PieceBeingDragged { get; set; }
        public ChessSquare OriginChessSquare { get; set; }
        public ChessSquare DestinationChessSquare { get; set; }
        // Helps paint the drag motion
        public Coordinates CurrentCoordinatesOfDrag { get; set; }
        // Tricky! The X/YOffsets help move the piece smoothly!
        // The offsets tell how far the user clicked from the top left corner of the ChessSquare.
        // As the mouse is moved and the image redrawn, the offsets are used when computing the rectangle to paint.
        public int XOffsetFromTopLeft { get; set; }
        public int YOffsetFromTopLeft { get; set; }

        public DragChessPiece()
        {
            DragInProgess = false;
            PieceBeingDragged = null;
            OriginChessSquare = null;
            DestinationChessSquare = null;
            CurrentCoordinatesOfDrag = new Coordinates(0, 0);
            XOffsetFromTopLeft = 0;
            YOffsetFromTopLeft = 0;
        }
        public void ResetDrag()
        {
            DragInProgess = false;
            PieceBeingDragged = null;
            OriginChessSquare = null;
            DestinationChessSquare = null;
            CurrentCoordinatesOfDrag = new Coordinates(0, 0);
            XOffsetFromTopLeft = 0;
            YOffsetFromTopLeft = 0;
        }
    }
}
