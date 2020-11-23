using Archivos;
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

        #region Constructores
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
        public Venta(int idVenta, Cliente cliente, List<Producto> listaProductos, double montoTotal) : this()
        {
            this.IdVenta = idVenta;
            this.Cliente = cliente;
            this.ListaProductos = listaProductos;
            this.PrecioFinal = montoTotal;
        }
        #endregion 


        #region Propiedades
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
        #endregion

        /// <summary>
        /// Override del ToString para ver los datos del producto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosVenta = new StringBuilder();
            datosVenta.AppendLine("Datos de la venta: ");
            datosVenta.AppendLine($"ID: {this.IdVenta}");
            datosVenta.AppendLine($"Cliente: {this.Cliente.ToString()}");
            datosVenta.AppendLine("Productos elegidos:");
            foreach (Producto item in ListaProductos)
            {
                datosVenta.AppendLine(item.ToString());
            }
            datosVenta.AppendLine($"Monto total: {this.PrecioFinal}");

            return datosVenta.ToString();
        }

        /// <summary>
        /// Calcula el precio final de la venta
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns>0 si hubo error, double con el precio final</returns>
        public static double PrecioFinalCalculado(List<Producto> carrito)
        {
            if (carrito.Count > 0)
            {

                double precioFinal = 0;
                if (carrito != null)
                {
                    foreach (Producto item in carrito)
                    {
                        precioFinal += item.Precio;
                    }
                }

                return precioFinal;
            }
            else
            {
                throw new Exception("Error, el carrito esta vacio");
            }
        }

        /// <summary>
        /// Serializa en un archivo xml las ventas existentes en la lista de ventas
        /// </summary>
        /// <returns></returns>
        public static bool SerializarVentas()
        {
            string ubicacionArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Ventas.xml");

            Xml<List<Venta>> auxXmlUniversidad = new Xml<List<Venta>>();
            if (auxXmlUniversidad.GuardarEnArchivo(ubicacionArchivo, Stock.VentasRealizadas))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Descuenta la cantidad del producto elegido, actualiza los items en la base de datos y
        /// agrega la venta a la lista de ventas
        /// </summary>
        /// <param name="ventaAConfirmar"></param>
        public static void ConfirmarCompra(Venta ventaAConfirmar)
        {
            if (ventaAConfirmar != null)
            {
                //Descuento 1 la cantidad a los productos elegidos
                foreach (Producto item in ventaAConfirmar.ListaProductos)
                {
                    if (item.GetType() == typeof(Software))
                    {
                        Stock.ListaProductosSoftware[Stock.GetIndiceProducto((Software)item)].Cantidad--;
                    }
                    else
                    {
                        Stock.ListaProductosHardware[Stock.GetIndiceProducto((Hardware)item)].Cantidad--;
                    }
                }

                //Actualizo la cantidad de cada producto en la Base de Datos

                foreach (Producto item in ventaAConfirmar.ListaProductos)
                {
                    if (item.GetType() == typeof(Software))
                    {
                        ManejoBaseDeDatos.ActualizarProductoVendido((Software)item);
                    }
                    else
                    {
                        ManejoBaseDeDatos.ActualizarProductoVendido((Hardware)item);
                    }
                }

                //Añado venta a la lista de ventas
                Stock.VentasRealizadas.Add(ventaAConfirmar);
            }
            else
            {
                throw new Exception("La venta que llego por parametro es nula");
            }

        }
    }
}
