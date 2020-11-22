using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Stock
    {
        static List<Software> listaProductosSoftware;
        static List<Hardware> listaProductosHardware;
        static List<Venta> ventasRealizadas;

        static Stock()
        {
            listaProductosSoftware = ManejoBaseDeDatos.ObtenerProductosSoftware();
            listaProductosHardware = ManejoBaseDeDatos.ObtenerProductosHardware();
            ventasRealizadas = new List<Venta>();
        }

        public static List<Software> ListaProductosSoftware { get => listaProductosSoftware; set => listaProductosSoftware = value; }
        public static List<Hardware> ListaProductosHardware { get => listaProductosHardware; set => listaProductosHardware = value; }


        /// <summary>
        /// Metodo que actualiza las listas
        /// </summary>
        public static void ActualizarListas()
        {
            listaProductosSoftware = null;
            listaProductosSoftware = ManejoBaseDeDatos.ObtenerProductosSoftware();
            listaProductosHardware = null;
            listaProductosHardware = ManejoBaseDeDatos.ObtenerProductosHardware();
        }

        public static int ObtenerUltimaIdListaProductos<T>(List<T> auxLista) where T : Producto
        {
            int auxLargo = auxLista.Count - 1;
            int auxIndice = -1;

            if (auxLargo == -1)
            {
                auxIndice = 0;
            }
            else
            {
                auxIndice = auxLista[auxLargo].IdProducto;

            }
            return auxIndice;
        }

        public static string ListarLosProductos()
        {
            StringBuilder lista = new StringBuilder();

            foreach(Producto software in Stock.listaProductosSoftware)
            {
                if(software.GetType() == typeof(Software))
                {
                    lista.AppendLine(software.ToStringParaConsola()); 
                }
            }

            return lista.ToString();
        }
    }
}
