using System;

class MarsBase
{
    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine()!);

        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine()!);

        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine()!);

        Console.Write("Введите w: ");
        int w = int.Parse(Console.ReadLine()!);

        Console.Write("Введите h: ");
        int h = int.Parse(Console.ReadLine()!);

        int d = 0;

        while (true)
        {
            int moduleWidth  = a + 2 * d;
            int moduleHeight = b + 2 * d;

            bool canFit = false;

            for (int orientation = 0; orientation < 2; orientation++)
            {
                int mw = moduleWidth;
                int mh = moduleHeight;

                if (orientation == 1)
                {
                    mw = moduleHeight;
                    mh = moduleWidth;
                }

                for (int rows = 1; rows <= n; rows++)
                {
                    int cols = (n + rows - 1) / rows; 

                    int totalWidth  = cols * mw;
                    int totalHeight = rows * mh;

                    if (totalWidth <= w && totalHeight <= h)
                    {
                        canFit = true;
                        break;
                    }
                }

                if (canFit) break;
            }

            if (!canFit)
                break;

            d++;
        }

        Console.WriteLine($"Ответ d = {d - 1}");
    }
}