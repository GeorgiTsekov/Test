namespace BurnedAcres
{
    using System;

    public class IntegerValidation : IIntegerValidation
    {
        public int InputIntegers(string name)
        {
            while (true)
            {
                Console.Write(Constants.ADD_POSITIVE_INTEGER, name);
                int width = IsValid(Console.ReadLine());
                if (width > 0)
                {
                    return width;
                }
            }
        }

        public int IsValid(string n)
        {
            if (String.IsNullOrWhiteSpace(n))
            {
                Console.WriteLine(Constants.NULL_OR_WHITESPACE);
                return -1;
            }
            bool isInteger = Int32.TryParse(n, out int result);

            if (!isInteger)
            {
                Console.WriteLine(Constants.NOT_INTEGER);
                return -1;
            }

            if (result < 1)
            {
                Console.WriteLine(Constants.NOT_POSITIVE);
            }

            return result;
        }
    }
}
