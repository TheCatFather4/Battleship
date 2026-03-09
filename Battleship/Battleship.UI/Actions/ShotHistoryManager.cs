using Battleship.UI.DTOs;
using Battleship.UI.Utilities;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// A class used to manage a player's shot history.
    /// </summary>
    public class ShotHistoryManager
    {
        public ShotHistoryCoordinate[] ShotHistory { get; private set; }

        public ShotHistoryManager()
        {
            ShotHistory = new ShotHistoryCoordinate[100];
        }

        /// <summary>
        /// Adds a coordinate to the player's shot history and the result of the shot.
        /// </summary>
        /// <param name="shot"></param>
        /// <param name="letter"></param>
        public void AddToShotHistory(Coordinate shot, string letter)
        {
            ShotHistory[Converter.CoordinateToElement(shot)] = new ShotHistoryCoordinate(shot.X, shot.Y, letter);
        }
    }
}