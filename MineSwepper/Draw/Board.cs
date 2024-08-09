using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MineSwepper.MineSwepperCodes;

namespace MineSwepper.Draw
{
    class Board
    {
        Game G = new Game();
        public MainForm Form1;
        public int iB, jB;
        int c = 0;
        private int SoilCount;
        Brush brush, brushMineM, brushGrass1, brushGrass2, brushSoil1, brushSoil2, brushMine;
        public bool found = false;
        bool Win = false;
        public bool GameOverF = false;
        public bool Use = true;
        internal void DrawB(Graphics graphics, Cells[,] Cell, System.Windows.Forms.Label label1,
            System.Windows.Forms.Timer timer, int v)
        {
            if (found == false)
            {
                int b = Cell[0, 0].MineCount;
                iB = Cell.GetLength(0);
                jB = Cell.GetLength(1);
                int All = iB * jB;
                All -= b;
                brushGrass1 = Brushes.LightGreen;
                brushGrass2 = Brushes.Green;
                brushSoil1 = Brushes.SandyBrown;
                brushSoil2 = Brushes.NavajoWhite;
                Pen pen = new Pen(Brushes.DarkOliveGreen, 3);
                found = false;
                for (int j = 0; j < Cell.GetLength(1); j++)
                {
                    for (int i = 0; i < Cell.GetLength(0); i++)
                    {
                        int TextX = Cell[i, j].Rect.X + 4;
                        int TextY = Cell[i, j].Rect.Y + 4;
                        if (j % 2 == 0)
                        {
                            if (i % 2 == 0)
                            {
                                brush = brushGrass1;
                            }
                            else
                            {
                                brush = brushGrass2;
                            }
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                brush = brushGrass2;
                            }
                            else
                            {
                                brush = brushGrass1;
                            }
                        }
                        if (Cell[i, j].flag == true && Cell[i, j].IsClick == false)
                        {
                        }
                        else
                        {
                            if (Cell[i, j].IsClick == true)
                            {
                                if (Cell[i, j].IsMine == true)
                                {
                                    found = true;
                                }
                                else
                                {
                                    SoilCount++;
                                    if (j % 2 == 0)
                                    {
                                        if (i % 2 == 0)
                                        {
                                            brush = brushSoil1;
                                            pen = new Pen(brushSoil1);
                                        }
                                        else
                                        {
                                            brush = brushSoil2;
                                            pen = new Pen(brushSoil2);
                                        }
                                    }
                                    else
                                    {
                                        if (i % 2 == 0)
                                        {
                                            brush = brushSoil2;
                                            pen = new Pen(brushSoil2);
                                        }
                                        else
                                        {
                                            brush = brushSoil1;
                                            pen = new Pen(brushSoil1);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                pen = new Pen(Brushes.DarkGreen, 2);
                            }
                        }
                        graphics.FillRectangle(brush, Cell[i, j].Rect);
                        graphics.DrawRectangle(pen, Cell[i, j].Rect);
                        if (Cell[i, j].flag == true)
                        {
                            if (Cell[i, j].IsClick == true)
                            { }
                            else
                            {

                                //string workingDirectory = Environment.CurrentDirectory;
                                //Image image = Image.FromFile(workingDirectory + "\\PhotoUsed\\Flag.jpg");
                                Pen pen1 = new Pen(brush, 1);
                                brush = Brushes.SkyBlue;

                                //graphics.DrawImage(image, Cell[i, j].Rect);
                                graphics.FillRectangle(brush, Cell[i, j].Rect);
                                graphics.DrawRectangle(pen1, Cell[i, j].Rect);
                            }
                        }
                        if (iB == 10)
                        {
                            TextX = Cell[i, j].Rect.X + 12;
                            TextY = Cell[i, j].Rect.Y + 12;
                        }
                        else if (iB == 15)
                        {
                            TextX = Cell[i, j].Rect.X + 10;
                            TextY = Cell[i, j].Rect.Y + 8;
                        }
                        else if (iB == 20)
                        {
                            TextX = Cell[i, j].Rect.X + 8;
                            TextY = Cell[i, j].Rect.Y + 6;
                        }
                        if (Cell[i, j].IsClick == true)
                        {
                            if (Cell[i, j].IsMine == true)
                            {
                            }
                            else
                            {
                                int MC = Cell[i, j].MineCounter;
                                if (MC == 0)
                                {

                                }
                                else
                                {
                                    if (MC == 1)
                                    {
                                        brush = Brushes.Blue;
                                    }
                                    else if (MC == 2)
                                    {
                                        brush = Brushes.Green;
                                    }
                                    else if (MC == 3)
                                    {
                                        brush = Brushes.Red;
                                    }
                                    else if (MC == 4)
                                    {
                                        brush = Brushes.Purple;
                                    }
                                    else if (MC == 5)
                                    {
                                        brush = Brushes.DarkRed;
                                    }
                                    else if (MC == 6)
                                    {
                                        brush = Brushes.Black;
                                    }
                                    else if (MC == 7)
                                    {
                                        brush = Brushes.DarkGray;
                                    }
                                    else if (MC == 8)
                                    {
                                        brush = Brushes.DarkCyan;
                                    }
                                    else
                                    {
                                        brush = Brushes.DarkCyan;
                                    }
                                    Font font = new Font("Serif", 12, FontStyle.Bold);
                                    graphics.DrawString(Cell[i, j].MineCounter.ToString(), font, brush, TextX, TextY);
                                }
                            }
                        }
                    }
                }
                Win = false;
                if (SoilCount == All)
                {
                    for (int j = 0; j < Cell.GetLength(1); j++)
                    {
                        for (int i = 0; i < Cell.GetLength(0); i++)
                        {
                            Cell[i, j].flag = false;
                        }
                    }
                    found = true;
                    Win = true;
                    GameOver(graphics, Cell, label1, 0);
                }
            }
            if (Win==false&&found == true && v == 0)
            {
                //string workingDirectory = Environment.CurrentDirectory;
                //workingDirectory += "\\Save Form C#";
                //var Path = workingDirectory + "\\Buffer1.txt";
                //File.WriteAllText(Path, "0");
                GameOver(graphics, Cell, label1, 1);
            }
        }
        private void GameOver(Graphics graphics, Cells[,] cell,
         Label label1, int v)
        {
            MainForm mf = new MainForm();

            GameOverF = true;
            int speed = 0;
            {
                if (found == true)
                {
                    label1.Visible = true;
                    //Thread.Sleep(500);
                    MainForm Mf = new MainForm();
                    int S = cell.GetLength(1);
                    if (S == 10)
                    {
                        speed = 65;
                    }
                    else if (S == 15)
                    {
                        speed = 40;
                    }
                    else if (S == 20)
                    {
                        speed = 20;
                    }
                    else if(S==30)
                    {
                        speed = 7;
                    }
                    for (int j = 0; j < cell.GetLength(1); j++)
                    {
                        for (int i = 0; i < cell.GetLength(0); i++)
                        {
                            if (cell[i, j].IsMine == true)
                            {
                                if (v != 1)
                                {
                                    brushMine = Brushes.LightGreen;
                                    brushMineM = Brushes.DarkGreen;
                                }
                                else
                                {
                                    if (c == 0)
                                    {
                                        brushMine = Brushes.LightPink;
                                        brushMineM = Brushes.DarkRed;
                                        c++;
                                    }
                                    else if (c == 1)
                                    {
                                        brushMine = Brushes.Red;
                                        brushMineM = Brushes.DarkRed;
                                        c++;
                                    }
                                    else if (c == 2)
                                    {
                                        brushMine = Brushes.Orange;
                                        brushMineM = Brushes.OrangeRed;
                                        c++;
                                    }
                                    else if (c == 3)
                                    {
                                        brushMine = Brushes.LightSkyBlue;
                                        brushMineM = Brushes.DarkBlue;
                                        c++;
                                    }
                                    else if (c == 4)
                                    {
                                        brushMine = Brushes.Yellow;
                                        brushMineM = Brushes.DarkGray;
                                        c++;
                                    }
                                    else if (c == 5)
                                    {
                                        brushMine = Brushes.MediumPurple;
                                        brushMineM = Brushes.Purple;
                                        c++;
                                    }
                                    else if (c == 6)
                                    {
                                        brushMine = Brushes.Blue;
                                        brushMineM = Brushes.DarkBlue;
                                        c++;
                                    }
                                    if (c == 6)
                                    {
                                        c = 0;
                                    }
                                }

                                brush = brushMine;
                                Thread.Sleep(speed);
                                graphics.FillRectangle(brush, cell[i, j].Rect);
                                graphics.FillEllipse(brushMineM, cell[i, j].MineRect);
                            }
                        }
                    }
                    Thread.Sleep(1);
                    //Player.Stop();
                    label1.ForeColor = Color.WhiteSmoke;
                    if (v == 1)
                    {
                        //label1.ForeColor = Color.Red;
                        label1.Text = "GameOver!";

                    }
                    if (v == 0)
                    {
                        label1.ForeColor = Color.Green;
                        label1.Text = " You Won!";
                        found = true;
                    }
                    label1.Visible = true;
                }
            }
        }
    }
}