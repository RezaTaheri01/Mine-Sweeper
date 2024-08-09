using MineSwepper.Draw;
using MineSwepper.MineSwepperCodes;
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

namespace MineSwepper
{
    public partial class MainForm : Form
    {
        CreateBoard CB = new CreateBoard();
        Board B = new Board();
        Game G = new Game();
        int X, Y;
        int s = 0;
        //int k1=0;
        public MainForm()
        {
            InitializeComponent();
            B.Form1 = this;
            G.Form = this;
            Folder();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void MainForm_Paint(object sender, PaintEventArgs e)
        {
            G.Games();
            string workingDirectory = Environment.CurrentDirectory;
            workingDirectory += "\\Save Form C#";
            string[] Lines = File.ReadAllLines(workingDirectory + "\\Buffer1.txt");
            var Path = workingDirectory + "\\Buffer1.txt";
            if (Lines.Length != 0 && Lines[0] == "2")
            { }
            else
            {
                if (Lines.Length == 0)
                { }
                else if (Lines[0] == "1")
                {
                    pauseToolStripMenuItem.Visible = false;
                    File.WriteAllText(Path, "0");
                    DoubleBuffered = false;
                    Refresh();
                }
                workingDirectory = Environment.CurrentDirectory;
                workingDirectory += "\\Save Form C#";
                string[] Lines2 = File.ReadAllLines(workingDirectory + "\\Buffer1.txt");
                if (Lines2.Length != 0 && Lines2[0] == "0")
                {
                    G.Games();
                    if (Lines.Length == 2)
                    {
                        G.Drawing(e.Graphics, label1, timer, 1);
                    }
                    else
                    {
                        G.Drawing(e.Graphics, label1, timer, 0);
                    }
                    if (B.GameOverF == false)
                    {
                        timer.Start();
                    }
                    else
                    {
                        timer.Stop();
                    }
                    if(Lines.Length == 2)
                    {
                        this.Paint -= new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
                    }
                    File.WriteAllText(Path, "2\n9");
                    
                }
                else if(Lines.Length==2)
                {
                    G.Drawing(e.Graphics, label1, timer, 1);
                }
                else
                {
                    G.Games();
                        G.Drawing(e.Graphics, label1, timer, 1);
                    if (B.GameOverF == false)
                    {
                        timer.Start();
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
            }
        }
        public void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            DoubleBuffered = true;
            G.MouseClickAction(e, label1, timer,label2);
        }
        private void Timer(object sender, EventArgs e)
        {
            
            if (s<10)
            {
                label2.Text = " 000" + s;
            }
            else if(s<100)
            {
                label2.Text = " 00" + s;
            }
            else if(s<1000)
            {
                
                label2.Text ="0"+s;
            }
            else
            {
                label2.Text ="" +s;
            }
            if (label1.Visible == false)
            {
                s++;
            }
            if(s==7202)
            {
                Close();
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Visible = true;
            string workingDirectory = Environment.CurrentDirectory;
            workingDirectory += "\\Save Form C#";
            var Path = workingDirectory + "\\Buffer1.txt";
            File.WriteAllText(Path, "");
            DoubleBuffered = true;
            label1.Visible = false;
            G.k = 0;
            s = 0;
            label2.Location = new Point(340, 0);
            label1.Location = new Point(312, 31);
            toolStripMenuItem1.Text = "U-Hard";
            G.BoardWidth = 30;
            G.BoardHeight = 20;
            FormSize();
            Size = new Size(X, Y);
            Invalidate();
            CenterToScreen();
        }
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Visible = true;
            string workingDirectory = Environment.CurrentDirectory;
            workingDirectory += "\\Save Form C#";
            var Path = workingDirectory + "\\Buffer1.txt";
            File.WriteAllText(Path, "");
            DoubleBuffered = true;
            label1.Visible = false;
            G.k = 0;
            s = 0;
            label1.Location = new Point(162, 31);
            label2.Location = new Point(190, 0);
            toolStripMenuItem1.Text = "Medium";
            G.BoardWidth = 15;
            G.BoardHeight = 15;
            FormSize();
            Size = new Size(X, Y);
            CenterToScreen();
            Invalidate();

        }
        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Visible = true;
            string workingDirectory = Environment.CurrentDirectory;
            workingDirectory += "\\Save Form C#";
            var Path = workingDirectory + "\\Buffer1.txt";
            File.WriteAllText(Path, "");
            DoubleBuffered = true;
            label1.Visible = false;
            G.k = 0;
            s = 0;
            label2.Location = new Point(236, 0);
            label1.Location = new Point(209, 31);
            toolStripMenuItem1.Text = "  Hard";
            G.BoardWidth = 20;
            G.BoardHeight = 20;
            FormSize();
            Size = new Size(X, Y);
            CenterToScreen();
            Invalidate();
        }
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Visible = true;
            string workingDirectory = Environment.CurrentDirectory;
            workingDirectory += "\\Save Form C#";
            var Path = workingDirectory + "\\Buffer1.txt";
            File.WriteAllText(Path, "");
            DoubleBuffered = true;
            label1.Visible = false;
            G.k = 0;
            s = 0;
            label2.Location = new Point(142, 0);
            label1.Location = new Point(113, 31);
            toolStripMenuItem1.Text = "  Easy";
            G.BoardWidth = 10;
            G.BoardHeight = 10;
            FormSize();
            Size = new Size(X, Y);
            CenterToScreen();
            Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void FormSize()
        {
            if(G.BoardWidth==10)
            {
                X = G.BoardWidth * 35;
                X += 30;
                Y = G.BoardHeight * 35;
                Y += 105;
            }
            else if (G.BoardWidth == 15)
            {
                X = G.BoardWidth * 30;
                X += 30;
                Y = G.BoardHeight * 30;
                Y += 105;
            }
            else if (G.BoardWidth == 20)
            {
                X = G.BoardWidth * 27;
                X += 30;
                Y = G.BoardHeight * 27;
                Y += 105;
            }
            else if(G.BoardWidth==30)
            {
                X = G.BoardWidth * 25;
                X += 30;
                Y = G.BoardHeight * 25;
                Y += 105;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (B.GameOverF == false)
            {
                if (label1.Visible == true)
                {
                    label1.Text = "";
                    label1.Visible = false;
                    timer.Start();
                    pauseToolStripMenuItem.Text = "Pause";
                }
                else
                {
                    label1.ForeColor = Color.WhiteSmoke;
                    label1.Text = "    Puase";
                    label1.Visible = true;
                    timer.Stop();
                    pauseToolStripMenuItem.Text = "Resume";
                }
                Update();
            }
            else
            {
                pauseToolStripMenuItem.Visible = false;
                Update();
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void Folder()
        {
            string workingDirectory = Environment.CurrentDirectory;
            workingDirectory += "\\Save Form C#";
            if (File.Exists(workingDirectory + "\\Buffer1.txt"))
            { }
            else
            {
                string workingDirectory2 = Environment.CurrentDirectory;
                workingDirectory2 += "\\Save Form C#";
                string dir = workingDirectory2;
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                dir = workingDirectory2 + "\\Buffer1.txt";
                using (FileStream fs = File.Create(dir)) {}
            }
        }
    }
}
