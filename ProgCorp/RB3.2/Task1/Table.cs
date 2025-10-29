using System;
using System.Collections.Generic;
public class Table
{
    private string id;
    private string placement;
    private int seats_number;
    private Dictionary<string, string> schedule = new Dictionary<string, string>();
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Placement { get; set; }
    public int Seats_number { get; set; }
    public Dictionary<string, Table> Schedule { get; set; }

    private static void PrintWithFill(Dictionary<string, string> data,
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
    private static string JoinWithFill(
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
    static public Table newTable(string id,
                                 string placement,
                                 int seats_number,
                                 Dictionary<string, string> schedule)
    {
        return new Table(id, placement, seats_number, schedule);
    }
    // изменение информации стола
    static public void changeInfoTable(Table table,
                                       string id = "01",
                                       string placement = "у окна",
                                       int seats_number = 3,
                                       Dictionary<string, string> schedule = null)
    {
        table.id = id;
        table.placement = placement;
        table.seats_number = seats_number;
        table.schedule = schedule;
    }
    // вывод инфы про стол
    static public void printTableInfo(Table table)
    {
        Console.WriteLine(JoinWithFill("ID: ", $"{table.id}"));
        Console.WriteLine(JoinWithFill("Расположение: ", $"{table.placement}"));
        Console.WriteLine(JoinWithFill("Количество мест: ", $"{table.seats_number}"));
        Console.WriteLine("Расписание:\n");
        PrintWithFill(table.schedule);
    }


} 


