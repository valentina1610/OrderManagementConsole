using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SimulacroParcial.Model;

namespace SimulacroParcial.Models
{
    public class Order
    {
        public List<Product> productsList { get; set; } = new List<Product>();
        public string client { get; set; }
        public string adress { get; set; }
        [JsonIgnore] // <- esto evita que System.Text.Json trate de serializar la interfaz
        public IShippingStrategy shipping { get; set; } 
        public string shippingType { get; set; }
        public double total { get; set; }

        public Order() { }

        public Order(List<Product> productsList, string client, string adress, IShippingStrategy shipping, double total, string shippingType)
        {
            this.productsList = productsList;
            this.client = client;
            this.adress = adress;
            this.shipping = shipping;
            this.total = total;
            this.shippingType = shippingType;
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
             double subtotal = CalculateSubtotal();
             if (shipping != null)
             {
                 total = subtotal + shipping.CalculateCost(subtotal);
             }
             else
             {
                 total = subtotal;
             } 
        }
        
        public void SetShipping(string type)
        {
            switch(type.ToLower())
            {
                case "moto":
                    shipping = new MotoShipping();
                    break;

                case "mail":
                    shipping = new MailShipping();
                    break;
                case "pickup":
                    shipping = new PickupShipping();
                    break;
                default:
                    Console.WriteLine("[ERROR]: Invalid shipping.");
                    break;
            }
        }
    }
}
