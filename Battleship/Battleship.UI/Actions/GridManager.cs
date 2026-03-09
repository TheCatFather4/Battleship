using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// A class used for managing a player's gameboard.
    /// </summary>
    public class GridManager
    {
        public Ship[] ships { get; private set; }

        public GridManager()
        {
            ships = new Ship[5];
        }

        /// <summary>
        /// Adds a ship to the player's array of ships.
        /// </summary>
        /// <param name="name">Name of the ship.</param>
        /// <param name="size">The ship's length.</param>
        /// <param name="direction">The direction the ship is placed in.</param>
        /// <param name="startingCoordinate">The first coordinate position.</param>
        public void AddShip(string name, int size, string direction, Coordinate startingCoordinate)
        {
            Ship ship = new Ship(name, size);

            ship.FillCoordinates(direction, startingCoordinate);

            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i] == null)
                {
                    ships[i] = ship;
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a ship placement will go off the game board.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="startingCoordinate"></param>
        /// <param name="shipSize"></param>
        /// <returns>An enum indicating the result.</returns>
        public ShipPlacementResult IsOffGrid(string direction, Coordinate startingCoordinate, int shipSize)
        {
            if (direction == "V")
            {
                if (startingCoordinate.X > (11 - shipSize))
                {
                    return ShipPlacementResult.OffBoard;
                }
                else
                {
                    return ShipPlacementResult.OnBoard;
                }
            }
            else
            {
                if (startingCoordinate.Y > (11 - shipSize))
                {
                    return ShipPlacementResult.OffBoard;
                }
                else
                {
                    return ShipPlacementResult.OnBoard;
                }
            }
        }

        /// <summary>
        /// Determines whether a ship placement will overlap with other ships already placed on the game board.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="startingCoordinate"></param>
        /// <param name="shipSize"></param>
        /// <param name="ships"></param>
        /// <returns>An enum indicating the result.</returns>
        public ShipPlacementResult IsAvailable(string direction, Coordinate startingCoordinate, int shipSize, Ship[] ships)
        {
            int startX;
            int startY;

            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i] != null)
                {
                    for (int j = 0; j < ships[i].Coordinates?.Length; j++)
                    {
                        if (ships[i]?.Coordinates?[j] != null)
                        {
                            // compare each coordinate with the current iteration
                            startX = startingCoordinate.X;
                            startY = startingCoordinate.Y;

                            for (int k = 0; k < shipSize; k++)
                            {
                                if (startX == ships[i]?.Coordinates?[j].X && startY == ships[i]?.Coordinates?[j].Y)
                                {
                                    return ShipPlacementResult.Overlap;
                                }
                                else
                                {
                                    if (direction == "V")
                                    {
                                        startX++;
                                    }
                                    else
                                    {
                                        startY++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ShipPlacementResult.Success;
        }
    }
}