namespace BurnedAcres
{
    public class Coordinate : ICoordinate
    {
        public Coordinate(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }
    }
}
