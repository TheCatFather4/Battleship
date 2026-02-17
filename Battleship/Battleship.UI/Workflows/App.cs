using Battleship.UI.Enums;
using Battleship.UI.Implementations;
using Battleship.UI.Utilities;

namespace Battleship.UI.Workflows
{
    public class App
    {
        public void Run()
        {
            Printer.PrintTitle();
            Prompter.AnyKey();

            var p1 = new HumanPlayer(Prompter.GetPlayerName("Player 1, please enter your name: "));
            var p2 = new HumanPlayer(Prompter.GetPlayerName("Player 2, please enter your name: "));
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
                        Console.WriteLine("Boom! You hit something.");
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.Miss)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "M");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Console.WriteLine("Splash! You missed.");
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.HitAndSunk)
                    {
                        p1.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p1.Mgr.Shot.ShotHistory);
                        Console.WriteLine("Kaboom! You sunk a ship!");
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
                        Console.WriteLine("Boom! You hit something.");
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.Miss)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "M");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Console.WriteLine("Splash! You missed.");
                        Prompter.AnyKey();
                        break;
                    }
                    else if (result == ShotResult.HitAndSunk)
                    {
                        p2.Mgr.Shot.AddToShotHistory(shot, "H");
                        Console.Clear();
                        Printer.PrintShotHistory(p2.Mgr.Shot.ShotHistory);
                        Console.WriteLine("Kaboom! You sunk a ship!");
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