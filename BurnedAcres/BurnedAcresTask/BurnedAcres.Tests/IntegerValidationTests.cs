namespace BurnedAcres.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class IntegerValidationTests
    {
        [TestCase("333")]
        [TestCase("1")]
        [TestCase("55")]
        public void IsValidMethodShouldReturnIntegerForValidInteger(string number)
        {
            var integerValidation = new IntegerValidation();
            int result = integerValidation.IsValid(number);
            Assert.AreEqual(result, int.Parse(number));
        }

        [TestCase("")]
        [TestCase(null)]
        public void IsValidMethodShouldReturnMinusOneForNullOrWhiteSpace(string number)
        {
            var integerValidation = new IntegerValidation();
            int result = integerValidation.IsValid(number);
            Assert.AreEqual(result, -1);
        }

        [TestCase("asdf")]
        [TestCase("13.51")]
        [TestCase("-313.51")]
        public void IsValidMethodShouldReturnMinusOneForDecimalOrString(string number)
        {
            var integerValidation = new IntegerValidation();
            int result = integerValidation.IsValid(number);
            Assert.AreEqual(result, -1);
        }
    }
}
