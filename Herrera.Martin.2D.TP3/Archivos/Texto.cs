using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Intentara guardar un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si lo logra, de lo contrario false</returns>
        public bool Guardar(string archivo, string datos) 
        {
            bool exitoAlEscribirArchivo = false;
            try
            {
                if(!String.IsNullOrEmpty(archivo) && !String.IsNullOrEmpty(datos))
                {
                    using (StreamWriter escritor = new StreamWriter(archivo, false))
                    {

                        escritor.WriteLine(datos);

                    }

                    exitoAlEscribirArchivo = true;
                }

            }
            catch(Exception)
            {
                throw new ArchivosException("Se produjo un error mientras se guardaba el archivo");
            }

            return exitoAlEscribirArchivo;

        }

        /// <summary>
        /// Intentara leer un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si lo logra, de lo contrario false</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool exitoAlLeerArchivo = false;
            datos = string.Empty;
            try
            {
                if (File.Exists(archivo))
                {
                    using (StreamReader lector = new StreamReader(archivo))
                    {
                        string lineaALeer = string.Empty;
                        while((lineaALeer = lector.ReadLine()) != null)
                        {
                            datos += lineaALeer + "\n";
                        }
                    }

                    exitoAlLeerArchivo = true;
                }

            }
            catch (Exception)
            {
                throw new ArchivosException("Se produjo un error mientras se leia el archivo");
            }

            return exitoAlLeerArchivo;
        }
    }
}
