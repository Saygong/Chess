using ChessApp.src.Board.ChessBoard;
using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessApp
{
    public partial class frmGame : Form
    {

        private PictureBox? firstClicked = null;
        private bool secondClick = false;
        private ChessBoard board;

        public frmGame(string type)
        {
            InitializeComponent();
        }

        private void colorMoves(List<Position>? allowed)
        {
            if (allowed != null)
            {
                foreach (Position position in allowed)
                {
                    // Sure casting beacuse we are sure that the retrieved element is a PictureBox
                    TableLayoutPanel table = this.tblChessBoard;
                    PictureBox valid = new PictureBox();
                    table.Controls.Remove(table.GetControlFromPosition(position.getRealCoord().first, position.getRealCoord().second));
                    
                    valid.ImageLocation = @"Resources/green_gradient1.png";
                    valid.SizeMode = PictureBoxSizeMode.Zoom;
                    table.Controls.Add(valid, position.getRealCoord().first, position.getRealCoord().second);

                }
            }
        }

        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
        }



        public void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clicked = (PictureBox)sender;
            if (!secondClick) { 
                if(clicked.Image != null)
                {
                    secondClick = true;
                    firstClicked = clicked;
                    int col = this.tblChessBoard.GetColumn(clicked);
                    int row = this.tblChessBoard.GetRow(clicked);

                    List<Position>? allowed = (board.getPiece(new Position(col, row))).getAllowedMoves(this.tblChessBoard);
                    this.lblInfo.Text = board.getPiece(new Position(col, row)).toString();
                    
                    colorMoves(allowed);

                }
                
            }
            else
            {

                clicked.Image = firstClicked.Image;
                firstClicked.Image = null;
                secondClick = false;
            }

        }


        private void frmGame_Load(object sender, EventArgs e)
        {
            ChessBoard board = new ChessBoard();
            this.board = board;
            board.initBoard();
            TableLayoutPanel table = this.tblChessBoard;

            board.placePieces(table);

            foreach (Control ctrl in table.Controls)
            {
                ctrl.Click += PictureBox_Click;
            }

        }

        private void lblTurn_Click(object sender, EventArgs e)
        {

        }
    }

}
