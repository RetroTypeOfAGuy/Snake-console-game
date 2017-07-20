using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class InputConsole:IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public int ReadKey()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            key = Console.ReadKey(true);

            return (int)key.KeyChar;
        }
    }
}