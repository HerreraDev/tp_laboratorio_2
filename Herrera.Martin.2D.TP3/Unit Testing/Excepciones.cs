using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace Unit_Testing
{
    [TestClass]
    public class Excepciones
    {
        /// <summary>
        /// Testea que se lance la excepcion DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Profesor dniInvalido = new Profesor(01,"Manolo","Lamas","1p23p4",Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        /// Testea que se lance la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Profesor dniInvalido = new Profesor(01, "Manolo", "Lamas", "87656788", Persona.ENacionalidad.Extranjero);
        }

        /// <summary>
        /// Testea que no sea null la lista de alumons que se crea por cada jornada
        /// </summary>
        [TestMethod]
        public void Test_Coleccion()
        {
            Profesor testProfesor = new Profesor();
            Jornada testJornada = new Jornada(Universidad.EClases.Laboratorio,testProfesor);

            Assert.IsNotNull(testJornada.Alumnos);

        }
    }
}
