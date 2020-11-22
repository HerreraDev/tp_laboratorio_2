using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;
namespace Entidades
{
    public class Cliente
    {
        public int idCliente;
        public string nombre;
        public string apellido;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Constructor con parametros que llama al por defecto
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        public Cliente(int idCliente, string nombre, string apellido) : this()
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
        }


        public int IdCliente
        {
            get
            {
                return this.idCliente;
            }
            set
            {
                this.idCliente = Validar.ValidarIds(value.ToString());
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (value == string.Empty)
                    this.nombre = "Error";
                else
                    this.nombre = value;
            }

        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value == string.Empty)
                    this.apellido = "Error";
                else
                    this.apellido = value;
            }
        }

    }
}
