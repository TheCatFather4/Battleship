using Battleship.UI.Enums;
using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;

namespace Battleship.UI.Factories
{
    /// <summary>
    /// A factory class for creating a new player.
    /// </summary>
    public class PlayerFactory
    {
        /// <summary>
        /// Creates a new player depending on user input.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>An implementation of the IPlayer interface.</returns>
        public IPlayer CreateNewPlayer(int num)
        {
            PlayerType playerType;

            do
            {
                Console.Write($"Is Player {num} a (H)uman or a (C)omputer?: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("This field is required.");
                }
                else if (input == "H")
                {
                    string name = Prompter.GetPlayerName($"Player {num}, please enter your name: ");
                    playerType = PlayerType.Human;
                    return new HumanPlayer(name, playerType);
                }
                else if (input == "C")
                {
                    string mode = Prompter.GetDifficultyMode();
                    if (mode == "E")
                    {
                        playerType = PlayerType.Computer;
                    }
                    else if (mode == "N")
                    {
                        playerType = PlayerType.NormalComputer;
                    }
                    else
                    {
                        playerType = PlayerType.HardComputer;
                    }

                    return new ComputerPlayer("Computer", playerType);
                }
                else
                {
                    Console.WriteLine("You must select either C or H.");
                }
            }
            while (true);
        }
    }
}