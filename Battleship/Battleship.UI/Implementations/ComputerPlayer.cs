using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;

namespace Battleship.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        public string Name { get; private set; }
        public GameManager Mgr { get; private set; }

        public ComputerPlayer(string name)
        {
            Name = name;
            Mgr = new GameManager();
        }

        public Coordinate FireShot()
        {
            do
            {
                Random rng = new Random();
                Coordinate shot = new Coordinate(rng.Next(1, 11), rng.Next(1, 11));
                int element = Converter.CoordinateToElement(shot);

                if (Mgr.Shot.ShotHistory[element] == null)
                {
                    return shot;
                }
            }
            while (true);
        }

        public void PlaceShips()
        {
            PlaceShip("Aircraft Carrier", 5);
            PlaceShip("Battleship", 4);
            PlaceShip("Cruiser", 3);
            PlaceShip("Submarine", 3);
            PlaceShip("Destroyer", 2);
        }

        private void PlaceShip(string shipName, int size)
        {
            do
            {
                string direction;
                Random rlg = new Random();
                int num = rlg.Next(1, 3);

                if (num == 1)
                {
                    direction = "V";
                }
                else
                {
                    direction = "H";
                }

                Random rng = new Random();

                Coordinate start = new Coordinate(rng.Next(1, 11), rng.Next(1, 11));

                ShipPlacementResult result = Mgr.Grid.IsOffGrid(direction, start, size);

                if (result == ShipPlacementResult.OnBoard)
                {
                    ShipPlacementResult result2 = Mgr.Grid.IsAvailable(direction, start, size, Mgr.Grid.ships);

                    if (result2 == ShipPlacementResult.Success)
                    {
                        Mgr.Grid.AddShip(shipName, size, direction, start);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            while (true);
        }
    }
}