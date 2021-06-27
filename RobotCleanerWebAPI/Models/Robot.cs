using RobotCleaner.WebAPI.Models;
using System;

namespace RobotCleaner.Models
{
    public class Robot : IRobot
    {
        public Coordinate CurrentCoordinate { get; set; }
        public Coordinate InitCoordinate { get; set; }

        public Robot()
        {
            var initialCoordinate = new Coordinate(0, 0, Direction.NORTH);
            InitCoordinate = initialCoordinate;
        }

        public void Move(Coordinate direction)
        {
            CurrentCoordinate += direction;
            OnMoved(new RobotMovedEventArgs(CurrentCoordinate));
        }

        protected void OnMoved(RobotMovedEventArgs e)
        {
            Moved(this, e);
        }

        public event EventHandler<RobotMovedEventArgs> Moved;
    }

    public class RobotMovedEventArgs : EventArgs
    {
        public RobotMovedEventArgs(Coordinate lastCoordinate)
        {
            LastCoordinate = lastCoordinate;
        }

        public Coordinate LastCoordinate { get; }
    }
}
