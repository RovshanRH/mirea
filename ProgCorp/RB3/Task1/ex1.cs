using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int reversed = ReverseRecursive(n, 0);
        Console.WriteLine(reversed);
    }
    
    static int ReverseRecursive(int n, int reversedSoFar)
    {
        if (n == 0)
            return reversedSoFar;
        
        int lastDigit = n % 10;
        int remaining = n / 10;
        int newReversed = reversedSoFar * 10 + lastDigit;
        
        return ReverseRecursive(remaining, newReversed);
    }
}