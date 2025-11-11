using System;
using BookingSystem.Table;


namespace BookingSystem.Booking
{
    using BookingSystem.Table;
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
            Console.WriteLine($"Информация о бронировании с ID: {id} изменена");
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
        static public void printFreeBookingTables()
        {
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
}