using System;
using SimulacroParcial.Controller;
using SimulacroParcial.Controllers;
using SimulacroParcial.Model;
using SimulacroParcial.Models;
using SimulacroParcial.Observers;
using SimulacroParcial.Repository;
using SimulacroParcial.Services;
using SimulacroParcial.View;
using SimulacroParcial.Views;

namespace SimulacroParcial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----- Observers -----
            var clientObserver = new ClientObserver();
            var logisticsObserver = new LogisticObserver();

            // ----- Services -----
            var orderService = new OrderService();
            orderService.OrderConfirmed += clientObserver.OnOrderConfirmed;
            orderService.OrderConfirmed += logisticsObserver.OnOrderConfirmed;

            // ----- Repository -----
            var repository = new RepositoryJson();

            // ----- Controllers -----
            var orderController = new OrderController(orderService, repository);
            var productController = new ProductController();

            // ----- Views -----
            var orderView = new OrderView();
            var productView = new ProductView();

            // ----- Builder -----
            var builder = new OrderBuilder();

            bool running = true;

            while (running)
            {
                Console.WriteLine("=== PRODUCTS MENU ===");
                Console.WriteLine("\n1. Add order");
                Console.WriteLine("2. Show all orders");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            // ----- Add products -----
                            var products = productView.AddProduct();

                            // Agregarlos al builder
                            foreach (var p in products)
                            {
                                builder.AddProduct(p);
                            }

                            // ----- Client info -----
                            var (client, address) = orderView.AddClient();
                            builder.SetClient(client, address);

                            // ----- Shipping -----
                            var shipping = orderView.AddShipping();
                            builder.SetShipping(shipping);

                            // ----- Build and confirm order -----
                            var order = builder.Build();

                            // ----- Confirm order (events + save) -----
                            orderService.ConfirmOrder(order);
                            repository.Save(order);

                            break;

                        case "2":
                            // Show all orders
                            var allOrders = repository.GetAll();
                            foreach (var o in allOrders)
                            {
                                orderView.ShowOrder(o);
                            }
                            break;

                        case "3":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
    }
}