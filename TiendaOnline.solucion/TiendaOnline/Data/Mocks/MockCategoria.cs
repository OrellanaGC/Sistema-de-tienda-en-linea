using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;

namespace TiendaOnline.Data.Mocks
{
    public class MockCategoria: ICategoria
    {
        public IEnumerable<Categoria> Categoria
        {
            get
            {
                return new List<Categoria>
                     {
                         new Categoria { NombreCategoria = "Tecnologia" },
                         new Categoria { NombreCategoria = "Libros" }
                     };
            }
            set { }
        }

    }
}
