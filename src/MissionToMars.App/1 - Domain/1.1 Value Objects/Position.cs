namespace MissionToMars.Domain
{
    public class Position
    {
        public Position(int x, int y, char orientation)
        {
            X = x;  
            Y = y;
            Orientation = orientation;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public char? Orientation { get; set; }
    }
}
