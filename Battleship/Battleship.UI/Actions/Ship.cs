using Battleship.UI.DTOs;
using Battleship.UI.Enums;
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

        /// <summary>
        /// Examines an incoming coordinate from a shot to see if it matches one of its own coordinates.
        /// </summary>
        /// <param name="incoming">The incoming coordinate to be examined</param>
        /// <returns>The result of the shot</returns>
        public ShotResult ExamineShot(Coordinate incoming)
        {
            for (int i = 0; i < Coordinates.Length; i++)
            {
                if (Coordinates[i].Equals(incoming) && !Coordinates[i].IsHit)
                {
                    Coordinates[i].IsHit = true;
                    HitsLeft--;
                    if (HitsLeft == 0)
                    {
                        return ShotResult.HitAndSunk;
                    }

                    return ShotResult.Hit;
                }
            }

            return ShotResult.Miss;
        }

        /// <summary>
        /// Checks a single coordinate from another ship with all the coordinates
        /// of this ship
        /// </summary>
        /// <param name="osc">The other ship coordinate</param>
        /// <returns>True if the other ship coordinate is the same as a coordinate of this ship. False if not</returns>
        public bool HasCoordinate(Coordinate osc)
        {
            for (int i = 0; i < Coordinates.Length; i++)
            {
                if (Coordinates[i].Equals(osc))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
