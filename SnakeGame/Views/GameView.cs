using System;
using System.Collections.Generic;

namespace SnakeGame.Views
{
    public class GameView
    {
        public void DrawBoard(List<(int X, int Y)> snake, (int X, int Y) food, int width, int height, int score)
        {
            // Draw top border
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("+" + new string('-', width) + "+");

            // Draw the snake, food, and the empty space
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y + 1); // Move the cursor to the new row
                Console.Write("|"); // Left border

                for (int x = 0; x < width; x++)
                {
                    if (snake[0] == (x, y))
                        Console.Write("@"); // Snake head
                    else if (snake.Contains((x, y)))
                        Console.Write("O"); // Snake body
                    else if (food.X == x && food.Y == y)
                        Console.Write("$"); // Food (dollar sign)
                    else
                        Console.Write(" "); // Empty space
                }

                Console.WriteLine("|"); // Right border
            }

            // Draw bottom border
            Console.SetCursorPosition(0, height + 1);
            Console.WriteLine("+" + new string('-', width) + "+");

            // Show score
            Console.SetCursorPosition(0, height + 2);
            Console.WriteLine($"Score: {score}");
        }

        public void ShowGameOver(int score)
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1); // Move down for better spacing
            Console.WriteLine("\nGame Over!");
            Console.WriteLine($"Final Score: {score}");

            if (score >= 20)
                Console.WriteLine("🏆 Great Score!");
            else if (score >= 10)
                Console.WriteLine("👍 Good Score!");
        }
    }
}
