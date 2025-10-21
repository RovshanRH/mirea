#define USE_PROGRAM4

class Program_4
{
    static double user_number;

    static double START = 0;
    static double END = 63;
    static double medium, choose;


    static void Main()
    {
        user_number = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < 7; i++)
        {
            medium = 0;
            choose = 0;

            
            medium = (END - START) / 2;
            Console.WriteLine("Ваше число больше {0} ?", medium);
            choose = Convert.ToDouble(Console.ReadLine());
            if (choose == 1)
            {
                START = medium;
            }
            else if (choose == 0)
            {
                END = medium;
            }

        }
        if (medium == user_number)
        {
            Console.WriteLine("Ваше число: {0}", medium);
        }
    }
}