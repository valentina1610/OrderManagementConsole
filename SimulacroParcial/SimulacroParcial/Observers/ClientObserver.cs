using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial.Observers
{
    public class ClientObserver
    {
        public void OnOrderConfirmed(string msg)
        {
            Console.WriteLine($"[CLIENT NOTIFICATION]: {msg}");
        }
    }
}
