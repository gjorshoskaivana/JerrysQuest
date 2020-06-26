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
        public List<Cheese> cheese;
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public int drawX { get; set; }
        public int drawY { get; set; }
        public DIRECTION direction { get; set; }
        Random rand;

        public Jerry(int x, int y)
        {
            X = x;
            Y = y;
            cheese = new List<Cheese>();
            Speed = 100;
            direction = DIRECTION.None;
            rand = new Random();
            player = Resources.jerry_running_left;
        }

        public void Move()
        {
            if(direction == DIRECTION.Up)
            {
                Y--;
            }
            else if(direction == DIRECTION.Down)
            {
                Y++;
            }
            else if(direction == DIRECTION.Left)
            {
                X--;
                this.player = Resources.jerry_running_left;
            }
            else if(direction == DIRECTION.Right)
            {
                X++;
                this.player = Resources.jerry_running_right;
            }

            for(int i=0; i<cheese.Count; i++)
            {
                if(cheese[i].X == this.X && cheese[i].Y == this.Y)
                {
                    cheese.Remove(cheese[i]);
                    Cheese newCh = newCheese(Game.WORLD_WIDTH, Game.WORLD_HEIGHT);
                    cheese.Add(newCh);
                }
            }
            
        }

        public Cheese newCheese(int width, int height)
        {
            Cheese novo = new Cheese(rand.Next(0, width + 2), rand.Next(0, height + 2));
            if((novo.X == this.X && novo.Y == this.Y) || Game.maze[novo.Y, novo.X] == true)
            {
                novo = newCheese(width, height);
            }
            if(cheese != null)
            {
                foreach(Cheese ch in cheese)
                            {
                                if(ch.X == novo.X && ch.Y == novo.Y)
                                {
                                    novo = newCheese(width, height);
                                    break;
                                }
                            }
            }
            
            return novo;
        }

        public void drawJerry(Graphics g)
        {
            // draw jerry
            g.DrawImage(player, drawX, drawY, player.Width, player.Height);

            //draw cheese
            foreach(Cheese ch in cheese)
            {
                ch.drawCheese(g);
            }
        }
    }
}
