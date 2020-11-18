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
            this.IdProducto = idProducto;
            this.NombreProducto = nombreProducto;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Tipo = tipo;
        }
        #endregion

        #region Propiedades
        public int IdProducto
        {
            get { return this.idProducto; }
            set { this.idProducto = Validar.ValidarEnteros(value.ToString()); }
        }
        public string NombreProducto
        {
            get { return this.nombreProducto; }
            set 
            {
                if(value!= string.Empty)
                    this.nombreProducto = value;
            }
        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = Validar.ValidarPrecio(value.ToString()); }

        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = Validar.ValidarCantidad(value.ToString()); }

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

        /// <summary>
        /// Genero un txt con el producto generado
        /// </summary>
        /// <param name="auxProd"></param>
        /// <returns></returns>
        public static bool Guardar(Producto auxProd)
        {
            string archivo = AppDomain.CurrentDomain.BaseDirectory + "UltimoProductoAgregado.txt";

            Texto auxParaEscribir = new Texto();

            return auxParaEscribir.GuardarEnArchivo(archivo, auxProd.ToString());
        }

        /// <summary>
        /// Verifica que el producto este en la lista
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="auxProducto"></param>
        /// <returns></returns>
        public static bool operator ==(List<Producto> productos, Producto auxProducto)
        {

            foreach (Producto item in productos)
            {
                if (item.idProducto == auxProducto.idProducto)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un producto no este en la lista
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="auxProducto"></param>
        /// <returns>true si no lo encuentra, false caso contrario</returns>
        public static bool operator !=(List<Producto> productos, Producto auxProducto)
        {
            return !(productos==auxProducto);
        }

        public static bool operator +(List<Producto> productos, Producto auxProducto)
        {
            bool exito;
            if (productos != auxProducto)
            {          
                ManejoBaseDeDatos.InsertarProducto(auxProducto);
                exito = true;
            }
            else
            {
                exito = false;
                throw new Exception();
            }

            return exito;
        }

    }
}
