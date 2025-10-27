#define USE_PROGRAM2

using System;

class Program_2
{
    static void Main()
    {
        Console.WriteLine("Введите номер билета: ");
        int ticket = Convert.ToInt32(Console.ReadLine());

        if (ticket < 100000 || ticket > 999999)
        {
            Console.WriteLine("Ошибка: номер билета должен быть шестизначным!");
            return;
        }

        int originalTicket = ticket;
        int sumFirst = 0, sumLast = 0;

        for (int i = 0; i < 6; i++)
        {
            int digit = ticket % 10;
            if (i < 3)
                sumLast += digit;
            else
                sumFirst += digit;

            ticket /= 10;
        }

        bool isLucky = sumFirst == sumLast;
        Console.WriteLine(isLucky);
    }
}