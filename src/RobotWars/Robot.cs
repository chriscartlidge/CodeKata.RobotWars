using System;
using System.Collections.Generic;

namespace RobotWars
{
    public class Robot : IRobot
    {
        private readonly Action<bool>[] _moveCommands;
        
        private readonly IArena _arena;

        public Robot(IArena arena)
        {
            if (arena == null)
            {
                throw new ArgumentNullException("arena");
            }

            _arena = arena;

            // Setup Commands...
            _moveCommands = new Action<bool>[]
            {
                NorthCommand,
                EastCommand,
                SouthCommand,
                WestCommand
            };
        }

        #region IRobot implementation

        public Position Position
        {
            get;
            private set;
        }
           
        public void Move(Motion command)
        {
            if (Position == null)
            {
                throw new InvalidOperationException("Start Position Not Set!");
            }

            if (Motion.Left == command || Motion.Right == command)
            { 
                _moveCommands[FindCommandIndexForCommand(command)].Invoke(false);
            }
            else 
            {
                _moveCommands[FindCommandIndexForCommand(command)].Invoke(true);  
            }
        }

        public void SetStartPosition(Position position)
        {
            if (!_arena.IsValidPosition(position))
            {
                throw new ArgumentException("Argument: 'startingPosition' is invalid.");
            }

            Position = position;
        }

        #endregion
             
        private void NorthCommand(bool forward)
        {
            if (forward)
            {
                var newPosition = new Position(
                    Position.XCoordinate, 
                    Position.YCoordinate + 1,
                    Position.Orientation);
                
                SetPosistionIfValid(newPosition);
            }
            else
            {
                Position.Orientation = Orientation.North;
            }
        }

        private void EastCommand(bool forward)
        {
            if (forward)
            {
                var newPosition = new Position(
                    Position.XCoordinate + 1, 
                    Position.YCoordinate,
                    Orientation.East);

                SetPosistionIfValid(newPosition);
            }
            else
            {
                Position.Orientation = Orientation.East;
            }
        }

        private void SouthCommand(bool forward)
        {
            if (forward)
            {
                var newPosition = new Position(
                    Position.XCoordinate, 
                    Position.YCoordinate - 1,
                    Orientation.South);

                SetPosistionIfValid(newPosition);
            }
            else
            {
                Position.Orientation = Orientation.South;
            }
        }

        private void WestCommand(bool forward)
        {
            if (forward)
            {
                var newPosition = new Position(
                    Position.XCoordinate - 1, 
                    Position.YCoordinate,
                    Orientation.West);
                
                SetPosistionIfValid(newPosition);
            }
            else
            {
                Position.Orientation = Orientation.West;
            }
        }

        private void SetPosistionIfValid(Position newPosition)
        {
            if (!_arena.IsValidPosition(newPosition))
            {
                throw new InvalidOperationException("Move Invalid For Arena Size");
            }

            Position = newPosition;
        }
                        
        private int FindCommandIndexForCommand(Motion command)
        {
            var resultingCommandIndex = FindCommandIndexForOrientation();

            switch (command)
            {
                case Motion.Left:
                    {
                        resultingCommandIndex --;

                        resultingCommandIndex = (resultingCommandIndex + _moveCommands.Length) % _moveCommands.Length;
                        break;
                    }

                case Motion.Right:
                    {
                        resultingCommandIndex ++;

                        resultingCommandIndex = (resultingCommandIndex) % _moveCommands.Length;

                        break;
                    }
            }

            return resultingCommandIndex;
        }

        private int FindCommandIndexForOrientation()
        {
            int commandIndex;

            switch (Position.Orientation)
            {
                case Orientation.North:
                    {
                        commandIndex = 0;
                        break;
                    }
                case Orientation.East:
                    {
                        commandIndex = 1;
                        break;
                    }
                case Orientation.South:
                    {
                        commandIndex = 2;
                        break;
                    }
                case Orientation.West:
                    {
                        commandIndex = 3;
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }

            return commandIndex;
        }
    }
}

