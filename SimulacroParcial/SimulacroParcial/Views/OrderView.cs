using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Model;
using SimulacroParcial.Models;

namespace SimulacroParcial.View
{
    public class OrderView
    {
        public (string client, string address) AddClient()
        {
            Console.Write("Enter client name: ");
            string client = Console.ReadLine() ?? "";

            Console.Write("Enter address: ");
            string address = Console.ReadLine() ?? "";

            return (client, address);
        }

        public IShippingStrategy AddShipping()
        {
            Console.Write("Enter shipping type (moto / mail / pickup): ");
            string shippingType = Console.ReadLine().ToLower();
            while (shippingType != "moto" && shippingType != "mail" && shippingType != "pickup")
            {
                Console.WriteLine("[ERROR]: Invalid shipping, try again!");
                shippingType = Console.ReadLine().ToLower();
            }

            IShippingStrategy shipping;

            if (shippingType.Equals("moto"))
                shipping = new MotoShipping();
            else if (shippingType.Equals("mail"))
                shipping = new MailShipping();
            else
                shipping = new PickupShipping();

            return shipping;
        }

        public void ShowOrder(Order order)
        {
            Console.WriteLine($"----- ORDER DETAILS -----");
            Console.WriteLine($"Client: {order.client}");
            Console.WriteLine($"Address: {order.adress}");
            Console.WriteLine($"Shipping: {order.shippingType}");
            Console.WriteLine("Products:");
            foreach (var product in order.productsList)
            {
                Console.WriteLine($"{product.name} - ${product.price} x {product.quantity} = ${product.Subtotal()}");
            }
            Console.WriteLine($"Total: ${order.total}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
