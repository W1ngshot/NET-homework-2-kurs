using HW2;
using Xunit;

namespace HW1_Tests
{
    public class TestsForParser
    {
        [Theory]
        [InlineData(1, new string[] {"a", "*", "1"})]
        [InlineData(1, new string[] {"41", "/", "t"})]
        public void ArgsAreNotValid(int expectedValue, string[] inputString)
        {
            var actualValue = Parser.TryParse(inputString, out _, out _, out _);
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(2, new string[] {"2", "**", "2"})]
        [InlineData(2, new string[] {"3", "t", "10"})]
        public void OperationsAreNotValid(int expectedValue, string[] inputString)
        {
            var actualValue = Parser.TryParse(inputString, out _, out _, out _);
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(3, new string[] {"5", "/", "0"})]
        [InlineData(3, new string[] {"5", ":", "0"})]
        public void DividingByZero(int expectedValue, string[] inputString)
        {
            var actualValue = Parser.TryParse(inputString, out _, out _, out _);
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(new string[] {"2", "+", "3"}, 0, 2, '+', 3)]
        [InlineData(new string[] {"7", "-", "2"}, 0, 7, '-', 2)]
        [InlineData(new string[] {"10", "/", "5"}, 0, 10, '/', 5)]
        [InlineData(new string[] {"20", ":", "10"}, 0, 20, ':', 10)]
        [InlineData(new string[] {"5", "*", "3"}, 0, 5, '*', 3)]
        public void InputIsCorrect(string[] args, int expValue, int expArg1, int expOperation, int expArg2)
        {
            var actualValue = Parser.TryParse(args, out int actArg1, out char actOperation, out int actArg2);
            Assert.Equal(expValue, actualValue);
            Assert.Equal(expArg1, actArg1);
            Assert.Equal(expOperation, actOperation);
            Assert.Equal(expArg2, actArg2);
        }
    }
}