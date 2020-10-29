﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public enum ENacionalidad
    {
        Argentino,
        Extranjero
    }



    public abstract class Persona
    {
        protected string apellido;
        protected int dni;
        protected ENacionalidad nacionalidad;
        protected string nombre;

        #region Propiedades
        /// <summary>
        /// Propiedad lectura y escritura apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad lectura y escritura dni
        /// </summary>
        public int DNI
        {
            get { return this.dni; }

            set 
            { 
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch(DniInvalidoException dniInvalido)
                {
                    Console.WriteLine(dniInvalido.Message);
                }
                catch(NacionalidadInvalidaException nacionalidadInvalida)
                {
                    Console.WriteLine(nacionalidadInvalida.Message);
                }
            }
            
        }
        
        /// <summary>
        /// Propiedad lectura y escritura nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad lectura y escritura nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad escritura dni 
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad,value); }
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();

            datosPersona.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            datosPersona.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            datosPersona.AppendLine($"DNI: {this.DNI}");

            return datosPersona.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI invalido");
            }


            if (nacionalidad == ENacionalidad.Argentino && (dato >= 90000000 && dato <= 99999999))
            {
                throw new NacionalidadInvalidaException("Ese dni no coincide con la nacionalidad argentino");
            }

            if (nacionalidad == ENacionalidad.Extranjero && (dato >= 1 && dato <= 89999999))
            {
                throw new NacionalidadInvalidaException("Ese dni no coincide con la nacionalidad extranjero");
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            if(!(int.TryParse(dato,out int datoParseado)))
            {
                throw new DniInvalidoException("DNI Incorrecto, solo debe contener numeros");
            }

            return this.ValidarDni(nacionalidad, datoParseado);
        }


        private string ValidarNombreApellido(string dato)
        {
            string validacion = "^[a-zA-Z]+$";

            if (dato.Length < 2 || dato == string.Empty || !Regex.IsMatch(dato, validacion))
            {
                dato = string.Empty;
            }

            return dato;
        }




        #endregion


    }
}