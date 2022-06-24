namespace BurnedAcres
{
    using System;
    using System.IO;
    using System.Text;

    public class Program
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

            int firesCount = burnedAcres.CalcFiresCount();
            int hours = burnedAcres.CalcHoursToBurnAllAcres();
            var result = burnedAcres.ToStringResults(firesCount, hours);
            
            Console.WriteLine(result);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Ms: {elapsedMs}");
            using (var stream = new StreamWriter("myTextFile.txt", false, Encoding.UTF8))
            {
                stream.Write(result);
                stream.WriteLine();
                stream.Write($"Ms: {elapsedMs}");
            }
        }
    }
}
