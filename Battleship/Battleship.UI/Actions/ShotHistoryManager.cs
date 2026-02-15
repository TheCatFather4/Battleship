using Battleship.UI.DTOs;

namespace Battleship.UI.Actions
{
    public class ShotHistoryManager
    {
        public ShotHistoryCoordinate[] ShotHistory { get; private set; }

        public ShotHistoryManager()
        {
            ShotHistory = new ShotHistoryCoordinate[100];
        }

        public void AddToShotHistory(int element, Coordinate shot, string letter)
        {
            ShotHistory[element] = new ShotHistoryCoordinate(shot.X, shot.Y, letter);
        }
    }
}