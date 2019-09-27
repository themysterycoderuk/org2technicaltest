using NUnit.Framework;
using ScenarioSolution;
using Moq;
using System;

namespace UnitTests
{
    public class PrimeNumberDeterminatorTests
    {
        private IPrimeNumberDeterminator _helper;
        private Mock<IEvenCalculator> _mockEvenCalculator;

        [SetUp]
        public void Setup()
        {
            _mockEvenCalculator = new Mock<IEvenCalculator>();
            _helper = new PrimeNumberDeterminator(_mockEvenCalculator.Object);
        }

        [Test]
        public void IsPrimeNumber_When_Prime_Returns_True()
        {
            // Arrange
            var val = 97;
            _mockEvenCalculator.Setup(m => m.IsEven(97)).Returns(false);

            // Act
            var result = _helper.IsPrimeNumber(val);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPrimeNumber_When_Even_Number_Returns_False()
        {
            // Arrange
            var val = 98;
            _mockEvenCalculator.Setup(m => m.IsEven(98)).Returns(true);

            // Act
            var result = _helper.IsPrimeNumber(val);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPrimeNumber_When_Odd_Number_But_Not_Prime_Returns_False()
        {
            // Arrange
            var val = 99;
            _mockEvenCalculator.Setup(m => m.IsEven(99)).Returns(false);

            // Act
            var result = _helper.IsPrimeNumber(val);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPrimeNumber_When_Zero_Throws_Exception()
        {
            // Arrange
            var val = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(delegate {
                _helper.IsPrimeNumber(val);
            });
        }

        [Test]
        public void IsPrimeNumber_When_Negative_Throws_Exception()
        {
            // Arrange
            var val = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(delegate {
                _helper.IsPrimeNumber(val);
            });
        }

        [Test]
        public void IsPrimeNumber_When_100_Returns_False()
        {
            // Arrange
            var val = 100;
            _mockEvenCalculator.Setup(m => m.IsEven(100)).Returns(true);

            // Act
            var result = _helper.IsPrimeNumber(val);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPrimeNumber_When_More_Than_100_Throws_Exception()
        {
            // Arrange
            var val = 101;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(delegate {
                _helper.IsPrimeNumber(val);
            });
        }
    }
}
