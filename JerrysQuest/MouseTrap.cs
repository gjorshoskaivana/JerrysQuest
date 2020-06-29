using JerrysQuest.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerrysQuest
{
    public class MouseTrap
    {
        public Image img { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public MouseTrap(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.img = Resources.mouse_trap;
        }

        public void drawTrap(Graphics g)
        {
            g.DrawImage(img, X * Game.SIDE, Y * Game.SIDE, img.Width, img.Height);
        }
    }
}
