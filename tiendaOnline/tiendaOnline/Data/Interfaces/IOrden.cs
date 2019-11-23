using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Models;

namespace tiendaOnline.Data.Interfaces
{
    public interface IOrden
    {
        void CrearOrden(Orden orden);
    }
}
