using System;
using System.Collections.Generic;
using System.IO;
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
            catch (Exception exc)
            {

                throw new ArchivosException("Se produjo  un error al guarda  el archivo XML");
            }

            return exitoAlGuardar;
        }

        /// <summary>
        /// Intentara leer un archivo XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si lo leyo con exito, de lo contrario falso</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool exitoAlLeer = false;

            datos = default(T);

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader auxReader = new XmlTextReader(archivo))
                    {
                        XmlSerializer auxLector = new XmlSerializer(typeof(T));

                        datos = (T)auxLector.Deserialize(auxReader);

                        exitoAlLeer = true;
                    }
                }
            }
            catch (Exception)
            {

                throw new ArchivosException("Se produjo un error al leer el archivo XML");
            }

            return exitoAlLeer;
        }
    }
}
