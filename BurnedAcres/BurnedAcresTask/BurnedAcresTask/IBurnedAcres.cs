namespace BurnedAcres
{
    public interface IBurnedAcres
    {
        int Width { get; }
        int Height { get; }
        void InputCoordinatesWithFire();
        int CalcFiresCount();
        int CalcHoursToBurnAllAcres();
        string ToStringResults(int fires, int hours);
    }
}
