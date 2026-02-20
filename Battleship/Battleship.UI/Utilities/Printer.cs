using Battleship.UI.DTOs;

namespace Battleship.UI.Utilities
{
    public static class Printer
    {
        public static void PrintHit(string name)
        {
            if (name == "Computer")
            {
                Console.WriteLine("Boom! The Computer player hit something.");
            }
            else
            {
                Console.WriteLine("Boom! You hit something.");
            }
        }

        public static void PrintMiss(string name)
        {
            if (name == "Computer")
            {
                Console.WriteLine("Splash! The Computer player missed.");
            }
            else
            {
                Console.WriteLine("Splash! You missed.");
            }
        }

        public static void PrintScore(string name1, int score1, string name2, int score2)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine($"| {name1}'s score: {score1} | {name2}'s score: {score2} |");
            Console.WriteLine("========================================================");
        }

        public static void PrintShipInfo(string name, int size)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"   Name: {name}   |    Size: {size}");
            Console.WriteLine("=============================================");
        }

        public static void PrintShipsOnBoard(Ship[] ships)
        {
            string[] elements = new string[100];

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = "o";
            }

            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i] != null)
                {
                    for (int j = 0; j < ships[i]?.Coordinates?.Length; j++)
                    {
                        int e = Converter.CoordinateToElement(ships[i].Coordinates[j]);
                        elements[e] = ships[i].Name.Substring(0, 1).ToUpper();
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10|");
            Console.WriteLine("---------------------------------------------");
            Console.Write("| A |");

            int cell = 0;

            string letters = "ABCDEFGHIJ";
            int index = 1;

            for (int i = 0; i < elements.Length; i++)
            {
                if (cell == 10)
                {
                    Console.WriteLine("\n---------------------------------------------");
                    Console.Write($"| {letters.Substring(index, 1)} |");
                    index++;

                    if (elements[i] != "o")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($" {elements[i]} ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write($" {elements[i]} |");
                    }

                    cell = 1;
                }
                else
                {
                    if (elements[i] != "o")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($" {elements[i]} ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write($" {elements[i]} |");
                    }

                    cell++;
                }
            }

            Console.WriteLine("\n---------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintShotHistory(ShotHistoryCoordinate[] shotHistory)
        {
            string[] elements = new string[100];

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = "o";
            }

            for (int j = 0; j < shotHistory.Length; j++)
            {
                if (shotHistory[j] != null)
                {
                    elements[j] = shotHistory[j].ShotResult;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10|");
            Console.WriteLine("---------------------------------------------");
            Console.Write("| A |");

            int cell = 0;

            string letters = "ABCDEFGHIJ";
            int index = 1;

            for (int i = 0; i < elements.Length; i++)
            {
                if (cell == 10)
                {
                    Console.WriteLine("\n---------------------------------------------");
                    Console.Write($"| {letters.Substring(index, 1)} |");
                    index++;

                    if (elements[i] == "H")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {elements[i]} ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    else if (elements[i] == "M")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" {elements[i]} ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write($" {elements[i]} |");
                    }

                    cell = 1;
                }
                else
                {
                    if (elements[i] == "H")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {elements[i]} ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    else if (elements[i] == "M")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" {elements[i]} ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write($" {elements[i]} |");
                    }

                    cell++;
                }
            }

            Console.WriteLine("\n---------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintSunk(string name)
        {
            if (name == "Computer")
            {
                Console.WriteLine("Kaboom! The computer player sunk a ship!");
            }
            else
            {
                Console.WriteLine("Kaboom! You sunk a ship!");
            }
        }

        public static void PrintTitle()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("| Welcome to Battleship! |");
            Console.WriteLine("==========================");
        }
    }
}