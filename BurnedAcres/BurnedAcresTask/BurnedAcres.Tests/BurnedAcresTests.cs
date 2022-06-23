namespace BurnedAcres.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class BurnedAcresTests
    {
        private BurnedAcres burnedAcres;

        [SetUp]
        public void Setup()
        {
            int width = 10;
            int heigth = 20;
            burnedAcres = new BurnedAcres(width, heigth);
            burnedAcres.InputCoordinatesWithFire("0 0");
            burnedAcres.InputCoordinatesWithFire("0 1");
            burnedAcres.InputCoordinatesWithFire("0 2");
            burnedAcres.InputCoordinatesWithFire("0 3");
            burnedAcres.InputCoordinatesWithFire("0 4");
        }

        [TestCase(15, 30)]
        [TestCase(2, 5)]
        [TestCase(200, 300)]
        public void IsConstructorReturnsTheSameValuesForWidthHeight(int width, int height)
        {
            var currentTable = new BurnedAcres(width, height);
            Assert.AreEqual(width + height, currentTable.Width + currentTable.Height);
        }

        [TestCase(2, -5)]
        [TestCase(0, 2)]
        [TestCase(0, -300)]
        public void IsConstructoThrowsAnExceptionWhenWidthOrHeightAreSmallerThenOne(int width, int height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new BurnedAcres(width, height));
        }

        [TestCase("1 1")]
        [TestCase("0 5")]
        [TestCase("9 19")]
        public void IsInputCoordinatesWithFireReturnsCorrectMessageWithCorrectCoordinates(string input)
        {
            var result = burnedAcres.InputCoordinatesWithFire(input);
            Assert.AreEqual(result, Constants.SUCCESSFULL);
        }

        [TestCase("0 0")]
        [TestCase("0 0")]
        [TestCase("0 0")]
        public void IsInputCoordinatesWithFireReturnsCorrectMessageWithDuplicatedCoordinates(string input)
        {
            var result = burnedAcres.InputCoordinatesWithFire(input);
            Assert.AreEqual(result, Constants.ADDED_ALREADY);
        }

        [TestCase("10 19")]
        [TestCase("9 20")]
        public void IsInputCoordinatesWithFireReturnsCorrectMessageWithOutsideCoordinates(string input)
        {
            var result = burnedAcres.InputCoordinatesWithFire(input);
            Assert.AreEqual(result, Constants.OUT_OF_RANGE);
        }

        [TestCase("-1 0")]
        [TestCase("0 -1")]
        [TestCase("123")]
        [TestCase("9  1")]
        [TestCase("9, 1")]
        [TestCase("sad 1")]
        [TestCase("2.1 1")]
        public void IsInputCoordinatesWithFireReturnsCorrectMessageWithNotValidCoordinates(string input)
        {
            var result = burnedAcres.InputCoordinatesWithFire(input);
            Assert.AreEqual(result, Constants.TWO_INTEGERS_WITH_SPACE);
        }


        [Test]
        public void IsInputCoordinatesWithFireReturnsCorrectMessageWithStopInput()
        {
            var result = burnedAcres.InputCoordinatesWithFire(Constants.STOP);
            Assert.AreEqual(result, Constants.STOP);
        }

        [Test]
        public void IsInputCoordinatesWithFireWorksCorrectly()
        {
            int result = burnedAcres.CoordinatesCount;
            Assert.AreEqual(result, 5);
        }

        [TestCase("1 0")]
        [TestCase("0 5")]
        [TestCase("1 1")]
        public void IsCalcFiresCountReturnsOneFire(string coordinates)
        {
            burnedAcres.InputCoordinatesWithFire(coordinates);
            int result = burnedAcres.CalcFiresCount();
            Assert.AreEqual(result, 1);
        }

        [TestCase("2 1")]
        [TestCase("0 6")]
        [TestCase("9 19")]
        public void IsCalcFiresCountReturnsTwoFires(string coordinates)
        {
            burnedAcres.InputCoordinatesWithFire(coordinates);
            int result = burnedAcres.CalcFiresCount();
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void IsCalcFiresCountReturnsFiveFires()
        {
            var acres = new BurnedAcres(6, 6);
            acres.InputCoordinatesWithFire("0 0");
            acres.InputCoordinatesWithFire("1 0");
            acres.InputCoordinatesWithFire("1 3");
            acres.InputCoordinatesWithFire("0 3");
            acres.InputCoordinatesWithFire("0 5");
            acres.InputCoordinatesWithFire("1 5");
            acres.InputCoordinatesWithFire("3 0");
            acres.InputCoordinatesWithFire("4 1");
            acres.InputCoordinatesWithFire("3 4");
            acres.InputCoordinatesWithFire("4 4");
            acres.InputCoordinatesWithFire("5 4");
            var result = acres.CalcFiresCount();
            Assert.AreEqual(result, 5);
        }

        [Test]
        public void IsCalcFiresCountReturnsZeroFires()
        {
            var acres = new BurnedAcres(5, 6);
            int result = acres.CalcFiresCount();
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void IsCalcHoursToBurnAllAcresReturnsMinusOneHour()
        {
            var acres = new BurnedAcres(5, 6);
            int result = acres.CalcHoursToBurnAllAcres();
            Assert.AreEqual(result, -1);
        }

        [TestCase("0 10")]
        [TestCase("9 10")]
        [TestCase("5 10")]
        public void IsCalcHoursToBurnAllAcresReturnsNineHours(string input)
        {
            burnedAcres.InputCoordinatesWithFire(input);
            burnedAcres.CalcFiresCount();
            int result = burnedAcres.CalcHoursToBurnAllAcres();
            Assert.AreEqual(result, 9);
        }

        [Test]
        public void IsCalcHoursToBurnAllAcresReturnsZeroHours()
        {
            var acres = new BurnedAcres(2, 2);
            acres.InputCoordinatesWithFire("0 0");
            acres.InputCoordinatesWithFire("1 1");
            acres.InputCoordinatesWithFire("1 0");
            acres.InputCoordinatesWithFire("0 1");
            acres.CalcFiresCount();
            int result = acres.CalcHoursToBurnAllAcres();
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void IsCalcHoursToBurnAllAcresReturnsOneHour()
        {
            var acres = new BurnedAcres(6, 6);
            acres.InputCoordinatesWithFire("0 0");
            acres.InputCoordinatesWithFire("1 0");
            acres.InputCoordinatesWithFire("1 3");
            acres.InputCoordinatesWithFire("0 3");
            acres.InputCoordinatesWithFire("0 5");
            acres.InputCoordinatesWithFire("1 5");
            acres.InputCoordinatesWithFire("3 0");
            acres.InputCoordinatesWithFire("4 1");
            acres.InputCoordinatesWithFire("3 4");
            acres.InputCoordinatesWithFire("4 4");
            acres.InputCoordinatesWithFire("5 4");
            acres.CalcFiresCount();
            int result = acres.CalcHoursToBurnAllAcres();
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void IsToStringResultsReturnsCorrectMessageIfMinusOne()
        {
            var acres = new BurnedAcres(6, 6);
            var fires = acres.CalcFiresCount();
            var hours = acres.CalcHoursToBurnAllAcres();
            var result = acres.ToStringResults(fires, hours);
            Assert.AreEqual(result, Constants.NO_FIRES);
        }
    }
}
