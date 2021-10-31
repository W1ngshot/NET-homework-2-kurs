using Xunit;
using HW6;

namespace Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, '^', 3, 4)]
        [InlineData(7, '-', 6, 1)]
        [InlineData(3, '*', 2, 6)]
        [InlineData(8, '/', 2, 4)]
        private void IntTests(decimal val1, char op, decimal val2, decimal expectedResult)
        {
            var actual = Calculator.calculate(val1, op, val2);
            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData(5.3, '^', 4, 9.3)]
        [InlineData(5.11, '-', 4, 1.11)]
        [InlineData(5.5, '*', 2, 11)]
        [InlineData(10, '/', 2.5, 4)]
        private void DecimalTests(decimal val1, char op, decimal val2, decimal expectedResult)
        {
            var actual = Calculator.calculate(val1, op, val2);
            Assert.Equal(expectedResult, actual);
        }
    }
}