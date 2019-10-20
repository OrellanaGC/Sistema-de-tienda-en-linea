using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;

namespace TiendaOnline.Data.Mocks
{
    public class MockProducto: IProducto
    {
        private readonly ICategoria _categoria = new MockCategoria();

        public IEnumerable<Producto> Productos {
            get
            {
                return new List<Producto>
                {
                    new Producto {
                        NombreProducto="Dell E550",
                        Preciounitario= 3.50M,
                        Codigodeproducto= _categoria.Categoria.First().NombreCategoria
                    },
                    new Producto {
                        NombreProducto="Dell E55a0",
                        Preciounitario= 3.50M,
                        Codigodeproducto= _categoria.Categoria.First().NombreCategoria
                    },
                    new Producto {
                        NombreProducto="Dell E55s0",
                        Preciounitario= 3.50M,
                        Codigodeproducto= _categoria.Categoria.First().NombreCategoria
                    }
                };
            }

            set => throw new NotImplementedException();
        }

        public Producto GetProductoById(int IdProducto)
        {
            throw new NotImplementedException();
        }
    }
}
