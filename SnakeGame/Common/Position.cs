using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }
       
        public Position(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }

        public static bool operator == (Position a, Position b)
        {
            if (a.X == b.X && a.Y == b.Y)
                return true;

            else
                return false;
        }

        public static bool operator !=(Position a, Position b)
        {
            if (a.X == b.X && a.Y == b.Y)
                return false;

            else
                return true;
        }
    }
}
