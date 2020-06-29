using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JerrysQuest
{
    public partial class Game : Form
    {
        bool gameOver;
        int score;
        Random rand;
        //Graphics graphics;
        //Bitmap buffer;
        //char[][] labrynth;
        public static Jerry jerry;
        public static int WORLD_WIDTH = 10;
        public static int WORLD_HEIGHT = 10;
        public static int SIDE = 50;
        public static readonly int STEPS = 3;
        private static Brush brush = new SolidBrush(Color.MidnightBlue);
        public static bool [,] maze;
        public List<Cheese> pom;

        public Game()
        {
            InitializeComponent();
            ScoreLabel.Text = "Score: 0";
            score = 0;
            rand = new Random();
            gameOver = false;

            newGame(WORLD_HEIGHT, WORLD_WIDTH);
            DoubleBuffered = true;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //Random rand = new Random();

            //List<Control> pb = new List<Control>();
            //foreach (Control c in this.Controls)
            //{
            //    if (c.Name.Contains("pictureBox"))
            //    {
            //        c.Tag = "wall";
            //        c.Location = new Point(rand.Next(50, 600), rand.Next(50, 300));
            //        pb.Add(c);
            //    }
            //}
            //newGame(WORLD_HEIGHT, WORLD_WIDTH);
            pom = new List<Cheese>(5);
            for (int i = 0; i < 5; i++)
            {
                Cheese newCh = jerry.newCheese(WORLD_WIDTH, WORLD_HEIGHT);
                pom.Add(newCh);
            }
            jerry.cheese = pom;

        }

        public void newGame(int height, int width)
        {
            jerry = new Jerry(height, 1);
            jerry.cheese = pom;

            GameTimer.Start();
            GameTimer.Interval = jerry.Speed;

            MazeGenerator mz = new MazeGenerator(WORLD_HEIGHT, WORLD_WIDTH);
            maze = mz.generate();
            mz = null;

            this.Width = 600 + 16;
            this.Height = 600 + 42;
            SIDE = 600 / Math.Max(WORLD_WIDTH + 2, WORLD_HEIGHT + 2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //Invalidate();
        }

        

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Up && Jerry.Location.X > 0) 
            //{
            //    if(!maze[Jerry.Location.X - 1, Jerry.Location.Y])
            //        up = true;

            //}
            //if (e.KeyCode == Keys.Down && Jerry.Location.X < 9)
            //{
            //    if(!maze[Jerry.Location.X + 1, Jerry.Location.Y])
            //        down = true;

            //}
            //if (e.KeyCode == Keys.Left && Jerry.Location.Y > 0)
            //{
            //    if(!maze[Jerry.Location.X, Jerry.Location.Y - 1])
            //        left = true;

            //}
            //if (e.KeyCode == Keys.Right && Jerry.Location.Y < 9)
            //{
            //    if(!maze[Jerry.Location.X, Jerry.Location.Y + 1])
            //        right = true;

            //}

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if(maze[jerry.Y, jerry.X - 1])
                    {
                        jerry.direction = DIRECTION.None;
                    }
                    else jerry.direction = DIRECTION.Left;
                    jerry.Move();
                    break;
                case Keys.Right:
                    if (maze[jerry.Y, jerry.X + 1])
                    {
                        jerry.direction = DIRECTION.None;
                    }
                    else jerry.direction = DIRECTION.Right;
                    jerry.Move();
                    break;
                case Keys.Up:
                    if (maze[jerry.Y - 1, jerry.X])
                    {
                        jerry.direction = DIRECTION.None;
                    }
                    else jerry.direction = DIRECTION.Up;
                    jerry.Move();
                    break;
                case Keys.Down:
                    if (maze[jerry.Y + 1, jerry.X])
                    {
                        jerry.direction = DIRECTION.None;
                    }
                    else jerry.direction = DIRECTION.Down;
                    jerry.Move();
                    break;
            }
        }



        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    up = false;

            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    down = false;

            //}
            //if (e.KeyCode == Keys.Left)
            //{
            //    left = false;

            //}
            //if (e.KeyCode == Keys.Right)
            //{
            //    right = false;

            //}
            
            
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ScoreLabel.Text = "Score: " + jerry.score;

            Invalidate();

            //if (left)
            //{
            //    Jerry.Left -= speed;
            //    Jerry.Image = Properties.Resources.jerry_running_left;
            //}
            //if (right)
            //{

            //    Jerry.Left += speed;
            //    Jerry.Image = Properties.Resources.jerry_running_right;
            //}
            //if (down)
            //{
            //    Jerry.Top += speed;
            //}
            //if (up)
            //{
            //    Jerry.Top -= speed;
            //}
            
        }

        private void GameOver(string msg)
        {

        }

        private void Start(object sender, Graphics g)
        {
            jerry.drawX = jerry.X * SIDE;
            jerry.drawY = jerry.Y * SIDE;
            
            for (int i = 0; i < WORLD_HEIGHT + 2; i++)
            {
                for (int j = 0; j < WORLD_WIDTH + 2; j++)
                {
                    if (maze[i,j])
                    {
                        g.FillRectangle(brush, j * SIDE, i * SIDE, SIDE, SIDE);
                    }
                }
            }


            //int n = 0;
            //while(n < numCheese)
            //{
            //    bool foodThere = false;
            //    //Cheese newCheese = new Cheese(rand.Next(0, WORLD_WIDTH + 1), rand.Next(0, WORLD_HEIGHT + 1));
            //    int x = rand.Next(0, WORLD_WIDTH + 1);
            //    int y = rand.Next(0, WORLD_HEIGHT + 1);
            //    if (!maze[x, y])
            //    {
            //        for(int i=0; i<cheese.Count; i++)
            //        {
            //            if(cheese[i].X == x && cheese[i].Y == y)
            //            {
            //                foodThere = true;
            //                break;
            //            }
            //        }

            //        if (foodThere == false)
            //        {
            //            cheese.Add(new Cheese(x, y));
            //            n++;
            //        }
            //    }

            //}

        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Start(sender, g);
            jerry.drawJerry(g);
        }

    }
}
