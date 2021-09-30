namespace HW1
{
    public class Calculator
    {
        public static double Calculate(int arg1, char operation, int arg2)
        {
            var result = operation switch
            {
                '+' => arg1 + arg2,
                '-' => arg1 - arg2,
                '*' => arg1 * arg2,
                ':' => (double)arg1 / arg2,
                '/' => (double)arg1 / arg2,
                _   => 0
            };
            return result;
        }
    }
}