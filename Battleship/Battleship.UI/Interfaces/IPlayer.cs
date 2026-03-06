using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        GameManager Mgr { get; }
        PlayerType PlayerType { get; }
        Coordinate FireShot();
        void PlaceShips();
    }
}