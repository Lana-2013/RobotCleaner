using RobotCleaner.Models;

namespace RobotCleaner.WebAPI.Models
{
    public interface IRobotTracker
    {
        void PlaceRobot(string input);
        void MoveDirection();
        void TurnLeft();
        void TurnRight();
        void ReportRobotPositionToConsole();
        void ResetToOrigin();
    }
}
