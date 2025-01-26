using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.DTOs
{
    /// <summary>
    /// This is the base class for instantiating a new coordinate object.
    /// </summary>
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// An override of the Equals().
        /// It compares the data of the incoming coordinate against the data of the invoking coordinate.
        /// </summary>
        /// <param name="obj">The incoming Coordinate object</param>
        /// <returns>True if incoming obj is a coordinate</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Coordinate)
            {
                Coordinate incoming = (Coordinate)obj;
                return incoming.X == X && incoming.Y == Y;
            }

            return false;
        }
    }
}
