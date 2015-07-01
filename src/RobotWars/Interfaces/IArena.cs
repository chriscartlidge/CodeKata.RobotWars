namespace RobotWars
{
    public interface IArena
    {
        bool IsValidPosition(Position position);

        void SetArenaSize(int xLength, int yLength);
    }
}


