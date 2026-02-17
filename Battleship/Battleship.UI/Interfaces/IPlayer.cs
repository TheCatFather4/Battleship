using Battleship.UI.DTOs;

namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        Coordinate FireShot();
        void PlaceShips();
    }
}