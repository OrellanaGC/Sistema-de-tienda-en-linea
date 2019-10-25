using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;
using TiendaOnline.Data;

namespace TiendaOnline.Data.Implementations
{
    public class ImpCategoria : ICategoria
    {
        private readonly ApplicationDbContext _tiendaDbContext;
        public ImpCategoria(ApplicationDbContext tiendaDbContext)
        {
            _tiendaDbContext = tiendaDbContext;
        }

        public IEnumerable<Categoria> Categoria => _tiendaDbContext.Categoria;

      
    }
}
