
#define USE_PROGRAM1
using System.Globalization;

class Program1
{
    public static int DaysInMonth = 31; //май
    static List<int> RelaxDays = [1, 2, 3, 4, 5, 8, 9, 10];

    static List<int> Days = new List<int>();

    public static void CalculateWeekend()
    {
        int number = 0;
        for (int i = 0; i < 5; i++)
        {
            List<int> Week = new List<int>();
            for (int j = 0; j < 7; j++)
            {
                number++;
                Week.Add(number);
                // Console.WriteLine(number);
                if (j == 5 || j == 6)
                {
                    RelaxDays.Add(number);
                    // Console.WriteLine(number);
                }
            }
            Days.AddRange(Week);
        }
    }

    // public static bool FindRelaxDays(int StartingDay)
    // {
    //     // если не 1, то отсчитываем разницу от единицы и уменьшаем каждое число в массиве на эту разницу,
    //     // после чего выписать числа в релакс дни 
    // }

    static void Main()
    {

        CalculateWeekend();
        // Console.WriteLine(RelaxDays);
        foreach (int i in RelaxDays)
        {
            Console.WriteLine(i);
        }

        while (true)
        {
            Console.WriteLine("Введите номер дня недели, с которого начинается месяц (1-пн,...7-вс)");
            int WeekNumber = Convert.ToInt32(Console.ReadLine());

            if (WeekNumber < 1 && WeekNumber > 7)
            {
                Console.WriteLine("Введите валидный номер дня недели, с которого начинается месяц (1-пн,...7-вс)");
                WeekNumber = Convert.ToInt32(Console.ReadLine());

                // int diff = WeekNumber - 1;
                // if (diff != 0)
                // {

                // }

            }
            else

            {
                Console.WriteLine("Введите день месяца: ");
                int DayNumber = Convert.ToInt32(Console.ReadLine());

                if (DayNumber < 1 && DayNumber > 31)
                {
                    Console.WriteLine("Введите валидный номер дня месяца: ");
                    DayNumber = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("----Проверяем выходной ли день----");

                    //string WhatADay;
                    string WhatADay = RelaxDays.Contains(DayNumber) ? "Выходной" : "Рабочий";
                    Console.WriteLine($"{WhatADay} день");

                }
            }

        }


    }
}
