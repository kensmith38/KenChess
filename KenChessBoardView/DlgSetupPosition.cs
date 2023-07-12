using KenChessBoardModel;
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
    public partial class DlgSetupPosition : Form
    {
        public string FENSetup { get; set; }
        public ChessBoard ChessBoard { get; set; } = new ChessBoard(null);

        public PictureBox selectedPictureBox = null;
        CachedImagesForPieces CachedImagesForPieces;

        public Color LightSquareColor { get; set; } = Color.FromArgb(211, 226, 234); //light shade of blue
        public Color LightSquareHighlightColor { get; set; } = Color.LightGoldenrodYellow;
        public Color DarkSquareColor { get; set; } = Color.FromArgb(107, 148, 186); //Dark shade of blue;
        public Color DarkSquareHighlightColor { get; set; } = Color.LightSkyBlue;
        public SolidBrush LightSquareBrush;
        public SolidBrush DarkSquareBrush;
        public SolidBrush LightSquareHighlightBrush;
        public SolidBrush DarkSquareHighlightBrush;
        public StringFormat stringFormatForPaint = new StringFormat();

        public Font FontForCoordinates { get; set; }

        public DlgSetupPosition(CachedImagesForPieces cachedImagesForPieces)
        {
            InitializeComponent();
            CachedImagesForPieces = cachedImagesForPieces;

        }

        private void DlgSetupPosition_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                initializePictureBoxImages();
                LightSquareBrush = new SolidBrush(LightSquareColor);
                DarkSquareBrush = new SolidBrush(DarkSquareColor);
                LightSquareHighlightBrush = new SolidBrush(LightSquareHighlightColor);
                DarkSquareHighlightBrush = new SolidBrush(DarkSquareHighlightColor);
                FontForCoordinates = new Font(this.Font.Name, 14);

                CachedImagesForPieces = new CachedImagesForPieces((Image)Properties.Resources.ResourceManager.GetObject("AlphaChessPieces"));
                // Default is the standard initial setup for a chess game
                string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
                ChessBoard = new ChessBoard(fen);
                panelChessBoard.Invalidate();

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
        private void initializePictureBoxImages()
        {
            char fenCharForWhiteKing = 'K';
            char fenCharForWhiteQueen = 'Q';
            char fenCharForWhiteRook = 'R';
            char fenCharForWhiteBishop = 'B';
            char fenCharForWhiteKnight = 'N';
            char fenCharForWhitePawn = 'P';

            char fenCharForBlackKing = 'k';
            char fenCharForBlackQueen = 'q';
            char fenCharForBlackRook = 'r';
            char fenCharForBlackBishop = 'b';
            char fenCharForBlackKnight = 'n';
            char fenCharForBlackPawn = 'p';

            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForWhiteKing, out Image whiteKingImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForWhiteQueen, out Image whiteQueenImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForWhiteRook, out Image whiteRookImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForWhiteBishop, out Image whiteBishopImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForWhiteKnight, out Image whiteKnightImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForWhitePawn, out Image whitePawnImage);

            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBlackKing, out Image BlackKingImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBlackQueen, out Image BlackQueenImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBlackRook, out Image BlackRookImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBlackBishop, out Image BlackBishopImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBlackKnight, out Image BlackKnightImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBlackPawn, out Image BlackPawnImage);

            pictureBoxWhiteKing.Image = whiteKingImage;
            pictureBoxWhiteQueen.Image = whiteQueenImage;
            pictureBoxWhiteRook.Image = whiteRookImage;
            pictureBoxWhiteBishop.Image = whiteBishopImage;
            pictureBoxWhiteKnight.Image = whiteKnightImage;
            pictureBoxWhitePawn.Image = whitePawnImage;

            pictureBoxBlackKing.Image = BlackKingImage;
            pictureBoxBlackQueen.Image = BlackQueenImage;
            pictureBoxBlackRook.Image = BlackRookImage;
            pictureBoxBlackBishop.Image = BlackBishopImage;
            pictureBoxBlackKnight.Image = BlackKnightImage;
            pictureBoxBlackPawn.Image = BlackPawnImage;
        }
        private void panelChessBoard_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = LightSquareBrush;
            int adjustedFileIndex;
            int adjustedRankIndex;
            float squareHeight = (float)panelChessBoard.Height / 8;
            float squareWidth = (float)panelChessBoard.Width / 8;
            e.Graphics.Clear(LightSquareBrush.Color);
            for (int fileIndex = 0; fileIndex < 8; fileIndex++)
            {
                for (int rankIndex = 0; rankIndex < 8; rankIndex++)
                {
                    ChessSquare chessSquare = ChessBoard.ChessBoardSquares[fileIndex, rankIndex];

                    adjustedFileIndex = checkBoxFlipBoard.Checked ? 7 - fileIndex : fileIndex;
                    adjustedRankIndex = checkBoxFlipBoard.Checked ? 7 - rankIndex : rankIndex;

                    float cornerX = (adjustedFileIndex) * (squareWidth);
                    float cornerY = (float)panelChessBoard.Height - (adjustedRankIndex + 1) * (squareHeight);
                    Rectangle destRect = new Rectangle((int)cornerX, (int)cornerY, (int)squareWidth, (int)squareHeight);
                    brush = (adjustedFileIndex + adjustedRankIndex) % 2 == 0 ? DarkSquareBrush : LightSquareBrush;
                    e.Graphics.FillRectangle(brush, destRect);

                    //
                    if (chessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        Image pieceImage = CachedImagesForPieces.CachedImages[chessSquare.PieceOnSquare.FENCharForPiece];
                        e.Graphics.DrawImage(pieceImage, destRect);
                    }
                }
            }
        }
        private void panelLeftCoordinates_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panelLeftCoordinates.BackColor);
            for (int rankLetterIndex = 0; rankLetterIndex < 8; rankLetterIndex++)
            {
                char letter = checkBoxFlipBoard.Checked ? "87654321"[7 - rankLetterIndex] : "87654321"[rankLetterIndex];
                float cornerX = 0;
                float cornerY = (rankLetterIndex) * ((float)panelLeftCoordinates.Height / 8); ;
                RectangleF layoutRect = new RectangleF(cornerX, cornerY, panelLeftCoordinates.Width, panelLeftCoordinates.Height / 8);

                // put pieces on squares
                e.Graphics.DrawString(letter.ToString(), FontForCoordinates, Brushes.Black, layoutRect, stringFormatForPaint);
            }
        }
        private void panelBottomCoordinates_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panelBottomCoordinates.BackColor);
            for (int fileLetterIndex = 0; fileLetterIndex < 8; fileLetterIndex++)
            {
                char letter = checkBoxFlipBoard.Checked ? "abcdefgh"[7 - fileLetterIndex] : "abcdefgh"[fileLetterIndex];
                float cornerX = (fileLetterIndex) * ((float)panelBottomCoordinates.Width / 8);
                float cornerY = 0;
                RectangleF layoutRect = new RectangleF(cornerX, cornerY, panelBottomCoordinates.Width / 8, panelBottomCoordinates.Height);

                // put pieces on squares
                e.Graphics.DrawString(letter.ToString(), FontForCoordinates, Brushes.Black, layoutRect, stringFormatForPaint);
            }
        }
        private void pictureBoxANY_Click(object sender, EventArgs e)
        {
            panelWhiteKing.BackColor = Color.White;
            panelWhiteQueen.BackColor = Color.White;
            panelWhiteRook.BackColor = Color.White;
            panelWhiteBishop.BackColor = Color.White;
            panelWhiteKnight.BackColor = Color.White;
            panelWhitePawn.BackColor = Color.White;

            panelBlackKing.BackColor = Color.White;
            panelBlackQueen.BackColor = Color.White;
            panelBlackRook.BackColor = Color.White;
            panelBlackBishop.BackColor = Color.White;
            panelBlackKnight.BackColor = Color.White;
            panelBlackPawn.BackColor = Color.White;

            PictureBox clickedPicture = (PictureBox)sender;
            selectedPictureBox = clickedPicture;
            selectedPictureBox.Parent.BackColor = Color.LightBlue;
        }

        private void checkBoxFlipBoard_CheckedChanged(object sender, EventArgs e)
        {
            panelChessBoard.Invalidate();
            panelBottomCoordinates.Invalidate();
            panelLeftCoordinates.Invalidate();
        }
        private ChessSquare getChessSquareFromChessPanelCoord(int xCoord, int yCoord)
        {
            ChessSquare chessSquare = null;
            float fileWidth = (float)panelChessBoard.Width / 8;
            float rankHeight = (float)panelChessBoard.Height / 8;
            int fileIndex = xCoord / (int)fileWidth;
            int rankIndex = 7 - (yCoord / (int)rankHeight);
            if (checkBoxFlipBoard.Checked)
            {
                fileIndex = 7 - fileIndex;
                rankIndex = 7 - rankIndex;
            }
            // make sure we aren't outside bounds of the board
            if ((fileIndex >= 0) && (fileIndex <= 7) && (rankIndex >= 0) && (rankIndex <= 7))
            {
                chessSquare = ChessBoard.ChessBoardSquares[fileIndex, rankIndex];
            }
            return chessSquare;
        }
        private void buttonResetBoard_Click(object sender, EventArgs e)
        {
            checkBoxBlackCanCastleLong.Checked = true;
            checkBoxBlackCanCastleShort.Checked = true;
            checkBoxWhiteCanCastleLong .Checked = true;
            checkBoxWhiteCanCastleShort .Checked = true;
            // Default is the standard initial setup for a chess game
            string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            ChessBoard = new ChessBoard(fen);
            panelChessBoard.Invalidate();
        }

        private void buttonClearBoard_Click(object sender, EventArgs e)
        {
            // Default is the standard initial setup for a chess game
            string fen = "8/8/8/8/8/8/8/8 w KQkq - 0 1";
            ChessBoard = new ChessBoard(fen);
            panelChessBoard.Invalidate();
        }

        private void panelChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            ChessSquare chessSquare = getChessSquareFromChessPanelCoord(e.X, e.Y);
            if (chessSquare != null)
            {
                if (selectedPictureBox != null)
                {
                    char fenChar = ' ';
                    if (selectedPictureBox == pictureBoxWhiteKing)   { fenChar = 'K'; }
                    else if (selectedPictureBox == pictureBoxWhiteQueen)  { fenChar = 'Q'; }
                    else if (selectedPictureBox == pictureBoxWhiteRook)   { fenChar = 'R'; }
                    else if (selectedPictureBox == pictureBoxWhiteBishop) { fenChar = 'B'; }
                    else if (selectedPictureBox == pictureBoxWhiteKnight) { fenChar = 'N'; }
                    else if (selectedPictureBox == pictureBoxWhitePawn)   { fenChar = 'P'; }
                    else if (selectedPictureBox == pictureBoxBlackKing)   { fenChar = 'k'; }
                    else if (selectedPictureBox == pictureBoxBlackQueen)  { fenChar = 'q'; }
                    else if (selectedPictureBox == pictureBoxBlackRook)   { fenChar = 'r'; }
                    else if (selectedPictureBox == pictureBoxBlackBishop) { fenChar = 'b'; }
                    else if (selectedPictureBox == pictureBoxBlackKnight) { fenChar = 'n'; }
                    else if (selectedPictureBox == pictureBoxBlackPawn)   { fenChar = 'p'; }

                    if (chessSquare.PieceOnSquare.FENCharForPiece == fenChar)
                    {
                        chessSquare.PieceOnSquare = new ChessPiece();
                    }
                    else
                    {
                        chessSquare.PieceOnSquare = new ChessPiece(fenChar);
                    }
                }
            }
            panelChessBoard.Invalidate();
        }

        private void panelChessBoard_MouseEnter(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                //this.Cursor = new Cursor(((Bitmap)selectedPictureBox.Image).GetHicon());
                Bitmap bmp = new Bitmap(new Bitmap(selectedPictureBox.Image, 48, 48));
                this.Cursor = new Cursor(bmp.GetHicon());
            }
        }
        private void panelChessBoard_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ChessBoard.ActivePlayer = radioButtonWhiteToMove.Checked ? 'w' : 'b';
            ChessBoard.WhiteCanCastleLong = checkBoxWhiteCanCastleLong.Checked;
            ChessBoard.WhiteCanCastleShort = checkBoxWhiteCanCastleShort.Checked;
            ChessBoard.BlackCanCastleLong = checkBoxBlackCanCastleLong.Checked;
            ChessBoard.BlackCanCastleShort = checkBoxBlackCanCastleShort.Checked;
            ChessBoard.EnPassantTargetSquare = null;
            if (!string.IsNullOrWhiteSpace(textBoxEnPassantSquareName.Text))
            {
                ChessBoard.EnPassantTargetSquare = ChessBoard.getChessSquareWithUciName(textBoxEnPassantSquareName.Text.Trim());
            }
            ChessBoard.HalfmoveClock = (int)numericUpDownHalfMoveClock.Value;
            ChessBoard.FullMoveNumber = (int)numericUpDownFullMoveNumber.Value;
            FENSetup = ChessBoard.FEN;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
