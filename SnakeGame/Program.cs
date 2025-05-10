using System;
using SnakeGame.Controllers;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GameController(30, 20);
            controller.RunGame();
        }
    }
}
