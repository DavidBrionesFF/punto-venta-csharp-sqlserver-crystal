using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Repositorio
{
    interface DAOImpl<T>
    {
        
        T find(int id);
        List<T> findAll();
        bool save(T model);
        bool save(List<T> models);
        bool update(T model);
        bool delete(T model);
    }
}
