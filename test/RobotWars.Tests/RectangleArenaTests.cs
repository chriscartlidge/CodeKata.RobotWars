using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class RectangleArenaTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException))]
        public void SetArenaSize_If_XLength_IsNotValid_ThrowArgumentException(int x)
        {
            // ARRANGE
            var rec = new RectangleArena();

            // ACT
            rec.SetArenaSize(x, 1);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException))]
        public void SetArenaSize_If_YLength_IsNotValid_ThrowArgumentException(int y)
        {
            // ARRANGE
            var rec = new RectangleArena();

            // ACT
            rec.SetArenaSize(1, y);
        }

        [Test]
        public void Given_ArenaSize_Is_5X5_Then_IsValidPosition_6X5_ReturnFalse()
        {
            // ARRANGE
            var rec = new RectangleArena();
            rec.SetArenaSize(5, 5);

            // ACT
            var result = rec.IsValidPosition(new Position(6 , 5, Orientation.East));

            // ASSERT
            Assert.False(result);
        }

        [Test]
        public void Given_ArenaSize_Is_1X1_Then_IsValidPosition_2X2_ReturnFalse()
        {
            // ARRANGE
            var rec = new RectangleArena();
            rec.SetArenaSize(1, 1);

            // ACT
            var result = rec.IsValidPosition(new Position(2 , 2, Orientation.East));

            // ASSERT
            Assert.False(result);
        }

        [Test]
        public void Given_Arena_Is_10X3_Then_IsValidPosition_2X2_Return_True()
        {
            // ARRANGE
            var rec = new RectangleArena();
            rec.SetArenaSize(10, 3);

            // ACT
            var result = rec.IsValidPosition(new Position(2 , 2, Orientation.East));

            // ASSERT
            Assert.True(result);
        }
    }


}

