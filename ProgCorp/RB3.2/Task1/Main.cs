using System;
using BookingSystem.Table;
using BookingSystem.Booking;

class main
{
    static private Dictionary<int, string> commandDesc = new Dictionary<int, string>
    {
        {1, "Создать стол"},
        {2, "Созданть бронь"},
        {3, "Изменение брони"},
        {4, "Отмена брони"},
        {5, "Редактирование информации стола"},
        {6, "Вывод информации о столе"},
        {7, "Вывод перечня всех доступных для бронирования столов"},
        {8, "Вывод перечня всех бронирований" },
        {9, "Поиск информации о бронировании"},
        {0, "Выход из программы"}
    };

    private static void printCommands()
    {
        for (int i = 0; i < commandDesc.Count; i++)
        {
            Console.WriteLine($"{i} - {commandDesc[i]}");
        }
    }

    static void Main()
    {
        Console.WriteLine("Система бронирования");
        while (true)
        {
            printCommands();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Создание стола...");
                    Console.WriteLine("Введите ID стола:");
                    string tableId = Console.ReadLine();
                    Console.WriteLine("Введите расположение стола:");
                    string placement = Console.ReadLine();
                    Console.WriteLine("Введите количество мест за столом:");
                    int seatsNumber = int.Parse(Console.ReadLine());
                    Table.newTable(tableId, placement, seatsNumber, new Dictionary<string, string>());
                    break;
                case 2:
                    Console.WriteLine("Создание брони...");
                    Console.WriteLine("Введите ID брони:");
                    string bookingId = Console.ReadLine();
                    Console.WriteLine("Введите имя клиента:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона клиента:");
                    string phoneNumber = Console.ReadLine();
                    Console.WriteLine("Введите дату и время начала бронирования (формат: ДД.ММ.ГГГГ ЧЧ:ММ):");
                    string dateStart = Console.ReadLine();
                    Console.WriteLine("Введите дату и время окончания бронирования (формат: ДД.ММ.ГГГГ ЧЧ:ММ):");
                    string dateEnd = Console.ReadLine();
                    Console.WriteLine("Введите комментарий к бронированию:");
                    string comment = Console.ReadLine();
                    Console.WriteLine("Введите ID стола для бронирования:");
                    string bookedTableId = Console.ReadLine();
                    if (Table.tables.ContainsKey(bookedTableId))
                    {
                        Table bookedTable = Table.tables[bookedTableId];
                        Booking.createBooking(bookingId, name, phoneNumber, dateStart, dateEnd, comment, bookedTable);
                    }
                    else
                    {
                        Console.WriteLine($"Стол с ID {bookedTableId} не найден.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Изменение брони...");
                    Console.WriteLine("Введите ID брони для изменения:");
                    string bookingIdToChange = Console.ReadLine();
                    Booking.changeInfoBooking(bookingIdToChange);
                    break;
                case 4:
                    Console.WriteLine("Отмена брони...");
                    Console.WriteLine("Введите ID брони для отмены:");
                    string bookingIdToDelete = Console.ReadLine();
                    Booking.deleteBooking(bookingIdToDelete);
                    break;
                case 5:
                    Console.WriteLine("Редактирование информации стола...");
                    Table.changeInfoTable(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine("Введите id стола: ");
                    Table.printTableInfo(Console.ReadLine());
                    break;
                case 7:
                    // Реализация вывода перечня...
                    Console.WriteLine("Перечень всех доступных для бронирования столов:");
                    Booking.printFreeBookingTables();
                    break;
                case 8:
                    // Реализация вывода перчня...
                    Console.WriteLine("Перечень всех бронирований:");
                    Booking.printBookingTables();
                    break;
                case 9:
                    // Поиск
                    Console.WriteLine("Введите последние 4 цифры номера телефона: ");
                    string last_four_numbers = Console.ReadLine();
                    Table foundTable = Booking.searchBookingTable(last_four_numbers);
                    if (foundTable != null)
                    {
                        Table.printTableInfo(foundTable.id);
                    }
                    else
                    {
                        Console.WriteLine("Бронирование не найдено.");
                    }
                    break;
                case 0:
                    return;
            }
        }
    }
}