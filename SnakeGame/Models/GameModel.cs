using System;
using System.Collections.Generic;

namespace SnakeGame.Models
{
    public class GameModel
    {
        public List<(int X, int Y)> Snake { get; private set; } = new();
        public (int X, int Y) Food { get; private set; }
        public int BoardWidth { get; }
        public int BoardHeight { get; }
        public char Direction { get; set; } = 'R';
        public bool IsGameOver { get; private set; } = false;
        public int Score { get; private set; } = 0;

        public GameModel(int width, int height)
        {
            BoardWidth = width;
            BoardHeight = height;
            ResetGame();
        }

        public void ResetGame()
        {
            Snake = new List<(int, int)> {
                (BoardWidth / 2, BoardHeight / 2),
                (BoardWidth / 2 - 1, BoardHeight / 2),
                (BoardWidth / 2 - 2, BoardHeight / 2)
            };
            GenerateFood();
            Direction = 'R';
            IsGameOver = false;
            Score = 0;
        }

        public void MoveSnake()
        {
            if (IsGameOver) return;

            var head = Snake[0];
            int newX = head.X;
            int newY = head.Y;

            switch (Direction)
            {
                case 'U': newY--; break;
                case 'D': newY++; break;
                case 'L': newX--; break;
                case 'R': newX++; break;
            }

            // Check for collisions with walls or self
            if (newX < 0 || newY < 0 || newX >= BoardWidth || newY >= BoardHeight || Snake.Contains((newX, newY)))
            {
                IsGameOver = true;
                return;
            }

            Snake.Insert(0, (newX, newY));

            if (newX == Food.X && newY == Food.Y)
            {
                Score++;
                GenerateFood();
            }
            else
            {
                Snake.RemoveAt(Snake.Count - 1);
            }
        }

        private void GenerateFood()
        {
            var rand = new Random();
            do
            {
                Food = (rand.Next(BoardWidth), rand.Next(BoardHeight));
            } while (Snake.Contains(Food));
        }
    }
}
