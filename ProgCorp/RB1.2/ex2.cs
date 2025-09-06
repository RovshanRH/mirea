#define USE_PROGRAM2

using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

class Program2
{
    public static double NumberOfMoney;
    public static List<int> MoneyList = [100, 200, 500, 1000, 2000, 5000];
    public static void Main()
    {
        Console.WriteLine("Введите сумму: ");
        NumberOfMoney = Convert.ToInt32(Console.ReadLine());

        int MaxIndex = MoneyList.Count() - 1;
        int MaxValueOfMoney = MoneyList.Max();

        while (NumberOfMoney != 0)
        {

            if (NumberOfMoney % 100 != 0)
            {
                Console.WriteLine("Невозможно");
                break;
            }

            if (NumberOfMoney >= 150_000)
            {
                Console.WriteLine("За раз банкомат не выдаёт более 150.000 рублей");
            }

            if (NumberOfMoney < MaxValueOfMoney)
            {
                MaxValueOfMoney = MoneyList[MaxIndex--];
            }
            else
            {
                double N = NumberOfMoney / MaxValueOfMoney;
                NumberOfMoney = NumberOfMoney % MaxValueOfMoney;
                Console.WriteLine($"{Math.Floor(N)} кюпур по {MaxValueOfMoney}");
            }

        }



    }
}