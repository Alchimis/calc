namespace Calculator
{
    partial class Program
    {
        public static int Main(string[] argvs)
        {
            Console.WriteLine("Вводите математические выражения, которые хотите выполнить \n" +
                "например: 1 + 2; 2 * 3; 3 / 4; 4 - 5 \n" +
                "Если захотите выйдти из приложенияя просто введите ENTER");
            while (true)
            {
                string? Line = Console.ReadLine();
                if ((Line == null) || (Line == ""))
                {
                    break;
                }
                string[] Operands = Line.Split(' ');
                try
                {
                    double? result = Calculation(Operands);
                    Console.WriteLine("Результат " + result);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine("Программа закочила свою работу");
            return 0;
        }

        private static double? Calculation(string[] Operands)
        {
            if (Operands.Length != 3)
            {
                throw new Exception("<Первое_число> <Математическая_операция> <Второе_число>");
            }
            double firstNumber = ValidateValue(Operands[0]);
            double secondNumber = ValidateValue(Operands[2]);
            switch (Operands[1])
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    if (secondNumber == 0)
                    {
                        throw new Exception("Ноль не может быть делителем");
                    };
                    return firstNumber / secondNumber;
                default:
                    throw new Exception("не предусмотренная математическая операция(+,-,*,/)");
            }
        }
        private static double ValidateValue(string value)
        {
            if (!double.TryParse(value, out double number))
            {
                throw new Exception($"Значение - {value}, нельзя привести к типу double");
            }
            if (number == double.PositiveInfinity || number == double.NegativeInfinity)
            {
                throw new Exception($"Значение {value} слишком бльшое");
            }
            return number;
        }
    }

}