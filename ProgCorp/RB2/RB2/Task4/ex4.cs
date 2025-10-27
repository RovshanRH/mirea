using System;


class Program_4
{
    static void Main()
    {
        Console.Write("Введите число от 0 до 63: ");
        if (!int.TryParse(Console.ReadLine(), out int user_number))
        {
            Console.WriteLine("Неверный ввод.");
            return;
        }
        if (user_number < 0 || user_number > 63)
        {
            Console.WriteLine("Число вне допустимого диапазона (0..63).");
            return;
        }

        int START = 0;
        int END = 63;
        int medium = 0;

        for (int i = 0; i < 7; i++)
        {
            medium = (START + END) / 2;
            Console.WriteLine($"Итерация {i + 1}: проверяю mid={medium} (диапазон {START}..{END})");

            if (user_number > medium)
            {
                START = medium + 1;
            }
            else
            {
                END = medium;
            }
        }

        int result = START;
        Console.WriteLine("Ваше число: {0}", result);
    }
}