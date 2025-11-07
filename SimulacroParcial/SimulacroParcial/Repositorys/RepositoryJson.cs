using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SimulacroParcial.Models;

namespace SimulacroParcial.Repository
{
    public class RepositoryJson : IRepository<Order>
    {
        private string file = "data.json";
        public void Save(Order order)
        {
            var orders = GetAll(); //carga todos los pedidos existentes
            orders.Add(order); //agrega el nuevo
            var json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(file, json);
        }

        public List<Order> GetAll()
        {
            if (!File.Exists(file)) return new List<Order>();
            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
        }

    }
    
}
