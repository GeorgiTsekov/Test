namespace BurnedAcres
{
    using System;

    class Program
    {
        static void Main()
        {
            var integerValidation = new IntegerValidation();
            int width = integerValidation.InputIntegers(nameof(width));
            int height = integerValidation.InputIntegers(nameof(height));

            var burnedAcres = new BurnedAcres(width, height);
            burnedAcres.InputCoordinatesWithFire();
            int firesCount = burnedAcres.CalcFiresCount();
            int hours = burnedAcres.CalcHoursToBurnAllAcres();
            var result = burnedAcres.ToStringResults(firesCount, hours);
            Console.WriteLine(result);
        }
    }
}
