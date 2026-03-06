using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Factories;
using Battleship.UI.Utilities;

namespace Battleship.UI.Workflows
{
    public class App
    {
        public void Run()
        {
            PlayerFactory factory = new PlayerFactory();

            Printer.PrintTitle();
            Prompter.AnyKey("begin");

            var p1 = factory.CreateNewPlayer(1);
            var p2 = factory.CreateNewPlayer(2);
            Console.Clear();

            p1.PlaceShips();
            p2.PlaceShips();

            string winner;

            do
            {
                // player 1 turn
                do
                {
                    Coordinate? shot;

                    if (p1.PlayerType == PlayerType.NormalComputer)
                    {
                        shot = ShotDifficulty.FireShotNormalMode(p2.Mgr.Grid.ships, p1);
                    }
                    else if (p1.PlayerType == PlayerType.HardComputer)
                    {
                        shot = ShotDifficulty.FireShotHardMode(p2.Mgr.Grid.ships, p1);
                    }
                    else
                    {
                        shot = p1.FireShot();
                    }

                    ShotResult result = p2.Mgr.ReceiveShot(shot);

                    if (result == ShotResult.Hit)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Console.WriteLine($"{p1.Name} fired at coordinate {Converter.CoordinateToString(shot)}.");
                        Printer.PrintHit(p1.Name);
                        Prompter.AnyKey("continue");
                        break;
                    }
                    else if (result == ShotResult.Miss)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "M");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Console.WriteLine($"{p1.Name} fired at coordinate {Converter.CoordinateToString(shot)}.");
                        Printer.PrintMiss(p1.Name);
                        Prompter.AnyKey("continue");
                        break;
                    }
                    else if (result == ShotResult.HitAndSunk)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        p1.Mgr.AddPoint();
                        Printer.PrintScore(p1.Name, p1.Mgr.Score, p2.Name, p2.Mgr.Score);
                        Console.WriteLine($"{p1.Name} fired at coordinate {Converter.CoordinateToString(shot)}.");
                        Printer.PrintSunk(p1.Name);
                        Prompter.AnyKey("continue");
                        break;
                    }
                }
                while (true);

                if (p1.Mgr.Score == 5)
                {
                    winner = p1.Name;
                    break;
                }

                // player 2 turn
                do
                {
                    Coordinate? shot;

                    if (p2.PlayerType == PlayerType.NormalComputer)
                    {
                        shot = ShotDifficulty.FireShotNormalMode(p1.Mgr.Grid.ships, p2);
                    }
                    else if (p2.PlayerType == PlayerType.HardComputer)
                    {
                        shot = ShotDifficulty.FireShotHardMode(p1.Mgr.Grid.ships, p2);
                    }
                    else
                    {
                        shot = p2.FireShot();
                    }

                    ShotResult result = p1.Mgr.ReceiveShot(shot);

                    if (result == ShotResult.Hit)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Console.WriteLine($"{p2.Name} fired at coordinate {Converter.CoordinateToString(shot)}.");
                        Printer.PrintHit(p2.Name);
                        Prompter.AnyKey("continue");
                        break;
                    }
                    else if (result == ShotResult.Miss)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "M");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Console.WriteLine($"{p2.Name} fired at coordinate {Converter.CoordinateToString(shot)}.");
                        Printer.PrintMiss(p2.Name);
                        Prompter.AnyKey("continue");
                        break;
                    }
                    else if (result == ShotResult.HitAndSunk)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        p2.Mgr.AddPoint();
                        Printer.PrintScore(p1.Name, p1.Mgr.Score, p2.Name, p2.Mgr.Score);
                        Console.WriteLine($"{p2.Name} fired at coordinate {Converter.CoordinateToString(shot)}.");
                        Printer.PrintSunk(p2.Name);
                        Prompter.AnyKey("continue");
                        break;
                    }
                }
                while (true);

                if (p2.Mgr.Score == 5)
                {
                    winner = p2.Name;
                    break;
                }
            }
            while (true);

            Console.WriteLine($"Congratulations {winner}! You won the game!");
        }
    }
}