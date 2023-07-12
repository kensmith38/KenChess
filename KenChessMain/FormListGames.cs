using KenChessPGNCoreLibrary;
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

namespace KenChessMain
{
    public partial class FormListGames : Form
    {
        public string RawPGNMultiGameContent { get; set; }
        public string GameDatabaseFilepath { get; set; }

        public FormListGames(string rawPGNMultiGameContent, string gameDatabaseFilepath)
        {
            InitializeComponent();
            RawPGNMultiGameContent = rawPGNMultiGameContent;
            GameDatabaseFilepath = gameDatabaseFilepath;
        }

        private void FormListGames_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // taller rows for button 
                dataGridViewListGames.RowTemplate.Height = 26;
                textBoxGameDatabaseName.Text = Path.GetFileName(GameDatabaseFilepath);
                populateListOfGames();
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
        private void populateListOfGames()
        {
            List<GameInfo> listGameInfo = GameInfo.GetListGameInfo(RawPGNMultiGameContent);
            if (listGameInfo.Count == 1)
            {
                string pgnContent = File.ReadAllText(GameDatabaseFilepath);
                GameRepresentation gameRepresentation = new GameRepresentation(pgnContent, 1);

                FormEditOrCreateGame frm = new FormEditOrCreateGame(gameRepresentation, GameDatabaseFilepath, false);
                frm.Show();

                Close();
            }
            else
            {
                int gameNumber = 1;
                dataGridViewListGames.Rows.Clear();

                foreach (GameInfo gameInfo in listGameInfo)
                {
                    DataGridViewRow dgvrow = dataGridViewListGames.Rows[dataGridViewListGames.Rows.Add()];
                    string pgnEvent = gameInfo.Event;
                    string pgnDate = gameInfo.Date;
                    string pgnWhite = gameInfo.White;
                    string pgnBlack = gameInfo.Black;
                    string pgnResult = gameInfo.Result;

                    dgvrow.Cells[Column_ListGames_GameNumber.Index].Value = gameNumber;
                    dgvrow.Cells[Column_ListGames_Event.Index].Value = pgnEvent;
                    dgvrow.Cells[Column_ListGames_Date.Index].Value = pgnDate;
                    dgvrow.Cells[Column_ListGames_Black.Index].Value = pgnBlack;
                    dgvrow.Cells[Column_ListGames_White.Index].Value = pgnWhite;
                    dgvrow.Cells[Column_ListGames_Result.Index].Value = pgnResult;
                    gameNumber++;
                }
                textBoxCtrGames.Text = (gameNumber - 1).ToString();
            }
        }
        private void dataGridViewListGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.ColumnIndex == Column_ListGames_LoadGame.Index)
                {
                    DataGridViewRow dgvrow = dataGridViewListGames.Rows[e.RowIndex];
                    int gameNumber = (int)dgvrow.Cells[Column_ListGames_GameNumber.Index].Value;
                    GameRepresentation gameRepresentation = new GameRepresentation(RawPGNMultiGameContent, gameNumber);
                    FormViewGame frm = new FormViewGame(gameRepresentation, GameDatabaseFilepath, gameNumber);
                    frm.Show();
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
