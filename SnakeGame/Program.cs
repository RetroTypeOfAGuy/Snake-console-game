using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Program
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            
            IInput input = new InputConsole();
            
            IGameEngine engine = new ConsoleGameEngine(renderer,input);

             engine.StartSceen();
        }
    }
}
