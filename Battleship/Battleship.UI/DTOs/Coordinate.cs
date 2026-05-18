namespace Battleship.UI.DTOs
{
    /// <summary>
    /// Represents the base <c>Coordinate</c> class.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// The coordinate's x value.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// The coordinate's y value.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Initializes a <c>Coordinate</c> with x and y integer values.
        /// </summary>
        /// <param name="x">The coordinate's x value.</param>
        /// <param name="y">The coordinate's y value.</param>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}