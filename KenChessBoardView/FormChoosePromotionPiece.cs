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
    public partial class FormChoosePromotionPiece : Form
    {
        public PictureBox selectedPictureBox = null;
        CachedImagesForPieces CachedImagesForPieces;
        char ActivePlayer;
        public FormChoosePromotionPiece(CachedImagesForPieces cachedImagesForPieces, char activePlayer)
        {
            InitializeComponent();
            CachedImagesForPieces = cachedImagesForPieces;
            ActivePlayer = activePlayer;
        }

        private void FormChoosePromotionPiece_Load(object sender, EventArgs e)
        {
            char fenCharForQueen = ActivePlayer == 'w' ? 'Q' : 'q';
            char fenCharForRook = ActivePlayer == 'w' ? 'R' : 'r';
            char fenCharForBishop = ActivePlayer == 'w' ? 'B' : 'b';
            char fenCharForKnight = ActivePlayer == 'w' ? 'N' : 'n';

            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForQueen, out Image queenImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForRook, out Image rookImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForBishop, out Image bishopImage);
            CachedImagesForPieces.CachedImages.TryGetValue(fenCharForKnight, out Image knightImage);

            pictureBoxQueen.Image = queenImage;
            pictureBoxRook.Image = rookImage;
            pictureBoxBishop.Image = bishopImage;
            pictureBoxKnight.Image = knightImage;
        }

        private void pictureBoxANY_Click(object sender, EventArgs e)
        {
            panelQueen.BackColor = Color.White;
            panelRook.BackColor = Color.White;
            panelBishop.BackColor = Color.White;
            panelKnight.BackColor = Color.White;

            PictureBox clickedPicture = (PictureBox)sender;
            selectedPictureBox = clickedPicture;
            selectedPictureBox.Parent.BackColor = Color.LightBlue;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
