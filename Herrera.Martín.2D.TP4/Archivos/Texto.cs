using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IManejoArchivos<string>
    {
        /// <summary>
        /// Crea un archivo .txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool GuardarEnArchivo(string archivo, string datos)
        {
            bool exitoAlEscribirArchivo = false;
            try 
            {
                if (!String.IsNullOrEmpty(archivo) && !String.IsNullOrEmpty(datos))
                {
                    using (StreamWriter escritor = new StreamWriter(archivo, true))
                    {
                        escritor.WriteLine(datos);
                    }
                }
                return exitoAlEscribirArchivo = true;
            }
            catch (Exception)
            {
                throw new ArchivosException("Se produjo un error mientras se guardaba el archivo txt");
            }
        }
    }
}
