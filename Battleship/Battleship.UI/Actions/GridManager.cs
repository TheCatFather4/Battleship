using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// Represents a player's gameboard with their ships.
    /// </summary>
    public class GridManager
    {
        /// <summary>
        /// The player's fleet of ships.
        /// </summary>
        public Ship[] ships { get; private set; }

        /// <summary>
        /// Initializes a <c>GridManager</c> with a fleet of 5 ships.
        /// </summary>
        public GridManager()
        {
            ships = new Ship[5];
        }

        /// <summary>
        /// Adds a ship to the player's fleet.
        /// </summary>
        /// <param name="name">Name of the ship.</param>
        /// <param name="size">The ship's length.</param>
        /// <param name="direction">The direction to place the ship.</param>
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
        /// Checks to see if a ship placement will be outside the bounds of the grid.
        /// </summary>
        /// <param name="direction">The direction to place the ship.</param>
        /// <param name="startingCoordinate">The starting coordinate position.</param>
        /// <param name="shipSize">The size of the ship.</param>
        /// <returns>A <c>ShipPlacementResult</c> enum indicating the result.</returns>
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
        /// Checks to see if a ship placement will overlap with other ships already on the gameboard.
        /// </summary>
        /// <param name="direction">The direction to be placed.</param>
        /// <param name="startingCoordinate">The starting coordinate position.</param>
        /// <param name="shipSize">The size of the ship.</param>
        /// <param name="ships">The player's fleet of ships.</param>
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