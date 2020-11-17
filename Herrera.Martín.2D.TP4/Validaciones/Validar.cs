using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Validaciones
{
    public static class Validar
    {

        /// <summary>
        /// Valida que sea entero
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns></returns>
        public static int Cantidad(string auxNumero)
        {
            int exito = -1;
            if (int.TryParse(auxNumero, out int parseado) && parseado > 0)
            {
                exito = parseado;
            }
            else 
            {
                throw new DatosErroneosException("La cantidad debe ser mayor a cero y no puede ser texto");
            }
            return exito;
        }

        /// <summary>
        /// Valida que sea double
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns></returns>
        public static double Precio(string auxNumero)
        {
            double exito = -1;
            if (double.TryParse(auxNumero, out double parseado) && parseado > 0)
            {
                exito = parseado;
            }
            else
            {
                throw new DatosErroneosException("El precio debe ser mayor a 0 y no puede tener texto");
            }
            return exito;
        }

    }
}
