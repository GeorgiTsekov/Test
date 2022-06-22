namespace BurnedAcres
{
    using System;

    public class IntegerValidation : IIntegerValidation
    {
        public int InputIntegers(string name)
        {
            while (true)
            {
                Console.Write($"Add positive integer for {name} of the land: ");
                int width = IsValid(Console.ReadLine());
                if (width > 0)
                {
                    return width;
                }
            }
        }

        private static int IsValid(string n)
        {
            if (String.IsNullOrWhiteSpace(n))
            {
                Console.WriteLine("The number cannot be null or whitespace!");
                return -1;
            }
            bool isInteger = Int32.TryParse(n, out int result);

            if (!isInteger)
            {
                Console.WriteLine("The number shout be positive Integer!");
                return -1;
            }

            if (result < 1)
            {
                Console.WriteLine($"Integer: {result} is not valid. Integer shout be bigger then 0!");
            }

            return result;
        }
    }
}
