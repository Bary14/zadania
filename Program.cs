using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Product> inventory = new List<Product>();
        int choice;

        do
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("4. Aktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProduct(inventory);
                    break;
                case 2:
                    RemoveProduct(inventory);
                    break;
                case 3:
                    DisplayProducts(inventory);
                    break;
                case 4:
                    UpdateProduct(inventory);
                    break;
                case 5:
                    CalculateInventoryValue(inventory);
                    break;
                case 6:
                    Console.WriteLine("Zakończono program.");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        } while (choice != 6);
    }

    static void AddProduct(List<Product> inventory)
    {
        Console.WriteLine("Podaj nazwę produktu:");
        string name = Console.ReadLine();
        Console.WriteLine("Podaj ilość:");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Podaj cenę jednostkową:");
        double unitPrice = Convert.ToDouble(Console.ReadLine());

        inventory.Add(new Product(name, quantity, unitPrice));
        Console.WriteLine("Produkt dodany!");
    }

    static void RemoveProduct(List<Product> inventory)
    {
        Console.WriteLine("Podaj nazwę produktu do usunięcia:");
        string name = Console.ReadLine();
        Product product = inventory.Find(p => p.Name == name);

        if (product != null)
        {
            inventory.Remove(product);
            Console.WriteLine("Produkt usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono produktu.");
        }
    }

    static void DisplayProducts(List<Product> inventory)
    {
        Console.WriteLine("Lista produktów:");
        foreach (var product in inventory)
        {
            Console.WriteLine($"Nazwa: {product.Name}, Ilość: {product.Quantity}, Cena: {product.UnitPrice}");
        }
    }

    static void UpdateProduct(List<Product> inventory)
    {
        Console.WriteLine("Podaj nazwę produktu do aktualizacji:");
        string name = Console.ReadLine();
        Product product = inventory.Find(p => p.Name == name);

        if (product != null)
        {
            Console.WriteLine("Co chcesz zaktualizować? (1 - Ilość, 2 - Cena, 3 - Oba)");
            int updateChoice = Convert.ToInt32(Console.ReadLine());

            if (updateChoice == 1 || updateChoice == 3)
            {
                Console.WriteLine("Podaj nową ilość:");
                product.Quantity = Convert.ToInt32(Console.ReadLine());
            }

            if (updateChoice == 2 || updateChoice == 3)
            {
                Console.WriteLine("Podaj nową cenę:");
                product.UnitPrice = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Produkt zaktualizowany!");
        }
        else
        {
            Console.WriteLine("Nie znaleziono produktu.");
        }
    }

    static void CalculateInventoryValue(List<Product> inventory)
    {
        double totalValue = 0;
        foreach (var product in inventory)
        {
            totalValue += product.Quantity * product.UnitPrice;
        }
        Console.WriteLine($"Całkowita wartość magazynu: {totalValue}");
    }
}

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }

    public Product(string name, int quantity, double unitPrice)
    {
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}