using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake:GameElement
    {
        public IList<BodyPart> SnakeBody { get; set; }
       
        private BodyPart Head {get;set;}
        
        private BodyPart Body {get;set;}
        
        private BodyPart Tail { get; set; }

        public Direction Direction { get; set; }

        public Snake(IRenderer renderer, Position position, string color):base(renderer, position, color)
        {
            SnakeBody = new List<BodyPart>();

            this.Head = new BodyPart(this.Renderer, this.Position, "Green");
            this.Body = new BodyPart(this.Renderer, new Position(this.Position.Y, this.Position.X-1), "White");
            this.Tail = new BodyPart(this.Renderer, new Position(this.Position.Y, this.Position.X-2), this.Color);

            SnakeBody.Add(this.Head);
            SnakeBody.Add(this.Body);
            SnakeBody.Add(this.Tail);

            this.Direction = new Direction();

            this.Direction.Dir = "right";
        }

        public override void Draw()
        {
            for (int i = 0; i < SnakeBody.Count; i++)
            {
                SnakeBody[i].Draw();
            }
        }

        public  void Remove()
        {
            for (int i = 0; i < SnakeBody.Count; i++)
            {
                SnakeBody[i].Remove();
            }
        }

        public void Move()
        {
            for (int i = SnakeBody.Count; i > 1; i--)
            {
                this.SnakeBody[i - 1].Position = this.SnakeBody[i - 2].Position;
            }

            this.SnakeBody[0].Position = this.Direction.ChangeToPosition(this.SnakeBody[0].Position);          
        }

        public void Grow()
        {
            this.SnakeBody.Add(new BodyPart(this.Renderer, this.SnakeBody[SnakeBody.Count-1].Position,"White"));

            BodyPart temp = SnakeBody[SnakeBody.Count - 1];

            SnakeBody[SnakeBody.Count - 1] = SnakeBody[SnakeBody.Count - 2];

            SnakeBody[SnakeBody.Count - 2] = temp;
        }
    }
}
