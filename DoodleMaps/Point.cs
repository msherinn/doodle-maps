namespace Kse.Algorithms.Samples
{
    public struct Point
    {
        public int Column { get; }
        public int Row { get; }
        public int Distance { set; get; }
        public int Parent { set; get; }
        public Point(int column, int row)
        {
            Column = column;
            Row = row;
            Distance = 0;
            Parent = 0;
        }
    }
}