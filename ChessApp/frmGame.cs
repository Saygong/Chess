using ChessApp.src.Board.ChessBoard;
using ChessApp.src.Positions;
using ChessApp.src.Pieces;
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

        
        private ChessBoard board;
        private PictureBox? first = null;
        private List<Position>? backupAllowed;
        private bool turn; 


        public frmGame(string type)
        {
            InitializeComponent();
            ChessBoard board = new ChessBoard();
            this.board = board;
            board.initBoard();
            TableLayoutPanel table = this.tblChessBoard;
            this.turn = board.player_turn;
            this.placePieces();

            foreach (Control ctrl in table.Controls)
            {
                ctrl.Click += PictureBox_Click;
            }
        }


        /** Method that will check the allowed field */
        private void colorMoves(List<Position>? allowed)
        {
            this.backupAllowed = allowed;
            if (allowed != null)
            {
                foreach (Position position in allowed)
                {
                    // Sure casting beacuse we are sure that the retrieved element is a PictureBox
                    TableLayoutPanel table = this.tblChessBoard;
                    PictureBox valid = new PictureBox() { Dock = DockStyle.Fill }; ;
                    table.Controls.Remove(table.GetControlFromPosition(position.getRealCoord().first, position.getRealCoord().second));
                    valid.Click +=  PictureBox_Click;
                    valid.Image = Properties.Resources.green;
                    valid.SizeMode = PictureBoxSizeMode.Zoom;
                    table.Controls.Add(valid, position.getRealCoord().first, position.getRealCoord().second);

                }
            }
        }



        /** Method that will reset the previously checked as allowed field */
        private void resetColouredMoves(List<Position>? allowed, PictureBox? second)
        {

            TableLayoutPanel table = this.tblChessBoard;
            Position? destination = null;
            if (second != null)
            {
                int row = table.GetRow(second);
                int col = table.GetColumn(second);
                destination = new Position(row, col);
                
            }

            if (allowed != null)
            {
                if(destination == null)
                {
                    foreach (Position position in allowed)
                    {

                        PictureBox cntrl = (PictureBox)table.GetControlFromPosition(position.getRealCoord().first, position.getRealCoord().second);
                        cntrl.Image = null;

                    }
                }
                else
                {
                    foreach (Position position in allowed)
                    {

                        if (!position.equals(destination))
                        {
                            PictureBox cntrl = (PictureBox)table.GetControlFromPosition(position.getRealCoord().first, position.getRealCoord().second);
                            if(cntrl != null)
                            {
                                cntrl.Image = null;
                            }
                            
                        }

                    }
                    second.Image = first.Image;
                    first.Image = null;
                    first = null;
                }
                
                
                
            }
            
            
        }




        
        
        public void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clicked = (PictureBox)sender;
            int row = this.tblChessBoard.GetRow(clicked);
            int col = this.tblChessBoard.GetColumn(clicked);

            if (clicked.Image != null)
            {

                if (first == null)
                {
                    List<Position>? toColor = this.board.makeMove(new Position(col, row));
                    first = clicked;
                    colorMoves(toColor);
                }
                else
                {
                    List<Position>? toUnColor = this.board.makeMove(new Position(col, row));
                    if (toUnColor != null)
                    {
                        resetColouredMoves(toUnColor, clicked);
                        List<Position> aiMove = this.board.randomAiMove();
                        int colStart = aiMove[0].getRealCoord().first;
                        int rowStart = aiMove[0].getRealCoord().second;
                        PictureBox start = (PictureBox)this.tblChessBoard.GetControlFromPosition(colStart, rowStart);
                        this.tblChessBoard.SetColumn(start, aiMove[1].getRealCoord().first);
                        this.tblChessBoard.SetRow(start, aiMove[1].getRealCoord().second);

                        
                    }
                    else {
                        resetColouredMoves(this.backupAllowed, null);
                        this.backupAllowed = null;
                    }



                }
            }
              

        }



        /** Place the pieces into the board */
        public void placePieces()
        {
            // Adding pictureboxes with images
            foreach (Piece piece in this.board.b_pieces)
            {

                PictureBox pb = new PictureBox() { Dock = DockStyle.Fill };
                pb.ImageLocation = @"../../../Resources/pieces/" + piece.name + ".png";
                pb.SizeMode = PictureBoxSizeMode.Zoom;

                int row = piece.p.getRealCoord().second;
                int col = piece.p.getRealCoord().first;
                this.tblChessBoard.Controls.Add(pb, col, row);
            }
        }



        private void frmGame_Load(object sender, EventArgs e)
        {
            

        }





    }

}
