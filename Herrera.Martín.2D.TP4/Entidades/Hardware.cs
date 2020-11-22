using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;

namespace Entidades
{
    public class Hardware : Producto
    {
        int numeroDeParte;

        #region Constructor
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Hardware()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// Utilizado para cuando se traen los producto de la base de datos
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Hardware(int idProducto, string nombreProducto, double precio, int cantidad, int numeroDeParte) : base(idProducto, nombreProducto, precio, cantidad)
        {
            this.NumeroDeParte = numeroDeParte;
        }


        /// <summary>
        /// Constructor utilizado para cuando se inserten datos a la base de datos
        /// No se usa el id ya que es autoincremental
        /// </summary>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        /// <param name="licenciaDelSoftware"></param>
        public Hardware(string nombreProducto, double precio, int cantidad, int numeroDeParte) : base(nombreProducto, precio, cantidad)
        {
            this.NumeroDeParte = numeroDeParte;
        }
        #endregion

        #region Propiedades
        public int NumeroDeParte
        {
            get { return this.numeroDeParte; }
            set { this.numeroDeParte = Validar.ValidarNumeroDeParte(value.ToString()); }
        }
        #endregion  


        /// <summary>
        /// Override del ToString
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            StringBuilder datosProducto = new StringBuilder();
            datosProducto.AppendLine("Producto de hardware:");
            datosProducto.AppendLine(base.ToString());
            datosProducto.AppendLine($"Codigo de parte: {this.NumeroDeParte}");
            datosProducto.AppendLine("---------------------------------------------------------");

            return datosProducto.ToString();
        }

        /// <summary>
        /// Metodo para cuando se muestre por consola un producto
        /// Utilizado para que se vea mas prolijo
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToStringParaConsola()
        {
            StringBuilder datosProducto = new StringBuilder();
            datosProducto.AppendLine(base.ToStringParaConsola());
            datosProducto.AppendLine($"Numero de parte: {this.NumeroDeParte}");
            datosProducto.AppendLine("---------------------------------------------------------");

            return datosProducto.ToString();
        }

        /// <summary>
        /// Verifica que el producto este en la lista
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="auxProducto"></param>
        /// <returns></returns>
        public static bool operator ==(List<Hardware> productos, Hardware auxProducto)
        {

            foreach (Hardware item in productos)
            {
                if (item.IdProducto == auxProducto.IdProducto)
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
        public static bool operator !=(List<Hardware> productos, Hardware auxProducto)
        {
            return !(productos == auxProducto);
        }

        /// <summary>
        /// Inserta un producto a la base de datos
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="auxProducto"></param>
        /// <returns></returns>
        public static bool operator +(List<Hardware> productos, Hardware auxProducto)
        {
            bool exito;
            if (productos != auxProducto)
            {
                ManejoBaseDeDatos.InsertarHardware(auxProducto);
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
