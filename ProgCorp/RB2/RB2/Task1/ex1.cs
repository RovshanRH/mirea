#define PROGRAM_1

using System;

class Program_1
{
    static double calculation(double x, double eps)
    {
        double term = 1.0;
        double total = term;
        int n = 1;

        while (Math.Abs(term) > eps)
        {
            term = -term * (Math.Pow(x, 2 * n) / (2 * n * (2 * n - 1)));
            total += term;
            n++;
        }

        return total;

    }

    static void Main()
    {
        Console.Write("Введите x функции cos(x): ");
        double x_func = double.Parse(Console.ReadLine()!);

        Console.Write("Введите e < 0,01: ");
        double epsilon = double.Parse(Console.ReadLine()!);

        if (epsilon >= 0.01 || epsilon <= 0)
        {
            Console.WriteLine("Ошибка: e должно быть 0 < e < 0.01");
            return;
        }

        Console.WriteLine("Введите номер вычисляемого члена (n): ");
        int number = int.Parse(Console.ReadLine()!);

        double result_func = calculation(x_func, epsilon);
        
        Console.Write("Введите x ряда: ");
        double x_series = double.Parse(Console.ReadLine()!);
        
        int sign = (number % 2 == 0) ? 1 : -1;
        double sum = sign * (Math.Pow(x_series, 2 * number) / (2 * number * (2 * number - 1)));
        
        Console.WriteLine($"Значение от {x_func}: {result_func:F4}\nЧлен ряда под номером {number}: {sum:F4}");
    }
}

