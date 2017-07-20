using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public interface IRenderer
    {
        void DrawAt(Position position, string color);

        void WriteAtWithColor(Position position, string tcolor, string text, string bcolor);

        List<string> ListOfColorNames();
    }
}
