using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShotTests
    {
        public GameManager SetUpGrid()
        {
            var mgr = new GameManager("Player 1");
            mgr.Grid.AddShip("Aircraft Carrier", 5, "V", new Coordinate(1, 1));
            mgr.Grid.AddShip("Battleship", 4, "V", new Coordinate(1, 3));
            mgr.Grid.AddShip("Cruiser", 3, "V", new Coordinate(1, 5));
            mgr.Grid.AddShip("Submarine", 3, "V", new Coordinate(1, 7));
            mgr.Grid.AddShip("Destroyer", 2, "V", new Coordinate(1, 9));
            return mgr;
        }

        [Test]
        public void AddToShotHistory_Success()
        {
            var mgr = new ShotHistoryManager();
            mgr.AddToShotHistory(4, new Coordinate(1, 5), "H");
            Assert.That(mgr.ShotHistory[4].X, Is.EqualTo(1));
            Assert.That(mgr.ShotHistory[4].Y, Is.EqualTo(5));
        }

        [Test]
        public void ReceiveShot_Hit()
        {
            var mgr = SetUpGrid();
            var result = mgr.ReceiveShot(new Coordinate(3, 1));
            Assert.That(result, Is.EqualTo(ShotResult.Hit));
        }

        [Test]
        public void ReceiveShot_HitAndSunk()
        {
            var mgr = SetUpGrid();
            var result = mgr.ReceiveShot(new Coordinate(1, 5));
            var result2 = mgr.ReceiveShot(new Coordinate(2, 5));
            var result3 = mgr.ReceiveShot(new Coordinate(3, 5));
            Assert.That(result, Is.EqualTo(ShotResult.Hit));
            Assert.That(result2, Is.EqualTo(ShotResult.Hit));
            Assert.That(result3, Is.EqualTo(ShotResult.HitAndSunk));
        }

        [Test]
        public void ReceiveShot_Miss()
        {
            var mgr = SetUpGrid();
            var result = mgr.ReceiveShot(new Coordinate(6, 1));
            Assert.That(result, Is.EqualTo(ShotResult.Miss));
        }
    }
}