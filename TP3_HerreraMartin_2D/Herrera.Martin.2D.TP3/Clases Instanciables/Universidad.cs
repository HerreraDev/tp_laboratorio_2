using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{

    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    throw new ArchivosException("Indice no valido de jornada");
                }

            }

            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
                else
                {
                    throw new ArchivosException("Indice no valido de jornada");
                }

            }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }



        #endregion

        #region Constructores

        /// <summary>
        /// Construcor por defecto
        /// </summary>
        public Universidad()
        {
            profesores = new List<Profesor>();
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos de los objetos tipo universidad que llegan por parametro
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUni = new StringBuilder();

            for(int i = 0; i < uni.jornada.Count; i++)
            {
                datosUni.AppendLine(uni.jornada[i].ToString());
            }

            return datosUni.ToString();
        }

        /// <summary>
        /// Pone visiblemente publicos los datos de MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Realiza el guardado de los datos para el tipo Universidad en un archivo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>true si pudo, de lo contrario false</returns>
        public static bool Guardar(Universidad uni)
        {
            string ubicacionArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Universidad.xml");
            Xml<Universidad> auxXmlUniversidad = new Xml<Universidad>();

            return auxXmlUniversidad.Guardar(ubicacionArchivo, uni);
        }

        /// <summary>
        /// Realiza la lectura de los datos traidos desde un archivo XML
        /// </summary>
        /// <returns>objeto cargado con los datos leidos de tipo universidad</returns>
        public static Universidad Leer()
        {
            string ubicacionArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Universidad.xml");
            Universidad universidadACargar = new Universidad();
            Xml<Universidad> auxXmlUniversidad = new Xml<Universidad>();
            auxXmlUniversidad.Leer(ubicacionArchivo, out universidadACargar);

            return universidadACargar;

        }
        #endregion

        #region Sobrecargas de operadores

        /// <summary>
        /// Verifica que el alumno este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si cumple la condicion, de lo contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            for(int i=0; i < g.alumnos.Count;i++)
            {
                if(g.alumnos[i] == a)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Verifica que el alumno no este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si cumple la condicion, de lo contrario false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica que el profesor este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si cumple la condicion, de lo contrario false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            for (int j = 0; j < g.profesores.Count; j++)
            {
                if (g.profesores[j].DNI == i.DNI)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica que el profesor no este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si cumple la condicion, de lo contrario false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Verifica que un profesor de la clase, de lo contrario lanza una excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>el profesor que da la clase o lanza la excepcion</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            for (int i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] == clase)
                {
                    return u.profesores[i];
                }
            }

            throw new SinProfesorException("No hay profesor para la clase.");
        }

        /// <summary>
        /// Verifica que un profesor no de la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve el profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            for (int i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] != clase)
                {
                    return u.profesores[i];
                }
            }

            throw new SinProfesorException("No hay profesor que no de la clase");
        }

        /// <summary>
        /// Agrega un profesor a la universidad si este no existe
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>objeto tipo universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Agrega un alumno a la universidad si este no existe
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>objeto tipo universidad, si no pudo lanza la excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }

            return u;
        }

        /// <summary>
        /// Se encarga de generar una jornada y a su vez, determinar que profesor la da y
        /// que alumonos la toman
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);

            for(int i = 0; i < g.alumnos.Count;i++)
            {
                if(g.alumnos[i] == clase)
                {
                    nuevaJornada += g.alumnos[i];
                }
            }

            g.jornada.Add(nuevaJornada);


            return g;

        }
        #endregion

    }
}
