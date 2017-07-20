using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public  class GamePhysics
    {
        List<Obstacle> Terrain { get; set; }

        private Snake Snake { get; set; }

        private Food Food { get; set; }

        private Border Border { get; set; }

        private Player Player { get; set; }

        private IRenderer Renderer { get; set; }

        private RandomGenerator RND { get; set; }

        public GamePhysics(IRenderer renderer, Snake snake, Border border, Food food, Player player, RandomGenerator rnd)
        {
            this.RND = rnd;
            this.Snake = snake;
            this.Food = food;
            this.Border = border;
            this.Player = player;
            this.Renderer = renderer;
            Terrain = new List<Obstacle>();
        }

        public void SnakeBordercheck()
        {
            if (Snake.SnakeBody[0].Position.Y == Border.Height - 1)
                Snake.SnakeBody[0].Position.Y = 1;
            
            if (Snake.SnakeBody[0].Position.Y == 0)
                Snake.SnakeBody[0].Position.Y = Border.Height - 2;

            if (Snake.SnakeBody[0].Position.X == Border.Wight-1)
                Snake.SnakeBody[0].Position.X = 1;

            if (Snake.SnakeBody[0].Position.X == 0)
                Snake.SnakeBody[0].Position.X = Border.Wight-2;
        }

        public void SnakeFoodCheck()
        {
            if (Snake.SnakeBody[0].Position == Food.Position)
            {
                this.Food.RandomPosition();

                this.FoodTerrainCheck();
                
                this.Snake.Grow();
                Player.AddScore(10);

                Terrain.Add(new Obstacle(this.Renderer, this.Border.Position, "Red", this.RND));

                foreach (var  item in Terrain)
                {
                    item.Draw();
                }
            }
        }

        public bool SnakeSnakeBodyCheck()
        {
            for (int i = 1; i < Snake.SnakeBody.Count; i++)
            {
                if (Snake.SnakeBody[0].Position == Snake.SnakeBody[i].Position)
                {
                    this.Snake.Direction.Stop();
                    return true;
                }
            }
            return false;
        }

        public void SnakeDirectionCheck(string tempDir, int key)
        {
            this.Snake.Direction.IntToDirection(key);

            if (tempDir == "right" && this.Snake.Direction.Dir == "left")
            {
                this.Snake.Direction.Dir = tempDir;
            }

            if (tempDir == "left" && this.Snake.Direction.Dir == "right")
            {
                this.Snake.Direction.Dir = tempDir;
            }

            if (tempDir == "up" && this.Snake.Direction.Dir == "down")
            {
                this.Snake.Direction.Dir = tempDir;
            }

            if (tempDir == "down" && this.Snake.Direction.Dir == "up")
            {
                this.Snake.Direction.Dir = tempDir;
            }
        }

        public bool SnakeTerrainCheck()
        {
            for (int i = 0; i < Terrain.Count; i++)
            {
                if (Terrain[i].Position == this.Snake.SnakeBody[0].Position)
                {
                    return true;
                }
            }
            return false;
        }

        public void FoodTerrainCheck()
        {
            foreach (var item in Terrain)
            {
                if (item.Position == Food.Position)
                {
                    this.Food.Remove();
                    this.Food.RandomPosition();
                }
            }
        }

        public void TerrainTerrainCheck()
        {

        }
    }
}