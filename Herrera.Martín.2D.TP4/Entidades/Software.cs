using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Software : Producto
    {
        string licenciaDelSoftware;
        public Software()
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
        public Software(int idProducto, string nombreProducto, double precio, int cantidad, string  licenciaDelSoftware) :base(idProducto,nombreProducto,precio,cantidad)
        {
            this.licenciaDelSoftware = licenciaDelSoftware;
        }


        /// <summary>
        /// Constructor utilizado para cuando se inserten datos a la base de datos
        /// </summary>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        /// <param name="licenciaDelSoftware"></param>
        public Software(string nombreProducto, double precio, int cantidad, string licenciaDelSoftware) : base(nombreProducto,precio,cantidad)
        {
            this.licenciaDelSoftware = licenciaDelSoftware;
        }

        public string LicenciaDelSoftware
        {
            get { return this.licenciaDelSoftware; }
            set 
            {
                if (value == string.Empty)
                    this.licenciaDelSoftware = "Error";
                else
                    this.licenciaDelSoftware = value;
            }
        }


        /// <summary>
        /// Override del ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosProducto = new StringBuilder();
            datosProducto.AppendLine("Producto de software:");
            datosProducto.AppendLine(base.ToString());
            datosProducto.AppendLine($"Licencia: {this.LicenciaDelSoftware}");
            datosProducto.AppendLine("---------------------------------------------------------");

            return datosProducto.ToString();
        }

        public override string ToStringParaConsola()
        {
            StringBuilder datosProducto = new StringBuilder();
            datosProducto.AppendLine(base.ToStringParaConsola());
            datosProducto.AppendLine($"Licencia: {this.LicenciaDelSoftware}");
            datosProducto.AppendLine("---------------------------------------------------------");

            return datosProducto.ToString();
        }

        /// <summary>
        /// Verifica que el producto este en la lista
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="auxProducto"></param>
        /// <returns></returns>
        public static bool operator ==(List<Software> productos, Software auxProducto)
        {

            foreach (Software item in productos)
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
        public static bool operator !=(List<Software> productos, Software auxProducto)
        {
            return !(productos == auxProducto);
        }

        public static bool operator +(List<Software> productos, Software auxProducto)
        {
            bool exito;
            if (productos != auxProducto)
            {
                ManejoBaseDeDatos.InsertarSoftware(auxProducto);
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
