using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Software : Producto
    {

        public Software()
        {

        }

        public Software(int idProducto, string nombreProducto, double precio, int cantidad, ETipoDeProducto tipo) :base(idProducto,nombreProducto,precio,cantidad,tipo)
        {

        }

        public override string ToString()
        {
            StringBuilder datosProducto = new StringBuilder();
            datosProducto.AppendLine("Software:");
            datosProducto.AppendLine(base.ToString());
            datosProducto.AppendLine("---------------------------------------------------------");

            return datosProducto.ToString();
        }
    }
}
