using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame

{
    public abstract class GameElement
    {
        public IRenderer Renderer { get; set; }

        public Position Position { get; set; }

        public string Color { get; set; }        

        public GameElement(IRenderer renderer, Position position, string color)
        {
            this.Position = position;
            this.Renderer = renderer;
            this.Color = color;
        }

        public abstract void Draw();
    }
}
