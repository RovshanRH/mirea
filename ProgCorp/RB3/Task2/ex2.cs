static int accerman(int m, int n)
{
    if (m == 0) return n + 1;
    if (m > 0 && n == 0) return accerman(m - 1, 1);
    if (m > 0 && n > 0) return accerman(m - 1, accerman(m, n - 1));
    return 1;
}
Console.WriteLine("Ввод: m=");
int m = int.Parse(Console.ReadLine());
Console.WriteLine("n=");
int n = int.Parse(Console.ReadLine());
Console.WriteLine($"Вывод: A(m,n)={accerman(m, n)}");