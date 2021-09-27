using System;
using System.Linq;

namespace HW1
{
    public class Parser
    {
        private static char[] operations = {'+', '-', '*', '/', ':'};
        public static int TryParse(string[] args, out int num1, out char operation, out int num2)
        {
            if (args.Length < 3)
                throw new ArgumentException();
            var isFirstArgInt = int.TryParse(args[0], out num1);
            var isOperationChar = char.TryParse(args[1], out operation);
            var isSecondArgInt = int.TryParse(args[2], out num2);

            if (!(isFirstArgInt && isSecondArgInt))
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} are not a valid arguments");
                return 1;
            }
            
            if (!(isOperationChar && operations.Contains(operation)))
            {
                Console.WriteLine($"{args[1]} is not a supported operation");
                return 2;
            }

            if (num2 == 0 && (operation == '/' || operation == ':'))
            {
                Console.WriteLine("Dividing by zero");
                return 3;
            }

            return 0;
        }
    }
}