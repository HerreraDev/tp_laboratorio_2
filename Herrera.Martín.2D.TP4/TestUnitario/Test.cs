using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Testea que se cargue la lista estatica que se carga con los productos que trae de la base de datos
        /// </summary>
        [TestMethod]
        public void TestListaProductos()
        {
            Assert.IsNotNull(Stock.ListaProductosHardware);
        }

        /// <summary>
        /// Testea si se lanza la excepcion DatosErroneosException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DatosErroneosException))]
        public void TestDatosErroneosException()
        {
            Software s = new Software("testSoft",-10,20,"SDAFEGRDDD");

        }


    }
}
