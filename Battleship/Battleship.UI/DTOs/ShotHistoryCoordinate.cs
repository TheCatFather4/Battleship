namespace Battleship.UI.DTOs
{
    public class ShotHistoryCoordinate : Coordinate
    {
        public string ShotResult { get; private set; }

        public ShotHistoryCoordinate(int x, int y, string shotResult) : base(x, y)
        {
            ShotResult = shotResult;
        }
    }
}