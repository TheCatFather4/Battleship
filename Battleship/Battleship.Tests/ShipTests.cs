using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void HitShip()
        {
            var mgr = new BoardManager();

            mgr.PlaceShip("Battleship", 4, new ShipCoordinate(1, 1), ShipDirection.Vertical);

            var result = mgr.ExamineFleet(new Coordinate(1, 1));

            Assert.That(result, Is.EqualTo(ShotResult.Hit));
        }

        [Test]
        public void MissShip()
        {
            var mgr = new BoardManager();

            mgr.PlaceShip("Cruiser", 3, new ShipCoordinate(2, 2), ShipDirection.Horizontal);
            mgr.PlaceShip("Submarine", 3, new ShipCoordinate(3, 3), ShipDirection.Horizontal);
            mgr.PlaceShip("Battleship", 4, new ShipCoordinate(4, 4), ShipDirection.Horizontal);
            mgr.PlaceShip("Aircraft Carrier", 5, new ShipCoordinate(5, 5), ShipDirection.Horizontal);
            mgr.PlaceShip("Destroyer", 2, new ShipCoordinate(6, 6), ShipDirection.Horizontal);

            var result = mgr.ExamineFleet(new Coordinate(1, 1));

            Assert.That(result, Is.EqualTo(ShotResult.Miss));
        }

        [Test]
        public void SunkShip()
        {
            var mgr = new BoardManager();

            mgr.PlaceShip("Destroyer", 2, new ShipCoordinate(1, 1), ShipDirection.Vertical);

            mgr.ExamineFleet(new Coordinate(1, 1));
            var result = mgr.ExamineFleet(new Coordinate(1, 2));

            Assert.That(result, Is.EqualTo(ShotResult.HitAndSunk));
        }
    }
}
