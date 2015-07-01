using System;

namespace RobotWars
{
    public interface ICommand
    {
        void Perform(string command);
    }
}

