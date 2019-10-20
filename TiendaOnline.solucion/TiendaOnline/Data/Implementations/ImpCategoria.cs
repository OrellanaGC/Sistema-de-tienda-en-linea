using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;

namespace TiendaOnline.Data.Implementations
{
    public class ImpCategoria : ICategoria
    {
        private readonly tiendaonlineDBContext _tiendaDbContext;
        public ImpCategoria(tiendaonlineDBContext tiendaDbContext)
        {
            _tiendaDbContext = tiendaDbContext;
        }

        public IEnumerable<Categoria> Categoria => _tiendaDbContext.Categoria;

      
    }
}
