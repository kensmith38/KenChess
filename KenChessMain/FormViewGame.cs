using KenChessPGNCoreLibrary;
using KenGenericNode;
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
    public partial class FormViewGame : Form
    {
        public GameRepresentation GameRepresentation { get; set; }
        public string GameDatabaseName { get; set; }
        public int GameNumber { get; set; }
        public FormViewGame(GameRepresentation gameRepresentation, string gameDatabaseName, int gameNumber)
        {
            InitializeComponent();
            GameRepresentation = gameRepresentation;
            GameDatabaseName = gameDatabaseName;
            GameNumber = gameNumber;
        }
        private void FormViewGame_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                textBoxGameDatabaseName.Text = GameDatabaseName;
                textBoxGameNumber.Text = GameNumber.ToString();
                kenChessUserControl1.LoadSpecificGame(GameRepresentation);
                kenChessUserControl1.UserCanMoveChessPieces = false;
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

        private void buttonCloneGame_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string pgnContent = kenChessUserControl1.GetGameAsPgnContent();
                // We save to predefined folder in Documents folder
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Constants.ViewingGamesLibraryFolderPath;

                saveFileDialog1.Filter = "pgn chess game (*.pgn)|*.pgn";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                // set default filename if database filename starts with _db_
                string dbFilename = Path.GetFileName(GameDatabaseName);
                if (dbFilename.StartsWith("_db_"))
                {
                    saveFileDialog1.FileName = dbFilename.Substring(4) + $"_game{GameNumber}.pgn";
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string currentGameFilepath = saveFileDialog1.FileName;
                    File.WriteAllText(currentGameFilepath, pgnContent);
                    Constants.DisplayInfoMessage($"Successfully saved as: {Path.GetFileName(currentGameFilepath)} ");
                    //
                    GameRepresentation = new GameRepresentation(pgnContent, 1);

                    FormEditOrCreateGame frm = new FormEditOrCreateGame(GameRepresentation, currentGameFilepath, false);
                    frm.Show();
                    //
                    Close();
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
}
