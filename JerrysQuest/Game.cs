using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JerrysQuest
{
    public partial class Game : Form
    {
        bool up, down, left, right, gameOver;
        int score, speed;

        public Game()
        {
            InitializeComponent();
            ScoreLabel.Text = "Score: 0";
            score = 0;
            gameOver = false;

            Jerry.Left = 8;
            Jerry.Top = 31;
            speed = 8;

            GameTimer.Start();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Random rand = new Random();

            List<Control> pb = new List<Control>();
            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains("pictureBox"))
                {
                    c.Tag = "wall";
                    c.Location = new Point(rand.Next(50, 600), rand.Next(50, 300));
                    pb.Add(c);
                }
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                up = true;

            }
            if (e.KeyCode == Keys.Down)
            {
                down = true;

            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;

            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = false;

            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;

            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;

            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ScoreLabel.Text = "Score: " + score;

            if (left)
            {
                Jerry.Left -= speed;
                Jerry.Image = Properties.Resources.jerry_running_left;
            }
            if (right)
            {
                Jerry.Left += speed;
                Jerry.Image = Properties.Resources.jerry_running_right;
            }
            if (down)
            {
                Jerry.Top += speed;
            }
            if (up)
            {
                Jerry.Top -= speed;
            }


        }

        private void GameOver(string msg)
        {

        }
    }
}
