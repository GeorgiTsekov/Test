namespace BurnedAcres
{
    using System;
    using System.Linq;
    using System.Text;

    public class BurnedAcres : IBurnedAcres
    {
        private int width;
        private int height;
        private static int size;
        private static int[,] land;
        private static bool[,] visited;

        public BurnedAcres(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            land = new int[this.Width, this.Height];
            visited = new bool[this.Width, this.Height];
        }

        public int Width
        {
            get
            {
                return width;
            }

            private set
            {
                IsSmallerThenOne(value);

                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            private set
            {
                IsSmallerThenOne(value);

                height = value;
            }
        }

        public int CoordinatesCount { get; private set; }

        public string InputCoordinatesWithFire(string input)
        {
            if (input.ToLower() == Constants.STOP)
            {
                return Constants.STOP;
            }

            if (input.Count(x => Char.IsWhiteSpace(x)) != 1 || input.Any(x => !Char.IsWhiteSpace(x) && !Char.IsDigit(x)))
            {
                return Constants.TWO_INTEGERS_WITH_SPACE;
            }

            var coordinatesWithFire = input.Split().Select(int.Parse).ToArray();
            int row = coordinatesWithFire[0];
            int col = coordinatesWithFire[1];

            if (AreOutside(row, col))
            {
                return Constants.OUT_OF_RANGE;
            }

            if (land[row, col] != 0)
            {
                return Constants.ADDED_ALREADY;
            }

            CoordinatesCount++;
            land[row, col] = 'F';
            return Constants.SUCCESSFULL;
        }

        public int CalcFiresCount()
        {
            int countOfFires = 0;
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

            return countOfFires;
        }

        public int CalcHoursToBurnAllAcres()
        {
            bool isNotVisited = false;
            int hours = 0;
            return AddFiresToVisitedAndCheckForMoreNotVisited(isNotVisited, hours);
        }

        public string ToStringResults(int fires, int hours)
        {
            var result = new StringBuilder();
            if (hours < 0 || fires == 0)
            {
                result.AppendLine(Constants.NO_FIRES);
            }
            else
            {
                result.AppendLine($"There is/are {fires} fire/s in the beggining.");
                result.AppendLine($"It takes {hours} hour/s to burn the whole area!");
            }

            return result.ToString().TrimEnd();
        }

        private static int AddFiresToVisitedAndCheckForMoreNotVisited(bool isNotVisited, int hours)
        {
            bool isVisited = false;

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
                            isVisited = true;
                            land[i, j] = 'F';
                        }
                    }
                }

                if (!isVisited)
                {
                    return -1;
                }

                if (isNotVisited)
                {
                    hours++;
                    AddVisitAroundFires();
                    isNotVisited = false;
                }
                else
                {
                    break;
                }
            }

            return hours;
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

        private static void AddVisitedIfNotAdded(int row, int col)
        {
            if (AreOutside(row, col))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;
        }

        private static void ExploreLandAddVisitedAndUpdateSize(int row, int col)
        {
            if (AreOutside(row, col))
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

        private static void IsSmallerThenOne(int value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException($"Integer: {value} is not valid. Integer shout be bigger then 0!");
            }
        }

        private static bool AreOutside(int row, int col)
        {
            if (land.GetLength(0) <= row || land.GetLength(1) <= col || row < 0 || col < 0)
            {
                return true;
            }

            return false;
        }
    }
}
