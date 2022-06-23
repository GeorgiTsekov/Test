namespace BurnedAcres
{
    public interface IBurnedAcres
    {
        int Width { get; }
        int Height { get; }
        int CoordinatesCount { get; }
        string InputCoordinatesWithFire(string input);
        int CalcFiresCount();
        int CalcHoursToBurnAllAcres();
        string ToStringResults(int fires, int hours);
    }
}
