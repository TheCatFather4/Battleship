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
            Prompter.AnyKey();

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
                    var shot = p1.FireShot();
                    ShotResult result = p2.Mgr.ReceiveShot(shot);

                    if (result == ShotResult.Hit)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Printer.PrintHit(p1.Name);
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.Miss)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "M");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Printer.PrintMiss(p1.Name);
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.HitAndSunk)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Printer.PrintSunk(p1.Name);
                        p1.Mgr.AddPoint();
                        Printer.PrintScore(p1.Name, p1.Mgr.Score, p2.Name, p2.Mgr.Score);
                        Prompter.AnyKey();
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
                    var shot = p2.FireShot();
                    ShotResult result = p1.Mgr.ReceiveShot(shot);

                    if (result == ShotResult.Hit)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Printer.PrintHit(p2.Name);
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.Miss)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "M");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Printer.PrintMiss(p2.Name);
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.HitAndSunk)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Printer.PrintSunk(p2.Name);
                        p2.Mgr.AddPoint();
                        Printer.PrintScore(p1.Name, p1.Mgr.Score, p2.Name, p2.Mgr.Score);
                        Prompter.AnyKey();
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