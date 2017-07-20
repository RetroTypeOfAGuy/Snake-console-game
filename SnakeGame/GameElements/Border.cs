using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Border : GameElement
    {
        public int Height { get; set; }

        public int Wight { get; set; }

        public Position StartPosition { get; set; }

        public Border(IRenderer rend, Position pos, string color)
            : base(rend, pos, color)
        {
            this.Height = this.Position.Y;
            this.Wight = this.Position.X;
            StartPosition = new Position(0,0);
        }

        public Border(IRenderer rend, Position spos, Position pos, string color)
            :base(rend,pos,color)
        {
            this.Height = this.Position.Y;
            this.Wight = this.Position.X;
            StartPosition = spos;
        }
        
        public override void Draw()
        {
            Position DrawPosition;

            for (int col = this.StartPosition.X; col < this.Position.X; col++)
            {
                for (int row = this.StartPosition.Y; row < this.Position.Y; row++)
                {
                    if (row == this.StartPosition.Y || row == this.Position.Y - 1)
                    {
                        DrawPosition = new Position(row, col);
                        this.Renderer.DrawAt(DrawPosition, this.Color);
                    }
                    else if (col == this.Position.X - 1 || col == this.StartPosition.X)
                    {
                        DrawPosition = new Position(row, col);
                        this.Renderer.DrawAt(DrawPosition, this.Color);
                    }
                }
            }
        }
    }
}
