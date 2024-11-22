using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        int landingGroundLevel = 15;
        int ceilingLevel = 1;
        int jumpHeight = 3; 
        int playerX = 10;
        int playerY = landingGroundLevel - 1;
        char playerSymbol = 'O';
        bool isJumping = false;
        int jumpProgress = 0;
        Random random = new Random();

        
        List<int> spikes = new List<int>();

        int spikeCooldown = 0;

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            playerY = landingGroundLevel - 1;
            isJumping = false;
            spikes.Clear();
            spikeCooldown = 0;
            
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
                
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(playerSymbol);
                
                for (int i = 0; i < spikes.Count; i++)
                {
                    int spikeX = spikes[i];
                    DrawSpike(spikeX, landingGroundLevel);
                    
                    if (spikeX == playerX && playerY == landingGroundLevel - 1)
                    {
                        GameOver();
                        goto Restart;
                    }
                    
                    spikes[i]--;
                }
                
                spikes.RemoveAll(spikeX => spikeX < 0);
                
                if (spikeCooldown == 0 && random.Next(0, 10) < 2)
                {
                    spikes.Add(Console.WindowWidth - 1);
                    spikeCooldown = 10;
                }
                
                if (spikeCooldown > 0)
                {
                    spikeCooldown--;
                }
                
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar && !isJumping)
                    {
                        isJumping = true;
                        jumpProgress = jumpHeight;
                    }
                }
                
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
  