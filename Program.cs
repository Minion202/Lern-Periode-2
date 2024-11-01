using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int emojiX = 5;
        int emojiY = 10;
        string emoji = "\ud83d\ude01";
        int landingGroundLevel = 15;
        int deathGroundLevel = Console.WindowHeight - 2;
        int ceilingLevel = 1;
        bool isJumping = false;
        int jumpHeight = 3;
        int jumpProgress = 0;

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, ceilingLevel);
                Console.Write("-");
            }
            
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, landingGroundLevel);
                Console.Write("-");
            }
            
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, deathGroundLevel);
                Console.Write("-");
            }
            
            Console.SetCursorPosition(emojiX, emojiY);
            Console.Write(emoji);
            
            if (emojiY >= deathGroundLevel)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.WriteLine("Game Over - Fell to Death Ground");
                break;
            }
            
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.A && emojiX > 0)
                {
                    emojiX--;
                }
                else if (key.Key == ConsoleKey.D && emojiX < Console.WindowWidth - 1)
                {
                    emojiX++;
                }
                else if (key.Key == ConsoleKey.Spacebar && !isJumping)
                {
                    isJumping = true;
                    jumpProgress = jumpHeight;
                }
            }
            
            if (isJumping)
            {
                if (jumpProgress > 0 && emojiY > ceilingLevel + 1)
                {
                    emojiY--;
                    jumpProgress--;
                }
                else
                {
                    isJumping = false;
                }
            }
            else if (emojiY < landingGroundLevel - 1)
            {
                emojiY++;
            }
            else if (emojiY < deathGroundLevel && emojiY > landingGroundLevel - 1)
            {
                emojiY++;
            }

            Thread.Sleep(100);
        }
        Console.ReadKey();
    }
}
