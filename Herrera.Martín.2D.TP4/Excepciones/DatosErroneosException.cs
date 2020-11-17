using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DatosErroneosException : Exception
    {
        public DatosErroneosException() : base("Dato Erroneo") { }

        public DatosErroneosException(string message) : base(message) { }
    }
}
