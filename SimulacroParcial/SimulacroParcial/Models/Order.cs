using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Model;

namespace SimulacroParcial.Models
{
    public class Order
    {
        public List<Product> productsList { get; set; }
        public string client { get; set; }
        public string adress { get; set; }
        /*public IShippingStrategy shipping { get; set; } */
        public double total { get; set; }

        public Order() { }

        public Order(List<Product> productsList, string client, string adress/*, IShippingStrategy shipping*/, double total)
        {
            this.productsList = productsList;
            this.client = client;
            this.adress = adress;
            // this.shipping = shipping
            this.total = total;
        }
        public double CalculateSubtotal()
        {
            double subtotal = 0;
            foreach (var product in productsList)
            {
                subtotal += product.Subtotal();
            }
            return subtotal;
        }

        public void CalculateTotal()
        {
            /* double subtotal = CalculateSubtotal();
             if (Shipping != null)
             {
                 total = subtotal + Shipping.CalculateCost(subtotal);
             }
             else
             {
                 total = subtotal;
             } */
        }
    }
}
