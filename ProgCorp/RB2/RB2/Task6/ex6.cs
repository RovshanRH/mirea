using System;

class PetriDish
{
    static void Main()
    {
        Console.Write("Введите количество бактерий: ");
        int N = int.Parse(Console.ReadLine()!);

        Console.Write("Введите количество антибиотика: ");
        int X = int.Parse(Console.ReadLine()!);

        int bacteria = N;
        int dropsLeft = X;
        int killPower = 10;
        int hour = 1;

        while (bacteria > 0)
        {
            bacteria *= 2;

            if (dropsLeft > 0)
            {
                int killed = Math.Min(bacteria, killPower);
                bacteria -= killed;
                dropsLeft--;
                killPower--;
            }

            Console.WriteLine($"После {hour} часа бактерий осталось {bacteria}");

            hour++;

            if (hour > 1000) break;
        }
    }
}