// using Math;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public string[] M_Actions = ["M+", "M-", "MR"];


    public double Calculate(string[] oper, double val_1, double val_2) => oper[0] switch
    {
        "+" => val_1 + val_2,
        "-" => val_1 - val_2,
        "*" => val_1 * val_2,
        "/" => val_2 != 0 ? val_1 / val_2 : throw new DivideByZeroException(),
        "%" => val_1 % val_2,
        "1/x" => 1 / val_1,
        "x^2" => Math.Pow(val_1, 2),
        "sqrt" => Math.Sqrt(val_1),
        // "M+" => memory = val_1,
        // "M-" => memory = 0,
        // "MR" => val_1 = memory,
        _ => throw new NotImplementedException()


    };


    public void MemoryFunction(string mem_oper, double value_2, ref double memory, ref double value_2_out) 
    {
        switch (mem_oper)
        {
            case "M+":
                memory = value_2;
                break;
            case "M-":
                memory = 0;
                break;
            case "MR":
                value_2_out = memory;
                break;
            default:
                break;
        }
    }

    // public double MemoryRecall() {

    // }

    static void Main(string[] args)
    {
        Program program = new Program();
        double memory = 0;
        while (true)
        {
            Console.WriteLine("Первая переменная: ");
            double value_1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Операнда: ");
            string? operation = Console.ReadLine();

            Console.WriteLine("Вторая переменная: ");
            double value_2 = Convert.ToDouble(Console.ReadLine());

            string[] oper = operation != null ? operation.Split(" ") : [];
            Console.WriteLine($"Произошла операция {oper[0]} и {oper[1]}");


            // if (oper[1] != "M+" & oper[1] != "M-" & oper[1] != "MR")
            if (oper.Length != 1 && program.M_Actions.Contains(oper[1]))
            {
                double newValue_2 = value_2;
                program.MemoryFunction(oper[1], value_2, ref memory, ref newValue_2);
                value_2 = newValue_2;
                Console.WriteLine($"Операция выполнена, memory: {memory} {oper[1]}");
            }
            Console.WriteLine($"Результат: {program.Calculate(oper, value_1, value_2)}");

        }
    }

}
