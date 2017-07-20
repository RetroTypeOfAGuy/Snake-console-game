using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class RandomGenerator
    {
        private Random rand;
        
        public RandomGenerator()
        {
            rand = new Random();
        }

        public int GetRandom(int first = 0, int last = int.MaxValue)
        {
            return rand.Next(first,last);
        }
    }
}
