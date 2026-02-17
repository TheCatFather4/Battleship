using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Utilities;

namespace Battleship.UI.Workflows
{
    public class App
    {
        public void Run()
        {
            Printer.PrintTitle();
            Prompter.AnyKey();
            Console.Clear();

            GameManager mgr = new GameManager(Prompter.GetPlayerName("Player 1, please enter your name: "));
            GameManager mgr2 = new GameManager(Prompter.GetPlayerName("Player 2, please enter your name: "));
            string winner;
            Console.Clear();

            Printer.PrintShipsOnBoard(mgr.Grid.ships);
            mgr.PlaceShipOnBoard("Aircraft Carrier", 5);
            Printer.PrintShipsOnBoard(mgr.Grid.ships);
            mgr.PlaceShipOnBoard("Battleship", 4);
            Printer.PrintShipsOnBoard(mgr.Grid.ships);
            mgr.PlaceShipOnBoard("Cruiser", 3);
            Printer.PrintShipsOnBoard(mgr.Grid.ships);
            mgr.PlaceShipOnBoard("Submarine", 3);
            Printer.PrintShipsOnBoard(mgr.Grid.ships);
            mgr.PlaceShipOnBoard("Destroyer", 2);

            Printer.PrintShipsOnBoard(mgr2.Grid.ships);
            mgr2.PlaceShipOnBoard("Aircraft Carrier", 5);
            Printer.PrintShipsOnBoard(mgr2.Grid.ships);
            mgr2.PlaceShipOnBoard("Battleship", 4);
            Printer.PrintShipsOnBoard(mgr2.Grid.ships);
            mgr2.PlaceShipOnBoard("Cruiser", 3);
            Printer.PrintShipsOnBoard(mgr2.Grid.ships);
            mgr2.PlaceShipOnBoard("Submarine", 3);
            Printer.PrintShipsOnBoard(mgr2.Grid.ships);
            mgr2.PlaceShipOnBoard("Destroyer", 2);

            // game flow
            do
            {
                // player 1 turn
                do
                {
                    Printer.PrintShotHistory(mgr.Shot.ShotHistory);
                    Console.WriteLine();
                    string sc = Prompter.GetStringCoordinate($"{mgr.Name}, enter a coordinate to fire at: ");
                    Coordinate? c = Converter.StringToCoordinate(sc);
                    int element = Converter.CoordinateToElement(c);
                    Console.Clear();

                    if (mgr.Shot.ShotHistory[element] == null)
                    {
                        ShotResult result = mgr2.ReceiveShot(c);

                        if (result == ShotResult.Hit)
                        {
                            mgr.Shot.AddToShotHistory(element, c, "H");
                            Printer.PrintShotHistory(mgr.Shot.ShotHistory);
                            Console.WriteLine("Boom! You hit something.");
                            Prompter.AnyKey();
                            break;
                        }
                        else if (result == ShotResult.Miss)
                        {
                            mgr.Shot.AddToShotHistory(element, c, "M");
                            Printer.PrintShotHistory(mgr.Shot.ShotHistory);
                            Console.WriteLine("Splash! You missed.");
                            Prompter.AnyKey();
                            break;
                        }
                        else if (result == ShotResult.HitAndSunk)
                        {
                            mgr.Shot.AddToShotHistory(element, c, "H");
                            Printer.PrintShotHistory(mgr.Shot.ShotHistory);
                            Console.WriteLine("Kaboom! You sunk a ship!");
                            mgr.AddPoint();
                            Printer.PrintScore(mgr, mgr2);
                            Prompter.AnyKey();
                            break;
                        }
                    }
                    else
                    {
                        Printer.PrintShotHistory(mgr.Shot.ShotHistory);
                        Console.WriteLine("You already fired at that coordinate. Please pick another one.");
                    }
                }
                while (true);

                if (mgr.Score == 5)
                {
                    winner = mgr.Name;
                    break;
                }

                // player 2 turn
                do
                {
                    Printer.PrintShotHistory(mgr2.Shot.ShotHistory);
                    Console.WriteLine();
                    string sc = Prompter.GetStringCoordinate($"{mgr2.Name}, enter a coordinate to fire at: ");
                    Coordinate? c = Converter.StringToCoordinate(sc);
                    int element = Converter.CoordinateToElement(c);
                    Console.Clear();

                    if (mgr2.Shot.ShotHistory[element] == null)
                    {
                        ShotResult result = mgr.ReceiveShot(c);

                        if (result == ShotResult.Hit)
                        {
                            mgr2.Shot.AddToShotHistory(element, c, "H");
                            Printer.PrintShotHistory(mgr2.Shot.ShotHistory);
                            Console.WriteLine("Boom! You hit something.");
                            Prompter.AnyKey();
                            break;
                        }
                        else if (result == ShotResult.Miss)
                        {
                            mgr2.Shot.AddToShotHistory(element, c, "M");
                            Printer.PrintShotHistory(mgr2.Shot.ShotHistory);
                            Console.WriteLine("Splash! You missed.");
                            Prompter.AnyKey();
                            break;
                        }
                        else if (result == ShotResult.HitAndSunk)
                        {
                            mgr2.Shot.AddToShotHistory(element, c, "H");
                            Printer.PrintShotHistory(mgr2.Shot.ShotHistory);
                            Console.WriteLine("Kaboom! You sunk a ship!");
                            mgr2.AddPoint();
                            Printer.PrintScore(mgr, mgr2);
                            Prompter.AnyKey();
                            break;
                        }
                    }
                    else
                    {
                        Printer.PrintShotHistory(mgr2.Shot.ShotHistory);
                        Console.WriteLine("You already fired at that coordinate. Please pick another one.");
                    }
                }
                while (true);

                if (mgr2.Score == 5)
                {
                    winner = mgr2.Name;
                    break;
                }

            }
            while (true);

            Console.WriteLine($"\nCongratulations {winner}! You won the game!");
        }
    }
}