using System;

class CoffeeMachine
{
    static void Main()
    {
        // 1. Ввод начального количества ингредиентов (один раз)
        Console.Write("Введите количество воды в мл: ");
        int water = int.Parse(Console.ReadLine()!);

        Console.Write("Введите количество молока в мл: ");
        int milk = int.Parse(Console.ReadLine()!);

        // счётчики
        int americanoCount = 0;
        int latteCount     = 0;
        int totalMoney     = 0;

        const int AMERICANO_WATER = 300;   // мл
        const int AMERICANO_PRICE = 150;   // руб.

        const int LATTE_WATER = 30;        // мл
        const int LATTE_MILK  = 270;       // мл
        const int LATTE_PRICE = 170;       // руб.

        // 2. Обслуживаем посетителей, пока хватает хотя бы одного напитка
        while (true)
        {
            // проверка, можно ли приготовить хотя бы один из напитков
            bool canAmericano = water >= AMERICANO_WATER;
            bool canLatte     = water >= LATTE_WATER && milk >= LATTE_MILK;

            if (!canAmericano && !canLatte)   // ни один напиток невозможен
                break;

            // запрос у посетителя
            Console.Write("Выберите напиток (1 — американо, 2 — латте): ");
            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 1)                     // американо
            {
                if (canAmericano)
                {
                    water -= AMERICANO_WATER;
                    americanoCount++;
                    totalMoney += AMERICANO_PRICE;
                    Console.WriteLine("Ваш напиток готов.");
                }
                else
                {
                    // хватает воды для латте, но не для американо → сообщение о воде
                    Console.WriteLine("Не хватает воды");
                }
            }
            else if (choice == 2)                // латте
            {
                if (canLatte)
                {
                    water -= LATTE_WATER;
                    milk  -= LATTE_MILK;
                    latteCount++;
                    totalMoney += LATTE_PRICE;
                    Console.WriteLine("Ваш напиток готов.");
                }
                else if (!canAmericano)          // воды не хватает даже на американо
                {
                    Console.WriteLine("Не хватает воды");
                }
                else                             // воды хватает, но молока нет
                {
                    Console.WriteLine("Не хватает молока");
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор, попробуйте ещё раз.");
            }
        }

        // 3. Итоговый отчёт
        Console.WriteLine("*Отчёт*");
        Console.WriteLine("Ингредиентов осталось:");
        Console.WriteLine($"    Вода: {water} мл");
        Console.WriteLine($"    Молоко: {milk} мл");
        Console.WriteLine($"Кружек американо приготовлено: {americanoCount}");
        Console.WriteLine($"Кружек латте приготовлено: {latteCount}");
        Console.WriteLine($"Итого: {totalMoney} рублей.");
    }
}