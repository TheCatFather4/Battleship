using Battleship.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// Contains the data and functions involving an individual ship.
    /// </summary>
    public class Ship
    {
        public string Name { get; private set; }
        public int Size { get { return Coordinates.Length; } }
        public int HitsLeft { get; private set; }
        public bool IsSunk { get { return HitsLeft == 0; } }
        public ShipCoordinate[] Coordinates { get; private set; }

        public Ship(string name, ShipCoordinate[] coordinates)
        {
            Coordinates = coordinates;
            HitsLeft = coordinates.Length;
            Name = name;
        }
    }
}
