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
        public List<MouseTrap> traps;
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public int drawX { get; set; }
        public int drawY { get; set; }
        public DIRECTION direction { get; set; }
        Random rand;
        public int score;

        public Jerry(int x, int y)
        {
            X = x;
            Y = y;
            score = 0;
            cheese = new List<Cheese>();
            traps = new List<MouseTrap>();
            Speed = 100;
            direction = DIRECTION.None;
            rand = new Random();
            player = Resources.jerry_running_left;
        }

        public void Move()
        {

            //move jerry
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


            // remove collected cheese and add new
            for(int i=0; i<cheese.Count; i++)
            {
                if(cheese[i].X == this.X && cheese[i].Y == this.Y)
                {
                    score++;
                    cheese.Remove(cheese[i]);
                    Cheese newCh = newCheese(Game.WORLD_WIDTH, Game.WORLD_HEIGHT);
                    cheese.Add(newCh);
                }
            }
            

            // add new trap to the maze after 5 collected cheese icons
            if(score % 5 == 0 && score != 0)
            {
                MouseTrap trap = newMouseTrap(Game.WORLD_WIDTH, Game.WORLD_HEIGHT);
                traps.Add(trap);
            }

            // if trap is collected, remove from list
            for(int i=0; i<traps.Count; i++)
            {
                if(traps[i].X == this.X && traps[i].Y == this.Y)
                {
                    traps.Remove(traps[i]);
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
            if (traps != null)
            {
                foreach (MouseTrap trap in traps)
                {
                    if (trap.X == novo.X && trap.Y == novo.Y)
                    {
                        novo = newCheese(width, height);
                        break;
                    }
                }
            }
            if (cheese != null)
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

        public MouseTrap newMouseTrap(int width, int height)
        {
            MouseTrap novo = new MouseTrap(rand.Next(0, width + 2), rand.Next(0, height + 2));
            if(novo.X == this.X && novo.Y == this.Y)
            {
                novo = newMouseTrap(width, height);
            }
            if(Game.maze[novo.Y, novo.X])
            {
                novo = newMouseTrap(width, height);
            }
            if (cheese != null)
            {
                foreach (Cheese ch in cheese)
                {
                    if (ch.X == novo.X && ch.Y == novo.Y)
                    {
                        novo = newMouseTrap(width, height);
                        break;
                    }
                }
            }
            if(traps != null)
            {
                foreach(MouseTrap trap in traps)
                {
                    if(trap.X == novo.X && trap.Y == novo.Y)
                    {
                        novo = newMouseTrap(width, height);
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

            // draw traps
            foreach(MouseTrap trap in traps)
            {
                trap.drawTrap(g);
            }
        }
    }
}
