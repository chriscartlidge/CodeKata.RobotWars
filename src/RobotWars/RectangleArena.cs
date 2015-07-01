using System;
using System.Drawing;

namespace RobotWars
{
    public sealed class RectangleArena : IArena
    {
        // Holds elements that existing in grid, used to detect collisions!
        // This is something I would have added given time...
        private bool[] _grid;
        private Point _gridSize = new Point();

        #region IArena implementation

        public void SetArenaSize(int xLength, int yLength)
        {
            if (xLength <= 0 || yLength <= 0)
            {
                throw new ArgumentException("Grid dimentions cannot be zero based");
            }

            // We do this because "the lower-left coordinates are assumed to be (0, 0)".
            // So If I have a 5 5 grid I still expect to put items in position 5 5.
            xLength += 1;
            yLength += 1;

            _gridSize = new Point(xLength, yLength);
            _grid = new bool[xLength*yLength];
        }

        public bool IsValidPosition(Position position)
        {
            var isValid = true;

            // We take 1 off because it's a zero based grid..
            var x = position.XCoordinate;
            var y = position.YCoordinate;

            var gridWidth = _gridSize.X;

           
            // Caculates the index in the array for the position.
            // If out of bounds then the Position is invalid.
            if ((gridWidth * x + y) > (_grid.Length - 1) || (gridWidth * x + y) < 0)
            {
                isValid = false;
            }
               
            return isValid;
        }

        #endregion
    }
}
