using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class RobotTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Arena_Is_Null_Then_Throw_ArgumentException()
        {
            // ARRANGE
            IArena arena = null;

            // ACT
            new Robot(arena);
        }

        [Test]
        public void Given_Arena_Is_Not_Null_Then_No_Exception()
        {
            // ARRANGE
            var arena = new RectangleArena();

            // ACT
            var result = new Robot(arena);

            // ASSERT
            Assert.NotNull(result);
        }

        [Test]
        public void Given_Not_Start_Position_Set_Then_Position_Return_Null()
        {
            // ARRANGE
            var arena = new RectangleArena();

            // ACT
            var result = new Robot(arena);

            // ASSERT
            Assert.Null(result.Position);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_SetStartPosition_Is_Not_Valid_Then_Throw_ArgumentExcpetion()
        {
            // ARRANGE
            var arena = new RectangleArena();
            arena.SetArenaSize(1, 1);

            var robot = new Robot(arena);

            // ACT
            robot.SetStartPosition(new Position(3, 4, Orientation.East));
        }

        [Test]
        public void Given_SetStartPosition_Is_Valid_Then_Position_Returns_InitialValue()
        {
            // ARRANGE
            var arena = new RectangleArena();
            arena.SetArenaSize(3, 4);

            var robot = new Robot(arena);

            // ACT
            robot.SetStartPosition(new Position(2, 3, Orientation.East));

            // ASSERT
            Assert.AreEqual(2, robot.Position.XCoordinate);
            Assert.AreEqual(3, robot.Position.YCoordinate);
            Assert.AreEqual(Orientation.East, robot.Position.Orientation);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Given_Start_Position_Not_Set_Then_Move_Throws_InvalidOperationException()
        {
            // ARRANGE
            var arena = new RectangleArena();
           
            // ACT
            new Robot(arena).Move(Motion.Left);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Given_Move_Is_Not_Valid_For_StartPosition_Then_Throw_InvalidOperationException()
        {
            // ARRANGE
            var arena = new RectangleArena();
            arena.SetArenaSize(1, 1);

            var robot = new Robot(arena);
            robot.SetStartPosition(new Position(1, 1, Orientation.North));

            // ACT
            robot.Move(Motion.Forward);
        }
    }
}

