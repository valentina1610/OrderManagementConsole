using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Model;

namespace SimulacroParcial.Views
{
    public class ProductView
    {
        public List<Product> AddProduct()
        {
            Console.Clear();
            List<Product> products = new List<Product>();
            bool adding = true;

            while (adding)
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter price: ");
                double price;
                while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                {
                    Console.WriteLine("[ERROR]: Enter a valid price!");
                }


                Console.Write("Enter quantity: ");
                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 1)
                {
                    Console.WriteLine("[ERROR]: Enter a valid quantity!");
                }

                var product = new Product(name, price, quantity);
                products.Add(product);

                // Mostrar productos agregados hasta ahora
                Console.WriteLine("\n--- Current products ---");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.name} - ${p.price} x {p.quantity} = ${p.Subtotal()}");
                }
                Console.WriteLine("------------------------\n");

                // Preguntar si quiere agregar otro
                Console.Write("Add another product? (y/n): ");
                string? more = Console.ReadLine();
                if (more == null || !more.Equals("y", StringComparison.OrdinalIgnoreCase))
                    adding = false;
            }

            return products;
        }

        public void ShowProducts(List<Product> products)
        {
            Console.WriteLine("----- PRODUCTS -----");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.name} - ${p.price} x {p.quantity} = ${p.Subtotal()}");
            }
        }
    }
}
