using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using KenChessPGNCoreLibrary;
using KenChessBoardView;
using System.Deployment.Application;

namespace KenChessMain
{
    public partial class FormMain : Form
    {
        // TODO Feature: incorporate a ChessEngine (Stockfish?) so a game could actaully be played vs computer.
        // TODO Feature: combine single pgn ascii games into a _db_ (database multi-game ASCII file)
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            panelRecommendCreateFolders.Visible = !Directory.Exists(Constants.KenChessTopLevelFolderPath);
            // This works for a published app, but won't work during development (not network deployed when running in Visual Studio)
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                versionNnnnToolStripMenuItem.Text = "Version " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
        }

        private void buttonCreateKenChessFolder_Click(object sender, EventArgs e)
        {
            string question;
            string infomssg = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Directory.CreateDirectory(Constants.ViewingGamesLibraryFolderPath);
                Directory.CreateDirectory(Constants.TrainingGamesFolderPath);
                if (Directory.GetFiles(Constants.ViewingGamesLibraryFolderPath).Count() == 0)
                {
                    question = "Successfully created KenChess folder in your documents folder."
                        + "\nWould you like two small sample files to be written in the KenChess folder?";
                    if (DialogResult.Yes == Constants.AskYesNoQuestion(question))
                    {
                        File.WriteAllText(Path.Combine(Constants.TrainingGamesFolderPath, "SampleTrainingGame.pgn"), SamplePGN.SampleTrainingGame);
                        File.WriteAllText(Path.Combine(Constants.ViewingGamesLibraryFolderPath, "_db_SampleGameDatabase.pgn"), SamplePGN.SampleGameDatabase);
                        infomssg = "Two sample files successfully created.";
                        Constants.DisplayInfoMessage(infomssg);
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

        private void openGameDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Constants.ViewingGamesLibraryFolderPath;
                    openFileDialog.Filter = "pgn files (*.pgn)|*.pgn|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }
                FormListGames frm = new FormListGames(fileContent, filePath);
                frm.Show();
            }
            catch (Exception exc)
            {
                Constants.DisplayErrorMessage(Constants.CommonErrorMessage);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
        
        private void openSinglePGNGameFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string rawPGNMultiGameContent = Clipboard.GetText();
                // if game tags seem to be missing then prepend some tags
                if (!rawPGNMultiGameContent.StartsWith("["))
                {
                    rawPGNMultiGameContent = "[Event \"Unknown\"]" + "[Site \"?\"]"
                        + $"[Date \"{DateTime.Today.ToShortDateString()}\"]\r\n" + "[Round \"?\"]"
                        + "[White \"Player1\"]\r\n[Black \"Player2\"]\r\n[Result \"*\"]\r\n"
                        + rawPGNMultiGameContent;
                }
                GameRepresentation gameRepresentation = new GameRepresentation(rawPGNMultiGameContent, 1);
                FormEditOrCreateGame frm = new FormEditOrCreateGame(gameRepresentation, null, false);
                frm.Show();
            }
            catch (Exception exc)
            {
                Constants.DisplayErrorMessage(Constants.CommonErrorMessage);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
        private void createTrainingGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string pgnContent = SamplePGN.InitialTrainingGamePGN;
                GameRepresentation gameRepresentation = new GameRepresentation(pgnContent, 1);
                FormEditOrCreateGame frm = new FormEditOrCreateGame(gameRepresentation, null, true);
                frm.Show();
            }
            catch (Exception exc)
            {
                Constants.DisplayErrorMessage(Constants.CommonErrorMessage);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void editExistingTrainingGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Constants.TrainingGamesFolderPath;
                    openFileDialog.Filter = "pgn files (*.pgn)|*.pgn|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pgnContent = null;
                        using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                        {
                            pgnContent = reader.ReadToEnd();
                        }
                        GameRepresentation gameRepresentation = new GameRepresentation(pgnContent, 1);

                        FormEditOrCreateGame frm = new FormEditOrCreateGame(gameRepresentation, openFileDialog.FileName, true);
                        frm.Show();
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

        private void startTrainingSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Constants.TrainingGamesFolderPath;
                    openFileDialog.Filter = "pgn files (*.pgn)|*.pgn|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FormTrainingSession frm = new FormTrainingSession(openFileDialog.FileName);
                        frm.Show();
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

        private void definitionAGameDatabaseIsAPGNFileContaining1OrMoreChessGamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp frm = new FormHelp();
            frm.Show();
        }

        private void createNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string pgnContent = SamplePGN.InitialGamePGN;
                GameRepresentation gameRepresentation = new GameRepresentation(pgnContent, 1);
                FormEditOrCreateGame frm = new FormEditOrCreateGame(gameRepresentation, null, false);
                frm.Show();
            }
            catch (Exception exc)
            {
                Constants.DisplayErrorMessage(Constants.CommonErrorMessage);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp frm = new FormHelp();
            frm.Show();
        }
    }
}
