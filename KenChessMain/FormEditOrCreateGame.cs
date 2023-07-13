using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChessBoardModel;
using KenChessBoardView;
using KenChessPGNCoreLibrary;
using KenGenericNode;

namespace KenChessMain
{
    public partial class FormEditOrCreateGame : Form
    {
        public GameRepresentation GameRepresentation { get; set; }
        public string CurrentGameFilepath { get; set; }
        public bool IsTrainingGame;
        
        /// <summary>
        /// Parm currentGameFilepath is null for a new training game or new game
        /// </summary>
        public FormEditOrCreateGame(GameRepresentation gameRepresentation, string currentGameFilepath, bool isTrainingGame)
        {
            InitializeComponent();
            GameRepresentation = gameRepresentation;
            CurrentGameFilepath = currentGameFilepath;
            IsTrainingGame = isTrainingGame;
        }
        private void FormEditOrCreateGame_Load(object sender, EventArgs e)
        {
            // Must initialize delegates
            kenChessUserControl1.userCompletedMoveGesture = UserCompletedMoveGesture;
            kenChessUserControl1.userCompletedBoardSetup = UserCompletedBoardSetup;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                labelGameFile.Text = "?";
                if (CurrentGameFilepath == null)
                {
                    labelGameFile.Text = IsTrainingGame ? "<new training game>" : "<new game>";
                }
                else
                {
                    labelGameFile.Text = Path.GetFileName(CurrentGameFilepath);
                }
                
                kenChessUserControl1.LoadSpecificGame(GameRepresentation);
                kenChessUserControl1.UserCanMoveChessPieces = true;
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
        public void UserCompletedBoardSetup(string fenPosition)
        {
            string pgnContent = SamplePGN.InitialGamePGN;
            GameRepresentation = new GameRepresentation(pgnContent, 1);
            GameRepresentation.GameTags.Add("SetUp", "1");
            GameRepresentation.GameTags.Add("FEN", fenPosition);
            kenChessUserControl1.GameRepresentation = GameRepresentation;
            kenChessUserControl1.RichTextViewer = new RichTextViewer(GameRepresentation, kenChessUserControl1.richTextBoxShowingMoves);
            kenChessUserControl1.CurrentChessMove = null;
            kenChessUserControl1.RichTextViewer.highlightCurrentMoveInRichText(null);
            kenChessUserControl1.Invalidate(true);
        }
        /// <summary>
        /// Delegate method invoked from KenChessUserControl. THe uciMove is the move gesture (dragging piece) from the user.
        /// </summary>
        public void UserCompletedMoveGesture(string uciMove)
        {
            // TODO refactor UserCompletedMoveGesture in FormEditOrCreateGame to simplify large method
            // determine if move is valid
            ChessBoard chessBoard = (ChessMoveNode)kenChessUserControl1.CurrentChessMove == null ?
                new ChessBoard(UtilitiesFEN.GetInitialFENSetupFromGameTags(GameRepresentation.GameTags)) :
                new ChessBoard(kenChessUserControl1.CurrentChessMove.FENPositionAfterChessMove);
            bool isLegalMove = UtilitiesLegalUCIMoves.IsLegalMove(chessBoard, uciMove);
            ChessMoveNode CurrentChessMove = kenChessUserControl1.CurrentChessMove;
            if (isLegalMove)
            {
                bool proceed = true;
                
                if ((CurrentChessMove == null) && (GameRepresentation.RootNode != null) && (GameRepresentation.RootNode.ChildNodes.Count > 0))
                {
                    Constants.DisplayInfoMessage("Move variations only allowed after the first move.");
                    proceed = false;
                }
                // Tricky! User could unintentionally enter a move variation that already exists!
                if ((CurrentChessMove != null) && (CurrentChessMove.ChildNodes.Count > 0))
                {
                    foreach (ChessMoveNode nextnode in CurrentChessMove.ChildNodes)
                    {
                        if (nextnode.UCImove == uciMove)
                        {
                            Constants.DisplayInfoMessage("Move variation already exists in RichTextBox.");
                            proceed = false;
                            break;
                        }
                    }
                }
                if (proceed)
                {
                    // At this point we know the move gesture is a legal move so we must:
                    // 1. Create a corresponding ChessMoveNode and link that new move to the current move
                    // 2. Update kenChessUserControl1 with the CurrentChessMove set to the new move
                    // 3. Rebuild kenChessBoardRichText ?? and highlight the current move in the RichTextBox

                    ChessBoard chessBoardBeforeMove = chessBoard;
                    string pgnSAN = UtilitiesPgnUciConversions.ConvertUciMoveToPgn(chessBoardBeforeMove, uciMove);
                    // construct a new ChessMoveNode
                    ChessMoveNode newChessMoveNode = new ChessMoveNode();
                    newChessMoveNode.UCImove = uciMove;
                    newChessMoveNode.SANmove = pgnSAN;
                    ChessBoard chessBoardAfterMove = chessBoardBeforeMove.clone();
                    chessBoardAfterMove.PerformUciMove(uciMove);
                    newChessMoveNode.FENPositionAfterChessMove = chessBoardAfterMove.FEN;
                    
                    // rebuild StructuredPGNGame.
                    if (CurrentChessMove == null)
                    {
                        newChessMoveNode.FriendlyMoveNumber = "1.";
                        newChessMoveNode.ParentNode = null;
                        newChessMoveNode.MoveVariationDepth = 0;
                        GameRepresentation.RootNode = newChessMoveNode;
                    }
                    else
                    {
                        bool whiteIsActivePlayer = UtilitiesFEN.GetActivePlayerFromFEN(newChessMoveNode.FENPositionAfterChessMove).Equals("b");
                        int fullmoveNumber = CurrentChessMove == null ? 1 : UtilitiesFEN.GetFullMoveNumberFromFEN(CurrentChessMove.FENPositionAfterChessMove);
                        newChessMoveNode.FriendlyMoveNumber = whiteIsActivePlayer ?
                            fullmoveNumber.ToString() + "." :
                            fullmoveNumber.ToString() + "... ";
                        newChessMoveNode.MoveVariationDepth = CurrentChessMove.ChildNodes.Count == 0 ?
                                CurrentChessMove.MoveVariationDepth : CurrentChessMove.MoveVariationDepth + 1;
                        // Link current to new move
                        CurrentChessMove.ChildNodes.Add(newChessMoveNode);
                        newChessMoveNode.ParentNode = CurrentChessMove;
                        //mark all nodes as needing expansion
                        newChessMoveNode.NodeNeedsExpansion = true;
                        
                    }
                    kenChessUserControl1.RichTextViewer = new RichTextViewer(GameRepresentation, kenChessUserControl1.richTextBoxShowingMoves);
                    kenChessUserControl1.CurrentChessMove = newChessMoveNode;
                    kenChessUserControl1.RichTextViewer.highlightCurrentMoveInRichText(newChessMoveNode);
                    kenChessUserControl1.Invalidate(true);
                    //
                    if (newChessMoveNode.ChildNodes.Count == 0)
                    {
                        GameResult gameResult = newChessMoveNode.GameResultAfterMove();
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
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentGameFilepath == null)
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                try
                {
                    if (userInputIsValid())
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string pgnContent = kenChessUserControl1.GetGameAsPgnContent();
                        //
                        File.WriteAllText(CurrentGameFilepath, pgnContent);
                        Constants.DisplayInfoMessage($"Successfully saved: {Path.GetFileName(CurrentGameFilepath)} ");
                    }
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
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (kenChessUserControl1.GameRepresentation.RootNode == null)
                {
                    Constants.DisplayErrorMessage("A game with no moves cannot be saved.");
                }
                else
                {
                    if (userInputIsValid() )
                    {
                        string pgnContent = kenChessUserControl1.GetGameAsPgnContent();
                        // We save to predefined folder in Documents folder
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.InitialDirectory = IsTrainingGame ? Constants.TrainingGamesFolderPath : Constants.ViewingGamesLibraryFolderPath;

                        saveFileDialog1.Filter = "pgn chess game (*.pgn)|*.pgn";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.RestoreDirectory = true;

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            CurrentGameFilepath = saveFileDialog1.FileName;
                            File.WriteAllText(CurrentGameFilepath, pgnContent);
                            Constants.DisplayInfoMessage($"Successfully saved as: {Path.GetFileName(CurrentGameFilepath)} ");
                            labelGameFile.Text = Path.GetFileName(CurrentGameFilepath);
                        }
                    }
                }
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
        private bool userInputIsValid()
        {
            bool inputIsValid = true;
            string errmssg = null;
            if (inputIsValid == true)
            {
                if (IsTrainingGame)
                {
                    // In Visual Studio designer make sure the textbox property, modifier, is set to public
                    bool meIsWhite = kenChessUserControl1.textBoxGameTagWhite.Text.Trim().Equals("Me");
                    bool meIsBlack = kenChessUserControl1.textBoxGameTagBlack.Text.Trim().Equals("Me");
                    bool meIsBothBlackAndWhite = meIsBlack && meIsWhite;
                    bool meIsNotAssigned = (!meIsWhite) && (!meIsBlack);
                    if (meIsNotAssigned || meIsBothBlackAndWhite)
                    {
                        inputIsValid = false;
                        errmssg = "Game tags must specify \"Me\" for either the White player or the Black player.";
                        Constants.DisplayErrorMessage(errmssg);
                    }
                }
            }
            return inputIsValid;
        }

        private void buttonCopyFEN_Click(object sender, EventArgs e)
        {
            string currentFEN = kenChessUserControl1.CurrentChessMove.FENPositionAfterChessMove;
            Clipboard.SetText(currentFEN);
        }
    }
}
