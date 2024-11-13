using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main() 
    {
        int landingGroundLevel = 15;
        int deathGroundLevel = Console.WindowHeight - 2;
        int ceilingLevel = 1;
        int jumpHeight = 3;
        int playerX = 10; 
        int playerY = landingGroundLevel - 1;
        char playerSymbol = 'O';
        bool isJumping = false;
        int jumpProgress = 0;
        Random random = new Random();

        // List to store active spikes on the screen
        List<int> spikes = new List<int>();

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            playerY = landingGroundLevel - 1;
            isJumping = false;
            spikes.Clear();

            // Infinite game loop
            while (true)
            {
                Console.Clear();
                
                // Draw ceiling
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.SetCursorPosition(x, ceilingLevel);
                    Console.Write("-");
                }
                
                // Draw landing ground
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.SetCursorPosition(x, landingGroundLevel);
                    Console.Write("-");
                }
                
                // Draw death ground
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.SetCursorPosition(x, deathGroundLevel);
                    Console.Write("-");
                }
                
                // Draw player
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(playerSymbol);

                // Draw and update spikes
                for (int i = 0; i < spikes.Count; i++)
                {
                    int spikeX = spikes[i];
                    DrawSpike(spikeX, landingGroundLevel - 1);

                    // Check for collision with the player
                    if (spikeX == playerX && playerY == landingGroundLevel - 1)
                    {
                        GameOver();
                        goto Restart;
                    }

                    // Move the spike to the left
                    spikes[i]--;
                }

                // Remove spikes that have gone off the screen
                spikes.RemoveAll(spikeX => spikeX < 0);

                // Randomly add new spikes from the right side
                if (random.Next(0, 10) < 2)
                {
                    spikes.Add(Console.WindowWidth - 1);
                }

                // Handle player jumping
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar && !isJumping)
                    {
                        isJumping = true;
                        jumpProgress = jumpHeight;
                    }
                }
                
                // Jump mechanics
                if (isJumping)
                {
                    if (jumpProgress > 0 && playerY > ceilingLevel + 1)
                    {
                        playerY--;
                        jumpProgress--;
                    }
                    else
                    {
                        isJumping = false;
                    }
                }
                else if (playerY < landingGroundLevel - 1)
                {
                    playerY++;
                }

                Thread.Sleep(100);
            }

        Restart:
            Thread.Sleep(2000);
        }
    }

    static void DrawSpike(int x, int groundLevel)
    {
        // Draw a spike moving horizontally from right to left
        Console.SetCursorPosition(x, groundLevel);
        Console.Write("^");
    }

    static void GameOver()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
        Console.WriteLine("Game Over!");
        Thread.Sleep(2000);
    }
}
