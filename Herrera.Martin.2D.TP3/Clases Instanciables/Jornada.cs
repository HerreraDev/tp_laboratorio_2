using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; } 
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Constuctores

        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Override del ToString() para mostrar los datos de la jornada
        /// </summary>
        /// <returns>cadena con todos los datos</returns>
        public override string ToString()
        {
            StringBuilder datosDeLaJornada = new StringBuilder();

            datosDeLaJornada.AppendLine("<--------------------------------------------------->");
            datosDeLaJornada.AppendLine("JORNADA: ");
            datosDeLaJornada.AppendLine($"CLASE DE {this.Clase} POR {this.Instructor.ToString()}");
            datosDeLaJornada.AppendLine("ALUMNOS: ");
            for (int i = 0; i < this.alumnos.Count; i++)
            {
                datosDeLaJornada.AppendLine(this.alumnos[i].ToString());
            }

            return datosDeLaJornada.ToString();
        }

        /// <summary>
        /// Verifica que el alumno particide la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true  si se cumple, false si no se cumple</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if(j.alumnos.Contains(a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica que el alumno no participe de la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si no particida, false si pasa lo contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si este no existe en la misma
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Guarda los  datos de la jornada en un  archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si puso guardarla, false si no pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            string archivo = AppDomain.CurrentDomain.BaseDirectory + "Jornada";

            Texto auxParaEscribir = new Texto();

            return auxParaEscribir.Guardar(archivo, jornada.ToString());
        }

        /// <summary>
        /// Lee del archivo de jornada los datos y los guarda en un string
        /// </summary>
        /// <returns>string con los datos</returns>
        public static string Leer()
        {
            string archivo = AppDomain.CurrentDomain.BaseDirectory + "Jornada";
            string datosJornada;

            Texto auxParaLeer = new Texto();

            auxParaLeer.Leer(archivo, out datosJornada);

            return datosJornada;

        }
        #endregion
    }
}
