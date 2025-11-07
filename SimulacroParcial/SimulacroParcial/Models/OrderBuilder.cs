using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Model;

namespace SimulacroParcial.Models
{
    public class OrderBuilder : IOrderBuilder
    {
        private Order order;
        public OrderBuilder()
        {
            order = new Order();
            order.productsList = new List<Product>();
        }
        public List<Product> GetProducts()
        {
            return order.productsList;
        }
        public void SetClient(string client, string adress)
        {
            order.client = client;
            order.adress = adress;
        }

        public void AddProduct(Product product)
        {
            order.productsList.Add(product);
        }
        public void SetShipping(IShippingStrategy shipping)
        {
            order.shipping = shipping;
            if (shipping is MotoShipping) order.shippingType = "Moto";
            else if (shipping is MailShipping) order.shippingType = "Mail";
            else order.shippingType = "Pickup";
        }
        //construye el pedido final y calcula el total
        public Order Build()
        {
            order.CalculateTotal();
            return order;
        }

    }
}
