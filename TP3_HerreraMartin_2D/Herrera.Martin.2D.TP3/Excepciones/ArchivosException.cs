using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base("Archivo con error",innerException) { }

        public ArchivosException() : base("Error creando archivo") { }

        public ArchivosException(string message) : base(message) { }


    }
}
