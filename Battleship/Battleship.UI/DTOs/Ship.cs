namespace Battleship.UI.DTOs
{
    /// <summary>
    /// Represents an individual ship.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// The name of the ship.
        /// </summary>
        public string? Name { get; private set; }

        /// <summary>
        /// The size of the ship.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Represents the ship's status. True if sunk, false if afloat.
        /// </summary>
        public bool IsSunk { get; private set; }

        /// <summary>
        /// Represents how many hits left a ship has until it is sunk.
        /// </summary>
        public int HitsLeft { get; private set; }

        /// <summary>
        /// The ship's coordinates. The amount of coordinates depends on the ship's size.
        /// </summary>
        public Coordinate[]? Coordinates { get; private set; }

        /// <summary>
        /// Initializes a <c>Ship</c> with a name, size, status, hits remaining, and an array of coordinates.
        /// </summary>
        /// <param name="name">The name of the ship.</param>
        /// <param name="size">The size of the ship.</param>
        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            IsSunk = false;
            HitsLeft = size;
            Coordinates = new Coordinate[size];
        }

        /// <summary>
        /// Assigns the coordinates of the ship based on direction, starting coordinate, and the length of its coordinate array.
        /// </summary>
        /// <param name="direction">The direction to assign coordinates.</param>
        /// <param name="startingCoordinate">The starting coordinate to begin from.</param>
        public void FillCoordinates(string direction, Coordinate startingCoordinate)
        {
            for (int i = 0; i < Coordinates?.Length; i++)
            {
                if (direction == "V")
                {
                    Coordinates[i] = new Coordinate(startingCoordinate.X + i, startingCoordinate.Y);
                }
                else
                {
                    Coordinates[i] = new Coordinate(startingCoordinate.X, startingCoordinate.Y + i);
                }
            }
        }

        /// <summary>
        /// Subtracts 1 from the ship's HitsLeft property.
        /// </summary>
        /// <returns>A <c>bool</c>; true if ship is sunk, false if ship is still afloat.</returns>
        public bool TakeHit()
        {
            HitsLeft--;

            if (HitsLeft == 0)
            {
                IsSunk = true;
            }

            return IsSunk;
        }
    }
}