using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class SetupArenaCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Arena_Null_Throw_Argument_Null_Exception()
        {
            // ACT
            new SetupArenaCommand(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Command_Is_Null_Throw_Argument_Null_Exception()
        {
            // ARRANGE
            var command = string.Empty;
            var arena = new RectangleArena();

            // ACT
            new SetupArenaCommand(arena).Perform(command);
        }

        [TestCase("1")]
        [TestCase("9 1 5")]
        [TestCase("3 1 N")]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_Command_Is_Invalid_Format_Throw_Argument_Exception(string command)
        {
            // ARRANGE
            var arena = new RectangleArena();

            // ACT
            new SetupArenaCommand(arena).Perform(command);
        }

        [Test]
        public void Given_Valid_Command_Arena_Should_Accept_Valid_Position()
        {
            // ARRANGE
            var command = "3 3";
            var arena = new RectangleArena();

            // ACT
            new SetupArenaCommand(arena).Perform(command);

            // ASSERT
            Assert.True(arena.IsValidPosition(new Position(0, 0, Orientation.East)));
            Assert.True(arena.IsValidPosition(new Position(1, 0, Orientation.East)));
            Assert.True(arena.IsValidPosition(new Position(2, 0, Orientation.East)));
            Assert.True(arena.IsValidPosition(new Position(0, 1, Orientation.East)));
            Assert.True(arena.IsValidPosition(new Position(1, 1, Orientation.East)));
            Assert.True(arena.IsValidPosition(new Position(2, 1, Orientation.East)));
        }

    }
}

