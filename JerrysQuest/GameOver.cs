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
    public partial class GameOver : Form
    {
        public int score;
        public GameOver(int score)
        {
            this.score = score;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game game = new Game();
            game.Show();
            this.Visible = false;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;
        }
    }
}
