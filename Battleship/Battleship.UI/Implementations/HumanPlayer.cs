using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;

namespace Battleship.UI.Implementations
{
    /// <summary>
    /// Implementation of the IPlayer interface.
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        public string Name { get; private set; }
        public GameManager Mgr { get; private set; }
        public PlayerType PlayerType { get; private set; }

        public HumanPlayer(string name, PlayerType playerType)
        {
            Name = name;
            Mgr = new GameManager();
            PlayerType = playerType;
        }

        /// <summary>
        /// The user is prompted to pick a coordinate to fire a shot towards.
        /// The user's shot history is provided for convenience.
        /// </summary>
        /// <returns>A valid coordinate.</returns>
        public Coordinate FireShot()
        {
            Printer.PrintShotHistory(Mgr.Shot.ShotHistory);

            do
            {
                string sc = Prompter.GetStringCoordinate($"{Name}, enter a coordinate to fire at: ");
                Coordinate? c = Converter.StringToCoordinate(sc);
                int element = Converter.CoordinateToElement(c);

                if (Mgr.Shot.ShotHistory[element] == null)
                {
                    return c;
                }
                else
                {
                    Console.WriteLine("You already fired at that coordinate. Please pick another one.");
                }
            }
            while (true);
        }

        /// <summary>
        /// The flow for placing ships for human players.
        /// </summary>
        public void PlaceShips()
        {
            Printer.PrintShipsOnBoard(Mgr.Grid.ships);
            Mgr.PlaceShipOnBoard(Name, "Aircraft Carrier", 5);
            Printer.PrintShipsOnBoard(Mgr.Grid.ships);
            Mgr.PlaceShipOnBoard(Name, "Battleship", 4);
            Printer.PrintShipsOnBoard(Mgr.Grid.ships);
            Mgr.PlaceShipOnBoard(Name, "Cruiser", 3);
            Printer.PrintShipsOnBoard(Mgr.Grid.ships);
            Mgr.PlaceShipOnBoard(Name, "Submarine", 3);
            Printer.PrintShipsOnBoard(Mgr.Grid.ships);
            Mgr.PlaceShipOnBoard(Name, "Destroyer", 2);
        }
    }
}