using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Player
    {
        public int Score { get; set; }

        public ColorText Name { get; set; }

        public ColorText TheScore { get; set; }

        public Player(IRenderer renderer, string name, string tColor, string bColor, Position namepos, Position scorepos)
        {
            this.Score = 0;
            this.TheScore = new ColorText("Score : " + this.Score, renderer, tColor, bColor, scorepos);
            this.Name = new ColorText(name, renderer, tColor, bColor, namepos);
        }

        public void AddScore(int score = 1)
        {
            this.Score = this.Score + score;
            this.TheScore.Text = "Score : " + this.Score;
        }
    }
}