using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    interface IGameEngine
    {
        void StartSceen();

        void GameStart();

        void GameOver();
    }
}
