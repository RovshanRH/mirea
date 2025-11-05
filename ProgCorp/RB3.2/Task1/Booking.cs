using System;
class Booking
{
    static private Dictionary<string, Booking> bookings = new Dictionary<string, Booking>();
    private string ID;
    private string NAME;
    private string PHONE_NUMBER;
    private string DATE_START;
    private string DATE_END;
    private string COMMENT;
    private Table TABLE;

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
        Console.WriteLine($"Бронирование создано по ID: {booking.ID}");
    }
    static public void changeInfoBooking(string id, string name = "Имя Фамилия", string phoneNumber = "+7 (999) 999-99-99", string dateStart = "01.01.2024 19:00", string dateEnd = "01.01.2024 21:00", string comment = "Комментарий", Table table = null)
    {
        Booking booking = bookings[id];
        booking.NAME = name;
        booking.PHONE_NUMBER = phoneNumber;
        booking.DATE_START = dateStart;
        booking.DATE_END = dateEnd;
        booking.COMMENT = comment;
        booking.TABLE = table;
    }
    static public void deleteBooking(string id)
    {
        bookings.Remove(id);
        Console.WriteLine($"Бронирование с ID: {id} удалено");
    }
    static public void printBookingTables()
    {
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
    
}