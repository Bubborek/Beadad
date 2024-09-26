using System;
using System.Collections.Generic;

class Program
{
    static List<(int x, int y, char character, ConsoleColor color)> blocks = new List<(int x, int y, char character, ConsoleColor color)>();
    static ConsoleColor currentColor = ConsoleColor.White;
    static char currentCharacter = '█';

    static void Main()
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        DrawFrame(width, height);
        int x = width / 2;
        int y = height / 2;
        Console.CursorVisible = true;
        DrawCursor(x, y);
        bool exit = false;

        while (!exit)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (!IsBlockAtPosition(x, y))
                {
                    ClearCursor(x, y);
                }
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.W:
                        if (y > 2) y--; 
                        break;
                    case ConsoleKey.S:
                        if (y < height - 2) y++;
                        break;
                    case ConsoleKey.A:
                        if (x > 1) x--;
                        break;
                    case ConsoleKey.D:
                        if (x < width - 2) x++;
                        break;
                    case ConsoleKey.Spacebar:
                        PlaceBlock(x, y);
                        break;
                    case ConsoleKey.D0:
                        currentColor = ConsoleColor.Red;
                        break;
                    case ConsoleKey.D1:
                        currentColor = ConsoleColor.Blue;
                        break;
                    case ConsoleKey.D2:
                        currentColor = ConsoleColor.Yellow;
                        break;
                    case ConsoleKey.D3:
                        currentColor = ConsoleColor.DarkGray;
                        break;
                    case ConsoleKey.D4:
                        currentColor = ConsoleColor.Magenta;
                        break;
                    case ConsoleKey.D5:
                        currentColor = ConsoleColor.DarkGreen;
                        break;
                    case ConsoleKey.D6:
                        currentColor = ConsoleColor.Cyan;
                        break;
                    case ConsoleKey.D7:
                        currentColor = ConsoleColor.DarkMagenta;
                        break;
                    case ConsoleKey.D8:
                        currentColor = ConsoleColor.White;
                        break;
                    case ConsoleKey.D9:
                        currentColor = ConsoleColor.Black;
                        break;
                    case ConsoleKey.Y:
                        currentCharacter = '░';
                        break;
                    case ConsoleKey.X:
                        currentCharacter = '▒';
                        break;
                    case ConsoleKey.C:
                        currentCharacter = '▓';
                        break;
                    case ConsoleKey.V:
                        currentCharacter = '█';
                        break;
                       
                }                            
                DisplayCurrentSelection();
            }
        }
    }

    static void DrawFrame(int width, int height)
    {
        Console.SetCursorPosition(0, 1); 
        Console.Write("╔");
        for (int i = 1; i < width - 1; i++)
        {
            Console.Write("═");
        }
        Console.Write("╗");

        for (int i = 2; i < height - 1; i++) 
        {
            Console.SetCursorPosition(0, i);
            Console.Write("║");
            Console.SetCursorPosition(width - 1, i);
            Console.Write("║");
        }

        Console.SetCursorPosition(0, height - 1);
        Console.Write("╚");
        for (int i = 1; i < width - 1; i++)
        {
            Console.Write("═");
        }
        Console.SetCursorPosition(width - 1, height - 1);
        Console.Write("╝");
    }

    static void DrawCursor(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = currentColor;
        Console.Write(currentCharacter);
        Console.ResetColor();
    }

    static void ClearCursor(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    static void PlaceBlock(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = currentColor;
        Console.Write(currentCharacter);
        Console.ResetColor();
        blocks.Add((x, y, currentCharacter, currentColor));
    }

    static bool IsBlockAtPosition(int x, int y)
    {
        return blocks.Exists(block => block.x == x && block.y == y);
    }

    static void DisplayCurrentSelection()
    {
        Console.SetCursorPosition(2, 0);
        Console.Write("Character: ");
        Console.Write(currentCharacter); 
        Console.Write(" Color: ");
        Console.ForegroundColor = currentColor; 
        Console.Write("█"); 
        Console.ResetColor();
    }
}
