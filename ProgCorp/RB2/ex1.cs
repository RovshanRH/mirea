

class Program
{
    static double e, x, n;

    static double func(double x, double n)
    {
        double result = Math.Pow(-1, n + 1) * (Math.Pow(x, n) / n);
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Введите e с точностью < 0,01: ");
        e = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите x в диапозоне (-1, 1]: ");
        x = Convert.ToDouble(Console.ReadLine());
        if (x <= -1 && x > 1)
        {
            Console.WriteLine("Введите x в диапозоне (-1, 1]: ");
            x = Convert.ToDouble(Console.ReadLine());
        }
        Console.WriteLine("Введите n: ");
        n = Convert.ToDouble(Console.ReadLine());



        Console.WriteLine($"{n}-ый член ряда равен: {func(x, n)}");

    }
}