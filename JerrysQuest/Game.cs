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
        public static Jerry jerry;
        public static int WORLD_WIDTH = 10;
        public static int WORLD_HEIGHT = 10;
        public static int SIDE = 50;
        public static readonly int STEPS = 3;
        private static Brush brush = new SolidBrush(Color.MidnightBlue);
        public static bool [,] maze;
        public List<Cheese> pom;
        public int scorePom = 0;
        public int removedTrapsPom = 0;
        private int counter=120;

        public Game()
        {
            InitializeComponent();
            Timer GameOverTimer = new Timer();
            ScoreLabel.Text = "Score: 0";
            score = 0;
            rand = new Random();
            gameOver = false;

            newGame(WORLD_HEIGHT, WORLD_WIDTH);
            DoubleBuffered = true;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            GameOverTimer = new Timer();
            GameOverTimer.Tick += new EventHandler(GameOverTimer_Tick);
            GameOverTimer.Interval = 1000;
            GameOverTimer.Start();
            lblTimer.Text = counter.ToString();

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
    
        }

        private void GameTimer_Tick(object sender, EventArgs e) 
        {
            ScoreLabel.Text = "Score: " + jerry.score;

            Invalidate();
            
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

        }

        private void Game_Paint(object sender, PaintEventArgs e) 
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Start(sender, g);
            jerry.drawJerry(g);
        }

        private void GameOverTimer_Tick(object sender, EventArgs e) 
        {
            counter--;
            if (counter <= 0)
            {
                this.Hide();
                GameOver gameOver = new GameOver(jerry.score);
                GameOverTimer.Stop();
                gameOver.Show();
                this.Visible = false;
            }

            if (removedTrapsPom != jerry.removedTraps)
            {
                removedTrapsPom++;
                counter -= 30;
            }
            if (scorePom != jerry.score)
            {
                scorePom++;
                counter += 5;
            }
            lblTimer.Text = counter.ToString();
        }
    }
}
