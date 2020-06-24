using JerrysQuest.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerrysQuest
{
    public enum DIRECTION { Up, Down, Left, Right, None };
    public class Jerry
    {
        public Image player { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public int drawX { get; set; }
        public int drawY { get; set; }
        public DIRECTION direction { get; set; }

        public Jerry(int x, int y)
        {
            X = x;
            Y = y;
            Speed = 100;
            direction = DIRECTION.None;
            player = Resources.jerry_running_left;
        }

        public void Move()
        {
            if(direction == DIRECTION.Up)
            {
                Y--;
                //drawX = X * 5;
                //drawY = Y * 5;
                return;
            }
            if(direction == DIRECTION.Down)
            {
                Y++;
                //drawX = X * 5;
                //drawY = Y * 5;
                return;
            }
            if(direction == DIRECTION.Left)
            {
                X--;
                this.player = Resources.jerry_running_left;
                //drawX = X * 5;
                //drawY = Y * 5;
                return;
            }
            if(direction == DIRECTION.Right)
            {
                X++;
                this.player = Resources.jerry_running_right;
                //drawX = X * 5;
                //drawY = Y * 5;
                return;
            }
        }

        //public Tuple<int, int> GetOffset()
        //{
        //    if (direction == DIRECTION.Right)
        //    {
        //        return new Tuple<int, int>(0, -1);
        //    }
        //    else if (direction == DIRECTION.Left)
        //    {
        //        return new Tuple<int, int>(0, 1);
        //    }
        //    else if (direction == DIRECTION.Up)
        //    {
        //        return new Tuple<int, int>(1, 0);
        //    }
        //    else if (direction == DIRECTION.Down)
        //    {
        //        return new Tuple<int, int>(-1, 0);
        //    }
        //    return new Tuple<int, int>(0, 0);
        //}

        public void drawJerry(Graphics g)
        {
            g.DrawImage(player, drawX, drawY, player.Width, player.Height);
        }
    }
}
