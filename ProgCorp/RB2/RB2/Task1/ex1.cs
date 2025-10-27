#define PROGRAM_1

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите x (|x| <= 1): ");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите точность e (< 0.01): ");
        double e = double.Parse(Console.ReadLine());

        double sum = 0.0;
        double term = x;
        int n = 0;

        while (Math.Abs(term) >= e)
        {
            sum += term;
            n++;

            double numerator = 1.0;
            for (int i = 1; i <= n; i++)
            {
                numerator *= (2 * i - 1);
            }

            double denominator = 1.0;
            for (int i = 1; i <= n; i++)
            {
                denominator *= (2 * i);
            }

            term = (numerator / denominator) * Math.Pow(x, 2 * n + 1) / (2 * n + 1);
        }

        Console.WriteLine($"arcsin({x}) ≈ {sum:F6}");
        Console.WriteLine($"Проверка: {Math.Asin(x):F6}\n");

        Console.WriteLine("Введите n (номер члена, начиная с 0): ");
        n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите x: ");
        x = double.Parse(Console.ReadLine());

        if (n == 0)
        {
            term = x;
        }
        else
        {
            double numerator = 1.0;
            for (int i = 1; i <= n; i++)
            {
                numerator *= (2 * i - 1);
            }

            double denominator = 1.0;
            for (int i = 1; i <= n; i++)
            {
                denominator *= (2 * i);
            }

            term = (numerator / denominator) * Math.Pow(x, 2 * n + 1) / (2 * n + 1);
        }

        Console.WriteLine($"n-й член (n={n}): {term:F6}");
    }
}