using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class GridTests
    {
        private GridManager _mgr;

        [SetUp]
        public void SetGridManager()
        {
            _mgr = new GridManager();
        }

        [Test]
        public void AddShip_Success()
        {
            _mgr.AddShip("Battleship", 4, "V", new Coordinate(1, 1));
            Assert.That(_mgr.ships[0].Name, Is.EqualTo("Battleship"));
            Assert.That(_mgr.ships[0].Coordinates?[3].X, Is.EqualTo(4));
        }

        [Test]
        public void IsAvailable_No()
        {
            _mgr.AddShip("Battleship", 4, "V", new Coordinate(1, 1));
            var result = _mgr.IsAvailable("H", new Coordinate(3, 1), 3, _mgr.ships);
            Assert.That(result, Is.EqualTo(ShipPlacementResult.Overlap));
        }

        [Test]
        public void IsAvailable_Yes()
        {
            _mgr.AddShip("Battleship", 4, "H", new Coordinate(1, 1));
            var result = _mgr.IsAvailable("H", new Coordinate(3, 1), 3, _mgr.ships);
            Assert.That(result, Is.EqualTo(ShipPlacementResult.Success));
        }

        [Test]
        public void IsOffGrid_Horizontal_No()
        {
            var result = _mgr.IsOffGrid("H", new Coordinate(1, 1), 4);
            Assert.That(result, Is.EqualTo(ShipPlacementResult.OnBoard));
        }

        [Test]
        public void IsOffGrid_Horizontal_Yes()
        {
            var result = _mgr.IsOffGrid("H", new Coordinate(1, 8), 4);
            Assert.That(result, Is.EqualTo(ShipPlacementResult.OffBoard));
        }

        [Test]
        public void IsOffGrid_Vertical_No()
        {
            var result = _mgr.IsOffGrid("V", new Coordinate(1, 1), 4);
            Assert.That(result, Is.EqualTo(ShipPlacementResult.OnBoard));
        }

        [Test]
        public void IsOffGrid_Vertical_Yes()
        {
            var result = _mgr.IsOffGrid("V", new Coordinate(8, 1), 4);
            Assert.That(result, Is.EqualTo(ShipPlacementResult.OffBoard));
        }
    }
}