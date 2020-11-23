using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Utilizada para manejar errores al trabajar con archivos
    /// </summary>
    public class ArchivosException : Exception
    {

        public ArchivosException() : base("Error en el guardado de archivo") { }

        public ArchivosException(string message) : base(message) { }
    }
}
