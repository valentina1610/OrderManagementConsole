using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Models;

namespace SimulacroParcial.Services
{
    public class OrderService
    {
        public event Action<string>? OrderConfirmed; //evento que significa que se
                                                     //confirmo el pedido
        public void ConfirmOrder(Order order)
        {
            //dispara el evento
            OrderConfirmed?.Invoke($"Order confirmed for client: {order.client}");
        }
    }
}
