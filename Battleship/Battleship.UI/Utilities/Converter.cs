using Battleship.UI.DTOs;

namespace Battleship.UI.Utilities
{
    /// <summary>
    /// A class used to convert values to and from coordinates.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts a coordinate by its x and y values in order to determine its element for the printer.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static int CoordinateToElement(Coordinate coordinate)
        {
            int element = 0;
            int x = coordinate.X;
            int y = coordinate.Y;

            switch (x)
            {
                case 1:
                    break;
                case 2:
                    element += 10;
                    break;
                case 3:
                    element += 20;
                    break;
                case 4:
                    element += 30;
                    break;
                case 5:
                    element += 40;
                    break;
                case 6:
                    element += 50;
                    break;
                case 7:
                    element += 60;
                    break;
                case 8:
                    element += 70;
                    break;
                case 9:
                    element += 80;
                    break;
                case 10:
                    element += 90;
                    break;
            }

            switch (y)
            {
                case 1:
                    break;
                case 2:
                    element += 1;
                    break;
                case 3:
                    element += 2;
                    break;
                case 4:
                    element += 3;
                    break;
                case 5:
                    element += 4;
                    break;
                case 6:
                    element += 5;
                    break;
                case 7:
                    element += 6;
                    break;
                case 8:
                    element += 7;
                    break;
                case 9:
                    element += 8;
                    break;
                case 10:
                    element += 9;
                    break;
            }

            return element;
        }

        /// <summary>
        /// Converts a coordinate to be expressed as a string.
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static string CoordinateToString(Coordinate coord)
        {
            string letter = "";

            switch (coord.X)
            {
                case 1:
                    letter = "A";
                    break;
                case 2:
                    letter = "B";
                    break;
                case 3:
                    letter = "C";
                    break;
                case 4:
                    letter = "D";
                    break;
                case 5:
                    letter = "E";
                    break;
                case 6:
                    letter = "F";
                    break;
                case 7:
                    letter = "G";
                    break;
                case 8:
                    letter = "H";
                    break;
                case 9:
                    letter = "I";
                    break;
                case 10:
                    letter = "J";
                    break;
            }

            return $"{letter}{coord.Y}";
        }

        /// <summary>
        /// Converts a string letter to an integer value.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static int LetterToNumber(string letter)
        {
            switch (letter.ToUpper())
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Converts a coordinate in string form to a coordinate object.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Coordinate? StringToCoordinate(string c)
        {
            if (int.TryParse(c.Substring(1), out int y))
            {
                int x = LetterToNumber(c.Substring(0, 1));
                return new Coordinate(x, y);
            }

            return null;
        }
    }
}