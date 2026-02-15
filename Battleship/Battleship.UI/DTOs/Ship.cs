namespace Battleship.UI.DTOs
{
    public class Ship
    {
        public string? Name { get; private set; }
        public int Size { get; private set; }
        public bool IsSunk { get; private set; }
        public int HitsLeft { get; private set; }
        public Coordinate[]? Coordinates { get; private set; }

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            IsSunk = false;
            HitsLeft = size;
            Coordinates = new Coordinate[size];
        }

        public void FillCoordinates(string direction, Coordinate startingCoordinate)
        {
            for (int i = 0; i < Coordinates?.Length; i++)
            {
                if (direction == "V")
                {
                    Coordinates[i] = new Coordinate(startingCoordinate.X + i, startingCoordinate.Y);
                }
                else
                {
                    Coordinates[i] = new Coordinate(startingCoordinate.X, startingCoordinate.Y + i);
                }
            }
        }

        public bool TakeHit()
        {
            HitsLeft--;

            if (HitsLeft == 0)
            {
                IsSunk = true;
            }

            return IsSunk;
        }
    }
}