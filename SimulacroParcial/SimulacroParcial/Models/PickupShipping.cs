using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial.Models
{
    public class PickupShipping : IShippingStrategy
    {
        public double CalculateCost(double subtotal)
        {
            return subtotal * 1; //gratis
        }
    }
}
