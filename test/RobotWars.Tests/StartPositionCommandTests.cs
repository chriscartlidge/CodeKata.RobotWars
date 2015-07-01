using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class StartPositionCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Robot_Is_Null_Should_Throw_Argument_Null_Exception()
        {
            // ACT
            new StartPositionCommand(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Null_Command_Should_Throw_Argument_Null_Exception()
        {
            // ARRANGE
            var command = string.Empty;

            var arena = new RectangleArena();
            var robot = new Robot(arena);

            // ACT
            new StartPositionCommand(robot).Perform(command);
        }

        [TestCase("N 9 8")]
        [TestCase("9 8 M")]
        [TestCase("9 1")]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_Invalid_Command_Supplied_Throw_Argument_Exception(string command)
        {
            // ARRANGE
            var arena = new RectangleArena();
            var robot = new Robot(arena);

            // ACT
            new StartPositionCommand(robot).Perform(command);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_Valid_Command_But_Invalid_Start_Position_Throw_Argument_Exception()
        {
            // ARRANGE
            var arena = new RectangleArena();
            arena.SetArenaSize(2, 2);

            var robot = new Robot(arena);

            // ACT
            new StartPositionCommand(robot).Perform("2 4 N");
        }

        [Test]
        public void Given_Valid_Command_Robot_Should_Have_Correct_Starting_Posistion()
        {
            // ARRANGE
            var arena = new RectangleArena();
            arena.SetArenaSize(2, 2);

            var robot = new Robot(arena);

            // ACT
            new StartPositionCommand(robot).Perform("0 1 E");

            // ASSERT
            Assert.AreEqual(0, robot.Position.XCoordinate);
            Assert.AreEqual(1, robot.Position.YCoordinate);
            Assert.AreEqual(Orientation.East, robot.Position.Orientation);
        }
    }
}

