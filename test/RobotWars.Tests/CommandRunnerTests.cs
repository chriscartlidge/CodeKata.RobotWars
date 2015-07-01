using System;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class CommandRunnerTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Null_Command_Then_Throw_Argument_Null_Exception()
        {
            // ACT
            new CommandRunner().Run(null);
        }

        [Test]
        public void Given_Invalid_Command_Then_No_Robots_Returned()
        {
            // ARRANGE
            var command = "M E %£";

            // ACT
            var result = new CommandRunner().Run(command);

            // ASSERT
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Given_Valid_Input_For_One_Robot_Then_One_Robot_Returned_With_Correct_Position()
        {
            // ARRANGE
            var command = "5 5\n1 2 N\nLMLMLMLMM\n";

            // ACT
            var result = new CommandRunner().Run(command);

            // ASSERT
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(1, result[0].Position.XCoordinate);
            Assert.AreEqual(3, result[0].Position.YCoordinate);
            Assert.AreEqual(Orientation.North, result[0].Position.Orientation);
        }

        [Test]
        public void Given_Valid_Input_For_Two_Robot_Then_Two_Robot_Returned_With_Correct_Positions()
        {
            // ARRANGE
            var command = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM\n";

            // ACT
            var result = new CommandRunner().Run(command);

            // ASSERT
            Assert.AreEqual(2, result.Count);

            // First Robot..
            Assert.AreEqual(1, result[0].Position.XCoordinate);
            Assert.AreEqual(3, result[0].Position.YCoordinate);
            Assert.AreEqual(Orientation.North, result[0].Position.Orientation);

            // Second Robot..
            Assert.AreEqual(5, result[1].Position.XCoordinate);
            Assert.AreEqual(1, result[1].Position.YCoordinate);
            Assert.AreEqual(Orientation.East, result[1].Position.Orientation);
        }
    }
}

