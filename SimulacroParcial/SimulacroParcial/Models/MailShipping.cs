using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial.Models
{
    public class MailShipping : IShippingStrategy
    {
        public double CalculateCost(double subtotal)
        {
            return subtotal * 10000;
        }
    }
}
