using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public interface IInput
    {
        string ReadLine();

        int ReadKey();
    }
}
