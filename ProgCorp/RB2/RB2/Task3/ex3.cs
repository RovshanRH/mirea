using System;

class Program_3
{
    private static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static (double N, double M) Finding_results(double N, double M)
    {
        if (M == 0)
            throw new DivideByZeroException("Знаменатель равен нулю");

        int sign = 1;
        if ((N < 0 && M > 0) || (N > 0 && M < 0))
            sign = -1;

        double absN = Math.Abs(N);
        double absM = Math.Abs(M);

        const long precision = 1_000_000_000;
        long intN = (long)Math.Round(absN * precision);
        long intM = (long)Math.Round(absM * precision);

        long gcd = GCD((int)(intN % intM == 0 ? intM : intN), (int)(intN % intM == 0 ? intN : intM));
        if (gcd == 0) gcd = 1;

        double reducedN = (intN / gcd) * sign / precision;
        double reducedM = intM / gcd / precision;

        return (reducedN, reducedM);
    }

    static void Main()
    {
        Console.WriteLine("Введите числитель: ");
        double N = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите знаменатель: ");
        double M = Convert.ToDouble(Console.ReadLine());

        try
        {
            var (N1, M1) = Finding_results(N, M);
            Console.WriteLine($"Результат: {N1} / {M1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}