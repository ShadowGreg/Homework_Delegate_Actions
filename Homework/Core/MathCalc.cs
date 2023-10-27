namespace Homework.Core; 

public static class MathCalc {
    public static double Add(double num1, double num2) {
        return num1 + num2;
    }

    public static double Subtract(double num1, double num2) {
        return num1 - num2;
    }

    public static double Multiply(double num1, double num2) {
        return num1 * num2;
    }

    public static double Divide(double num1, double num2) {
        if (num2 == 0) {
            Console.WriteLine("Деление на ноль невозможно.");
            return 0;
        }

        return num1 / num2;
    }
}