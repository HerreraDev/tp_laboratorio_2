using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool GuardarEnArchivo(string archivo, T datos)
        {
            bool exitoAlGuardar = false;
            try
            {
                if (archivo != null)
                {
                    using (XmlTextWriter auxWriter = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer auxEscritor = new XmlSerializer(typeof(T));

                        auxEscritor.Serialize(auxWriter, datos);

                        exitoAlGuardar = true;
                    }
                }
            }
            catch (Exception)
            {

                throw new ArchivosException("Se produjo  un error al guarda  el archivo XML");
            }

            return exitoAlGuardar;
        }
    }
}
