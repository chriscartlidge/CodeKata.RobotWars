using System;
using System.Collections.Generic;

namespace RobotWars
{
    public class StartPositionCommand : ICommand
    {
        private readonly IDictionary<char, Orientation> orientationMapping = new Dictionary<char, Orientation>
        {
            {'N', Orientation.North},
            {'E', Orientation.East},
            {'S', Orientation.South},
            {'W', Orientation.West}
        };

        private readonly IRobot robot;

        public StartPositionCommand(IRobot robot)
        {
            if (robot == null)
            {
                throw new ArgumentNullException("robot");
            }

            this.robot = robot;
        }

        #region ICommand implementation

        public void Perform(string command)
        {
            var args = GuardValidCommands(command);

            var x = int.Parse(args[0]);
            var y = int.Parse(args[1]);

            var orientation = orientationMapping[args[2][0]];

            robot.SetStartPosition(new Position(x, y, orientation));
        }

        #endregion

        private string[] GuardValidCommands(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException("command");
            }

            var args = command.Split(' ');

            if (args.Length != 3 || (args.Length == 3 && !orientationMapping.ContainsKey(args[2][0])))
            {
                throw new ArgumentException("Argument: 'command' incorrect format");
            }

            return args;
        }
    }
}

