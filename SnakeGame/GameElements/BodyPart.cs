using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class BodyPart:GameElement
    {
        public BodyPart(IRenderer renderer, Position position, string color):base(renderer, position, color)
        {

        }

        public override void Draw()
        {
            Renderer.DrawAt(this.Position,this.Color);
        }

        public  void Remove()
        {
            Renderer.DrawAt(this.Position, "Black");
        }
    }
}
