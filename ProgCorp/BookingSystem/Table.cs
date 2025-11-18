using System;
using System.Collections.Generic;


public class Table
{
    static public Dictionary<string, Table> tables = new Dictionary<string, Table>();
    public string id;
    public string placement;
    public string[] PlacementOptions = { "у окна", "у прохода", "у выхода", "в глубине" };
    public int seats_number;
    public Dictionary<string, string> schedule = new Dictionary<string, string>();
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Placement { get; set; }
    public int Seats_number { get; set; }
    public Dictionary<string, Table> Schedule { get; set; }

    public static void PrintWithFill(Dictionary<string, string> data,
                                    int labelWidth = 12,
                                    char fill = '-')
    {
        int totalWidth = 40; // Общая ширина строки

        foreach (var kvp in data)
        {
            string label = kvp.Key.PadLeft(labelWidth);
            string value = kvp.Value;
            int fillCount = totalWidth - labelWidth - value.Length;

            string line = fillCount > 0
                ? label + new string(fill, fillCount) + value
                : label + value;

            Console.WriteLine(line);
        }
    }
    public static string JoinWithFill(
        string left,
        string right,
        int totalWidth = 40,
        char fillChar = '-')
    {
        // Вычисляем, сколько места остаётся между left и right
        int used = left.Length + right.Length;
        int fillCount = totalWidth - used;

        if (fillCount <= 0)
        {
            return left + right; // Не хватает места — просто склеиваем
        }

        string fill = new string(fillChar, fillCount);
        return left + fill + right;
    }

    public Table(string id,
                string placement,
                int seats_number,
                Dictionary<string, string> schedule)
    {
        this.id = id;
        this.placement = placement;
        this.seats_number = seats_number;
        this.schedule = schedule;
    }
    // создание стола
    static public void newTable(string id,
                                string placement,
                                int seats_number,
                                Dictionary<string, string> schedule)
    {
        Table table = new Table(id, placement, seats_number, schedule);

        tables[table.id] = table;
        Console.WriteLine($"Стол создан по ID: {table.id}");

    }
    // изменение информации стола
    static public void changeInfoTable(string id,
                                    string placement,
                                    int seats_number)
    {
        if (!tables.ContainsKey(id))
        {
            Console.WriteLine($"Стол с ID: {id} не найден.");
            return;
        }
        Table table = tables[id];
        if (table.schedule.Count > 0)
        {
            Console.WriteLine($"Невозможно изменить информацию о столе с ID: {id}, так как на него есть бронирования");
        }
        else
        {
            if (Array.Exists(table.PlacementOptions, element => element == placement))
            {
                Console.WriteLine($"Изменение расположения стола с ID: {id}");
                table.placement = placement;
            }
            else
            {
                Console.WriteLine("Некорректное расположение стола. Допустимые варианты: у окна, у прохода, у выхода, в глубине.");
                return;
            }

            table.seats_number = seats_number;
            Console.WriteLine($"Информация о столе с ID: {id} изменена");
        }
    }
    // вывод инфы про стол
    public static void printTableInfo(string id)
    {
        if (!tables.ContainsKey(id))
        {
            Console.WriteLine($"Стол с ID: {id} не найден.");
            return;
        }
        Table table = tables[id];
        Console.WriteLine(JoinWithFill("ID: ", $"{id}"));
        Console.WriteLine(JoinWithFill("Расположение: ", $"{table.placement}"));
        Console.WriteLine(JoinWithFill("Количество мест: ", $"{table.seats_number}"));
        Console.WriteLine("Расписание:\n");
        
        if (table.schedule.Count > 0)
        {
            PrintWithFill(table.schedule);
        }
        else
        {
            Console.WriteLine("Расписание пустое");
        }
    }
}



    