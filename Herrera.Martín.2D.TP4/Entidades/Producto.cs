using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;
using Archivos;

namespace Entidades
{
    public abstract class Producto
    {
        public enum ETipoDeProducto
        {
            hardware,
            software
        }

        int idProducto;
        string nombreProducto;
        double precio;
        int cantidad;
        ETipoDeProducto tipo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto(){ }

        /// <summary>
        /// Constructor que llama al por defecto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(int idProducto, string nombreProducto, double precio, int cantidad, ETipoDeProducto tipo) : this()
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.precio = precio;
            this.cantidad = cantidad;
            this.tipo = tipo;
        }
        #endregion

        #region Propiedades
        public int IdProducto
        {
            get { return this.idProducto; }
            set { this.idProducto = value; }
        }
        public string NombreProducto
        {
            get { return this.nombreProducto; }
        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }

        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }

        }

        public ETipoDeProducto Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }

        }
        #endregion

        public override string ToString()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine($"ID: {this.IdProducto}");
            datosProducto.AppendLine($"Nombre: {this.NombreProducto}");
            datosProducto.AppendLine($"Precio: {this.Precio}");
            datosProducto.AppendLine($"Cantidad: {this.Cantidad}");
            datosProducto.AppendLine($"Tipo: {this.Tipo.ToString()}");

            return datosProducto.ToString();
        }

        public static bool Guardar(Producto auxProd)
        {
            string archivo = AppDomain.CurrentDomain.BaseDirectory + "UltimoProductoAgregado.txt";

            Texto auxParaEscribir = new Texto();

            return auxParaEscribir.GenerarTicketTxt(archivo, auxProd.ToString());
        }


    }
}
