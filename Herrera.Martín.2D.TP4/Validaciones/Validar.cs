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
        /// Valida que la cantidad ingresada sea correcta
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns>retorna el numero parseado o lanza una excepcion</returns>
        public static int ValidarIds(string auxNumero)
        {
            int parseado = ValidarEnteros(auxNumero);
            if (parseado > 0)
            {
                return parseado;
            }
            else
            {
                throw new DatosErroneosException("El id debe ser mayor a 0 y no de contener letras");
            }
        }

        /// <summary>
        /// Valida que la cantidad ingresada sea correcta
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns>retorna el numero parseado o lanza una excepcion</returns>
        public static int ValidarNumeroDeParte(string auxNumero)
        {
            int parseado = ValidarEnteros(auxNumero);
            if (parseado > 0)
            {
                return parseado;
            }
            else
            {
                throw new DatosErroneosException("El numero de parte debe ser mayor a 0 y no de contener letras");
            }
        }

        /// <summary>
        /// Valida que la cantidad ingresada sea correcta
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns>retorna el numero parseado o lanza una excepcion</returns>
        public static int ValidarCantidad(string auxNumero)
        {
            int parseado = ValidarEnteros(auxNumero);
            if (parseado > 0)
            {
                return parseado;
            }
            else
            {
                throw new DatosErroneosException("La cantidad ingresada debe ser mayor a 0 y no de contener letras");
            }
        }

        /// <summary>
        /// Valida que el precio ingresado sea correcta
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns>retorna el numero parseado o lanza una excepcion</returns>
        public static double ValidarPrecio(string auxNumero)
        {
            double parseado = ValidarDouble(auxNumero);
            if (parseado > 0)
            {
                return parseado;
            }
            else
            {
                throw new DatosErroneosException("El precio ingresado debe ser mayor a 0 y no de contener letras");
            }
        }


        /// <summary>
        /// Valida que sea entero
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns></returns>
        public static int ValidarEnteros(string auxNumero)
        {
            int exito;
            if (int.TryParse(auxNumero, out int parseado) && parseado > 0)
            {
                exito = parseado;
            }
            else 
            {
                exito = -1;
            }
            return exito;
        }

        /// <summary>
        /// Valida que sea double
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns></returns>
        public static double ValidarDouble(string auxNumero)
        {
            double exito;
            if (double.TryParse(auxNumero, out double parseado) && parseado > 0)
            {
                exito = parseado;
            }
            else
            {
                exito = -1;
            }
            return exito;
        }

    }
}
