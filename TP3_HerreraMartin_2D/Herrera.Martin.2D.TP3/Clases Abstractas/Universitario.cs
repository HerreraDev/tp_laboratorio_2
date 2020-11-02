using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        protected int legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
       
        public Universitario() : base() { }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion



        #region Metodos
        /// <summary>
        /// Genera una cadena con los datos 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datosSb = new StringBuilder();
            datosSb.AppendLine(base.ToString());
            datosSb.AppendLine($"LEGAJO NUMERO: {this.legajo}");

            return datosSb.ToString();
        }

        /// <summary>
        /// Metodo abstracto 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Se fija que las instancias sean del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>false si no son del mismo tipo, de lo contrario devuelve true</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida que los dos universitarios sean del mismo tipo y que tengan el mismo legajo o dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>true si cumple la condicion, de lo contrario devuelve false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if( pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.dni == pg2.dni))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve lo contrario a lo que devuelve el operator ==
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>devuelve false si son iguales, de lo contrario true</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion




    }
}
