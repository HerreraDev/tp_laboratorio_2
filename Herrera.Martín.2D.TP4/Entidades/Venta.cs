using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Venta
    {
        int idVenta;
        Cliente cliente;
        List<Producto> listaProductos;
        double precioFinal;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Venta()
        {
            listaProductos = new List<Producto>();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="cliente"></param>
        /// <param name="listaProductos"></param>
        /// <param name="montoTotal"></param>
        public Venta(int idVenta, Cliente cliente, List<Producto> listaProductos, double montoTotal):this()
        {
            this.IdVenta = idVenta;
            this.Cliente = cliente;
            this.ListaProductos = listaProductos;
            this.PrecioFinal = montoTotal;
        }


        public int IdVenta
        {
            get { return this.idVenta; }
            set { this.idVenta = value; }
        }

        public Cliente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        public List<Producto> ListaProductos
        {
            get { return this.listaProductos; }
            set { this.listaProductos = value; }
        }

        public double PrecioFinal
        {
            get { return this.precioFinal; }
            set { this.precioFinal = value; }
        }
    


        public static bool PrecioFinalCalculado(Venta venta)
        {
            if (venta != null)
            {
                foreach (Producto item in venta.ListaProductos)
                {
                    venta.precioFinal += item.Precio;
                }

                return true;
            }

            return false;
        }
    }
}
