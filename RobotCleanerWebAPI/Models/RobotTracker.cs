using RobotCleaner.WebAPI.Models;
using System;

namespace RobotCleaner.Models
{
    public class RobotTracker : IRobotTracker
    {
        public IRobot Robot { get; set; }
        public string Report { get; set; }
        public RobotTracker(IRobot robot)
        {
            if(robot == null)
            {
                return;
            }
            Robot = robot;
            Robot.Moved += Robot_Moved;
        }

        private void Robot_Moved(object sender, RobotMovedEventArgs e)
        {
            var coordinate = e.LastCoordinate;
            Report = $"{coordinate.X},{coordinate.Y},{coordinate.RobDirection}";
        }

        private void SetCoordinate(Coordinate coordinate)
        {
            Robot.CurrentCoordinate = coordinate;
        }

        private void SetDirection(Direction direction)
        {
            var coordinate = Robot.CurrentCoordinate;
            coordinate.RobDirection = direction;
            SetCoordinate(coordinate);
        }

        private bool CheckIfValidCoordinate(Coordinate coordinate)
        {
            if (coordinate.X <= 5 && coordinate.Y <= 5)
                return true;

            return false;
        }

        public void ReportRobotPositionToConsole()
        {
            Console.WriteLine($"Robot is placed at  - {Robot.CurrentCoordinate}");
        }

        public void PlaceRobot(string input)
        {
            var splitCoordinate = input.Split(',');
            var direction = (Direction)Enum.Parse(typeof(Direction), splitCoordinate[2].ToUpper());
            var newCoordinate = new Coordinate(int.Parse(splitCoordinate[0]), int.Parse(splitCoordinate[1]), direction);
            if (CheckIfValidCoordinate(newCoordinate))
            {
                SetCoordinate(newCoordinate);
            }
        }       

        public void MoveDirection()
        {
            var newCoordinate = new Coordinate();
            var coordinate = Robot.CurrentCoordinate;
            if (coordinate.RobDirection == Direction.NORTH)
            {
                newCoordinate = new Coordinate(coordinate.X, coordinate.Y + 1, coordinate.RobDirection);
            }
            if (coordinate.RobDirection == Direction.SOUTH)
            {
                newCoordinate = new Coordinate(coordinate.X, coordinate.Y - 1, coordinate.RobDirection);
            }
            if (coordinate.RobDirection == Direction.EAST)
            {
                newCoordinate = new Coordinate(coordinate.X + 1, coordinate.Y, coordinate.RobDirection);
            }
            if (coordinate.RobDirection == Direction.WEST)
            {
                newCoordinate = new Coordinate(coordinate.X - 1, coordinate.Y, coordinate.RobDirection);
            }
            if (CheckIfValidCoordinate(newCoordinate))
            {
                SetCoordinate(newCoordinate);
            }            
        }

        public void TurnLeft()
        {
            switch (Robot.CurrentCoordinate.RobDirection)
            {
                case Direction.NORTH:
                    SetDirection(Direction.WEST);
                    break;
                case Direction.SOUTH:
                    SetDirection(Direction.EAST);
                    break;
                case Direction.EAST:
                    SetDirection(Direction.NORTH);
                    break;
                case Direction.WEST:
                    SetDirection(Direction.SOUTH);
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Robot.CurrentCoordinate.RobDirection)
            {
                case Direction.NORTH:
                    SetDirection(Direction.EAST);
                    break;
                case Direction.SOUTH:
                    SetDirection(Direction.WEST);
                    break;
                case Direction.EAST:
                    SetDirection(Direction.SOUTH);
                    break;
                case Direction.WEST:
                    SetDirection(Direction.NORTH);
                    break;
            }            
        }

        public void ResetToOrigin()
        {
            SetCoordinate(new Coordinate(0, 0, Direction.NORTH));
        }
    }
}
