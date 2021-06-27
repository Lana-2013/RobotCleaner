using RobotCleaner.Models;
using System;

namespace RobotCleaner.WebAPI.Models
{
    public interface IRobot
    {
        Coordinate CurrentCoordinate { get; set; }

        Coordinate InitCoordinate { get; set; }

        event EventHandler<RobotMovedEventArgs> Moved;
    }
}
