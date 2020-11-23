using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public static class Stock
    {
        static List<Software> listaProductosSoftware;
        static List<Hardware> listaProductosHardware;
        static List<Venta> ventasRealizadas;
        static List<Cliente> clientes;

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Stock()
        {
            listaProductosSoftware = ManejoBaseDeDatos.ObtenerProductosSoftware();
            listaProductosHardware = ManejoBaseDeDatos.ObtenerProductosHardware();
            ventasRealizadas = DeserealizarArchivoVentas();
            clientes = DeserealizarArchivoClientes();
        }

        #region Propiedades
        public static List<Software> ListaProductosSoftware { get => listaProductosSoftware; set => listaProductosSoftware = value; }
        public static List<Hardware> ListaProductosHardware { get => listaProductosHardware; set => listaProductosHardware = value; }
        public static List<Venta> VentasRealizadas { get => ventasRealizadas; set => ventasRealizadas = value; }
        public static List<Cliente> Clientes { get => clientes; set => clientes = value; }
        #endregion

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

        /// <summary>
        /// Genera un string con los metodos .ToStringParaConsola() de los objetos de tipo producto o que hereden de producto
        /// Es generica porque se le puede pasar una lista de tipo Software o una de Hardware
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auxLista"></param>
        /// <returns></returns>
        public static string ListarLosProductos<T>(List<T> auxLista) where T : Producto
        {
            if (auxLista.Count > 0)
            {
                StringBuilder lista = new StringBuilder();

                foreach (Producto item in auxLista)
                {
                    lista.AppendLine(item.ToStringParaConsola());
                }

                return lista.ToString();
            }
            else
            {
                throw new Exception("Error, la lista no posee elementos");
            }

        }

        /// <summary>
        /// Deserealiza un archivo llamado Clientes.xml que contiene clientes
        /// Estos son ingresados a la lista de clientes
        /// </summary>
        /// <returns></returns>
        private static List<Cliente> DeserealizarArchivoClientes()
        {

            string ubicacionArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Clientes.xml");
            List<Cliente> auxLista = new List<Cliente>();
            Xml<List<Cliente>> Leer = new Xml<List<Cliente>>();
            Leer.Leer(ubicacionArchivo, out auxLista);
            
            return auxLista;
        }

        /// <summary>
        /// Deserealiza un archivo llamado Clientes.xml que contiene clientes
        /// Estos son ingresados a la lista de clientes
        /// </summary>
        /// <returns></returns>
        private static List<Venta> DeserealizarArchivoVentas()
        {
            string ubicacionArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Ventas.xml");
            List<Venta> auxLista = new List<Venta>();
            Xml<List<Venta>> Leer = new Xml<List<Venta>>();
            Leer.Leer(ubicacionArchivo, out auxLista);

            return auxLista;
        }

        /// <summary>
        /// Obtiene el ultimo id de la lista de ventas
        /// </summary>
        /// <returns></returns>
        public static int GetUltimaIdVentas()
        {
            if(ventasRealizadas.Count > 0)
            {
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
            else
            {
                throw new Exception("Error, la lista no posee elementos");
            }

        }

        /// <summary>
        /// Obtiene el ultimo id de la lista que le llegue, siento T de los objetos de tipo producto o que hereden de producto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="auxLista"></param>
        /// <returns></returns>
        public static int GetUltimaIdListaProductos<T>(List<T> auxLista) where T : Producto
        {
            if (auxLista.Count > 0)
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
            else
            {
                throw new Exception("Error, la lista no posee elementos");
            }
        }

        /// <summary>
        /// Obtiene el indice del producto que le llega, buscandolo en la lista de su respectivo tipo,
        /// ya sea software o hardware
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static int GetIndiceProducto<T>(T producto) where T : Producto
        {
            try
            {
                if (producto.GetType() == typeof(Software))
                {
                    for (int i = 0; i < ListaProductosSoftware.Count; i++)
                    {
                        if (producto.IdProducto == ListaProductosSoftware[i].IdProducto)
                        {
                            return i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ListaProductosHardware.Count; i++)
                    {
                        if (producto.IdProducto == ListaProductosHardware[i].IdProducto)
                        {
                            return i;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return -1;
        }
    }
}
