using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// This class manages the data of the game board (i.e. building and placing ships).
    /// </summary>
    public class BoardManager
    {
        public Ship[] Fleet { get; private set; } = new Ship[5];

        /// <summary>
        /// Checks to see if a ship's potential coordinates will go outside the bounds of the gameboard.
        /// </summary>
        /// <param name="size">The size of the ship to be placed</param>
        /// <param name="start">The first coordinate to be in the ship's coordinate array</param>
        /// <param name="direction">The direction in which the ship will be placed</param>
        /// <returns>True if outside the game board, False if within the game board</returns>
        private bool IsOffBoard(int size, Coordinate start, ShipDirection direction)
        {
            if (direction == ShipDirection.Horizontal)
            {
                if (start.X + size - 1 > 10)
                {
                    return true;
                }
            }
            else
            {
                if (start.Y + size - 1 > 10)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Instantiates an array of ship coordinates and fills the elements based on 
        /// the starting coordinate and the direction in which the ship will be placed.
        /// </summary>
        /// <param name="name">The name of the ship to be built</param>
        /// <param name="size">How many coordinates the ship will have</param>
        /// <param name="starting">The first coordinate in the ship's array of coordinates</param>
        /// <param name="direction">The direction in which the ship will be placed</param>
        /// <returns>A new ship object</returns>
        private Ship BuildShip(string name, int size, ShipCoordinate starting, ShipDirection direction)
        {
            ShipCoordinate[] coordinates = new ShipCoordinate[size];

            if (direction == ShipDirection.Horizontal)
            {
                int currentX = starting.X;

                for (int i = 0; i < size; i++)
                {
                    coordinates[i] = new ShipCoordinate(currentX, starting.Y);
                    currentX++;
                }
            }
            else
            {
                int currentY = starting.Y;

                for (int i = 0; i < size; i++)
                {
                    coordinates[i] = new ShipCoordinate(starting.X, currentY);
                    currentY++;
                }
            }

            return new Ship(name, coordinates);
        }

        /// <summary>
        /// Uses IsOffBoard() and BuildShip() to prepare a ship object for placement.
        /// If there is a ship object in the fleet, each coordinate of our newly created ship is checked against
        /// each coordinate of the ship in the fleet. Each ship in the fleet is checked for overlap.
        /// </summary>
        /// <param name="name">The name of the ship to be placed</param>
        /// <param name="size">The number of coordinates to be in the ship's coordinate array</param>
        /// <param name="start">The starting coordinate used to build the other coordinates in BuildShip()</param>
        /// <param name="direction">The direction in which the ship is to be placed</param>
        /// <returns>A placement result enum in accord with the result</returns>
        public PlacementResult PlaceShip(string name, int size, ShipCoordinate start, ShipDirection direction)
        {
            if (IsOffBoard(size, start, direction))
            {
                return PlacementResult.OffBoard;
            }

            Ship ship = BuildShip(name, size, start, direction);

            for (int i = 0; i < Fleet.Length; i++)
            {
                if (Fleet[i] != null)
                {
                    for (int j = 0; j < ship.Coordinates.Length; j++)
                    {
                        if (Fleet[i].HasCoordinate(ship.Coordinates[j]))
                        {
                            return PlacementResult.Overlap;
                        }
                    }
                }
                else
                {
                    Fleet[i] = ship;
                    return PlacementResult.Success;
                }
            }

            return PlacementResult.Error;
        }
    }
}
