using System;

public class Order
{
    private static Dictionary<int, Order> Orders = new Dictionary<int, Order>();
    public int OrderId {get; private set;}
    public int TableId {get; private set; }
    public List<Dish> Dishes {get; private set; }
    public static Dictionary<int, Order>? ClosedOrders {get; private set; }
    public string comment {get; private set; }
    public string timeStart {get; private set; }
    public int officiant {get; private set;  }
    public string timeEnd {get; private set; }

    public int price {get; private set; }

    public static Dictionary<Dish, int> DishStatistics = new Dictionary<Dish, int>();

    public Order(int orderId, int tableId, List<Dish> dishes, string comment, string timeStart, int officiant, string timeEnd, int price)
    {
        OrderId = orderId;
        TableId = tableId;
        Dishes = dishes;
        this.comment = comment;
        this.timeStart = timeStart;
        this.officiant = officiant;
        this.timeEnd = timeEnd;
        this.price = price;
    }
    public static void newOrder(int orderId, int tableId, List<Dish> dishes, string comment, string timeStart, int officiant, string timeEnd, int price)
    {
        Order order = new Order(orderId, tableId, dishes, comment, timeStart, officiant, timeEnd, price);
        Orders.Add(orderId, order);
    }

    public static void changeInfoOfOrder(int orderId, int tableId, List<Dish> dishes, string comment, string timeStart, int officiant, string timeEnd, int price)
    {
        if (!Orders.ContainsKey(orderId))
        {
            Console.WriteLine($"Заказ с ID: {orderId} не найден.");
            return;
        }
        Order order = Orders[orderId];
        order.TableId = tableId;
        order.Dishes = dishes;
        order.comment = comment;
        order.timeStart = timeStart;
        order.officiant = officiant;
        order.timeEnd = timeEnd;
        order.price = price;
    }

    public static void printOrderInfo(int orderId)
    {
        if (!Orders.ContainsKey(orderId))
        {
            Console.WriteLine($"Заказ с ID: {orderId} не найден.");
            return;
        }
        Order order = Orders[orderId];
        Console.WriteLine($"ID заказа: {order.OrderId}");
        Console.WriteLine($"ID стола: {order.TableId}");
        Console.WriteLine($"Блюда в заказе: ");
        foreach (var dish in order.Dishes)
        {
            Console.WriteLine($" - Блюдо ID: {dish.Id}, Название: {dish.Name}, Цена: {dish.Price}");
        }
        Console.WriteLine($"Комментарий: {order.comment}");
        Console.WriteLine($"Время начала: {order.timeStart}");
        Console.WriteLine($"Официант ID: {order.officiant}");
        Console.WriteLine($"Время окончания: {order.timeEnd}");
        Console.WriteLine($"Цена: {order.price}");
    }

    public static void closeOrder(int orderId)
    {
        if (!Orders.ContainsKey(orderId))
        {
            Console.WriteLine($"Заказ с ID: {orderId} не найден.");
            return;
        }
        Order order = Orders[orderId];
        Orders.Remove(orderId);

        foreach (var dish in order.Dishes)
        {
            if (DishStatistics.ContainsKey(dish))
            {
                DishStatistics[dish]++;
            }
            else
            {
                DishStatistics[dish] = 1;
            }
        }

        if (ClosedOrders == null)
        {
            ClosedOrders = new Dictionary<int, Order>();
        }
        ClosedOrders.Add(orderId, order);
    }

    public static void printClosedOrder(int id)
    {
        if (ClosedOrders == null || ClosedOrders.Count == 0)
        {
            Console.WriteLine("Нет закрытых заказов.");
            return;
        }
        if (!ClosedOrders.ContainsKey(id))
        {
            Console.WriteLine($"Закрытый заказ с ID: {id} не найден.");
            return;
        }
        Order order = ClosedOrders[id];
        Console.WriteLine($"Столик: {order.TableId}");
        Console.WriteLine($"Официант: {order.officiant}");
        Console.WriteLine($"Период обсуживания: с {order.timeStart} по {order.timeEnd}\n");
        
        double Result = 0;
        foreach (var category in new string[]{"Spicy", "Vegan", "Halal", "Kosher"})
        {
            Console.WriteLine($"{category}");
            foreach (var dish in order.Dishes)
            {
                if (dish.Type.ToString() == category)
                {
                    Result += dish.Price;
                    Console.WriteLine($"{dish.Name} \t Цена: {dish.Price}");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Итог счета: {Result}\n");
    
    }
    public static void countAllClosedOrdersPrice()
    {
        if (ClosedOrders == null || ClosedOrders.Count == 0)
        {
            Console.WriteLine("Нет закрытых заказов.");
            return;
        }
        double Total = 0;
        foreach (var order in ClosedOrders.Values)
        {
            Total += order.price;
        }
        Console.WriteLine($"Общая сумма всех закрытых заказов: {Total}");
    }

    public static void countOfficientClosedOrders()
    {
       if (ClosedOrders == null || ClosedOrders.Count == 0)
        {
            Console.WriteLine("Нет закрытых заказов.");
            return;
        }
        Dictionary<int, double> officiantTotals = new Dictionary<int, double>();
        foreach (var order in ClosedOrders.Values)
        {
            if (!officiantTotals.ContainsKey(order.officiant))
            {
                officiantTotals[order.officiant] = 0;
            }
            officiantTotals[order.officiant]++;
        }
        foreach (var kvp in officiantTotals)
        {
            Console.WriteLine($"Официант ID: {kvp.Key} - Количество закрытых заказов: {kvp.Value}");
        }
    }

    public static void printDishStatistics()
    {
        if (DishStatistics.Count == 0)
        {
            Console.WriteLine("Нет статистики по блюдам.");
            return;
        }
        Console.WriteLine("Статистика по блюдам:");
        foreach (var kvp in DishStatistics)
        {
            Console.WriteLine($"Блюдо: {kvp.Key.Name}, Количество заказов: {kvp.Value}");
        }
    }

}