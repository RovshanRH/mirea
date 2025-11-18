using System;
using System.Linq;
using System.Collections.Generic;


class Booking
{
    static public Dictionary<string, Booking> bookings = new Dictionary<string, Booking>();
    private string ID;
    private string NAME;
    private string PHONE_NUMBER;
    private string DATE_START;
    private string DATE_END;
    private string COMMENT;
    public Table TABLE;

    public Booking(string id, string name, string phoneNumber, string dateStart, string dateEnd, string comment, Table table)
    {
        ID = id;
        NAME = name;
        PHONE_NUMBER = phoneNumber;
        DATE_START = dateStart;
        DATE_END = dateEnd;
        COMMENT = comment;
        TABLE = table;
    }
    // Создание бронирования
    static public void createBooking(string id, string name, string phoneNumber, string dateStart, string dateEnd, string comment, Table table)
    {
        Booking booking = new Booking(id, name, phoneNumber, dateStart, dateEnd, comment, table);
        bookings[booking.ID] = booking;
        table.schedule.Add(booking.DATE_START, booking.DATE_END);
        Console.WriteLine($"Бронирование создано по ID: {booking.ID}");
    }
    static public void changeInfoBooking(string id, string name = "Имя Фамилия", string phoneNumber = "+7 (999) 999-99-99", string dateStart = "01.01.2024 19:00", string dateEnd = "01.01.2024 21:00", string comment = "Комментарий")
    {
        if (!bookings.ContainsKey(id))
        {
            Console.WriteLine($"Бронирование с ID: {id} не найдено.");
            return;
        }
        Booking booking = bookings[id];
        if (booking.TABLE.schedule.ContainsKey(booking.DATE_START))
        {
            booking.DATE_START = dateStart;
            booking.DATE_END = dateEnd;
        }
        booking.NAME = name;
        booking.PHONE_NUMBER = phoneNumber;
        booking.COMMENT = comment;
        Console.WriteLine($"Информация о бронировании с ID: {id} изменена");
    }
    static public void deleteBooking(string id)
    {
        if (!bookings.ContainsKey(id))
        {
            Console.WriteLine($"Бронирование с ID: {id} не найдено.");
            return;
        }
        bookings.Remove(id);
        Console.WriteLine($"Бронирование с ID: {id} удалено");
    }
    static public void printBookingTables()
    {
        if (bookings.Count == 0)
        {
            Console.WriteLine("Нет созданных бронирований.");
            return;
        }
        for (int i = 0; i < bookings.Count; i++)
        {
            Booking booking = bookings.Values.ElementAt(i);
            Console.WriteLine(Table.JoinWithFill("Бронирование ID: ", $"{booking.ID}"));
            Console.WriteLine(Table.JoinWithFill("Имя: ", $"{booking.NAME}"));
            Console.WriteLine(Table.JoinWithFill("Телефон: ", $"{booking.PHONE_NUMBER}"));
            Console.WriteLine(Table.JoinWithFill("Дата начала: ", $"{booking.DATE_START}"));
            Console.WriteLine(Table.JoinWithFill("Дата конца: ", $"{booking.DATE_END}"));
            Console.WriteLine(Table.JoinWithFill("Комментарий: ", $"{booking.COMMENT}"));
            Console.WriteLine();
        }
    }
    static public void printSchedule(string TableId)
        {
            // Находим бронирования для данного стола
            var tableBookings = bookings.Values
                .Where(booking => booking.TABLE.id == TableId)
                .ToList();

            Console.WriteLine($"Расписание для стола ID: {TableId}:");

            // Выводим временные интервалы
            for (int hour = 9; hour < 18; hour++) // с 9:00 до 17:00
            {
                string timeSlot = $"{hour}:00-{hour + 1}:00";
                string bookingInfo = "Свободно";

                // Проверяем, есть ли бронирование на этот временной интервал
                foreach (var booking in tableBookings)
                {
                    // Здесь должна быть логика проверки пересечения временных интервалов
                    // Это упрощенная версия - просто показываем первое найденное бронирование
                    bookingInfo = $"ID: {TableId}, Имя: {booking.NAME}, Телефон: {booking.PHONE_NUMBER}";
                    break;
                }

                Console.WriteLine(Table.JoinWithFill(timeSlot, bookingInfo));
            }
        }
    static public void printFreeBookingTables()
    {
        if (Table.tables.Count == 0)
        {
            Console.WriteLine("Нет доступных столов для бронирования.");
            return;
        }
        for (int i = 0; i < Table.tables.Count; i++)
        {
            Table table = Table.tables.Values.ElementAt(i);
            bool isBooked = false;
            for (int j = 0; j < bookings.Count; j++)
            {
                Booking booking = bookings.Values.ElementAt(j);
                if (booking.TABLE.id == table.id)
                {
                    isBooked = true;
                    break;
                }
            }
            if (!isBooked)
            {
                Console.WriteLine(Table.JoinWithFill("Свободный стол ID: ", $"{table.id}"));
                Console.WriteLine(Table.JoinWithFill("Расположение: ", $"{table.placement}"));
                Console.WriteLine(Table.JoinWithFill("Количество мест: ", $"{table.seats_number}"));
                Console.WriteLine();
            }
        }
        
    }
    static public Table searchBookingTable(string last_for_numbers)
    {
        for (int i = 0; i < Booking.bookings.Count; i++)
        {
            Booking booking = Booking.bookings.Values.ElementAt(i);
            if (booking.PHONE_NUMBER.EndsWith(last_for_numbers))
            {
                return booking.TABLE;
            }
        }
        return null;
    }

}
