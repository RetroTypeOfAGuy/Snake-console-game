using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Obstacle : GameElement
    {

        public Obstacle(IRenderer rend, Position pos, string color, RandomGenerator random)
            : base(rend, pos, color)
        {
            this.Position = new Position(random.GetRandom(1, pos.Y / 2 - 1 + pos.Y / 2), random.GetRandom(1,pos.X / 2 - 1 + pos.X / 2));
        }
        public override void Draw()
        {
            this.Renderer.DrawAt(this.Position, this.Color);
        }
    }
}
