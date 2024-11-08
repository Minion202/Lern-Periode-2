using System;
using System.Threading;

namespace Erdbeerschoggi
{
    internal class Program
    {
        static char[,] maze = {
           { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { 'S', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', '#', '#', '#', ' ', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'E', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        static int playerX = 0; 
        static int playerY = 1; 
        static string playerSymbol = "O";

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                DrawMaze();

                
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(playerSymbol);
                
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    
                    int newX = playerX;
                    int newY = playerY;

                    
                    if (key.Key == ConsoleKey.W) newY--;         
                    else if (key.Key == ConsoleKey.S) newY++;    
                    else if (key.Key == ConsoleKey.A) newX--;    
                    else if (key.Key == ConsoleKey.D) newX++;    

                  
                    if (newX >= 0 && newX < maze.GetLength(1) && newY >= 0 && newY < maze.GetLength(0) &&
                        (maze[newY, newX] == ' ' || maze[newY, newX] == 'S' || maze[newY, newX] == 'E'))
                    {
                        playerX = newX;
                        playerY = newY;
                    }
                }

                Thread.Sleep(75);
            }
        }

        static void DrawMaze()
        {
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    Console.Write(maze[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
