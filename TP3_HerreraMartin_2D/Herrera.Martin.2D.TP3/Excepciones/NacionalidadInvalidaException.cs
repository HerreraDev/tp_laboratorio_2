using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor sin mensaje
        /// </summary>
        public NacionalidadInvalidaException() : base()
        {

        }

        /// <summary>
        /// Constructor con parametro mensaje
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
