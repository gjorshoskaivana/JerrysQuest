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
        public Game()
        {
            InitializeComponent();
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
    }
}
