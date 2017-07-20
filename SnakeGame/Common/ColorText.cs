using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class ColorText
    {
        public string Text { get; set; }

        private IRenderer Renderer { get; set; }

        private string TextColor { get; set; }

        private string BackGColor { get; set; }

        public Position Position { get; set; }

        public ColorText(string text, IRenderer renderer, string tColor, string bColor, Position position)
        {
            this.Text = text;
            this.Renderer = renderer;
            this.BackGColor = bColor;
            this.TextColor = tColor;
            this.Position = position;
        }

        public Position GetPosition()
        {
            return this.Position;
        }

        public void Render()
        {
            this.Renderer.WriteAtWithColor(this.Position, this.TextColor, this.Text, this.BackGColor);
        }

        public void Invert()
        {
            this.Renderer.WriteAtWithColor(this.Position, "Black", this.Text, this.TextColor);
        }
    }
}