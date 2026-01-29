using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WindowHeight = 16;
        Console.WindowWidth = 32;
        int screenwidth = Console.WindowWidth;
        int screenheight = Console.WindowHeight;
        Random randomnummer = new Random();

        // --- MULTIPLAYER
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\n\tSNAKE ONLINE");
        Console.WriteLine("\tSzukanie serwera...");
        Thread.Sleep(500);
        Console.WriteLine("\tŁączenie z graczem 2...");
        Thread.Sleep(500);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\tBłąd połączenia! Tryb Offline.");
        Thread.Sleep(1000);
        Console.Clear();
        //

        while (true)
        {
            int score = 0;
            string movement = "RIGHT";
            Pixel head = new Pixel();
            head.xPos = screenwidth / 2;
            head.yPos = screenheight / 2;
            head.ScreenColor = ConsoleColor.Red;

            List<int> tailPositions = new List<int>();
            tailPositions.Add(head.xPos);
            tailPositions.Add(head.yPos);

            Obstakel fruit = new Obstakel();
            fruit.Character = "■";
            fruit.ScreenColor = ConsoleColor.Cyan;
            fruit.xPos = randomnummer.Next(1, screenwidth - 2);
            fruit.yPos = randomnummer.Next(1, screenheight - 2);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0); Console.Write("■");
                Console.SetCursorPosition(i, screenheight - 1); Console.Write("■");
            }
            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i); Console.Write("■");
                Console.SetCursorPosition(screenwidth - 1, i); Console.Write("■");
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    switch (info.Key)
                    {
                        case ConsoleKey.UpArrow: if (movement != "DOWN") movement = "UP"; break;
                        case ConsoleKey.DownArrow: if (movement != "UP") movement = "DOWN"; break;
                        case ConsoleKey.LeftArrow: if (movement != "RIGHT") movement = "LEFT"; break;
                        case ConsoleKey.RightArrow: if (movement != "LEFT") movement = "RIGHT"; break;
                    }
                }

                if (movement == "UP") head.yPos--;
                if (movement == "DOWN") head.yPos++;
                if (movement == "LEFT") head.xPos--;
                if (movement == "RIGHT") head.xPos++;

                if (head.xPos == fruit.xPos && head.yPos == fruit.yPos)
                {
                    score++;
                    fruit.xPos = randomnummer.Next(1, screenwidth - 2);
                    fruit.yPos = randomnummer.Next(1, screenheight - 2);
                }
                else
                {
                    if (tailPositions.Count > 0)
                    {
                        Console.SetCursorPosition(tailPositions[tailPositions.Count - 2], tailPositions[tailPositions.Count - 1]);
                        Console.Write(" ");
                        tailPositions.RemoveAt(tailPositions.Count - 1);
                        tailPositions.RemoveAt(tailPositions.Count - 1);
                    }
                }

                tailPositions.Insert(0, head.xPos);
                tailPositions.Insert(1, head.yPos);

                if (head.xPos <= 0 || head.xPos >= screenwidth - 1 || head.yPos <= 0 || head.yPos >= screenheight - 1)
                {
                    break;
                }

                for (int i = 2; i < tailPositions.Count; i += 2)
                {
                    if (head.xPos == tailPositions[i] && head.yPos == tailPositions[i + 1])
                    {
                        goto GameOverLabel;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(2, 0);
                Console.Write($"Score: {score}");

                Console.ForegroundColor = fruit.ScreenColor;
                Console.SetCursorPosition(fruit.xPos, fruit.yPos);
                Console.Write(fruit.Character);

                Console.ForegroundColor = head.ScreenColor;
                Console.SetCursorPosition(head.xPos, head.yPos);
                Console.Write("■");

                Thread.Sleep(100);
            }

        GameOverLabel:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 - 1);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
            Console.WriteLine($"Twój wynik: {score}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 3);
            Console.WriteLine("Jeszcze raz? (Y/N)");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y) break;
                    if (key.Key == ConsoleKey.N) return;
                }
            }
        }
    }
}