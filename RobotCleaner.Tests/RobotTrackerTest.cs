using NUnit.Framework;
using RobotCleaner.Models;

namespace RobotCleaner.Tests
{
    public class RobotTrackerTest
    {
        [SetUp]
        public void Setup()
        {
                       
        }

        [Test]
        [TestCase("1,1,East", 2,1,Direction.EAST)]
        [TestCase("1,1,West", 0, 1, Direction.WEST)]
        [TestCase("0,0,North", 0, 1, Direction.NORTH)]
        public void PlaceRobotWithMoveTest(string input, int x,int y,Direction direction )
        {
            var expected = new Coordinate(x, y, direction);
            var mockRobot = new Robot();
            var robotTracker = new RobotTracker(mockRobot);
            robotTracker.PlaceRobot(input);            
            robotTracker.MoveDirection();
            Assert.IsTrue(robotTracker.Robot.CurrentCoordinate.Equals(expected));
        }

        [Test]
        [TestCase("1,1,East", 1, 1, Direction.NORTH)]
        [TestCase("1,1,West", 1, 1, Direction.SOUTH)]
        [TestCase("0,0,North", 0, 0, Direction.WEST)]
        public void PlaceRobotWithLeftTest(string input, int x, int y, Direction direction)
        {
            var expected = new Coordinate(x, y, direction);
            var mockRobot = new Robot();
            var robotTracker = new RobotTracker(mockRobot);
            robotTracker.PlaceRobot(input);
            robotTracker.TurnLeft();
            Assert.IsTrue(robotTracker.Robot.CurrentCoordinate.Equals(expected));
        }

        [Test]
        [TestCase("1,2,East", 3, 3, Direction.NORTH)]
        public void RobotMultipleMoveCommandTest(string input, int x, int y, Direction direction)
        {
            var expected = new Coordinate(x, y, direction);
            var mockRobot = new Robot();
            var robotTracker = new RobotTracker(mockRobot);
            robotTracker.PlaceRobot(input);
            robotTracker.MoveDirection();
            robotTracker.MoveDirection();
            robotTracker.TurnLeft();
            robotTracker.MoveDirection();            
            Assert.IsTrue(robotTracker.Robot.CurrentCoordinate.Equals(expected));
        }

        [Test]
        [TestCase("1,2,East", 0, 0, Direction.NORTH)]
        public void RobotReturnToOriginAfterMultipleMoveTest(string input, int x, int y, Direction direction)
        {
            var expected = new Coordinate(x, y, direction);
            var mockRobot = new Robot();
            var robotTracker = new RobotTracker(mockRobot);
            robotTracker.PlaceRobot(input);
            robotTracker.MoveDirection();
            robotTracker.MoveDirection();
            robotTracker.TurnLeft();
            robotTracker.MoveDirection();
            robotTracker.ResetToOrigin();
            Assert.IsTrue(robotTracker.Robot.CurrentCoordinate.Equals(expected));
        }

    }
}