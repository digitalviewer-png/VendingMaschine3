using VendingMaschine3;

int cashMoney = 0;
int cardMoney = 0;
int totalMoney = 0;

Products Cola = new("Cola", 120, 4);
Products Fanta = new("Fanta", 120, 3);
Products Lays = new("Lays", 160, 5);
Products Snickers = new("Snickers", 100, 5);
Products Mars = new("Mars", 100, 1);
Products Sandwich = new("Sandwich", 180, 2);
Products Sprite = new("Sprite", 120, 6);
Products Lipton = new("Lipton", 150, 3);
Products Pivo = new("Pivo", 300, 1);
Products KitKat = new("KitKat", 130, 2);

List<Products> list = new() { Cola, Fanta, Lays, Snickers, Mars, Sandwich, Sprite, Lipton, Pivo, KitKat };


bool MainMenu()
{
    Console.Clear();
    Console.WriteLine("                Тоговый Автомат");
    Console.WriteLine("1) Добавить денег     ||  AddMoney");
    Console.WriteLine("2) Получить сдачу     ||  GetChange");
    Console.WriteLine("3) Показать продукты  ||  ShowProducts");
    Console.WriteLine("4) Купить продукт     ||  BuyProducts");
    Console.WriteLine("5) Показать баланс    ||  ShowBalance");
    Console.Write("\r\nВыберите опцию: ");

    switch (Console.ReadLine().Trim().ToLower())
    {
        case "addmoney":
            AddMoney();
            return true;
        case "getchange":
            GetChange();
            return true;
        case "showproducts":
            ShowProducts();
            return true;
        case "buyproducts":
            BuyProducts();
            return true;
        case "showbalance":
            ShowBalance();
            return true;
        default:
            Console.WriteLine("Введите значение от 1 до 4!");
            MainMenu();
            return true;
    }
}

MainMenu();

bool AddMoney()
{
    Console.Clear();
    Console.WriteLine("Выберите способ оплаты:");
    Console.WriteLine("1) Банковской картой");
    Console.WriteLine("2) Наличными");
    Console.Write("Выберите способ: ");
    int userInput;
    if (!int.TryParse(Console.ReadLine(), out userInput))
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Выберите способ оплаты: ");
        } while (!int.TryParse(Console.ReadLine(), out userInput));
    }
    else if (userInput > 2 || userInput < 1)
    {
        do
        {
            Console.WriteLine("Писать нужно в диапозоне от 1 до 2!");
            Console.ReadKey();
        } while (userInput <= 2 && userInput >= 1);
    }

    switch (userInput)
    {
        case 1:
            PayByCreditCard();
            return true;
        case 2:
            PayByCash();
            return true;

        default:
            AddMoney();
            return true;
    }
}

void GetChange()
{
    Console.Clear();
    int coins = 0;
    if (totalMoney <= 0)
    {
        Console.WriteLine("На балансе недостаточно средств");
    }

    while (totalMoney >= 10)
    {
        coins++;
        totalMoney -= 10;
    }
    Console.WriteLine($"Выданы {coins} монет с номиналом \"10\".");
    coins = 0;

    if (totalMoney >= 5)
    {
        coins++;
        totalMoney -= 5;
    }

    Console.WriteLine($"Выданы {coins} монет с номиналом \"5\".");
    coins = 0;

    if (totalMoney >= 2)
    {
        while (totalMoney >= 2)
        {
            coins++;
            totalMoney -= 2;
        }
    }
    Console.WriteLine($"Выданы {coins} монет с номиналом \"2\".");
    coins = 0;

    if (totalMoney >= 1)
    {
        coins++;
        totalMoney -= 1;
    }

    Console.WriteLine($"Выданы {coins} монет с номиналом \"1\".");
    Console.ReadKey();
    MainMenu();
}


bool PayByCash()
{
    Console.Clear();
    int ten;
    int five;
    int two;
    int one;
    int sum;
    int type;

    Console.Write("Введите количество десяток: ");
    if (!int.TryParse(Console.ReadLine(), out ten))
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Введите количество десяток: ");
        } while (!int.TryParse(Console.ReadLine(), out ten));
    }

    Console.Write("Введите количество пятёрок: ");
    if (!int.TryParse(Console.ReadLine(), out five))
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Введите количество пятёрок:");
        } while (!int.TryParse(Console.ReadLine(), out five));
    }

    Console.Write("Введите количество двоек: ");
    if (!int.TryParse(Console.ReadLine(), out two))
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Введите количество двоек: ");
        } while (!int.TryParse(Console.ReadLine(), out two));
    }

    Console.Write("Введите количество единиц: ");
    if (!int.TryParse(Console.ReadLine(), out one))
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Введите количество единиц: ");
        } while (!int.TryParse(Console.ReadLine(), out one));
    }

    cashMoney += (ten * 10) + (five * 5) + (two * 2) + one;
    totalMoney += cashMoney;
    Console.WriteLine($"Ваша сумма ввода равна: {cashMoney}");
    Console.WriteLine("Нажмите любую кнопку для выхода на главный экран");
    Console.ReadKey();
    MainMenu();
    return true;


}

void PayByCreditCard()
{
    Console.Clear();
    int sum;
    Console.Write("Введите сумму, которую хотите внести: ");
    if (!int.TryParse(Console.ReadLine(), out sum))
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Введите сумму, которую хотите внести: ");
        } while (!int.TryParse(Console.ReadLine(), out sum));
    }
    cardMoney += sum;
    totalMoney += cardMoney;
    Console.WriteLine($"Вы ввели {cardMoney} руб.");
    Console.ReadKey();
    MainMenu();
}

void ShowProducts()
{
    for (int i = 0; i < list.Count; i++)
    {
        Console.WriteLine($"\n {i + 1}. {list[i].Name} ||  Price: {list[i].Price} ||  Count: {list[i].Count}");
    }
    Console.ReadKey();
    MainMenu();
}
void ShowBalance()
{
    Console.WriteLine($"Ваш баланс {totalMoney} руб.");
    Console.ReadKey();
    MainMenu();
}

void BuyProducts()
{
    Console.Clear();
    for (int i = 0; i < list.Count; i++)
    {
        Console.WriteLine($"\n {i + 1}. {list[i].Name} ||  Price: {list[i].Price} ||  Count: {list[i].Count}");
    }
    Console.WriteLine("\n");
    Console.WriteLine($"Ваш баланс {totalMoney} руб.");
    Console.WriteLine("\n");
    Console.WriteLine("\nКакой продукт желаете?");
    Console.Write("\nНапишите номер товара от 1 - 10: ");

    int product;

    if (!int.TryParse(Console.ReadLine(), out product) || list[product - 1].Count == 0)
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Напишите номер товара: ");
        } while (!int.TryParse(Console.ReadLine(), out product));
    }

    else if (product > list.Count || product < 1)
    {
        do
        {
            Console.WriteLine("Писать нужно в диапозоне от 1 до 10!");
        } while (product <= list.Count && product > 0);
    }

    Console.Write("Напишите количество товара: ");
    int count;
    if (!int.TryParse(Console.ReadLine(), out count) || count < 0 || count > list[product - 1].Count)
    {
        do
        {
            Console.WriteLine("Некорректный ввод!");
            Console.Write("Напишите количество: ");
        } while (!int.TryParse(Console.ReadLine(), out count));

    }

    if ((list[product].Price * count) <= totalMoney)
    {
        totalMoney -= list[product].Price * count;
        list[product - 1].Count -= count;
        Console.Clear();
        MainMenu();
    }

}

