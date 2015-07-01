using System;
using RobotWars;

namespace RobotWars
{
    public interface IRobot
    {
        void Move(Motion command);

        void SetStartPosition(Position position);

        Position Position { get; }
    } 
}

