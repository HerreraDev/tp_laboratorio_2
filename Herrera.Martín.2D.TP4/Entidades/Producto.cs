using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;
using Archivos;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Hardware))]
    [XmlInclude(typeof(Software))]
    public abstract class Producto
    {

        int idProducto;
        string nombreProducto;
        double precio;
        int cantidad;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto(){ }

        /// <summary>
        /// Constructor que llama al por defecto
        /// Este sera utilizado para cuando se inserte un producto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(string nombreProducto, double precio, int cantidad) : this()
        {
            this.NombreProducto = nombreProducto;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }

        /// <summary>
        /// Sobrecarga del constructor que sera utilizado 
        /// cuando se traigan los producto de la base de datos
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(int idProducto, string nombreProducto, double precio, int cantidad) : this(nombreProducto,precio,cantidad)
        {
            this.IdProducto = idProducto;
        }
        #endregion

        #region Propiedades
        public int IdProducto
        {
            get { return this.idProducto; }
            set { this.idProducto = Validar.ValidarIds(value.ToString()); }
        }
        public string NombreProducto
        {
            get { return this.nombreProducto; }
            set 
            {
                if(value == string.Empty)
                    this.nombreProducto = "Error";
                else
                {
                    this.nombreProducto = value;
                }

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

        #endregion

        public override string ToString()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine($"ID: {this.IdProducto}");
            datosProducto.AppendLine($"Nombre: {this.NombreProducto}");
            datosProducto.AppendLine($"Precio: {this.Precio}");
            datosProducto.AppendLine($"Cantidad: {this.Cantidad}");

            return datosProducto.ToString();
        }

        public virtual string ToStringParaConsola()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine($"ID: {this.IdProducto} | Nombre: {this.NombreProducto} | Precio: {this.Precio} | Cantidad: {this.Cantidad}");


            return datosProducto.ToString();
        }

        /// <summary>
        /// Genero un txt con el producto generado
        /// </summary>
        /// <param name="auxProd"></param>
        /// <returns></returns>
        public static bool Guardar(Producto auxProd)
        {
            string archivo = AppDomain.CurrentDomain.BaseDirectory + "LogProductosInsertados.txt";

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



    }
}
