﻿using ChessApp.src.Board.ChessBoard;
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
        private List<Position>? allowed; 


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
                    PictureBox valid = new PictureBox() { Dock = DockStyle.Fill }; ;
                    table.Controls.Remove(table.GetControlFromPosition(position.getRealCoord().first, position.getRealCoord().second));
                    valid.Click +=  PictureBox_Click;
                    valid.Image = Properties.Resources.green;
                    valid.SizeMode = PictureBoxSizeMode.Zoom;
                    table.Controls.Add(valid, position.getRealCoord().first, position.getRealCoord().second);

                }
            }
        }

        private void resetColouredMoves(List<Position> allowed, Position destination)
        {
            TableLayoutPanel table = this.tblChessBoard;
            foreach (Position position in allowed)
            {

                if (!position.equals(destination))
                {
                    PictureBox cntrl = (PictureBox)table.GetControlFromPosition(position.getRealCoord().first, position.getRealCoord().second);
                    cntrl.Image = null;
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

                    this.allowed = (board.getPiece(new Position(col, row))).getAllowedMoves(this.tblChessBoard, board);
                    
                    colorMoves(allowed);

                }
                
            }
            else
            {
                
                int col = this.tblChessBoard.GetColumn(clicked);
                int row = this.tblChessBoard.GetRow(clicked);
                bool correct = false;
                Position destination = new Position(col, row);
                
                if(allowed != null) { 

                    foreach(Position p in allowed)
                    {
                     
                        if (destination.equals(p))
                        {
                            correct = true;
                        }
                    }

                    if (correct)
                    {
                        resetColouredMoves(this.allowed, destination);
                        clicked.Image = firstClicked.Image;
                        firstClicked.Image = null;
                        secondClick = false;
                        Position starting = new Position(this.tblChessBoard.GetColumn(firstClicked), this.tblChessBoard.GetRow(firstClicked));
                        board.makeMove(board.getPiece(starting), destination);
                        
                    }
                    else
                    {
                        secondClick = false;
                        resetColouredMoves(this.allowed, destination);
                        allowed = null;
                    }
                    this.allowed = null;
                }
                
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
