using Battleship.UI.DTOs;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Utilities
{
    public static class ShotDifficulty
    {
        public static Coordinate? FireShotHardMode(Ship[] ships, IPlayer cp)
        {
            Random rng = new Random();
            int num = rng.Next(1, 11);

            if (num <= 4)
            {
                for (int i = 0; i < ships.Length; i++)
                {
                    for (int j = 0; j < ships[i]?.Coordinates?.Length; j++)
                    {
                        int element = Converter.CoordinateToElement(ships[i].Coordinates[j]);

                        if (cp.Mgr.Shot.ShotHistory[element] == null)
                        {
                            var cn = new Coordinate(ships[i].Coordinates[j].X, ships[i].Coordinates[j].Y);
                            return cn;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                var ce = cp.FireShot();
                return ce;
            }

            return null;
        }

        public static Coordinate? FireShotNormalMode(Ship[] ships, IPlayer cp)
        {
            Random rng = new Random();
            int num = rng.Next(1, 11);

            if (num <= 3)
            {
                for (int i = 0; i < ships.Length; i++)
                {
                    for (int j = 0; j < ships[i]?.Coordinates?.Length; j++)
                    {
                        int element = Converter.CoordinateToElement(ships[i].Coordinates[j]);

                        if (cp.Mgr.Shot.ShotHistory[element] == null)
                        {
                            var cn = new Coordinate(ships[i].Coordinates[j].X, ships[i].Coordinates[j].Y);
                            return cn;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                var ce = cp.FireShot();
                return ce;
            }

            return null;
        }
    }
}