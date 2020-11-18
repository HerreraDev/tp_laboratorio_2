using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Stock
    {
        static List<Producto> listaProductos;

        static Stock()
        {
            ListaProductos = ManejoBaseDeDatos.TraerProductos();
        }

        public static List<Producto> ListaProductos { get => listaProductos; set => listaProductos = value; }




    }
}
