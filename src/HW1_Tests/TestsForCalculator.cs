using System;
using HW1;
using Xunit;

namespace HW1_Tests
{
    public class TestsForCalculator
    {
        [Theory]
        [InlineData(12, '+', 5, 17)]
        [InlineData(14, '-', 10, 4)]
        [InlineData(10, '*', 2, 20)]
        [InlineData(15, '/', 3, 5)]
        [InlineData(15, ':', 3, 5)]
        [InlineData(15, '^', 3, 0)]
        public void CalculateTestWithValidInput(int arg1, char operation, int arg2, double expectedValue)
        {
            var actualValue = Calculator.Calculate(arg1, operation, arg2); 
            Assert.Equal(expectedValue, actualValue);
        }
    }
}