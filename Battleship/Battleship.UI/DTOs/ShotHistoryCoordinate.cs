namespace Battleship.UI.DTOs
{
    /// <summary>
    /// Represents a coordinate in the player's shot history. Inherits from <c>Coordinate</c>.
    /// </summary>
    public class ShotHistoryCoordinate : Coordinate
    {
        /// <summary>
        /// A letter representing the result of the shot fired.
        /// </summary>
        public string ShotResult { get; private set; }

        /// <summary>
        /// Initializes a <c>ShotHistoryCoordinate</c> with x and y values and a shot result.
        /// </summary>
        /// <param name="x">The coordinate's x value.</param>
        /// <param name="y">The coordinate's y value.</param>
        /// <param name="shotResult">A letter representing the shot's result.</param>
        public ShotHistoryCoordinate(int x, int y, string shotResult) : base(x, y)
        {
            ShotResult = shotResult;
        }
    }
}