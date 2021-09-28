using Xunit;
using Program = HW2_Console.Program;

namespace HW1_Tests
{
    public class TestsForProgram
    {
        [Theory]
        [InlineData(new string[] {"14", "2", "2"}, 2)]
        [InlineData(new string[] {"14", "a", "2"}, 2)]
        [InlineData(new string[] {"a", "*", "2"}, 1)]
        [InlineData(new string[] {"12", "+", "t"}, 1)]
        [InlineData(new string[] {"14", "+", "3"}, 0)]
        [InlineData(new string[] {"8", "-", "5"}, 0)]
        public void InputTests(string[] args, int expectedResult)
        {
            var actualValue = Program.Main(args);
            Assert.Equal(expectedResult, actualValue);
        }
    }
}