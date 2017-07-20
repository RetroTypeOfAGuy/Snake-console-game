using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class ConsoleRenderer : IRenderer
    {
        public ConsoleColor Color { get; set; }

        public IDictionary<string, ConsoleColor> Colors { get; set; }

        public ConsoleRenderer()
        {
            Colors = new Dictionary<string, ConsoleColor>();

            Type type = typeof(ConsoleColor);

            foreach (var name in Enum.GetNames(type))
            {
                this.Colors.Add(name, (ConsoleColor)Enum.Parse(type, name));
            }

        }

        private void DetectColor(string color)
        {
            foreach (KeyValuePair<string,ConsoleColor> pair in this.Colors)
            {
                if (pair.Key == color)
                {
                    this.Color = pair.Value;
                    break;
                }
            } 
        }

        public void DrawAt(Position position, string color)
        {
            DetectColor(color);
            Console.SetCursorPosition(position.X, position.Y);
            Console.BackgroundColor = this.Color;            
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
        }


        public void WriteAtWithColor(Position position, string tcolor, string text, string bcolor)
        {
            DetectColor(tcolor);
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = this.Color;
            DetectColor(bcolor);
            Console.BackgroundColor = this.Color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
        }


        public List<string> ListOfColorNames()
        {
            List<string> colors = new List<string>();

            foreach(KeyValuePair<string, ConsoleColor> color in this.Colors)
            {
                colors.Add(color.Key);
            }

            return colors;
        }
    }
}