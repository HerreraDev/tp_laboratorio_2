using Clases_Abstractas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Constructores
        /// <summary>
        /// Constructor estatico para incicializar el atributo random solamente
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto sin parametros
        /// </summary>
        public Profesor() : base() { }

        /// <summary>
        /// Constructor parametrizado que inicializa clases del dia y le asigna valores a traves del metodo _randomClases
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Genera un numero enter 1 y 4, depende el numero que salga le asigna un valor a el atributo clases del dia
        /// esto lo hara solamente dos veces, ya que este es el numero maximo de clases que puede tener un profesor
        /// </summary>
        private void _randomClases()
        {
            int numeroAleatorio;

            for (int clasesMaximas = 2; clasesMaximas > 0; clasesMaximas--)
            {
                numeroAleatorio = random.Next(1, 4);

                switch (numeroAleatorio)
                {
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 4:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                }
            }
        }

        /// <summary>
        /// Genera la cadena clases del día y le va concatenando abajo las clases que dara
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clase = new StringBuilder();

            clase.AppendLine($"CLASES DEL DÍA:");
            for (int i = 0; i < this.clasesDelDia.Count; i++)
            {
                clase.AppendLine(Convert.ToString(this.clasesDelDia.Peek()));
            }

            return clase.ToString();
        }

        /// <summary>
        /// Genera una cadena con todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine(ParticiparEnClase());

            return datos.ToString();
        }

        /// <summary>
        /// Hace que los datos del profesor sean visiblemente publicos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        

        /// <summary>
        /// Determina si el profesor da una clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si da la clase, false si no la da</returns>
        public static bool operator ==(Profesor i ,Universidad.EClases clase)
        {
            if(i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Determina si el profesor no da la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si no la da, false si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
