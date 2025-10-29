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
        int killPower = 10*X;
        int hour = 1;
        int killed = 0;
        while (bacteria != 0 && killPower != 0)
        {
            bacteria *= 2;
            Console.WriteLine($"Бактерий размножилось: {bacteria}");

            if (killPower > 0)
            {
                killed = Math.Min(bacteria, killPower);
                bacteria -= killed;
                dropsLeft--;
                killPower--;
            }

            Console.WriteLine($"После {hour} часа убило {killed} бактерий, бактерий осталось {bacteria}");

            hour++;

        } 
    }
}