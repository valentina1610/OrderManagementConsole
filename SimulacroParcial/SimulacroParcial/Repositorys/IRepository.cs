using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial.Repository
{
    public interface IRepository<T>
    {
        void Save(T entity);
        List<T> GetAll();
    }
}
