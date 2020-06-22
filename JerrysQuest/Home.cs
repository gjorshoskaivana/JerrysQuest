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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game game = new Game();
            game.Show();
            this.Visible = false;
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            HowToPlay howToPlay = new HowToPlay();
            howToPlay.Show();
            this.Visible = false;
        }
    }
}
