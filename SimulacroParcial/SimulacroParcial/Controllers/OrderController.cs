using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Models;
using SimulacroParcial.Repository;
using SimulacroParcial.Services;

namespace SimulacroParcial.Controllers
{
    public class OrderController
    {
        private readonly OrderService _service;
        private readonly IRepository<Order> _repository;

        public OrderController(OrderService service, IRepository<Order> repository)
        {
            _service = service;
            _repository = repository;
        }

        public void ConfirmOrder(Order order)
        {
            try
            {
                order.CalculateTotal();
                _service.ConfirmOrder(order);
                _repository.Save(order);
                Console.WriteLine("Order confirmed and saved to orders.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        }
    }
}
