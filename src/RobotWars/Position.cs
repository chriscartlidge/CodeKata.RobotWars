using System;
using System.Windows;

namespace RobotWars
{
    public sealed class Position
    {
        public Position(int xCoordinate , int yCoordinate, Orientation orientation)
        {
            // TODO: More Guards..

            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Orientation = orientation;
        }
           
        public int XCoordinate
        {
            get;
            private set;
        }

        public int YCoordinate
        {
            get;
            private set;
        }
            
        public Orientation Orientation
        {
            get; set;
        }
    }
}
