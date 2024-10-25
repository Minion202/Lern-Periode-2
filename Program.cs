using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int emojiX = 5;
        int emojiY = 10;
        string emoji = "\ud83d\ude01";
        int groundLevel = emojiY;
        bool isJumping = false;
        int jumpHeight = 3;
        int jumpProgress = 0;

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            Console.SetCursorPosition(emojiX, emojiY);
            Console.Write(emoji);
            
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
                if (jumpProgress > 0)
                {
                    emojiY--; 
                    jumpProgress--;
                }
                else
                {
                    isJumping = false;
                }
            }
            else if (emojiY < groundLevel)
            {
                emojiY++;
            }

            Thread.Sleep(100);
        }
    }
}