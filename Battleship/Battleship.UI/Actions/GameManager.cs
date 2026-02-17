using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Utilities;

namespace Battleship.UI.Actions
{
    public class GameManager
    {
        public string Name { get; private set; }
        public GridManager Grid { get; private set; }
        public ShotHistoryManager Shot { get; private set; }
        public int Score { get; private set; }

        public GameManager(string name)
        {
            Name = name;
            Grid = new GridManager();
            Shot = new ShotHistoryManager();
            Score = 0;
        }

        public void AddPoint()
        {
            Score++;
        }

        public ShipPlacementResult PlaceShipOnBoard(string shipName, int size)
        {
            Printer.PrintShipInfo(shipName, size);

            do
            {
                string coordinate = Prompter.GetStringCoordinate($"{Name}, please enter the starting coordinate for your ship: ");

                Coordinate? start = Converter.StringToCoordinate(coordinate);

                string direction = Prompter.GetPlacementDirection("Would you like to place the ship (V)ertically or (H)orizontally?: ");

                ShipPlacementResult result = Grid.IsOffGrid(direction, start, size);

                if (result == ShipPlacementResult.OnBoard)
                {
                    ShipPlacementResult result2 = Grid.IsAvailable(direction, start, size, Grid.ships);

                    if (result2 == ShipPlacementResult.Success)
                    {
                        Grid.AddShip(shipName, size, direction, start);
                        Console.Clear();
                        Printer.PrintShipsOnBoard(Grid.ships);
                        Console.WriteLine($"You have successfully placed your {shipName}.");
                        Prompter.AnyKey();
                        return ShipPlacementResult.Success;
                    }
                    else
                    {
                        Console.WriteLine("This set of coordinates will overlap a ship already on the gameboard. Try another starting coordinate.");
                    }
                }
                else
                {
                    Console.WriteLine("This set of coordinates will go off the gameboard. Try another starting coordinate.");
                }
            }
            while (true);
        }

        public ShotResult ReceiveShot(Coordinate shot)
        {

            for (int i = 0; i < Grid.ships.Length; i++)
            {
                for (int j = 0; j < Grid.ships[i]?.Coordinates?.Length; j++)
                {
                    if (shot.X == Grid.ships[i]?.Coordinates?[j].X && shot.Y == Grid.ships[i]?.Coordinates?[j].Y)
                    {

                        bool IsSunk = Grid.ships[i].TakeHit();

                        if (IsSunk)
                        {
                            return ShotResult.HitAndSunk;
                        }

                        return ShotResult.Hit;
                    }
                }
            }

            return ShotResult.Miss;
        }
    }
}