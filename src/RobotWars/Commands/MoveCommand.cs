using System.Linq;
using System.Collections.Generic;
using System;

namespace RobotWars
{
    public class MoveCommand : ICommand
    {
        private readonly IDictionary<char, Motion> moveCommandMapping = new Dictionary<char, Motion>
        {
            {'L', Motion.Left},
            {'R', Motion.Right},
            {'M', Motion.Forward}
        };

        private readonly IRobot robot;

        public MoveCommand(IRobot robot)
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

            foreach (var arg in args)
            {
                if (!moveCommandMapping.ContainsKey(arg))
                {
                    throw new ArgumentException("Argument: 'command' is invalid");
                }

                robot.Move(moveCommandMapping[arg]);
            }
        }

        #endregion

        private char[] GuardValidCommands(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException("command");
            }

            return command.ToCharArray();
        }
    }
}

