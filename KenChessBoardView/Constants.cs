using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessBoardView
{
    public static class Constants
    {
        public const string AppName = "KenChessBoard";
        public const string WindowShortTitleText = "KenChessBoard";
        public const string VersionInfo = "Version 1.0.0.1";

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

    }
}
