using System;
using System.Collections.Generic;
using System.Linq;

// Define the Product class to represent a product with its properties
class Product
{
    public string Category { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    // Constructor to initialize the Product object with category, product name, and price
    public Product(string category, string productName, double price)
    {
        Category = category;
        ProductName = productName;
        Price = price;
    }
}

class Program
{
    static void Main()
    {
        // Create a list to store Product objects
        List<Product> products = new List<Product>();

        Console.WriteLine("Welcome to the Product Management System!");

        while (true)
        {
            // Prompt the user for product details
            Console.WriteLine("\nEnter product details or type 'q' to quit:");

            // Get Category input
            Console.Write("1. Category: ");
            string category = Console.ReadLine();

            // Check if the user wants to quit
            if (category.ToLower() == "q")
                break;

            // Get Product Name input
            Console.Write("2. Product Name: ");
            string productName = Console.ReadLine();

            double price;

            // Ensure a valid price is entered using error handling
            while (true)
            {
                Console.Write("3. Price: ");
                string priceInput = Console.ReadLine();

                if (double.TryParse(priceInput, out price))
                {
                    // Valid input, break from the loop
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid price.");
                }
            }

            // Create a new Product object and add it to the list
            Product product = new Product(category, productName, price);
            products.Add(product);

            // Sort the list of products by price in ascending order using LINQ
            products = products.OrderBy(p => p.Price).ToList();

            // Display the sorted list of products
            Console.WriteLine("\nProduct List:");
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Category} - {prod.ProductName} - ${prod.Price:F2}");
            }

            // Calculate and display the total price of all products
            double totalPrice = products.Sum(p => p.Price);
            Console.WriteLine($"\nTotal Price: ${totalPrice:F2}");
        }

        Console.WriteLine("\nThank you for using the Product Management System!");
    }
}