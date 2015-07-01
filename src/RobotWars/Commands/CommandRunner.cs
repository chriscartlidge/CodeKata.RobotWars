using System;
using System.Collections.Generic;
using RobotWars;
using System.Linq;
using System.Text.RegularExpressions;

namespace RobotWars
{
    public class CommandRunner
    {
        private readonly IList<IRobot> robots;

        private IDictionary<string, Func<ICommand>> commandMap;
        private IArena arena;
      
        public CommandRunner()
        {
            commandMap = new Dictionary<string, Func<ICommand>>
            {
                { "^\\d+ \\d+$", SetupArenaCommand },
                { "^\\d+ \\d+ [NSEW]$", SetupRobotCommand },
                { "^[LRM]+$", SetRobotMoveCommand }
            };

            robots = new List<IRobot>();
        }
     
        public IList<IRobot> Run(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new ArgumentNullException("commandLine"); 
            }
                
            var commands = commandLine.Split(new[] { '\n' }, StringSplitOptions.None);

            foreach (var command in commands)
            {
                var action = commandMap.SingleOrDefault(reg => new Regex(reg.Key).IsMatch(command));

                if (action.Value != null)
                {
                    action.Value.Invoke().Perform(command);
                }
            }

            return robots;
        }

        private ICommand SetupArenaCommand()
        {
            arena = new RectangleArena();

            return new SetupArenaCommand(arena);
        }

        private ICommand SetupRobotCommand()
        {
            robots.Add(new Robot(arena));

            return new StartPositionCommand(GetActiveRobot());
        }

        private ICommand SetRobotMoveCommand()
        {
            return new MoveCommand(GetActiveRobot());   
        }

        private IRobot GetActiveRobot()
        {
            return robots.Last();
        }
    }
}

