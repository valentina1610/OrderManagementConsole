using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial.Model
{
    public class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public Product() { }

        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public double Subtotal()
        {
            return price * quantity;
        }

    }
}
