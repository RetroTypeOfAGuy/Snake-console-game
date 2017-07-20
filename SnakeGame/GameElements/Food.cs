using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food:GameElement
    {
        private Position SpawnSpaceMaximum { get; set; }
        private RandomGenerator RND { get; set; }

        public Food(IRenderer renderer, Position position, string color, Position spawn, RandomGenerator rand)
            :base(renderer, position, color)
        {
            this.RND = rand;
            this.SpawnSpaceMaximum = spawn;
        }
       
        public override void Draw()
        {
            this.Renderer.DrawAt(this.Position, this.Color);
        }

        public  void Remove()
        {
            this.Renderer.DrawAt(this.Position, "Black");
        }

        public void RandomPosition()
        {
            this.Position = new Position(RND.GetRandom(1, this.SpawnSpaceMaximum.Y - 2), RND.GetRandom(1, this.SpawnSpaceMaximum.X - 2));
        }
    }
}
