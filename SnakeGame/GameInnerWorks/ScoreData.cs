using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct ScoreData
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public ScoreData(int score, string name)
            :this()
        {
            this.Name = name;
            this.Score = score;
        }

        public static ScoreData operator > (ScoreData a, ScoreData b)
        {
            if (a.Score > b.Score)
	        {
		        return a;
	        }
            else
	        {
                return b;
	        }
        }
        public static ScoreData operator < (ScoreData a, ScoreData b)
        {
            if (b.Score > a.Score)
            {
                return b;
            }
            else
            {
                return a;
            }
        }

        public static bool operator == (ScoreData a, ScoreData b)
        {
            if (a.Score == b.Score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator != (ScoreData a, ScoreData b)
        {
            if (a.Score != b.Score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
