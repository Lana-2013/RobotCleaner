namespace RobotCleaner.Models
{
    public struct Coordinate
    {
        public Coordinate(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            RobDirection = direction;
        } 
        
        public int X { get; set; }
        public int Y { get; set; }

        public Direction RobDirection { get; set; }

        public override string ToString()
        {
            return $"{X},{Y},{RobDirection}";
        }        

        public static Coordinate operator +(Coordinate c1, Coordinate c2) => new Coordinate(c1.X + c2.X, c1.Y + c2.Y,c1.RobDirection);
    }

    public enum Direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }
}
