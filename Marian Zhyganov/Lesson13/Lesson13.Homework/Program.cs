using Lesson13.Homework;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson13.Homework
{
    //interface IFood
    //{
    //    int DaysToGone { get; }
    //}
    interface IInterface
    {

    }
    class ShopItem
    {

        public string Name { get; set; }
        public double Price { get; set; }
        public ShopItem(string name, double price)
        {
            Name = name;
            Price = price;

        }

        public virtual void Info()
        {
            Console.WriteLine($"Product name: {Name} - price {Price} UAH");
        }



    }
}

class Basket : ShopItem
{
    public string Name { get; set; }
    public double Price { get; set; }
    public Basket(string name, double price) : base(name, price)
    {
        Name = name;
        Price = price;
    }

    public override void Info()
    {
        Console.WriteLine("your basket");
        Console.WriteLine($"Product name: {Name} - price {Price} UAH");
    }
}
class Shop
{
    List<ShopItem> shopItems = new List<ShopItem>();
    List<Basket> baskets = new List<Basket>();
    public Shop()
    {
        shopItems = new List<ShopItem>()
            {

                new ShopItem("Apple", 17.50),
                new ShopItem("berry", 23.23),
                new ShopItem("banana", 20),
                new ShopItem("pineapple", 104.75),
            };
    }

    public void ShowProducts(List<ShopItem> shopItems)
    {

        foreach (var item in shopItems)
        {
            item.Info();
        }
    }

    public void ShowBasket(List<Basket> baskets)
    {
        foreach (var item in baskets)
        {
            item.Info();
        }
    }

    public void AddProduct(List<ShopItem> shopItems)
    {

        Console.WriteLine("Name product");
        string name = Console.ReadLine();
        Console.WriteLine("Price product");
        double price = Double.Parse(Console.ReadLine());
        shopItems.Add(new ShopItem(name, price));
    }

    public void AddBasket(List<Basket> baskets)
    {
        Console.WriteLine("Name product");
        string name = Console.ReadLine();
        Console.WriteLine("Name product");
        double price = Double.Parse(Console.ReadLine());

        for (int i = 0; i < shopItems.Count; i++)
        {
            if (name == shopItems[i].Name)
            {
                baskets.Add(new Basket(name, price));

            }
        }

    }

    public void RemoveBasket(List<Basket> baskets)
    {
        Console.WriteLine("Name product");
        string name = Console.ReadLine();
        Console.WriteLine("Name product");
        double price = Double.Parse(Console.ReadLine());
        for (int i = 0; i < baskets.Count; i++)
        {
            if (name == baskets[i].Name)
            {
                baskets.Remove(new Basket(name, price));

            }
        }
    }

    public void Proceed()
    {
        var action = Console.ReadKey();
        Console.WriteLine();

        switch (action.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine("Product we have");
                ShowProducts(shopItems);

                break;
            case ConsoleKey.D2:
                Console.WriteLine("What would you like to add");
                AddProduct(shopItems);

                break;
            case ConsoleKey.D3:
                Console.WriteLine("What would you like to add to the basket");
                AddBasket(baskets);

                break;
            case ConsoleKey.D4:
                Console.WriteLine("What do you want to remove");
                RemoveBasket(baskets);

                break;
            case ConsoleKey.D5:
                Console.WriteLine("Product you have");
                ShowBasket(baskets);

                break;
            case ConsoleKey.D0:
                Console.WriteLine("");


                break;
            default:
                break;
        }

    }

}

internal class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("1: Show products");
        Console.WriteLine("2: Add product");
        Console.WriteLine("3: Add to basket");
        Console.WriteLine("4: Remove from basket");
        Console.WriteLine("5: Show basket");
        Console.WriteLine("0: Exit");

        Shop shop1 = new Shop();

        while (true)
        {
            shop1.Proceed();

        }

    }
}

