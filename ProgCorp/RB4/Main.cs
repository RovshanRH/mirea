using System;
using System.Collections.Generic;
using System.Linq;

class MainProgram
{
    // private static List<Dish> availableDishes = new List<Dish>();
    private static int nextOrderId = 1;

    static void Main()
    {
        // InitializeSampleData();
        ShowMainMenu();
    }

    // static void InitializeSampleData()
    // {
    //     // Создаем несколько демонстрационных блюд
    //     availableDishes.Add(new Dish(1, "Салат Цезарь", "Курица, салат, сухарики, соус цезарь", "300г", 450, Dish.Status.Salads, 15, Dish.FoodType.Spicy));
    //     availableDishes.Add(new Dish(2, "Веганский салат", "Овощи, зелень, оливковое масло", "250г", 320, Dish.Status.Salads, 10, Dish.FoodType.Vegan));
    //     availableDishes.Add(new Dish(3, "Стейк", "Говядина, специи", "400г", 890, Dish.Status.HotDishes, 25, Dish.FoodType.Halal));
    //     availableDishes.Add(new Dish(4, "Торт Наполеон", "Тесто, крем", "200г", 280, Dish.Status.Desserts, 5, Dish.FoodType.Kosher));

    //     // Добавляем блюда в систему
    //     foreach (var dish in availableDishes)
    //     {
    //         Dish.newDish(dish.Id, dish.Name, dish.Composition, dish.Weight, dish.Price, 
    //                     dish.DishStatus, dish.TimeOfCooking, dish.Type);
    //     }
    // }

    static void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ РЕСТОРАНОМ ===");
            Console.WriteLine("1. Управление блюдами");
            Console.WriteLine("2. Управление заказами");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите опцию: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowDishMenu();
                    break;
                case "2":
                    ShowOrderMenu();
                    break;
                case "3":
                    Console.WriteLine("Выход из системы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowDishMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== УПРАВЛЕНИЕ БЛЮДАМИ ===");
            Console.WriteLine("1. Создание блюда");
            Console.WriteLine("2. Редактирование блюда");
            Console.WriteLine("3. Вывод информации о блюде");
            Console.WriteLine("4. Удаление блюда");
            Console.WriteLine("5. Просмотр меню блюд");
            Console.WriteLine("6. Статистика блюд");
            Console.WriteLine("7. Назад в главное меню");
            Console.Write("Выберите опцию: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateDish();
                    break;
                case "2":
                    EditDish();
                    break;
                case "3":
                    ShowDishInfo();
                    break;
                case "4":
                    DeleteDish();
                    break;
                case "5":
                    ShowAllDishes();
                    break;
                case "6":
                    Order.printDishStatistics();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowOrderMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== УПРАВЛЕНИЕ ЗАКАЗАМИ ===");
            Console.WriteLine("1. Создание заказа");
            Console.WriteLine("2. Изменение заказа");
            Console.WriteLine("3. Вывод информации о заказе");
            Console.WriteLine("4. Закрытие заказа");
            Console.WriteLine("5. Вывод чека");
            Console.WriteLine("6. Подсчет стоимости всех закрытых заказов на текущий момент");
            Console.WriteLine("7. Подсчет всех закрытых заказов конкретного официанта");
            Console.WriteLine("8. Назад в главное меню");
            Console.Write("Выберите опцию: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateOrder();
                    break;
                case "2":
                    EditOrder();
                    break;
                case "3":
                    ShowOrderInfo();
                    break;
                case "4":
                    CloseOrder();
                    break;
                case "5":
                    ShowReceipt();
                    break;
                case "6":
                    Order.countAllClosedOrdersPrice();
                    break;
                case "7":
                    Order.countOfficientClosedOrders();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // === ФУНКЦИИ ДЛЯ БЛЮД ===

    static void CreateDish()
    {
        Console.Clear();
        Console.WriteLine("=== СОЗДАНИЕ БЛЮДА ===");

        try
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Название: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Состав: ");
            string composition = Console.ReadLine() ?? string.Empty;

            Console.Write("Вес: ");
            string weight = Console.ReadLine() ?? string.Empty;

            Console.Write("Цена: ");
            double price = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Категории: 0-Drinks, 1-Salads, 2-ColdDishes, 3-HotSnacks, 4-Soups, 5-HotDishes, 6-Desserts");
            Console.Write("Категория: ");
            Dish.Status status = (Dish.Status)int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Время приготовления (мин): ");
            int time = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Типы: 0-Spicy, 1-Vegan, 2-Halal, 3-Kosher");
            Console.Write("Тип: ");
            Dish.FoodType type = (Dish.FoodType)int.Parse(Console.ReadLine() ?? "0");

            Dish.newDish(id, name, composition, weight, price, status, time, type);

            Console.WriteLine("Блюдо успешно создано!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void EditDish()
    {
        Console.Clear();
        Console.WriteLine("=== РЕДАКТИРОВАНИЕ БЛЮДА ===");
        
        Console.Write("Введите ID блюда для редактирования: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // var dish = availableDishes.Find(d => d.Id == id);
            if (Dish.Dishs != null)
            {
                try
                {
                    Console.Write("Новое название: ");
                    string name = Console.ReadLine() ?? string.Empty;

                    Console.Write("Новый состав: ");
                    string composition = Console.ReadLine() ?? string.Empty;

                    Console.Write("Новый вес: ");
                    string weight = Console.ReadLine() ?? string.Empty;

                    Console.Write("Новая цена: ");
                    double price = double.Parse(Console.ReadLine() ?? string.Empty);

                    Console.WriteLine("Категории: 0-Drinks, 1-Salads, 2-ColdDishes, 3-HotSnacks, 4-Soups, 5-HotDishes, 6-Desserts");
                    Console.Write("Новая категория: ");
                    Dish.Status status = (Dish.Status)int.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Новое время приготовления (мин): ");
                    int time = int.Parse(Console.ReadLine() ?? string.Empty);

                    Console.WriteLine("Типы: 0-Spicy, 1-Vegan, 2-Halal, 3-Kosher");
                    Console.Write("Новый тип: ");
                    Dish.FoodType type = (Dish.FoodType)int.Parse(Console.ReadLine() ?? string.Empty);

                    // Dish.changeInfoDish(id, name, composition, weight, price, status, time, type);
                    Dish.changeInfoDish(id, name, composition, weight, price, status, time, type);
                    Console.WriteLine("Блюдо успешно отредактировано!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Блюдо с указанным ID не найдено.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void ShowDishInfo()
    {
        Console.Clear();
        Console.WriteLine("=== ИНФОРМАЦИЯ О БЛЮДЕ ===");
        
        Console.Write("Введите ID блюда: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var dish = Dish.Dishs.Values.FirstOrDefault(d => d.Id == id);
            if (dish != null)
            {
                dish.printDishInfo(id);
            }
            else
            {
                Console.WriteLine("Блюдо с указанным ID не найдено.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void DeleteDish()
    {
        Console.Clear();
        Console.WriteLine("=== УДАЛЕНИЕ БЛЮДА ===");
        
        Console.Write("Введите ID блюда для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var dish = Dish.Dishs.Values.FirstOrDefault(d => d.Id == id);
            if (dish != null)
            {
                dish.deleteDish(id);
                Dish.Dishs.Remove(id);
                Console.WriteLine("Блюдо успешно удалено!");
            }
            else
            {
                Console.WriteLine("Блюдо с указанным ID не найдено.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void ShowAllDishes()
    {
        Console.Clear();
        Console.WriteLine("=== МЕНЮ ===");
        
        Dish.printdishMenu();
        
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    // === ФУНКЦИИ ДЛЯ ЗАКАЗОВ ===

    static void CreateOrder()
    {
        Console.Clear();
        Console.WriteLine("=== СОЗДАНИЕ ЗАКАЗА ===");

        try
        {
            int orderId = nextOrderId++;
            Console.WriteLine($"ID заказа: {orderId}");

            Console.Write("ID стола: ");
            int tableId = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Комментарий: ");
            string comment = Console.ReadLine() ?? string.Empty;

            Console.Write("Время начала (формат: ЧЧ:ММ): ");
            string timeStart = Console.ReadLine() ?? string.Empty;

            Console.Write("ID официанта: ");
            int officiantId = int.Parse(Console.ReadLine() ?? string.Empty);

            // Выбор блюд
            List<Dish> selectedDishes = SelectDishesForOrder();
            if (selectedDishes.Count == 0)
            {
                Console.WriteLine("Не выбрано ни одного блюда. Заказ не создан.");
                Console.ReadKey();
                return;
            }

            // Расчет суммы
            int totalPrice = 0;
            foreach (var dish in selectedDishes)
            {
                totalPrice += (int)dish.Price;
            }

            Order.newOrder(orderId, tableId, selectedDishes, comment, timeStart, officiantId, "", totalPrice);
            
            Console.WriteLine($"Заказ #{orderId} успешно создан!");
            Console.WriteLine($"Стол: {tableId}, Официант: {officiantId}, Сумма: {totalPrice} руб.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании заказа: {ex.Message}");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void EditOrder()
    {
        Console.Clear();
        Console.WriteLine("=== ИЗМЕНЕНИЕ ЗАКАЗА ===");
        
        Console.Write("Введите ID заказа для изменения: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            try
            {
                Console.Write("Новый ID стола: ");
                int tableId = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Новый комментарий: ");
                string comment = Console.ReadLine() ?? string.Empty;

                Console.Write("Новое время начала (формат: ЧЧ:ММ): ");
                string timeStart = Console.ReadLine() ?? string.Empty;

                Console.Write("Новый ID официанта: ");
                int officiantId = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Новое время окончания (формат: ЧЧ:ММ): ");
                string timeEnd = Console.ReadLine() ?? string.Empty;

                // Выбор новых блюд
                List<Dish> selectedDishes = SelectDishesForOrder();
                if (selectedDishes.Count == 0)
                {
                    Console.WriteLine("Не выбрано ни одного блюда. Изменения не применены.");
                    Console.ReadKey();
                    return;
                }

                // Расчет новой суммы
                int totalPrice = 0;
                foreach (var dish in selectedDishes)
                {
                    totalPrice += (int)dish.Price;
                }

                Order.changeInfoOfOrder(orderId, tableId, selectedDishes, comment, timeStart, officiantId, timeEnd, totalPrice);
                
                Console.WriteLine($"Заказ #{orderId} успешно изменен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при изменении заказа: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void ShowOrderInfo()
    {
        Console.Clear();
        Console.WriteLine("=== ИНФОРМАЦИЯ О ЗАКАЗЕ ===");
        
        Console.Write("Введите ID заказа: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            Order.printOrderInfo(orderId);
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void CloseOrder()
    {
        Console.Clear();
        Console.WriteLine("=== ЗАКРЫТИЕ ЗАКАЗА ===");
        
        Console.Write("Введите ID заказа для закрытия: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            try
            {
                Console.Write("Время окончания (формат: ЧЧ:ММ): ");
                string timeEnd = Console.ReadLine() ?? string.Empty;

                Order.closeOrder(orderId);
                
                Console.WriteLine($"Заказ #{orderId} успешно закрыт!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при закрытии заказа: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void ShowReceipt()
    {
        Console.Clear();
        Console.WriteLine("=== ВЫВОД ЧЕКА ===");
        
        Console.Write("Введите ID закрытого заказа: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            Order.printClosedOrder(orderId);
        }
        else
        {
            Console.WriteLine("Неверный формат ID.");
        }

        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    // === ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ ===

    static List<Dish> SelectDishesForOrder()
    {
        List<Dish> selectedDishes = new List<Dish>();
        bool addingDishes = true;

        while (addingDishes)
        {
            Console.Clear();
            Console.WriteLine("=== ВЫБОР БЛЮД ДЛЯ ЗАКАЗА ===");
            ShowAllDishesBrief();
            
            Console.Write("Введите ID блюда для добавления (или 0 для завершения): ");
            if (int.TryParse(Console.ReadLine(), out int dishId))
            {
                if (dishId == 0)
                {
                    addingDishes = false;
                }
                else
                {
                    var dish = Dish.Dishs.Values.FirstOrDefault(d => d.Id == dishId);
                    if (dish != null)
                    {
                        selectedDishes.Add(dish);
                        Console.WriteLine($"Блюдо '{dish.Name}' добавлено в заказ.");
                    }
                    else
                    {
                        Console.WriteLine("Блюдо с указанным ID не найдено.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }
            
            if (addingDishes)
            {
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        return selectedDishes;
    }

    static void ShowAllDishesBrief()
    {
        Dish.printdishMenu();
    }
}