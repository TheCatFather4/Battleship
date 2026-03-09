using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Utilities;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// A class used to manage a player's game state.
    /// </summary>
    public class GameManager
    {
        public GridManager Grid { get; private set; }
        public ShotHistoryManager Shot { get; private set; }
        public int Score { get; private set; }

        public GameManager()
        {
            Grid = new GridManager();
            Shot = new ShotHistoryManager();
            Score = 0;
        }

        /// <summary>
        /// Adds a point to the player's current score.
        /// </summary>
        public void AddPoint()
        {
            Score++;
        }

        /// <summary>
        /// Places a ship on a human player's gameboard.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="shipName"></param>
        /// <param name="size"></param>
        /// <returns>An enum indicating the result.</returns>
        public ShipPlacementResult PlaceShipOnBoard(string playerName, string shipName, int size)
        {
            Printer.PrintShipInfo(shipName, size);

            do
            {
                string coordinate = Prompter.GetStringCoordinate($"{playerName}, please enter the starting coordinate for your ship: ");

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
                        Console.Write($"You have successfully placed your {shipName}. ");
                        Prompter.AnyKey("continue");
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

        /// <summary>
        /// Receives a shot fired from another player.
        /// The shot is compared with the player's ship coordinates.
        /// </summary>
        /// <param name="shot">The incoming shot.</param>
        /// <returns>An enum indicating the result of the shot.</returns>
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