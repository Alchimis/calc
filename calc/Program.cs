namespace Calculator
{
    partial class Program
    {
        public static int Main(string[] argvs)
        {
            Console.WriteLine("Вводите математичекие выражения, которые хотите выполнить \n" +
                "Если захотите выйдти из приложенияя прото введите ENTER");
            while (true)
            {
                string? Line = Console.ReadLine();
                if ((Line == null)||(Line == "")) { break; }
                string[] Operands = Line.Split(' ');
                double? result = Calculation(Operands);
                if (result != null) { Console.WriteLine("Результат "+result); }
            }
            Console.WriteLine("Программа закочила свою работу");
            return 0;
        }

        private static double? Calculation(string[] Operands) 
        {
            if(Operands.Length != 3) 
            {
                Console.Error.WriteLine("<Первое_число> <Математическая_операция> <Второе_число>");
                return null; 
            }
            double? firstNumber = StringToDouble(Operands[0]);
            if (firstNumber == null) { return null; };
            double? secondNumber = StringToDouble(Operands[2]);
            if(secondNumber == null) { return null; };
            switch (Operands[1]) 
            { 
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    if(secondNumber == 0) 
                    {
                        Console.WriteLine("Клёво на {0} делишь",secondNumber);
                        return null; 
                    };
                    return firstNumber / secondNumber;
                default:
                    Console.WriteLine("не предусмотренная математическая операция(+,-,*,/)");
                    return null;
            } 
        }
        private static Double? StringToDouble(string maybeInt) 
        {
            if (maybeInt != null) { 
                Double output = 0;
                try { 
                    output = Convert.ToDouble(maybeInt);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} не число",maybeInt); 
                    return null; 
                }
                catch (OverflowException) {Console.WriteLine("Число {0} слишком большое",maybeInt); return null; };
                return output; 
            }
            return null; 
        }
    }

}