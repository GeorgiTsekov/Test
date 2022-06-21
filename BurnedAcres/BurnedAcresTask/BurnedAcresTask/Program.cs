using System;
using System.Linq;

namespace BurnedAcres
{
    class Program
    {
        private static char[,] land;
        private static int countOfFires;
        private static int size;
        private static int houres;
        private static bool[,] visited;

        static void Main()
        {
            int width = InputInteger();
            int height = InputInteger();

            land = new char[width, height];
            visited = new bool[width, height];
            InputCoordinatesWithFire();

            FindFiresCount();

            Console.WriteLine($"count of fires: {countOfFires}");

            AddFiresToVisitedAndCheckForMoreNotVisited();

            Console.WriteLine(houres);
        }

        private static void AddVisitAroundFires()
        {
            for (int i = 0; i < land.GetLength(0); i++)
            {
                for (int j = 0; j < land.GetLength(1); j++)
                {
                    if (land[i, j] == 'F')
                    {
                        AddVisitedIfNotAdded(i - 1, j);
                        AddVisitedIfNotAdded(i + 1, j);
                        AddVisitedIfNotAdded(i, j - 1);
                        AddVisitedIfNotAdded(i, j + 1);
                        AddVisitedIfNotAdded(i + 1, j + 1);
                        AddVisitedIfNotAdded(i - 1, j - 1);
                        AddVisitedIfNotAdded(i + 1, j - 1);
                        AddVisitedIfNotAdded(i - 1, j + 1);
                    }
                }
            }
        }

        private static void AddFiresToVisitedAndCheckForMoreNotVisited()
        {
            bool isNotVisited = false;
            while (true)
            {
                for (int i = 0; i < land.GetLength(0); i++)
                {
                    for (int j = 0; j < land.GetLength(1); j++)
                    {
                        if (!visited[i, j])
                        {
                            isNotVisited = true;
                        }
                        else
                        {
                            land[i, j] = 'F';
                        }
                    }
                }

                if (isNotVisited)
                {
                    houres++;
                    AddVisitAroundFires();
                    isNotVisited = false;
                }
                else
                {
                    break;
                }
            }
        }

        private static void AddVisitedIfNotAdded(int row, int col)
        {
            if (AreInside(row, col))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;
        }

        private static void FindFiresCount()
        {
            for (int i = 0; i < land.GetLength(0); i++)
            {
                for (int j = 0; j < land.GetLength(1); j++)
                {
                    size = 0;
                    if (land[i, j] == 'F' && !visited[i, j])
                    {
                        ExploreLandAddVisitedAndUpdateSize(i, j);
                    }

                    if (size != 0)
                    {
                        countOfFires++;
                    }
                }
            }
        }

        private static void ExploreLandAddVisitedAndUpdateSize(int row, int col)
        {
            if (AreInside(row, col))
            {
                return;
            }

            if (land[row, col] == 0)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            ExploreLandAddVisitedAndUpdateSize(row - 1, col);
            ExploreLandAddVisitedAndUpdateSize(row + 1, col);
            ExploreLandAddVisitedAndUpdateSize(row, col - 1);
            ExploreLandAddVisitedAndUpdateSize(row, col + 1);
            ExploreLandAddVisitedAndUpdateSize(row + 1, col + 1);
            ExploreLandAddVisitedAndUpdateSize(row - 1, col - 1);
            ExploreLandAddVisitedAndUpdateSize(row + 1, col - 1);
            ExploreLandAddVisitedAndUpdateSize(row - 1, col + 1);

            size++;
        }

        private static void InputCoordinatesWithFire()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "stop")
                {
                    break;
                }

                var coordinatesWithFire = input.Split(" ").Select(int.Parse).ToArray();
                int row = coordinatesWithFire[0];
                int col = coordinatesWithFire[1];

                if (AreInside(row, col))
                {
                    Console.WriteLine("Current coordinates are outside of the lend!");
                    continue;
                }

                if (land[row, col] != 0)
                {
                    Console.WriteLine($"There are coordinates: {row}, {col} already!");
                    continue;
                }

                land[row, col] = 'F';
            }
        }

        private static int InputInteger()
        {
            return int.Parse(Console.ReadLine());
        }

        private static bool AreInside(int row, int col)
        {
            if (land.GetLength(0) <= row || land.GetLength(1) <= col || row < 0 || col < 0)
            {
                return true;
            }

            return false;
        }
    }
}
