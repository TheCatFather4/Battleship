using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;

namespace Battleship.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; private set; }
        public GameManager Mgr { get; private set; }

        public HumanPlayer(string name)
        {
            Name = name;
            Mgr = new GameManager();
        }

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