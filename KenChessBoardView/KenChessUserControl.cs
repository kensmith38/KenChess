using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChessBoardModel;
using KenChessPGNCoreLibrary;

namespace KenChessBoardView
{
    public partial class KenChessUserControl : UserControl
    {
        private bool _userCanMoveChessPieces = false;
        // DELEGATE: A move gesture is the dragging of a chess piece on the chessboard GUI
        public delegate void DelUserCompletedMoveGesture(string uciMove);
        public delegate void DelUserCompletedBoardSetup(string fenPosition);

        // null instances of delegates (must be instantiated by FormTrainingSession or FormEditOrCreateGame
        public DelUserCompletedMoveGesture userCompletedMoveGesture;
        public DelUserCompletedBoardSetup userCompletedBoardSetup;

        // These 4 objects are the only ones needed to paint the chessboard and generate the text for the richTextBoxShowingMoves.
        // GameRepresentation, CurrentChessMove, DragChessPiece, AnimatedChessPiece
        public GameRepresentation GameRepresentation;
        public ChessMoveNode CurrentChessMove;
        // Tracks the most recent drag operation by the user.
        public DragChessPiece DragChessPiece { get; set; }
        public AnimatedChessPiece AnimatedChessPiece { get; set; }

        public RichTextViewer RichTextViewer;

        public bool UserNavigationEnabled { get; set; }

        public CachedImagesForPieces CachedImagesForPieces { get; set; }
        // When viewing a game you would not allow user to move chess pieces.
        [Description("Specify if user is allowed to move chess pieces.")]
        public bool UserCanMoveChessPieces
        {
            get { return _userCanMoveChessPieces; }
            set
            {
                _userCanMoveChessPieces = value;
                // if user can move pieces then they can also enter data into game tag textboxes
                textBoxGameTagEvent.ReadOnly = !value;
                textBoxGameTagSite.ReadOnly = !value;
                textBoxGameTagDate.ReadOnly = !value;
                textBoxGameTagRound.ReadOnly = !value;
                textBoxGameTagWhite.ReadOnly = !value;
                textBoxGameTagBlack.ReadOnly = !value;
                textBoxGameTagResult.ReadOnly = !value;
                buttonSetupPosition.Visible = value;
            }
        }
        public StringFormat stringFormatForPaint = new StringFormat();
        public Font FontForPieces { get; set; }

        public Font FontForCoordinates { get; set; }
        // Tricky 6/10/2023 These property values are used if you drag this user control on a form in designer,
        //              but the values set in the designer are actually used when you run the Window's app which has this user control!
        public Color LightSquareColor { get; set; } = Color.FromArgb(211, 226, 234); //light shade of blue
        public Color LightSquareHighlightColor { get; set; } = Color.LightGoldenrodYellow;
        public Color DarkSquareColor { get; set; } = Color.FromArgb(107, 148, 186); //Dark shade of blue;
        public Color DarkSquareHighlightColor { get; set; } = Color.LightSkyBlue;
        public SolidBrush LightSquareBrush;
        public SolidBrush DarkSquareBrush;
        public SolidBrush LightSquareHighlightBrush;
        public SolidBrush DarkSquareHighlightBrush;
        // Pieces look nicer using images.  Pieces are displayed using Unicode font or images.
        public bool UseImagesForPieces { get; set; } = true;
        public KenChessUserControl()
        {
            InitializeComponent();
            DragChessPiece = new DragChessPiece();

            stringFormatForPaint.LineAlignment = StringAlignment.Center;
            stringFormatForPaint.Alignment = StringAlignment.Center;
            LightSquareBrush = new SolidBrush(LightSquareColor);
            DarkSquareBrush = new SolidBrush(DarkSquareColor);
            LightSquareHighlightBrush = new SolidBrush(LightSquareHighlightColor);
            DarkSquareHighlightBrush = new SolidBrush(DarkSquareHighlightColor);
            char unicodeCharForWhiteKing = '♔'; // '\u2654';
            FontForPieces = GetAdjustedFont(
                pictureBoxChessBoard.CreateGraphics(), unicodeCharForWhiteKing.ToString(),
                this.Font, pictureBoxChessBoard.Width / 8, 36, 6, true);
            FontForCoordinates = new Font(this.Font.Name, 14);
            //
            CachedImagesForPieces = new CachedImagesForPieces((Image)Properties.Resources.ResourceManager.GetObject("AlphaChessPieces"));
            // Tricky! For Visual Studio designer we need a dummy game loaded
            GameRepresentation = new GameRepresentation(SamplePGN.InitialGamePGN, 1);
            RichTextViewer = new RichTextViewer(GameRepresentation, richTextBoxShowingMoves);
            CurrentChessMove = GameRepresentation.RootNode;
            UserNavigationEnabled = true;
        }
        /// <summary>
        /// Adjusts a Font to ensure text fits in specified rectangle.  Min and max fontsize must be specified.
        /// Does not consider height of text!
        /// </summary>
        /// <param name="g"></param>
        /// <param name="graphicString"></param>
        /// <param name="originalFont"></param>
        /// <param name="containerWidth"></param>
        /// <param name="maxFontSize"></param>
        /// <param name="minFontSize"></param>
        /// <param name="smallestOnFail"></param>
        /// <returns></returns>
        private static Font GetAdjustedFont(Graphics g, string graphicString, Font originalFont, int containerWidth, int maxFontSize, int minFontSize, bool smallestOnFail)
        {
            Font testFont = null;
            // We utilize MeasureString which we get via a control instance           
            for (int adjustedSize = maxFontSize; adjustedSize >= minFontSize; adjustedSize--)
            {
                testFont = new Font(originalFont.Name, adjustedSize, originalFont.Style);

                // Test the string with the new size
                SizeF adjustedSizeNew = g.MeasureString(graphicString, testFont);

                if (containerWidth > Convert.ToInt32(adjustedSizeNew.Width))
                {
                    // Good font, return it
                    return testFont;
                }
            }

            // If you get here there was no fontsize that worked
            // return minimumSize or original?
            if (smallestOnFail)
            {
                return testFont;
            }
            else
            {
                return originalFont;
            }
        }
        public void LoadSpecificGame(GameRepresentation gameRepresentation)
        {
            GameRepresentation = gameRepresentation;
            RichTextViewer = new RichTextViewer(gameRepresentation, richTextBoxShowingMoves);
            CurrentChessMove = null;
            populateGameTagInfo();
            pictureBoxChessBoard.Invalidate();
            UserNavigationEnabled = true;
        }
        private void populateGameTagInfo()
        {
            textBoxGameTagEvent.Clear();
            textBoxGameTagDate.Clear();
            textBoxGameTagRound.Clear();
            textBoxGameTagWhite.Clear();
            textBoxGameTagBlack.Clear();
            textBoxGameTagResult.Clear();
            if (GameRepresentation.GameTags.ContainsKey("Event"))
            {
                textBoxGameTagEvent.Text = GameRepresentation.GameTags["Event"];
            }
            if (GameRepresentation.GameTags.ContainsKey("Site"))
            {
                textBoxGameTagSite.Text = GameRepresentation.GameTags["Site"];
            }
            if (GameRepresentation.GameTags.ContainsKey("Date"))
            {
                textBoxGameTagDate.Text = GameRepresentation.GameTags["Date"];
            }
            if (GameRepresentation.GameTags.ContainsKey("Round"))
            {
                textBoxGameTagRound.Text = GameRepresentation.GameTags["Round"];
            }
            if (GameRepresentation.GameTags.ContainsKey("White"))
            {
                textBoxGameTagWhite.Text = GameRepresentation.GameTags["White"];
            }
            if (GameRepresentation.GameTags.ContainsKey("Black"))
            {
                textBoxGameTagBlack.Text = GameRepresentation.GameTags["Black"];
            }
            if (GameRepresentation.GameTags.ContainsKey("Result"))
            {
                textBoxGameTagResult.Text = GameRepresentation.GameTags["Result"];
            }
        }
        /// <summary>
        /// Returns the created game as PGN content
        /// </summary>
        /// <returns></returns>
        public string GetGameAsPgnContent()
        {
            // Note: We essentially ignore textBoxGameTagResult; I kept that code (in comments) because I haven't thoroughly tested the logic 
            //      to automatically determine gameResult.
            /*
            string resultValue = string.IsNullOrWhiteSpace(textBoxGameTagResult.Text) ? "*" : textBoxGameTagResult.Text.Trim();
            if ((!resultValue.Equals("1-0")) && (!resultValue.Equals("0-1")) && (!resultValue.Equals("1/2-1/2")))
            {
                resultValue = "*";
            }
            */
            ChessMoveNode lastMainlineMove = ChessMoveNode.GetMainlinePath(GameRepresentation.RootNode).Last();
            if (lastMainlineMove.SANmove == null)
            {
                lastMainlineMove = lastMainlineMove.ParentNode as ChessMoveNode;
            }
            string resultValue = "*";
            GameResult gameResult = lastMainlineMove.GameResultAfterMove();
            switch (gameResult)
            {
                case GameResult.Unknown:
                    resultValue = "*";
                    break;
                case GameResult.Stalemate:
                    resultValue = "1/2-1/2";
                    break;
                case GameResult.Checkmate:
                    // active player is the player to move
                    string activePlayer = UtilitiesFEN.GetActivePlayerFromFEN(CurrentChessMove.FENPositionAfterChessMove);
                    resultValue = activePlayer.Equals("w") ? "0-1" : "1-0";
                    break;
                default:
                    break;
            }

            // See PGN spec: the Seven Tag Roster requires 7 tags in this order:
            //    Event, Site, Date, Round, White, Black, Results
            string eventValue = string.IsNullOrWhiteSpace(textBoxGameTagEvent.Text) ? "?" : textBoxGameTagEvent.Text;
            string siteValue = string.IsNullOrWhiteSpace(textBoxGameTagSite.Text) ? "?" : textBoxGameTagSite.Text;
            string dateValue = string.IsNullOrWhiteSpace(textBoxGameTagDate.Text) ? "?" : textBoxGameTagDate.Text;
            string roundValue = string.IsNullOrWhiteSpace(textBoxGameTagRound.Text) ? "?" : textBoxGameTagRound.Text;
            string whiteValue = string.IsNullOrWhiteSpace(textBoxGameTagWhite.Text) ? "?" : textBoxGameTagWhite.Text;
            string blackValue = string.IsNullOrWhiteSpace(textBoxGameTagBlack.Text) ? "?" : textBoxGameTagBlack.Text;
            string gameTags = $"[Event \"{eventValue}\"]\r\n" + $"[Site \"{siteValue}\"]\r\n" + $"[Date \"{dateValue}\"]\r\n"
                       + $"[Round \"{roundValue}\"]\r\n" + $"[White \"{whiteValue}\"]\r\n" + $"[Black \"{blackValue}\"]\r\n"
                       + $"[Result \"{resultValue}\"]";
            if (GameRepresentation.GameTags.ContainsKey("FEN"))
            {
                GameRepresentation.GameTags.TryGetValue("FEN", out string fen);
                gameTags += $"\r\n[SetUp \"1\"]\r\n[FEN \"{fen}\"]";
            }

            string movetext = GameRepresentation.GenerateAsciiPgnGNMoveText();
            return gameTags + "\r\n\r\n" + movetext + " " + resultValue;
        }
        private void pictureBoxChessBoard_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = LightSquareBrush;
            int adjustedFileIndex;
            int adjustedRankIndex;
            float squareHeight = (float)pictureBoxChessBoard.Height / 8;
            float squareWidth = (float)pictureBoxChessBoard.Width / 8;
            e.Graphics.Clear(LightSquareBrush.Color);
            // Design: Ken weighed performance vs simplifying logic for painting the chess board.
            //          A chessboard could be saved as a property but then we would have to maintain its state.
            ChessBoard chessBoard = (ChessMoveNode)CurrentChessMove == null ?
                new ChessBoard(UtilitiesFEN.GetInitialFENSetupFromGameTags(GameRepresentation.GameTags)) :
                new ChessBoard(CurrentChessMove.FENPositionAfterChessMove);
            for (int fileIndex = 0; fileIndex < 8; fileIndex++)
            {
                for (int rankIndex = 0; rankIndex < 8; rankIndex++)
                {
                    ChessSquare chessSquare = chessBoard.ChessBoardSquares[fileIndex, rankIndex];

                    adjustedFileIndex = checkBoxFlipBoard.Checked ? 7 - fileIndex : fileIndex;
                    adjustedRankIndex = checkBoxFlipBoard.Checked ? 7 - rankIndex : rankIndex;

                    float cornerX = (adjustedFileIndex) * (squareWidth);
                    float cornerY = (float)pictureBoxChessBoard.Height - (adjustedRankIndex + 1) * (squareHeight);
                    Rectangle destRect = new Rectangle((int)cornerX, (int)cornerY, (int)squareWidth, (int)squareHeight);
                    brush = (adjustedFileIndex + adjustedRankIndex) % 2 == 0 ? DarkSquareBrush : LightSquareBrush;
                    e.Graphics.FillRectangle(brush, destRect);

                    //
                    if (chessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        // a piece being dragged will be painted at the end but draw circle
                        if ((DragChessPiece.DragInProgess) && (DragChessPiece.OriginChessSquare.UciSquareName.Equals(chessSquare.UciSquareName)))
                        {
                            e.Graphics.DrawEllipse(Pens.Red, destRect);
                            continue;
                        }
                        // put pieces on squares (except for animated square from)
                        if (UseImagesForPieces)
                        {
                            Image pieceImage = CachedImagesForPieces.CachedImages[chessSquare.PieceOnSquare.FENCharForPiece];

                            e.Graphics.DrawImage(pieceImage, destRect);
                            if ((AnimatedChessPiece != null) && (AnimatedChessPiece.SquareFromUciName.Equals(chessSquare.UciSquareName)))
                            {
                                e.Graphics.FillRectangle(brush, destRect);
                            }
                        }
                        else
                        {
                            char pieceAsUnicodeChar = chessSquare.PieceOnSquare.UnicodeCharForPiece;
                            e.Graphics.DrawString(pieceAsUnicodeChar.ToString(), FontForPieces, Brushes.Black, destRect, stringFormatForPaint);
                        }
                    }
                }

            }
            if (AnimatedChessPiece != null)
            {
                RectangleF animatedPieceLayoutRect = AnimatedChessPiece.getRectForPercentComplete(pictureBoxChessBoard, checkBoxFlipBoard.Checked);
                ChessSquare chessSquareFrom = chessBoard.getChessSquareWithUciName(AnimatedChessPiece.SquareFromUciName);
                ChessSquare chessSquareTo = chessBoard.getChessSquareWithUciName(AnimatedChessPiece.SquareToUciName);

                // This happens but shouldn't!
                if (chessSquareFrom.PieceOnSquare.FENCharForPiece == ' ')
                {
                    Constants.DisplayInfoMessage("WTF!");
                }
                else
                {
                    if (UseImagesForPieces)
                    {
                        Image pieceImage = CachedImagesForPieces.CachedImages[chessSquareFrom.PieceOnSquare.FENCharForPiece];
                        e.Graphics.DrawImage(pieceImage, animatedPieceLayoutRect);
                    }
                    else
                    {
                        char pieceAsUnicodeChar = chessSquareFrom.PieceOnSquare.UnicodeCharForPiece;
                        e.Graphics.DrawString(pieceAsUnicodeChar.ToString(), FontForPieces, Brushes.Black, animatedPieceLayoutRect, stringFormatForPaint);
                    }
                }
            }
            if (DragChessPiece.DragInProgess)
            {
                paintPieceBeingDragged(e.Graphics, chessBoard);
            }
        }
        private void paintPieceBeingDragged(Graphics graphics, ChessBoard chessBoard)
        {
            float squareHeight = (float)pictureBoxChessBoard.Height / 8;
            float squareWidth = (float)pictureBoxChessBoard.Width / 8;
            // highlight the destination square 
            ChessSquare destSquare = getChessSquareFromChessPanelCoord(
                DragChessPiece.CurrentCoordinatesOfDrag.Xcoord,
                DragChessPiece.CurrentCoordinatesOfDrag.Ycoord,
                chessBoard);
            if (destSquare != null)
            {
                paintHighlightSquare(graphics, destSquare);
                // Tricky!
                Rectangle dragRect = new Rectangle(
                        DragChessPiece.CurrentCoordinatesOfDrag.Xcoord - DragChessPiece.XOffsetFromTopLeft,
                        DragChessPiece.CurrentCoordinatesOfDrag.Ycoord - DragChessPiece.YOffsetFromTopLeft,
                        (int)squareWidth, (int)squareHeight);
                paintPieceInRectangle(graphics, DragChessPiece.OriginChessSquare.PieceOnSquare, dragRect);
            }
        }
        private void paintHighlightSquare(Graphics graphics, ChessSquare chessSquare)
        {
            int squareHeight = pictureBoxChessBoard.Height / 8;
            int squareWidth = pictureBoxChessBoard.Width / 8;
            int fileIndex = chessSquare.fileIndex;
            int rankIndex = chessSquare.rankIndex;

            int adjustedFileIndex = checkBoxFlipBoard.Checked ? 7 - fileIndex : fileIndex;
            int adjustedRankIndex = checkBoxFlipBoard.Checked ? 7 - rankIndex : rankIndex;

            Rectangle destRect = new Rectangle(adjustedFileIndex * squareWidth, (7 - adjustedRankIndex) * squareHeight, squareWidth, squareHeight);
            SolidBrush brush = (adjustedFileIndex + adjustedRankIndex) % 2 == 0 ? DarkSquareHighlightBrush : LightSquareHighlightBrush;
            graphics.FillRectangle(brush, destRect);
            if (chessSquare.PieceOnSquare != null)
            {
                paintPieceInRectangle(graphics, chessSquare.PieceOnSquare, destRect);
            }
        }
        private void paintPieceInRectangle(Graphics graphics, ChessPiece chessPiece, Rectangle destRect)
        {
            if (chessPiece.PieceType != PieceType.None)
            {
                if (UseImagesForPieces)
                {
                    Image pieceImage = getImageForPiece(chessPiece);

                    graphics.DrawImage(pieceImage, destRect);
                }
                else
                {
                    char pieceAsUnicodeChar = chessPiece.UnicodeCharForPiece;
                    graphics.DrawString(pieceAsUnicodeChar.ToString(), FontForPieces, Brushes.Black, destRect, stringFormatForPaint);
                }
            }
        }
        private Image getImageForPiece(ChessPiece chessPiece)
        {
            Image image = null;
            CachedImagesForPieces.CachedImages.TryGetValue(chessPiece.FENCharForPiece, out image);
            return image;
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
        private void checkBoxUseImagesForPieces_CheckedChanged(object sender, EventArgs e)
        {
            UseImagesForPieces = !UseImagesForPieces;
            pictureBoxChessBoard.Invalidate();
        }
        private void checkBoxFlipBoard_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxChessBoard.Invalidate();
            panelLeftCoordinates.Invalidate();
            panelBottomCoordinates.Invalidate();
        }
        private void pictureBoxChessBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (!UserCanMoveChessPieces) { return; }
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                if ((e.Button == MouseButtons.Left) && (DragChessPiece.DragInProgess == false))
                {
                    ChessBoard chessBoard = (ChessMoveNode)CurrentChessMove == null ?
                        new ChessBoard(UtilitiesFEN.GetInitialFENSetupFromGameTags(GameRepresentation.GameTags)) :
                        new ChessBoard(CurrentChessMove.FENPositionAfterChessMove);
                    ChessSquare chessSquare = getChessSquareFromChessPanelCoord(e.X, e.Y, chessBoard);
                    // should never be null but in case
                    if (chessSquare == null)
                    {
                        DragChessPiece.ResetDrag();
                        pictureBoxChessBoard.Invalidate();
                    }
                    else
                    {
                        DragChessPiece.DragInProgess = true;
                        DragChessPiece.OriginChessSquare = chessSquare;
                        DragChessPiece.DestinationChessSquare = null;
                        DragChessPiece.CurrentCoordinatesOfDrag = new Coordinates(e.X, e.Y);
                        DragChessPiece.PieceBeingDragged = DragChessPiece.OriginChessSquare.PieceOnSquare;
                        int fileWidth = pictureBoxChessBoard.Width / 8;
                        int rankHeight = pictureBoxChessBoard.Height / 8;
                        DragChessPiece.XOffsetFromTopLeft = e.X % fileWidth;
                        DragChessPiece.YOffsetFromTopLeft = e.Y % rankHeight;
                        //
                        if (DragChessPiece.PieceBeingDragged == null)
                        {
                            DragChessPiece.ResetDrag();
                        }
                    }
                }
                UserNavigationEnabled = true;
            }
        }

        private void pictureBoxChessBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (!UserCanMoveChessPieces) { return; }
            if ((e.Button == MouseButtons.Left) && (DragChessPiece.DragInProgess))
            {
                DragChessPiece.CurrentCoordinatesOfDrag = new Coordinates(e.X, e.Y);
                pictureBoxChessBoard.Invalidate();
            }
        }

        private void pictureBoxChessBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (!UserCanMoveChessPieces) { return; }
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                if ((e.Button == MouseButtons.Left) && (DragChessPiece.DragInProgess))
                {
                    ChessBoard chessBoard = (ChessMoveNode)CurrentChessMove == null ?
                        new ChessBoard(UtilitiesFEN.GetInitialFENSetupFromGameTags(GameRepresentation.GameTags)) :
                        new ChessBoard(CurrentChessMove.FENPositionAfterChessMove);
                    ChessSquare chessSquare = getChessSquareFromChessPanelCoord(e.X, e.Y, chessBoard);
                    // null square if we went out of bounds of panel
                    if (chessSquare == null)
                    {
                        DragChessPiece.ResetDrag();
                        pictureBoxChessBoard.Invalidate();
                    }
                    else
                    {
                        DragChessPiece.DestinationChessSquare = chessSquare;
                        DragChessPiece.CurrentCoordinatesOfDrag = new Coordinates(e.X, e.Y);
                        DragChessPiece.DragInProgess = false;
                        handleCompletedDragOperation();
                    }
                }
                UserNavigationEnabled = true;
            }
        }
        /// <summary>
        /// A completed drag operation becomes a UCI move request sent to the CONTROLLER which indicates valid/invalid move in the return value.
        /// The CONTROLLER updates the MODEL by performing the move only if the move is valid.
        /// </summary>
        private void handleCompletedDragOperation()
        {
            if (!UserCanMoveChessPieces) { return; }
            if (DragChessPiece.OriginChessSquare != DragChessPiece.DestinationChessSquare)
            {
                string uciMove = DragChessPiece.OriginChessSquare.UciSquareName + DragChessPiece.DestinationChessSquare.UciSquareName;
                if (DragChessPiece.OriginChessSquare.PieceOnSquare.PieceType == PieceType.Pawn)
                {
                    bool isWhitePawnPromotion = (DragChessPiece.DestinationChessSquare.rankIndex == 7) &&
                                                (DragChessPiece.OriginChessSquare.PieceOnSquare.PieceColor == 'w');
                    bool isBlackPawnPromotion = (DragChessPiece.DestinationChessSquare.rankIndex == 0) &&
                                                (DragChessPiece.OriginChessSquare.PieceOnSquare.PieceColor == 'b');

                    if (isWhitePawnPromotion || isBlackPawnPromotion)
                    {
                        // handle pawn promotion to pieces other than queen
                        string activePlayerAfterMove = UtilitiesFEN.GetActivePlayerFromFEN(CurrentChessMove.FENPositionAfterChessMove);
                        char activePlayer = activePlayerAfterMove.Equals("w") ? 'b' : 'w';
                        FormChoosePromotionPiece dlg = new FormChoosePromotionPiece(CachedImagesForPieces, activePlayer);
                        if (DialogResult.OK == dlg.ShowDialog())
                        {
                            // Tricky! You would be wrong to use Q instead og q for white pawn promotion! (uci always uses lowercase!)
                            if (dlg.selectedPictureBox.Name.Equals("pictureBoxQueen")) { uciMove += "q"; }
                            if (dlg.selectedPictureBox.Name.Equals("pictureBoxRook")) { uciMove += "r"; }
                            if (dlg.selectedPictureBox.Name.Equals("pictureBoxBishop")) { uciMove += "b"; }
                            if (dlg.selectedPictureBox.Name.Equals("pictureBoxKnight")) { uciMove += "n"; }
                        }
                        else
                        {
                            uciMove += "q";
                        }
                    }
                }
                // Delegate method in FormTrainingSession or FormEditOrCreateGame
                userCompletedMoveGesture(uciMove);
            }
            pictureBoxChessBoard.Invalidate();
            //
            DragChessPiece.ResetDrag();
        }
        private ChessSquare getChessSquareFromChessPanelCoord(int xCoord, int yCoord, ChessBoard chessBoard)
        {
            ChessSquare chessSquare = null;
            float fileWidth = (float)pictureBoxChessBoard.Width / 8;
            float rankHeight = (float)pictureBoxChessBoard.Height / 8;
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
                chessSquare = chessBoard.ChessBoardSquares[fileIndex, rankIndex];
            }
            return chessSquare;
        }

        private void buttonGoToStart_Click(object sender, EventArgs e)
        {
            if (GameRepresentation.RootNode == null) { return; }
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                if (AnimatedChessPiece == null)
                {
                    string fenInitialSetup = UtilitiesFEN.GetInitialFENSetupFromGameTags(GameRepresentation.GameTags);
                    ChessBoard chessBoard = new ChessBoard(fenInitialSetup);
                    CurrentChessMove = null;
                    RichTextViewer.highlightCurrentMoveInRichText(CurrentChessMove);
                    richTextBoxShowingMoves.SelectionStart = 1;
                    richTextBoxShowingMoves.ScrollToCaret();
                    pictureBoxChessBoard.Invalidate();
                }
                UserNavigationEnabled = true;
            }
        }
        private void buttonBackOneMove_Click(object sender, EventArgs e)
        {
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                if (AnimatedChessPiece == null)
                {
                    if ((CurrentChessMove == null) || (CurrentChessMove.ParentNode == null))
                    {
                        string fenInitialSetup = UtilitiesFEN.GetInitialFENSetupFromGameTags(GameRepresentation.GameTags);
                        //..ChessBoard chessBoard = new ChessBoard(fenInitialSetup);
                        CurrentChessMove = null;
                        RichTextViewer.highlightCurrentMoveInRichText(CurrentChessMove);
                    }
                    else
                    {
                        jumpToSpecificChessMove((ChessMoveNode)CurrentChessMove.ParentNode);
                    }
                    pictureBoxChessBoard.Invalidate();
                }
                UserNavigationEnabled = true;
            }
        }
        private void buttonForwardOneMove_Click(object sender, EventArgs e)
        {
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                if (AnimatedChessPiece != null) { return; }
                if (CurrentChessMove == null)
                {
                    CurrentChessMove = GameRepresentation.RootNode;
                    RichTextViewer.highlightCurrentMoveInRichText(CurrentChessMove);
                    pictureBoxChessBoard.Invalidate();
                }
                else
                {
                    if (CurrentChessMove.ChildNodes.Count > 0)
                    {
                        ChessMoveNode nextMove = (ChessMoveNode)CurrentChessMove.ChildNodes[0];
                        if (CurrentChessMove.ChildNodes.Count > 1)
                        {
                            // ask user what move to make
                            if (!checkBoxAutoChooseMainlineMove.Checked)
                            {
                                DlgChooseMoveVariation dlg = new DlgChooseMoveVariation(CurrentChessMove);
                                dlg.ShowDialog();
                                nextMove = dlg.UserSelectedChessMoveNode;
                            }
                        }
                        string uciMove = nextMove.UCImove;

                        // uciMove should never be null but check for it
                        if (uciMove != null)
                        {
                            string squareFromUciName = uciMove.Substring(0, 2);
                            string squareToUciName = uciMove.Substring(2, 2);

                            AnimatedChessPiece = new AnimatedChessPiece(squareFromUciName, squareToUciName, nextMove);
                            timer1.Start();
                            timer1.Interval = Math.Max(1, 5 * (trackBarAnimationSpeed.Maximum - trackBarAnimationSpeed.Value));
                        }
                    }
                }
                // we are animating a move so don't allow user action
                UserNavigationEnabled = AnimatedChessPiece == null;
            }
        }
        private void buttonGoToEnd_Click(object sender, EventArgs e)
        {
            if (GameRepresentation.RootNode == null) { return; }
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                if (AnimatedChessPiece == null)
                {
                    // get last node in mainline path
                    List<ChessMoveNode> mainlinePath = ChessMoveNode.GetMainlinePath(GameRepresentation.RootNode);
                    ChessMoveNode lastMainlineNode = mainlinePath.Last();
                    // TODO remove commented code after testing 7/12/2023
                    /* The mainlinePath will never end with a game result node as of 7/12/2023. 
                    // Tricky! When viewing a game the last node is game result (1-0 0-1 1/2-1/2 *) so we go parent of last node.
                    //         When creating a training game we don't have a game result node so we go to last node!
                    if (lastMainlineNode.SANmove == null)
                    {
                        lastMainlineNode = (ChessMoveNode)lastMainlineNode.ParentNode;
                    }
                    */
                    jumpToSpecificChessMove(lastMainlineNode);
                    // jumpTo will invalidate the panelChessBoard
                    //panelChessBoard.Invalidate();
                    richTextBoxShowingMoves.ScrollToCaret();
                }
                UserNavigationEnabled = true;
            }
        }
        private void jumpToSpecificChessMove(ChessMoveNode chessMoveNode)
        {
            // The GUI paints the chessboard using ChessBoard in the state corresponding to the specific move (node).
            if ((chessMoveNode != null) && (chessMoveNode.SANmove != null))
            {
                //ChessBoard = new ChessBoard(chessMoveNode.FENPositionAfterChessMove);
                CurrentChessMove = chessMoveNode;
                RichTextViewer.highlightCurrentMoveInRichText(CurrentChessMove);
            }
            pictureBoxChessBoard.Invalidate();
            if (chessMoveNode != null)
            {
                if ((chessMoveNode.ChildNodes.Count == 0) || ((ChessMoveNode)chessMoveNode.ChildNodes[0]).SANmove == null)
                {
                    GameResult gameResult = chessMoveNode.GameResultAfterMove();
                    if (gameResult == GameResult.Checkmate)
                    {
                        Constants.DisplayInfoMessage("Checkmate!");
                    }
                    else if (gameResult == GameResult.Stalemate)
                    {
                        Constants.DisplayInfoMessage("Stalemate!");
                    }
                }
            }
        }
        // A left mouse click makes the selected move the current move.
        // A right mouse click displays a context menu to change commentary for the selected move.
        // Tricky! Must use mouse down instead of mouse click because RichTextBox does not detect right mouse click!
        private void richTextBoxShowingMoves_MouseDown(object sender, MouseEventArgs e)
        {
            if (UserNavigationEnabled == true)
            {
                UserNavigationEnabled = false;
                // Obtain the character index where the user clicks on the control.
                int clickedPosition = richTextBoxShowingMoves.GetCharIndexFromPosition(new Point(e.X, e.Y));
                //char characterClicked = richTextBoxShowingMoves.Text.Length > clickedPosition ? richTextBoxShowingMoves.Text[clickedPosition] : '~';
                //Constants.DisplayInfoMessage($"Clicked position {clickedPosition.ToString()}; char={characterClicked}");
                if (clickedPosition <= richTextBoxShowingMoves.Text.Length)
                {
                    // @ken 6/23/2023 Restricting to left button prevents right mouse click context menu from setting current move and highlighting it.
                    if (1 == 1) //(e.Button == MouseButtons.Left)
                    {
                        // pass event to RichTextViewer which tells us the ChessMove that the user wants to jump to
                        ChessMoveNode userRequestsJumpToChessMove = RichTextViewer.userMouseDownInRichTextBox(e);
                        jumpToSpecificChessMove(userRequestsJumpToChessMove);
                        pictureBoxChessBoard.Invalidate();
                    }
                    if (e.Button == MouseButtons.Right)
                    {

                        ChessMoveNode chessMove = RichTextViewer.GetChessMove(clickedPosition);
                        //Constants.DisplayInfoMessage($"Clicked SAN: {chessMove.SANmove}");
                        RichTextViewer.ChessMoveNodeForRTBContextMenu = chessMove;
                        RichTextViewer.ContextMenuRichTextBox.Show(richTextBoxShowingMoves, new Point(e.X, e.Y));
                    }
                }
                UserNavigationEnabled = true;
            }
        }
        /// <summary>
        /// Timer is used for piece animation (move chess piece from square to square)
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            AnimatedChessPiece.PercentComplete += 10;
            if (AnimatedChessPiece.PercentComplete >= 100)
            {
                timer1.Stop();
                if (AnimatedChessPiece.JumpToChessMoveNodeAfterAnimation != null)
                {
                    ChessMoveNode jumpToNode = AnimatedChessPiece.JumpToChessMoveNodeAfterAnimation;
                    AnimatedChessPiece = null;
                    //CurrentChessMove = AnimatedChessPiece.JumpToChessMoveNodeAfterAnimation;
                    jumpToSpecificChessMove(jumpToNode);
                }
                UserNavigationEnabled = true;
                //AnimatedChessPiece = null;
            }
            pictureBoxChessBoard.Invalidate();
        }
        private void buttonSetupPosition_Click(object sender, EventArgs e)
        {
            DlgSetupPosition dlg = new DlgSetupPosition(CachedImagesForPieces);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                string fenSetup = dlg.FENSetup;
                userCompletedBoardSetup(fenSetup);
            }
        }

        private void checkBoxHideRichTextBox_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxShowingMoves.Visible = !checkBoxHideRichTextBox.Checked;
        }

        
    }
}
