using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        public DniInvalidoException() : base() { }

        /// <summary>
        /// Constructor con mensaje default
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : base ("El DNI es invalido",e){ }

        /// <summary>
        /// Constructor con mensaje
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message) { }


        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message, e){ }





    }
}
