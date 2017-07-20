using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace SnakeGame
{
    class ConsoleGameEngine : IGameEngine
    {
        private IRenderer Renderer { get; set; }

        private IInput Input { get; set; }

        private RandomGenerator RND { get; set; }

        ScoreXmlHandler ScoreHandler { get; set; }

        public ConsoleGameEngine(IRenderer renderer, IInput input)
        {
            this.Renderer = renderer;
            this.Input = input;
            this.ScoreHandler = new ScoreXmlHandler();
            Console.BufferHeight = Console.LargestWindowHeight-5;
            Console.BufferWidth = Console.LargestWindowWidth-5;
            Console.Title = "Snake by R.A.I.";
            Console.CursorSize = 10;
            Console.CursorVisible = false;
            Console.WindowHeight = Console.BufferHeight;
            Console.WindowWidth = Console.BufferWidth;
            RND = new RandomGenerator();
        } 

        public void StartSceen()
        {
            Border border = new Border(this.Renderer, new Position(Console.WindowHeight / 2 - 5, Console.WindowWidth / 2 - 20),
new Position(Console.WindowHeight / 2 + 4, Console.WindowWidth / 2 + 20), "Green");

            border.Draw();

            List<ColorText> menuOptions = new List<ColorText>();

            ColorText startGame = new ColorText("Start", this.Renderer, "Green", "Red",
                new Position(border.StartPosition.Y + 2, Console.WindowWidth / 2 - 3));

            menuOptions.Add(startGame);

            ColorText highScore = new ColorText("High Scores", this.Renderer, "Green", "Red",
                new Position(border.StartPosition.Y + 4, Console.WindowWidth / 2 - 6));

            menuOptions.Add(highScore);

            ColorText quit = new ColorText("Quit", this.Renderer, "Green", "Red",
                new Position(border.StartPosition.Y + 6, Console.WindowWidth / 2 - 2));

            menuOptions.Add(quit);

            for (int i = 1; i < menuOptions.Count; i++)
            {
                menuOptions[i].Render();
            }

            startGame.Invert();

            CursorHighlight cursor = new CursorHighlight(menuOptions.Count);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Input.ReadKey())
                    {
                        case 87:
                        case 119:
                            cursor.SetPlace(-1);
                            break;

                        case 83:
                        case 115:
                            cursor.SetPlace(1);
                            break;

                        case 13:
                            this.GoToOption(cursor.GetPlace());
                            break;

                        default:
                            break;
                    }

                    for (int i = 0; i < menuOptions.Count; i++)
                    {
                        if (i == cursor.GetPlace())
                        {
                            menuOptions[i].Invert();
                        }
                        else
                        {
                            menuOptions[i].Render();
                        }
                    }
                }
            }
        }

        public void GameStart()
        {
            Random rnd = new Random();

            Renderer.WriteAtWithColor(new Position(Console.WindowHeight / 2, Console.WindowWidth / 2 - 1), "Green", "Choose name : ", "Black");

            Border border = new Border(this.Renderer, new Position(Console.WindowHeight - 15, Console.BufferWidth), "Green");

            Food food = new Food(Renderer, new Position(rnd.Next(1, border.Height - 2), rnd.Next(1, border.Wight - 2)), "Yellow", border.Position, RND);

            Snake snake = new Snake(Renderer, new Position(border.Height / 2, border.Wight / 2), "Blue");

            Player player = new Player(this.Renderer, Input.ReadLine(), "Green", "Black", new Position(border.Height + 1, 1), new Position(border.Height + 3, 1));

            GamePhysics physics = new GamePhysics(this.Renderer, snake, border, food, player , RND);

            Console.Clear();

            border.Draw();

            player.Name.Render();

            bool gameOver = false;

            while (true)
            {
                food.Remove();
                snake.Remove();

                player.TheScore.Render();

                if (Console.KeyAvailable)
                {
                    int temp = this.Input.ReadKey();

                    string tempDir = snake.Direction.Dir;

                    physics.SnakeDirectionCheck(tempDir, temp);
                }

                snake.Move();

                physics.SnakeBordercheck();
                physics.SnakeFoodCheck();

                gameOver = physics.SnakeSnakeBodyCheck();
                if (player.Score > 0 && gameOver == false)
                {
                    gameOver = physics.SnakeTerrainCheck();
                }


                food.Draw();
                snake.Draw();

                if (gameOver == true)
                {
                    ScoreHandler.WriteScores(player.Name.Text, player.Score);
                    GoToOption(5);
                }

                Thread.Sleep(50);
            }
        }

        public void GameOver()
        {
            StringToImageConverter game = new StringToImageConverter(this.Renderer, "Green", "Black", "game", 
                new Position(Console.WindowHeight / 2 - 4, Console.WindowWidth / 2 - 11));

            StringToImageConverter over = new StringToImageConverter(this.Renderer, "Green", "Black", "Over", 
                new Position(Console.WindowHeight / 2 + 4, Console.WindowWidth / 2 - 11));

            game.PrintText(false);
            over.PrintText(false);

            ConsoleKeyInfo key = Console.ReadKey(false);

            if (key.Key == ConsoleKey.Escape)
            {
                GoToOption(4);
            }
            else
            {
                GoToOption(5);
            }
        }

        public void HighScore()
        {
            int i = 2;

            Console.Clear();

            ColorText name = null;

            ColorText score = null;

            List<ScoreData> scores = this.ScoreHandler.GetScores();

            foreach (var item in scores)
	        {
                name = new ColorText("Player : " + item.Name, this.Renderer, "Green", "Black", new Position(i, 3));
                score = new ColorText("Score : " + item.Score, this.Renderer, "Green", "Black", new Position(i, name.Position.X+name.Text.Length + 3));
                i += 2;
                name.Render();
                score.Render();
	        }

            ConsoleKeyInfo key = Console.ReadKey(false);

            if (key.Key == ConsoleKey.Escape)
            {
                GoToOption(4);
            }
            else
            {
                HighScore();
            }
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        private void GoToOption(int to)
        {
            switch (to)
            {
                case 0:
                    Console.Clear();
                    this.GameStart();
                    break;

                case 1:
                    Console.Clear();
                    this.HighScore();
                    break;

                case 5:
                    this.GameOver();
                    break;

                case 4:
                    Console.Clear();
                    StartSceen();
                    break;

                case 2:
                    this.Quit();
                    break;

                default:
                    break;
            }
        }
    }
}