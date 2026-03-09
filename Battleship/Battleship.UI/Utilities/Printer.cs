using Battleship.UI.DTOs;

namespace Battleship.UI.Utilities
{
    /// <summary>
    /// A class used to print to the console.
    /// </summary>
    public static class Printer
    {
        /// <summary>
        /// Prints a hit message if a fired shot matches.
        /// </summary>
        /// <param name="name"></param>
        public static void PrintHit(string name)
        {
            if (name == "Computer")
            {
                Console.Write("Boom! The Computer player hit something. ");
            }
            else
            {
                Console.Write("Boom! You hit something. ");
            }
        }

        /// <summary>
        /// Prints a miss message if a fired shot misses.
        /// </summary>
        /// <param name="name"></param>
        public static void PrintMiss(string name)
        {
            if (name == "Computer")
            {
                Console.Write("Splash! The Computer player missed. ");
            }
            else
            {
                Console.Write("Splash! You missed. ");
            }
        }

        /// <summary>
        /// Prints the current score of both players.
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="score1"></param>
        /// <param name="name2"></param>
        /// <param name="score2"></param>
        public static void PrintScore(string name1, int score1, string name2, int score2)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine($"| {name1}'s score: {score1} | {name2}'s score: {score2} |");
            Console.WriteLine("========================================================");
        }

        /// <summary>
        /// Prints the details of the current ship to place.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        public static void PrintShipInfo(string name, int size)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"   Name: {name}   |    Size: {size}");
            Console.WriteLine("=============================================");
        }

        /// <summary>
        /// Prints the current ships places on the game board.
        /// </summary>
        /// <param name="ships"></param>
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

        /// <summary>
        /// Prints the shot history and their results on the game board.
        /// </summary>
        /// <param name="shotHistory"></param>
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

        /// <summary>
        /// Prints a sunk message if a shot sunk a ship.
        /// </summary>
        /// <param name="name"></param>
        public static void PrintSunk(string name)
        {
            if (name == "Computer")
            {
                Console.Write("Kaboom! The computer player sunk a ship! ");
            }
            else
            {
                Console.Write("Kaboom! You sunk a ship! ");
            }
        }

        /// <summary>
        /// Prints the title screen of the game.
        /// </summary>
        public static void PrintTitle()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("| Welcome to Battleship! |");
            Console.WriteLine("==========================");
        }
    }
}