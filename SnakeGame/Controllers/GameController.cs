using System;
using System.Threading;
using SnakeGame.Models;
using SnakeGame.Views;

namespace SnakeGame.Controllers
{
    public class GameController
    {
        private readonly GameModel model;
        private readonly GameView view;

        public GameController(int width, int height)
        {
            model = new GameModel(width, height);
            view = new GameView();
        }

        public void RunGame()
        {
            Console.CursorVisible = false;
            while (!model.IsGameOver)
            {
                HandleInput();
                model.MoveSnake();
                view.DrawBoard(model.Snake, model.Food, model.BoardWidth, model.BoardHeight, model.Score);
                Thread.Sleep(150);
            }

            view.ShowGameOver(model.Score);
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow: if (model.Direction != 'D') model.Direction = 'U'; break;
                    case ConsoleKey.DownArrow: if (model.Direction != 'U') model.Direction = 'D'; break;
                    case ConsoleKey.LeftArrow: if (model.Direction != 'R') model.Direction = 'L'; break;
                    case ConsoleKey.RightArrow: if (model.Direction != 'L') model.Direction = 'R'; break;
                }
            }
        }
    }
}
