using System;

namespace HW1
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var parseResult = Parser.TryParse(args, out var val1, out var operation, out var val2);
            if (parseResult != 0)
                return parseResult;

            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine(result);
            return 0;
        }
    }
}