
static string func(int n)
{
    if (n == 0) return "";
    return  $"{(n%10)}" + $"{func(n/10)}";
}
Console.WriteLine($"{func(123456)}");