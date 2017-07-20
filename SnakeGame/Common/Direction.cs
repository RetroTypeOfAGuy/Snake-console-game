using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Direction
    {
        public string Dir { get; set; }

        public void MoveLeft()
        {
            this.Dir = "left";
        }

        public void MoveRight()
        {
            this.Dir = "right";
        }
        
        public void MoveUp()
        {
            this.Dir = "up";
        }
        
        public void MoveDown()
        {
            this.Dir = "down";
        }
        
        public void Stop()
        {
            this.Dir = "noMove";
        }

        public Position ChangeToPosition(Position pos)
        {
            switch(this.Dir)
            {
                case "left":
                    pos = new Position(pos.Y, pos.X-1);
                    break;
                case "right":
                    pos = new Position(pos.Y, pos.X+1);
                    break;
                case "up":
                    pos = new Position(pos.Y-1, pos.X);
                    break;
                case "down":
                    pos = new Position(pos.Y+1, pos.X);
                    break;
                case "diagonalUpRight":
                    pos = new Position(pos.Y-1, pos.X + 1);
                    break;
                case "diagonalUpLeft":
                    pos = new Position(pos.Y-1, pos.X - 1);
                    break;
                case "diagonalDownRight":
                    pos = new Position(pos.Y + 1, pos.X + 1);
                    break;
                case "diagonalDownLeft":
                    pos = new Position(pos.Y + 1, pos.X - 1);
                    break;
                
            }
                    return pos;
            
        }

        public void IntToDirection(int i)
        {
            switch (i)
            {
                case 87:
                case 119:
                    this.MoveUp();
                    break;

                case 65:
                case 97:
                    this.MoveLeft();
                    break;

                case 68:
                case 100:
                    this.MoveRight();
                    break;

                case 83:
                case 115:
                    MoveDown();
                    break;
            }
        }
    }
}
