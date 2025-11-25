using System;

public class Dish
{
    public enum Status 
    { 
        Drinks, Salads, ColdDishes, HotSnacks, Soups, HotDishes, Desserts 
    }
    
    public enum FoodType 
    { 
        Spicy, Vegan, Halal, Kosher 
    }

    // Используем свойства вместо полей
    public int Id;
    public string Name;
    public string Composition;
    public string Weight;
    public double Price;
    public Status DishStatus;
    public int TimeOfCooking;
    public FoodType Type;
    public static Dictionary<int, Dish> Dishs = new Dictionary<int, Dish>();

    public Dish(
        int id,
        string name,
        string composition,
        string weight,
        double price,
        Status status,
        int timeOfCooking,
        FoodType type
    )
    {
        Id = id;
        Name = name;
        Composition = composition;
        Weight = weight;
        Price = price;
        DishStatus = status;
        TimeOfCooking = timeOfCooking;
        Type = type;
    }
    public static void newDish(
        int id,
        string name,
        string composition,
        string weight,
        double price,
        Status status,
        int timeOfCooking,
        FoodType type
    )
    {
        Dish Dish = new Dish(
            id,
            name,
            composition,
            weight,
            price,
            status,
            timeOfCooking,
            type
        );
        Dishs.Add(Dish.Id, Dish);
        Console.WriteLine($"Заказ создан с ID: {Dish.Id}");
    }
    public void printDishInfo(int id)
    {
        if (!Dishs.ContainsKey(id))
        {
            Console.WriteLine($"Заказ с ID: {id} не найден.");
            return;
        }
        Dish Dish = Dishs[id];
        Console.WriteLine($"ID: {Dish.Id}");
        Console.WriteLine($"Название: {Dish.Name}");
        Console.WriteLine($"Состав: {Dish.Composition}");
        Console.WriteLine($"Вес: {Dish.Weight}");
        Console.WriteLine($"Цена: {Dish.Price}");
        Console.WriteLine($"Статус: {Dish.DishStatus}");
        Console.WriteLine($"Время приготовления: {Dish.TimeOfCooking} минут");
        Console.WriteLine($"Тип еды: {Dish.Type}");
    }
    public void deleteDish(int id)
    {
        if (!Dishs.ContainsKey(id))
        {
            Console.WriteLine($"Заказ с ID: {id} не найден.");
            return;
        }
        Dishs.Remove(id);
        Console.WriteLine($"Заказ с ID: {id} удален.");
    }
    public static void changeInfoDish(int id,
    string name, 
    string composition,
    string weight,
    double price,
    Status status,
    int timeOfCooking,
    FoodType type
    )
    {
        if (!Dishs.ContainsKey(id))
        {
            Console.WriteLine($"Заказ с ID: {id} не найден.");
            return;
        }
        Dish Dish = Dishs[id];
        Dish.Name = name;
        Dish.Composition = composition;
        Dish.Weight = weight;
        Dish.Price = price;
        Dish.DishStatus = status;
        Dish.TimeOfCooking = timeOfCooking;
        Dish.Type = type;
        Console.WriteLine($"Информация о заказе с ID: {id} изменена.");
    }
    public static void printdishMenu()
    {
        foreach (var status in new string[] { "Drinks", "Salads", "ColdDishes", "HotSnacks", "Soups", "HotDishes", "Desserts" })
        {
            Console.WriteLine($"\n--- {status} ---");
            foreach (var dish in Dishs.Values)
            {
                if (dish.DishStatus.ToString() == status)
                {
                    Console.WriteLine($"ID: {dish.Id}, Название: {dish.Name}, Цена: {dish.Price}");
                }
            }
            Console.WriteLine();
        }
    }
}