using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class CursorHighlight
    {
        private int Place { get; set; }

        private int count;

        public CursorHighlight(int c)
        {
            this.count = c;
        }

        public int GetPlace()
        {
            return this.Place;
        }

        public void SetPlace(int plus)
        {
            this.Place += plus;

            if (this.Place > this.count - 1)
            {
                this.Place = this.count - 1;
            }
            if (this.Place < 0 )
            {
                this.Place = 0;
            }
        }
    }
}
