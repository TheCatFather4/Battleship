namespace Battleship.UI.Utilities
{
    public static class Prompter
    {
        public static void AnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static string GetPlacementDirection(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string? direction = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrEmpty(direction))
                {
                    Console.WriteLine("You must select a direction that you would like to place the ship in.");
                }
                else if (direction == "H" || direction == "V")
                {
                    return direction;
                }
                else
                {
                    Console.WriteLine("The direction must be (V)ertical or (H)orizontal.");
                }
            }
            while (true);
        }

        public static string GetPlayerName(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string? name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("You must enter a name to play the game.");
                }
                else
                {
                    return name;
                }
            }
            while (true);
        }

        public static string GetStringCoordinate(string prompt)
        {
            int number;

            do
            {
                Console.Write(prompt);
                string? coord = Console.ReadLine();

                if (string.IsNullOrEmpty(coord))
                {
                    Console.WriteLine("A coordinate is requirerd.");
                }
                else if (Converter.LetterToNumber(coord.Substring(0, 1)) == -1)
                {
                    Console.WriteLine("A coordinate must start with a letter, and can only be A-J.");
                }
                else if (!int.TryParse(coord.Substring(1), out number))
                {
                    Console.WriteLine("A coordinate must end with a number. For example: 1, 2, 3, etc.");
                }
                else if (int.TryParse(coord.Substring(1), out number) && number < 1 || number > 10)
                {
                    Console.WriteLine("A coordinate must end with a number from 1 to 10.");
                }
                else
                {
                    return coord;
                }

            } while (true);
        }
    }
}