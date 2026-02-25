using System;
using System.Collections.Generic;
using System.Linq; 
using SieMarketProject.Classes;
using SieMarketProject.Services;
class Program
{
    static void Main(string[] args)
    {
        var orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                CustomerName = "Robert",
                OrderDate = DateTime.Now.AddDays(-2),
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Laptop", Quantity = 1, UnitPrice = 1200 },
                    new OrderItem { ProductName = "Mouse", Quantity = 2, UnitPrice = 25 }
                }
            },
            new Order
            {
                OrderId = 2,
                CustomerName = "Alin",
                OrderDate = DateTime.Now.AddDays(-1),
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Smartphone", Quantity = 1, UnitPrice = 800 },
                    new OrderItem { ProductName = "Headphones", Quantity = 1, UnitPrice = 150 }
                }
            },
            new Order
            {
                OrderId = 3,
                CustomerName = "Robert",
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Tablet", Quantity = 1, UnitPrice = 300 },
                    new OrderItem { ProductName = "Keyboard", Quantity = 1, UnitPrice = 50 }
                }
            }
        };

        var orderService = new OrderService();

        foreach (var order in orders)
        {
            decimal finalPrice = orderService.FinalPrice(order);
            Console.WriteLine($"Order ID: {order.OrderId}, Final Price: {finalPrice:C}");
        }

        string topCustomer = orderService.GetTopSpendingCustomer(orders);
        Console.WriteLine($"Top Spending Customer: {topCustomer}");

        var popularProducts = orderService.GetPopularProducts(orders);
        Console.WriteLine("Popular Products:");
        foreach (var product in popularProducts)
        {
            Console.WriteLine($"{product.Key}: {product.Value} sold");
        }
    }
}