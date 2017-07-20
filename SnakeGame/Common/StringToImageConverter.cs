using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class StringToImageConverter
    {
        private string Text { get; set; }

        private string FColor { get; set; }

        private string BColor { get; set; }

        public Dictionary<char, Grid> Conversion { get; set; }

        IRenderer Renderer { get; set; }

        public Position Position { get; set; }

        public StringToImageConverter(IRenderer rend, string fcolor, string bcolor, string text, Position pos)
        {
            this.Renderer = rend;
            this.Text = text;
            this.FColor = fcolor;
            this.BColor = bcolor;
            this.Position = pos;

            this.Conversion = new Dictionary<char, Grid>();

            this.FillDictionary();
        }

        private void FillDictionary()
        {
            int[] arr;

            //add 'a' to 'z'
            this.Conversion.Add('a', new Grid(arr = new int[] { 2, 3, 5, 8, 9, 10, 11, 12, 13, 16, 17, 20 }, 5, 4));
            this.Conversion.Add('b', new Grid(arr = new int[] { 1, 2, 3, 5, 8, 9, 10, 11, 13, 16, 17, 18, 19 }, 5, 4));
            this.Conversion.Add('c', new Grid(arr = new int[] { 2, 3, 4, 5, 9, 13, 18, 19, 20 }, 5, 4));
            this.Conversion.Add('d', new Grid(arr = new int[] { 1, 2, 3, 5, 8, 9, 12, 13, 16, 17, 18, 19 }, 5, 4));
            this.Conversion.Add('e', new Grid(arr = new int[] { 1, 2, 3, 4, 5, 9, 10, 11, 13, 17, 18, 19, 20 }, 5, 4));
            this.Conversion.Add('f', new Grid(arr = new int[] { 1, 2, 3, 4, 5, 9, 10, 11, 13, 17 }, 5, 4));
            this.Conversion.Add('g', new Grid(arr = new int[] { 2, 3, 4, 5, 9, 11, 12, 13, 16, 18, 19, 20 }, 5, 4));
            this.Conversion.Add('h', new Grid(arr = new int[] { 1, 4, 5, 8, 9, 10, 11, 12, 13, 16, 17, 20 }, 5, 4));
            this.Conversion.Add('i', new Grid(arr = new int[] { 3, 7, 11, 15, 19 }, 5, 4));
            this.Conversion.Add('j', new Grid(arr = new int[] { 4, 8, 12, 13, 16, 18, 19 }, 5, 4));
            this.Conversion.Add('k', new Grid(arr = new int[] { 1, 4, 5, 7, 9, 10, 13, 15, 17, 20 }, 5, 4));
            this.Conversion.Add('l', new Grid(arr = new int[] { 1, 5, 9, 13, 17, 18, 19 }, 5, 4));
            this.Conversion.Add('m', new Grid(arr = new int[] { 1, 4, 5, 6, 7, 8, 9, 12, 13, 16, 17, 20 }, 5, 4));
            this.Conversion.Add('n', new Grid(arr = new int[] { 1, 4, 5, 8, 9, 10, 12, 13, 15, 16, 17, 20 }, 5, 4));
            this.Conversion.Add('o', new Grid(arr = new int[] { 2, 3, 5, 8, 9, 12, 13, 16, 18, 19 }, 5, 4));
            this.Conversion.Add('p', new Grid(arr = new int[] { 1, 2, 3, 5, 8, 9, 10, 11, 13, 17 }, 5, 4));
            this.Conversion.Add('q', new Grid(arr = new int[] { 2, 3, 5, 8, 9, 12, 13, 15, 16, 18, 19, 20 }, 5, 4));
            this.Conversion.Add('r', new Grid(arr = new int[] { 1, 2, 3, 5, 8, 9, 10, 11, 13, 15, 17, 20 }, 5, 4));
            this.Conversion.Add('s', new Grid(arr = new int[] { 2, 3, 4, 5, 10, 11, 16, 17, 18, 19 }, 5, 4));
            this.Conversion.Add('t', new Grid(arr = new int[] { 1, 2, 3, 6, 10, 14, 18 }, 5, 4));
            this.Conversion.Add('u', new Grid(arr = new int[] { 1, 4, 5, 8, 9, 12, 13, 16, 17, 18, 19, 20 }, 5, 4));
            this.Conversion.Add('v', new Grid(arr = new int[] { 1, 4, 5, 8, 9, 12, 13, 16, 18, 19 }, 5, 4));
            this.Conversion.Add('w', new Grid(arr = new int[] { 1, 4, 5, 8, 9, 12, 13, 14, 15, 16, 18, 19 }, 5, 4));
            this.Conversion.Add('x', new Grid(arr = new int[] { 1, 4, 5, 8, 10, 11, 14, 15, 17, 20 }, 5, 4));
            this.Conversion.Add('y', new Grid(arr = new int[] { 1, 4, 5, 8, 9, 10, 11, 12, 14, 15, 18, 19 }, 5, 4));
            this.Conversion.Add('z', new Grid(arr = new int[] { 1, 2, 3, 4, 8, 11, 14, 17, 18, 19, 20 }, 5, 4));
            this.Conversion.Add(' ', new Grid(arr = new int[] { }, 5, 4));

        }

        public void DrawChar(char c, Position pos)
        {
            Grid tempGrid;
            if ((int)c < 96)
            {
                c = (char)((int)c + 32);
            }
            tempGrid = this.Conversion[(char)c];

            for (int i = 0; i < tempGrid.GetLenght(0); i++)
            {
                for (int j = 0; j < tempGrid.GetLenght(1); j++)
                {
                    if (tempGrid.Matrix[i, j] == true)
                    {
                        this.Renderer.DrawAt(new Position(i + pos.Y, j + pos.X), this.FColor);
                    }
                    else
                    {
                        this.Renderer.DrawAt(new Position(i + pos.Y, j + pos.X), this.BColor);
                    }
                }
            }
        }

        public void InvertDrawChar(char c, Position pos)
        {
            Grid tempGrid;

            if ((int)c < 96)
            {
                c = (char)((int)c + 32);
            }

            tempGrid = this.Conversion[(char)c];

            for (int i = 0; i < tempGrid.GetLenght(0); i++)
            {
                for (int j = 0; j < tempGrid.GetLenght(1); j++)
                {
                    if (tempGrid.Matrix[i, j] == true)
                    {
                        this.Renderer.DrawAt(new Position(i + pos.Y + 1, j + pos.X + 1), this.BColor);
                    }
                    else
                    {
                        this.Renderer.DrawAt(new Position(i + pos.Y + 1, j + pos.X + 1), this.FColor);
                    }
                }
            }
        }

        public void PrintText(bool test)
        {
            char[] c = this.Text.ToCharArray();

            if (test == true)
            {
                this.Border(test);

                for (int i = 0; i < c.Length; i++)
                {
                    this.DrawChar(c[i], new Position(this.Position.Y, this.Position.X + i * 5));
                }
            }
            else
            {
                Border(test);

                for (int i = 0; i < c.Length; i++)
                {
                    this.InvertDrawChar(c[i], new Position(this.Position.Y, this.Position.X + i * 5));
                }
            }
        }

        private void Border(bool test)
        {
            int row, col;

            char[] c = this.Text.ToCharArray();

            row = 7;

            col = c.Length * 5 + 1;

            if (test == false)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        this.Renderer.DrawAt(new Position(this.Position.Y + i, this.Position.X + j), this.FColor);
                    }
                }
            }
            else
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        this.Renderer.DrawAt(new Position(this.Position.Y + i, this.Position.X + j), this.BColor);
                    }
                }
            }
        }

    }

    class Grid
    {
        public bool[,] Matrix { get; set; }

        public Grid(int[] arr, int r, int c)
        {
            this.Matrix = new bool[r, c];

            for (int k = 0; k < arr.Length; k++)
            {
                int count = 0;

                for (int i = 0; i < this.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < this.Matrix.GetLength(1); j++)
                    {
                        count++;

                        if (arr[k] == count)
                        {
                            this.Matrix[i, j] = true;
                        }
                    }
                }
            }
        }

        public int GetLenght(int i)
        {
            if (i == 0)
            {
                return this.Matrix.GetLength(0);
            }
            else
            {
                return this.Matrix.GetLength(1);
            }
        }
    }
}
