using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulacroParcial.Model;

namespace SimulacroParcial.Models
{
    public interface IOrderBuilder
    {
        void SetClient(string client, string adress); // datos de el cliente
        void AddProduct(Product product); //agrega un producto
        void SetShipping(IShippingStrategy shipping); // define el tipo de envio
        Order Build(); //construye el pedido final
    }
}
