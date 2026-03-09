namespace Battleship.UI.DTOs
{
    /// <summary>
    /// Inherits from the base coordinate class.
    /// Used for printing shot results to the console grid.
    /// </summary>
    public class ShotHistoryCoordinate : Coordinate
    {
        public string ShotResult { get; private set; }

        public ShotHistoryCoordinate(int x, int y, string shotResult) : base(x, y)
        {
            ShotResult = shotResult;
        }
    }
}