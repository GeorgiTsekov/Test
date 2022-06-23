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
            while (true)
            {
                Console.Write(Constants.ADD_COORDINATES, Constants.STOP);
                var input = Console.ReadLine();
                string output = burnedAcres.InputCoordinatesWithFire(input);
                if (output == Constants.STOP)
                {
                    break;
                }

                Console.WriteLine(output);
            }
            
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine(burnedAcres.CoordinatesCount);
            int firesCount = burnedAcres.CalcFiresCount();
            int hours = burnedAcres.CalcHoursToBurnAllAcres();
            var result = burnedAcres.ToStringResults(firesCount, hours);
            Console.WriteLine(result);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Ms: {elapsedMs}");
        }
    }
}
