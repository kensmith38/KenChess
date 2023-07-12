using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessMain
{
    public static class Constants
    {
        public const string AppName = "KenChess";
        public const string WindowShortTitleText = "KenChess";
        public static string KenChessTopLevelFolderPath =
            Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KenChess");
        public static string TrainingGamesFolderPath =
            Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KenChess", "TrainingGames");
        public static string ViewingGamesLibraryFolderPath =
            Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KenChess", "GamesLibrary");
        public const string DebugLogFilename = "KenDebug.txt";
        public const string CommonErrorMessage = "Error: The clipboard does not contain valid PGN content."
                    + "\nA common error is PGN content missing a valid result token (1-0 or * etc.) at the end."
                    + "\nGames downloaded from a website may also contain invalid PGN in one or more of the games in the file.";
        public static void DisplayInfoMessage(string message)
        {
            MessageBox.Show(message, WindowShortTitleText, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message, WindowShortTitleText, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void DisplayExceptionMessage(Exception exc)
        {
            if (exc == null)
            {
                throw new ArgumentNullException(nameof(exc));
            }
            string primaryMessage = exc.Message;
            // The null-propagation operator (?.) will return null if anything in the object reference chain is null. 
            string innerMessage = exc.InnerException?.Message;
            string message = primaryMessage + ((innerMessage == null) ? "" : "\n" + innerMessage);
            message = message + "\nStack trace:\n" + exc.StackTrace;
            MessageBox.Show(message, WindowShortTitleText, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult AskYesNoQuestion(string question)
        {
            DialogResult result = MessageBox.Show(question, WindowShortTitleText, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }
    }
}
