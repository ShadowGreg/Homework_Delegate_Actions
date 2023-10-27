using Homework.Core;

namespace Homework.View; 

public static class Calc {
    private static Stack<double> history = new Stack<double>();

    public static void RunCalculator() {
        bool exit = false;
        while (!exit) {
            Console.WriteLine("Enter a number:");
            double num = ReadNumberFromConsole();
            
            Console.WriteLine("Choose an operation (+, -, *, /, exit) or enter 'exit' to quit:");
            string operation = Console.ReadLine();
            
            if (string.IsNullOrEmpty(operation) || operation.Equals("exit")) {
                exit = true;
                continue;
            }
            
            if (operation == "cancel") {
                if (history.Count == 0) {
                    Console.WriteLine("No actions to cancel.");
                    continue;
                }
                history.Pop();
                if (history.Count == 0) {
                    Console.WriteLine("All actions canceled.");
                    continue;
                }
            }
            else {
                Console.WriteLine("Enter a number:");
                double num2 = ReadNumberFromConsole();
                CalculatorOperation calculatorOperation;
                switch (operation) {
                    case "+":
                        calculatorOperation = MathCalc.Add;
                        break;
                    case "-":
                        calculatorOperation = MathCalc.Subtract;
                        break;
                    case "*":
                        calculatorOperation = MathCalc.Multiply;
                        break;
                    case "/":
                        calculatorOperation = MathCalc.Divide;
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        continue;
                }
                double result = calculatorOperation(num, num2);
                Console.WriteLine("Result: " + result);
                history.Push(result);
            }
        }
    }

    private static double ReadNumberFromConsole() {
        double num;
        while (!double.TryParse(Console.ReadLine(), out num)) {
            Console.WriteLine("Invalid number format. Please try again:");
        }
        return num;
    }
}