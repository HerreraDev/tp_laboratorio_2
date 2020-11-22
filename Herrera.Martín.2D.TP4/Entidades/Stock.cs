using Archivos;
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
        static List<Cliente> clientes;

        static Stock()
        {
            listaProductosSoftware = ManejoBaseDeDatos.ObtenerProductosSoftware();
            listaProductosHardware = ManejoBaseDeDatos.ObtenerProductosHardware();
            ventasRealizadas = new List<Venta>();
            clientes = deserealizarArchivoClientes();
        }

        public static List<Software> ListaProductosSoftware { get => listaProductosSoftware; set => listaProductosSoftware = value; }
        public static List<Hardware> ListaProductosHardware { get => listaProductosHardware; set => listaProductosHardware = value; }
        public static List<Venta> VentasRealizadas { get => ventasRealizadas; set => ventasRealizadas = value; }
        public static List<Cliente> Clientes { get => clientes; set => clientes = value; }


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


        public static string ListarLosProductos<T>(List<T> auxLista) where T : Producto
        {
            StringBuilder lista = new StringBuilder();

            foreach(Producto item in auxLista)
            {
                lista.AppendLine(item.ToStringParaConsola()); 
            }

            return lista.ToString();
        }

        private static List<Cliente> deserealizarArchivoClientes()
        {
            string ubicacionArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Clientes.xml");
            List<Cliente> auxLista = new List<Cliente>();
            Xml<List<Cliente>> Leer = new Xml<List<Cliente>>();
            Leer.Leer(ubicacionArchivo, out auxLista);

            return auxLista;
        }

        public static int GetUltimaIdVentas()         {
            int auxLargo = ventasRealizadas.Count - 1;
            int auxIndice = -1;

            if (auxLargo == -1)
            {
                auxIndice = 0;
            }
            else
            {
                auxIndice = ventasRealizadas[auxLargo].IdVenta;

            }
            return auxIndice;
        }

        public static int GetUltimaIdListaProductos<T>(List<T> auxLista) where T : Producto
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
    }
}
