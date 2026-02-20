using Battleship.UI.Actions;
using Battleship.UI.DTOs;

namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        GameManager Mgr { get; }
        Coordinate FireShot();
        void PlaceShips();
    }
}