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
            Assert.IsNotNull(Stock.ListaProductos);
        }

        /// <summary>
        /// Testea si se podria eliminar un producto
        /// </summary>
        [TestMethod]
        public void TestEliminarProducto()
        {
            Software s = new Software(1, "Prod", 20, 2, Producto.ETipoDeProducto.hardware);

            ManejoBaseDeDatos.EliminarProducto(s);
        }

        /// <summary>
        /// Testea si se lanza la excepcion DatosErroneosException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DatosErroneosException))]
        public void TestDatosErroneosException()
        {
            Software s = new Software(1, "Prod", -20, 2, Producto.ETipoDeProducto.hardware);

            ManejoBaseDeDatos.EliminarProducto(s);
        }


    }
}
