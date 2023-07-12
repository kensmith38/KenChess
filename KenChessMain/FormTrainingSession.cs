using KenChessBoardModel;
using KenChessBoardView;
using KenChessPGNCoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessMain
{
    public partial class FormTrainingSession : Form
    {
        public string TrainingGameFilepath { get; set; }
        public bool MeIsWhite { get; set; }
        public GameRepresentation GameRepresentation { get; set; }
        //public ChessMoveNode CurrentChessMove { get; set; }
        //public AnimatedChessPiece AnimatedChessPiece { get; set; }

        public FormTrainingSession(string trainingGameFilepath)
        {
            InitializeComponent();
            TrainingGameFilepath = trainingGameFilepath;
        }

        private void FormTrainingSession_Load(object sender, EventArgs e)
        {
            // Must initialize delegates
            kenChessUserControl1.userCompletedMoveGesture = UserCompletedMoveGesture;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                labelGameFile.Text = Path.GetFileName(TrainingGameFilepath);
                string pgnContent = null;
                using (StreamReader reader = new StreamReader(TrainingGameFilepath))
                {
                    pgnContent = reader.ReadToEnd();
                }
                GameRepresentation = new GameRepresentation(pgnContent, 1);
                kenChessUserControl1.LoadSpecificGame(GameRepresentation);
                kenChessUserControl1.UserNavigationEnabled = true;
                // Me is white by default; Me is only black if the "Black" gametag = Me
                if ((!kenChessUserControl1.GameRepresentation.GameTags["White"].Equals("Me")) &&
                    (!kenChessUserControl1.GameRepresentation.GameTags["Black"].Equals("Me")))
                {
                    Constants.DisplayInfoMessage("You will be playing the White pieces in this training session.");
                    MeIsWhite = true;
                }
                else
                {
                    MeIsWhite = kenChessUserControl1.GameRepresentation.GameTags["White"].Equals("Me");
                }
                kenChessUserControl1.UserCanMoveChessPieces = MeIsWhite;
                if (!MeIsWhite)
                {
                    kenChessUserControl1.checkBoxFlipBoard.Checked = true;
                    MakeMoveForComputer(GameRepresentation.RootNode);
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
        /// <summary>
        /// Delegate method invoked from KenChessUserControl. THe uciMove is the move gesture (dragging piece) from the user.
        /// </summary>
        public void UserCompletedMoveGesture(string uciMove)
        {
            //Constants.DisplayInfoMessage("Debug: Wow");
            ChessMoveNode currentChessMove = kenChessUserControl1.CurrentChessMove;
            // The list of moves (mainline and variation) for training at this current chess move
            List<ChessMoveNode> listValidTrainingMoves = getValidTrainingResponseMoves(currentChessMove);
            ChessMoveNode userMove = null;
            foreach (ChessMoveNode chessMoveNode in listValidTrainingMoves)
            {
                if (chessMoveNode.UCImove.Equals(uciMove))
                {
                    userMove = chessMoveNode;
                    break;
                }
            }
            if (userMove == null)
            {
                // TODO improve pseudoPGN logic for invalid traing move
                // Reason for complication: We don't even check that the user move gesture was a legal move (user could gesture moving any piece anywhere)
                ChessBoard chessBoard = new ChessBoard(currentChessMove.FENPositionAfterChessMove);
                ChessPiece chessPiece = chessBoard.getChessPieceOnSquare(uciMove.Substring(0,2));
                // Could improve pseudoPGN by looking for capture and castling etc.
                string pseudoPGN = chessPiece.PieceType == PieceType.Pawn ?
                    uciMove.Substring(2, 2) :
                    chessPiece.FENCharForPiece.ToString().ToUpper() + uciMove.Substring(2,2);
                Constants.DisplayInfoMessage($"This move, {pseudoPGN}, (uci={uciMove}) is not the correct training move (and may be illegal move).");
            }
            else
            {
                PerformValidatedMove(userMove);
                currentChessMove = kenChessUserControl1.CurrentChessMove;
                // now make move for computer
                ChessMoveNode computerMove = GetComputerMove(currentChessMove);
                if (computerMove != null)
                {
                    MakeMoveForComputer(computerMove);
                }
            }
        }
        private List<ChessMoveNode> getValidTrainingResponseMoves(ChessMoveNode currentChessMove)
        {
            List<ChessMoveNode> listValidTrainingMoves = new List<ChessMoveNode>();
            if (currentChessMove == null)
            {
                listValidTrainingMoves.Add(GameRepresentation.RootNode);
            }
            else
            {
                if (currentChessMove.ChildNodes.Count > 0)
                {
                    listValidTrainingMoves.Add((ChessMoveNode)currentChessMove.ChildNodes[0]);
                    for (int iii=1; iii<currentChessMove.ChildNodes.Count; iii++)
                    {
                        ChessMoveNode variationMove = (ChessMoveNode)currentChessMove.ChildNodes[iii];
                        listValidTrainingMoves.Add(variationMove);
                    }
                }
            }
            return listValidTrainingMoves;
        }
        // Serious logic problems (or bug?) when using async methods: UserNavigationEnabled=false ignored in MakeMoveForComputer.
        // So you could click a navigation button and it would think UserNavigationEnabled=true.
        /// <summary>
        /// Delays the computer response to make the game more natural and prevents user action on chessboard until
        /// the computer move has been completed.
        /// </summary>
        private async Task SimulateComputerThinking()
        {
            await Task.Delay(3000);
        }
        /// <summary>
        /// Makes the computer move based on currentChessMove.
        /// </summary>
        private void MakeMoveForComputer(ChessMoveNode computerMove)
        {
            if (computerMove.SANmove == null)
            {
                Constants.DisplayInfoMessage("You have reached the end of the training game.");
            }
            else
            {
                //await SimulateComputerThinking();
                kenChessUserControl1.UserNavigationEnabled = false;
                kenChessUserControl1.UserCanMoveChessPieces = false;
                string squareFromUciName = computerMove.UCImove.Substring(0, 2);
                string squareToUciName = computerMove.UCImove.Substring(2, 2);
                kenChessUserControl1.AnimatedChessPiece = new AnimatedChessPiece(squareFromUciName, squareToUciName, computerMove);
                // Tricky! Async methods SimulateComputerThinking had serious problems so here is a trick!
                // The timer interval is set to a large value (ex 2000 ms) but the interval is reset to desired animation speed after the first tick (see timerMoveAnimation_Tick)
                //timerMoveAnimation.Interval = Math.Max(1, 5 * (kenChessUserControl1.trackBarAnimationSpeed.Maximum - kenChessUserControl1.trackBarAnimationSpeed.Value));
                timerMoveAnimation.Interval = 2000;
                timerMoveAnimation.Start();
                kenChessUserControl1.Invalidate(true);
            }
        }
        private ChessMoveNode GetComputerMove(ChessMoveNode currentChessMove)
        {
            ChessMoveNode computerMove = null;
            if (currentChessMove == null)
            {
                computerMove = GameRepresentation.RootNode;
            }
            else
            {
                // TODO Future feature: assign weight to chess moves so each random move in training has more or less likelihood of being chosen
                // pick randomly from mainline and variations
                List<ChessMoveNode> listValidTrainingMoves = getValidTrainingResponseMoves(currentChessMove);
                if (listValidTrainingMoves.Count == 0)
                {
                    Constants.DisplayInfoMessage("You have reached the end of this branch of moves.");
                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(listValidTrainingMoves.Count);
                    computerMove = listValidTrainingMoves[randomNumber];
                }
            }
            return computerMove;
        }
        private void PerformValidatedMove(ChessMoveNode chessMove)
        {
            kenChessUserControl1.CurrentChessMove = chessMove;
            kenChessUserControl1.Invalidate(true);
            kenChessUserControl1.RichTextViewer.highlightCurrentMoveInRichText(chessMove);
        }
        /// <summary>
        /// Timer is used for piece animation (move chess piece from square to square)
        /// </summary>
        private void timerMoveAnimation_Tick(object sender, EventArgs e)
        {
            kenChessUserControl1.AnimatedChessPiece.PercentComplete += 10;
            // Tricky! The interval for 1st tick was very large (ex 2000 ms) so now we set to normal animation speed
            timerMoveAnimation.Interval = Math.Max(1, 5 * (kenChessUserControl1.trackBarAnimationSpeed.Maximum - kenChessUserControl1.trackBarAnimationSpeed.Value));
            if (kenChessUserControl1.AnimatedChessPiece.PercentComplete >= 100)
            {
                timerMoveAnimation.Stop();
                if (kenChessUserControl1.AnimatedChessPiece.JumpToChessMoveNodeAfterAnimation != null)
                {
                    PerformValidatedMove(kenChessUserControl1.AnimatedChessPiece.JumpToChessMoveNodeAfterAnimation);
                }
                kenChessUserControl1.AnimatedChessPiece = null;
                kenChessUserControl1.UserNavigationEnabled = true;
                kenChessUserControl1.UserCanMoveChessPieces = true;
            }
            kenChessUserControl1.Invalidate(true);
        }
    }
}
