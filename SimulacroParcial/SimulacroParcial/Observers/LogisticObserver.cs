using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial.Observers
{
    public class LogisticObserver
    {
        public void OnOrderConfirmed(string msg)
        {
            Console.WriteLine($"[LOGISTIC NOTIFICATION]: {msg}");
        }
    }
}
