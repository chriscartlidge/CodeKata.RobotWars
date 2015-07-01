using System;

namespace RobotWars
{
    public class SetupArenaCommand : ICommand
    {
        private readonly IArena arena;

        public SetupArenaCommand(IArena arena)
        {
            if (arena == null)
            {
                throw new ArgumentNullException("arena");
            }

            this.arena = arena;
        }

        #region ICommand implementation

        public void Perform(string command)
        {
            var args = GuardValidCommands(command);

            var x = int.Parse(args[0]);
            var y = int.Parse(args[1]);

            arena.SetArenaSize(x, y);
        }

        #endregion

        private string[] GuardValidCommands(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException("command");
            }
            var args = command.Split(' ');

            if (args.Length != 2)
            {
                throw new ArgumentException("Argument: 'command' is invalid format");
            }

            return args;
        }
    }
}

