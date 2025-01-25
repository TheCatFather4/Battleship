using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.DTOs
{
    /// <summary>
    /// A coordinate specially designed for ship objects. 
    /// Inherits the base Coordinate class.
    /// The bool property adds data to track if a coordinate was hit.
    /// </summary>
    public class ShipCoordinate : Coordinate
    {
        public bool IsHit { get; set; }

        public ShipCoordinate(int x, int y) : base(x, y)
        {

        }
    }
}
