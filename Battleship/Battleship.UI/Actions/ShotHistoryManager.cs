using Battleship.UI.DTOs;
using Battleship.UI.Utilities;

namespace Battleship.UI.Actions
{
    public class ShotHistoryManager
    {
        public ShotHistoryCoordinate[] ShotHistory { get; private set; }

        public ShotHistoryManager()
        {
            ShotHistory = new ShotHistoryCoordinate[100];
        }

        public void AddToShotHistory(Coordinate shot, string letter)
        {
            ShotHistory[Converter.CoordinateToElement(shot)] = new ShotHistoryCoordinate(shot.X, shot.Y, letter);
        }
    }
}