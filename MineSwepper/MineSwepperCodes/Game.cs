using MineSwepper.Draw;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSwepper.MineSwepperCodes
{
    class Game
    {
        public MainForm Form;
        Cells[,] Cell;
        public int BoardWidth = 10;
        public int BoardHeight = 10;
        public int k = 0;
        public void Games()
        {
            if (k == 0)
            {
                CreateBoard CB = new CreateBoard();
                Cell = CB.Init(BoardWidth, BoardHeight);
                string workingDirectory = Environment.CurrentDirectory;
                workingDirectory += "\\Save Form C#";
                var Path = workingDirectory + "\\Buffer1.txt";
                File.WriteAllText(Path, "");
                k = 1;
            }
        }
        internal void Drawing(Graphics graphics, Label label1, Timer timer, int v)
        {
            graphics.Clear(Color.DarkGreen);
            Board B = new Board();
            B.DrawB(graphics, Cell, label1, timer, v);
        }
        internal void MouseClickAction(MouseEventArgs e, Label label1, Timer timer, Label label2)
        {
            if (label1.Visible==false)
            {
                string workingDirectory = Environment.CurrentDirectory;
                workingDirectory += "\\Save Form C#";
                string[] Lines = File.ReadAllLines(workingDirectory + "\\Buffer1.txt");
                if (Lines.Length == 0)
                {

                }
                else if (Lines[0] == "0")
                {
                    Form.Update();
                }
                //int C = 0;
                Board B = new Board();
                int X = e.X;
                int Y = e.Y;
                X -= 7;
                Y -= 60;
                if (X > -1 && Y > -1)
                {
                    if (BoardWidth == 10)
                    {
                        X = X / 35;
                        Y = Y / 35;
                    }
                    else if (BoardWidth == 15)
                    {
                        X = X / 30;
                        Y = Y / 30;
                    }
                    else if (BoardWidth == 20)
                    {
                        X = X / 27;
                        Y = Y / 27;
                    }
                    else if (BoardWidth == 30)
                    {
                        X = X / 25;
                        Y = Y / 25;
                    }
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (X < BoardWidth && Y < BoardHeight)
                        {
                            //label1.Text = "[" + X + "," + Y + "]";
                            if (Cell[X, Y].flag == true)
                            {

                            }
                            else
                            {
                                Cell[X, Y].IsClick = true;
                                ZeroCell(Cell, X, Y, label1);
                            }
                        }
                        if (label1.Visible == true)
                        {

                        }
                        else
                        {
                            ReDraw();
                        }
                    }
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (Y < BoardHeight && X < BoardWidth)
                        {
                            if (Cell[X, Y].flag == true)
                            {
                                Cell[X, Y].flag = false;
                            }
                            else
                            {
                                Cell[X, Y].flag = true;
                            }
                            if (label1.Visible == true)
                            {

                            }
                            else
                            {
                                ReDraw();
                            }
                        }
                    }
                }
            }
        }
        public void ReDraw()
        {
            Form.Refresh();
            //Drawing(graphics1, label11, timer1);
            //MouseClickAction(e, label11, graphics1, timer1);

        }
        private void ZeroCell(Cells[,] cell, int i, int j, Label label1)
        {

            if (cell[i, j].IsMine == false)
            {
                if (j > 0)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i, j - 1].IsClick == false && cell[i, j - 1].IsMine == false)
                    {
                        cell[i, j - 1].IsClick = true;
                        if (cell[i, j - 1].MineCounter == 0)
                        {
                            ZeroCell(cell, i, j - 1, label1);
                        }
                    }
                }
                if (j < BoardHeight - 1)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i, j + 1].IsClick == false && cell[i, j + 1].IsMine == false)
                    {
                        cell[i, j + 1].IsClick = true;
                        if (cell[i, j + 1].MineCounter == 0)
                        {
                            ZeroCell(cell, i, j + 1, label1);
                        }
                    }
                }
                if (i < BoardWidth - 1)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i + 1, j].IsClick == false && cell[i + 1, j].IsMine == false)
                    {
                        cell[i + 1, j].IsClick = true;
                        if (cell[i + 1, j].MineCounter == 0)
                        {
                            ZeroCell(cell, i + 1, j, label1);
                        }
                    }
                }
                if (i > 0)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i - 1, j].IsClick == false && cell[i - 1, j].IsMine == false)
                    {
                        cell[i - 1, j].IsClick = true;
                        if (cell[i - 1, j].MineCounter == 0)
                        {
                            ZeroCell(cell, i - 1, j, label1);
                        }
                    }
                }
                if (i > 0 && j > 0)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i - 1, j - 1].IsClick == false && cell[i - 1, j - 1].IsMine == false)
                    {
                        cell[i - 1, j - 1].IsClick = true;
                        if (cell[i - 1, j - 1].MineCounter == 0)
                        {
                            ZeroCell(cell, i - 1, j - 1, label1);
                        }
                    }
                }
                if (i < BoardWidth - 1 && j > 0)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i + 1, j - 1].IsClick == false && cell[i + 1, j - 1].IsMine == false)
                    {
                        cell[i + 1, j - 1].IsClick = true;
                        if (cell[i + 1, j - 1].MineCounter == 0)
                        {
                            ZeroCell(cell, i + 1, j - 1, label1);
                        }
                    }
                }
                if (i > 0 && j < BoardHeight - 1)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i - 1, j + 1].IsClick == false && cell[i - 1, j + 1].IsMine == false)
                    {
                        cell[i - 1, j + 1].IsClick = true;
                        if (cell[i - 1, j + 1].MineCounter == 0)
                        {
                            ZeroCell(cell, i - 1, j + 1, label1);
                        }
                    }
                }
                if (i < BoardWidth - 1 && j < BoardHeight - 1)
                {
                    if (cell[i, j].MineCounter == 0 && cell[i + 1, j + 1].IsClick == false && cell[i + 1, j + 1].IsMine == false)
                    {
                        cell[i + 1, j + 1].IsClick = true;
                        if (cell[i + 1, j + 1].MineCounter == 0)
                        {
                            ZeroCell(cell, i + 1, j + 1, label1);
                        }
                    }
                }
                string workingDirectory = Environment.CurrentDirectory;
                workingDirectory += "\\Save Form C#";
                string[] Lines = File.ReadAllLines(workingDirectory + "\\Buffer1.txt");
                var Path = workingDirectory + "\\Buffer1.txt";
                if (Lines.Length == 0)
                {
                    int b = Cell[0, 0].MineCount;
                    int All2 = BoardHeight * BoardWidth;
                    All2 -= b;
                    int SoilCount2 = 0;
                    for (int j2 = 0; j2 < Cell.GetLength(1); j2++)
                    {
                        for (int i2 = 0; i2 < Cell.GetLength(0); i2++)
                        {
                            if (Cell[i2, j2].IsClick == true)
                            {
                                if (Cell[i2, j2].IsMine == true)
                                {
                                }
                                else
                                {
                                    SoilCount2++;
                                }
                            }
                        }
                    }
                    if (All2 == SoilCount2)
                    {
                         workingDirectory = Environment.CurrentDirectory;
                        workingDirectory += "\\Save Form C#";
                        Lines = File.ReadAllLines(workingDirectory + "\\Buffer1.txt");
                         Path = workingDirectory + "\\Buffer1.txt";
                        File.WriteAllText(Path, "1\n9");
                        ReDraw();
                    }
                }
                
            }

            else if (cell[i, j].IsMine == true)
            {
                string workingDirectory = Environment.CurrentDirectory;
                workingDirectory += "\\Save Form C#";
                string[] Lines = File.ReadAllLines(workingDirectory + "\\Buffer1.txt");
                var Path = workingDirectory + "\\Buffer1.txt";
                File.WriteAllText(Path, "1");
                label1.Visible = true;
            }
        }
    }
}