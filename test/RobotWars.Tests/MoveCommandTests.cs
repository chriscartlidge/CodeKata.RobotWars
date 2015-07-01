using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class MoveCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Robot_Is_Null_Should_Throw_Argument_Null_Exception()
        {
            // ACT
            new MoveCommand(null);
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
            new MoveCommand(robot).Perform(command);
        }
       
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_Invalid_Command_Throw_Argument_Exception()
        {
            // ARRANGE
            var command = "L R M X";

            var arena = new RectangleArena();
            arena.SetArenaSize(5, 5);

            var robot = new Robot(arena);
            robot.SetStartPosition(new Position(0, 0, Orientation.North));

            // ACT
            new MoveCommand(robot).Perform(command);
        }

        [Test]
        public void Given_Valid_Command_Then_Robot_Should_Have_Correct_Position()
        {
            // ARRANGE
            var command = "LRMM";

            var arena = new RectangleArena();
            arena.SetArenaSize(5, 5);

            var robot = new Robot(arena);
            robot.SetStartPosition(new Position(0, 0, Orientation.North));

            // ACT
            new MoveCommand(robot).Perform(command); 

            // ASSERT
            Assert.AreEqual(0, robot.Position.XCoordinate);
            Assert.AreEqual(2, robot.Position.YCoordinate);
            Assert.AreEqual(Orientation.North, robot.Position.Orientation);
        }

    }
}

