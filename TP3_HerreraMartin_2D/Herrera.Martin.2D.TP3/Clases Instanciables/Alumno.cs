using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{

    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoDeCuenta;

        #region Constructores

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Alumno() : base() { }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoDeCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoDeCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoDeCuenta = estadoDeCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera la cadena para saber que clase toma
        /// </summary>
        /// <returns>string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clase = new StringBuilder();

            clase.AppendLine($"TOMA CLASES DE {this.claseQueToma}");

            return clase.ToString();

        }
        /// <summary>
        /// Genera un stringbuilder con todos los datos del alumno 
        /// </summary>
        /// <returns>string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine($"ESTADO DE CUENTA: {this.estadoDeCuenta}");
            datos.AppendLine(ParticiparEnClase());

            return datos.ToString();
        }

        /// <summary>
        /// Hace visiblemente publicos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return this.MostrarDatos();

        }

        /// <summary>
        /// Verifica que el alumno tome una clase y que no sea deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si se cumple la condicion, de lo contrario false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoDeCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica que el alumno no tome la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si se cumple la condicion, de lo contrario false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion


    }
}
