using NUnit.Framework;
using ScenarioSolution;

namespace UnitTests
{
    public class EvenCalculatorTests
    {
        private IEvenCalculator _helper;

        [SetUp]
        public void Setup()
        {
            _helper = new EvenCalculator();
        }

        [Test]
        public void IsEven_When_Even_Returns_True()
        {
            // Act
            var val = 22;

            // Arrange
            var result = _helper.IsEven(val);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEven_When_Odd_Returns_False()
        {
            // Act
            var val = 23;

            // Arrange
            var result = _helper.IsEven(val);

            // Assert
            Assert.IsFalse(result);
        }
    }
}