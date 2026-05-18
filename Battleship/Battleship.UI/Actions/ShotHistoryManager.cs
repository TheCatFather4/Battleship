using Battleship.UI.DTOs;
using Battleship.UI.Utilities;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// Represents a player's shot history.
    /// </summary>
    public class ShotHistoryManager
    {
        /// <summary>
        /// The player's previous shots recorded in a <c>ShotHistoryCoordinate[]</c>.
        /// </summary>
        public ShotHistoryCoordinate[] ShotHistory { get; private set; }

        /// <summary>
        /// Initializes a <c>ShotHistoryManager</c> with an array of 100 shot history coordinates.
        /// </summary>
        public ShotHistoryManager()
        {
            ShotHistory = new ShotHistoryCoordinate[100];
        }

        /// <summary>
        /// Adds a coordinate to the player's shot history and a letter representing the result of the shot.
        /// </summary>
        /// <param name="shot">The coordinate values to add to the shot history.</param>
        /// <param name="letter">The result of the shot in letter form.</param>
        public void AddToShotHistory(Coordinate shot, string letter)
        {
            ShotHistory[Converter.CoordinateToElement(shot)] = new ShotHistoryCoordinate(shot.X, shot.Y, letter);
        }
    }
}