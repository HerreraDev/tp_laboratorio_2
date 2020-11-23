using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Console.WriteLine("Testeando insertar productos a la base de datos: ");

                Hardware h1 = new Hardware("Teclado 2.0", 80, 60, 484645);
                Hardware h2 = new Hardware("Pendrive 3.0", 200, 100, 849415);
                Software s1 = new Software("Disney plus", 250, 250, "APOSJPFRPE");
                Software s2 = new Software("Mozilla", 96, 145, "OKDSAOPAKSD");


                Console.WriteLine("Tabla Software actualmente: ");
                Console.WriteLine(Stock.ListarLosProductos(Stock.ListaProductosSoftware));

                Console.WriteLine("Tabla Hardware actualmente: ");
                Console.WriteLine(Stock.ListarLosProductos(Stock.ListaProductosHardware));

                Console.WriteLine("Toque una tecla para continuar");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.ReadKey();
                Console.Clear();

                if (Stock.ListaProductosHardware + h1 &&
                    Stock.ListaProductosHardware + h2 &&
                    Stock.ListaProductosSoftware + s1 &&
                    Stock.ListaProductosSoftware + s2)
                {
                    Console.WriteLine("Se insertaron los productos correctamente");
                    Console.WriteLine("Asi estan las tablas ahora: ");

                    Stock.ActualizarListas();

                    Console.WriteLine(" ");
                    Console.WriteLine("Tabla de software:");
                    Console.WriteLine(Stock.ListarLosProductos(Stock.ListaProductosSoftware));

                    Console.WriteLine("Tabla de hardware:");
                    Console.WriteLine(Stock.ListarLosProductos(Stock.ListaProductosHardware));

                    Console.WriteLine("Base de datos actualizada");
                }
                else
                {
                    Console.WriteLine("Alguno de esos prodcutos ya existe en la base de datos");
                }

            }
            catch (DatosErroneosException errorEx)
            {
                Console.WriteLine(errorEx.Message);
            }
            catch(Exception errorGeneral)
            {
                Console.WriteLine(errorGeneral.Message);
            }
            LimpiarPantalla();

            try
            {
                Console.WriteLine("Testeando generar una venta y serializarla");
                Console.WriteLine("");
                Console.WriteLine($"Cantidad de ventas actualmente: {Stock.VentasRealizadas.Count}");
                Console.WriteLine("");

                //Genero numeros random que serviran de indice para elegir un cliente aleatorio y productos aleatorios
                Random random = new Random();
                int clienteRandom = random.Next(0, Stock.Clientes.Count-1);
                int productoRandom = random.Next(0, Stock.ListaProductosSoftware.Count - 1);
                int producto2Random = random.Next(0, Stock.ListaProductosHardware.Count - 1);

                //Lista que simularia un carrito ya que almacena los prodcutos de la venta
                List<Producto> listaTestVenta = new List<Producto>();

                //Agrego productos random a el carrito
                listaTestVenta.Add(Stock.ListaProductosSoftware[productoRandom]);
                listaTestVenta.Add(Stock.ListaProductosHardware[producto2Random]);

                //Creo una venta
                Venta v1 = new Venta(Stock.GetUltimaIdVentas()+1,
                                     Stock.Clientes[clienteRandom],
                                     listaTestVenta,
                                     Venta.PrecioFinalCalculado(listaTestVenta));

                //Realiza el descuento a la cantidad del producto elejido
                //Actualiza la base de datos respecto a la cantidad descontada
                //Añade a la lista de ventas dicha venta para luego ser serializada en un archivo xml
                Venta.ConfirmarCompra(v1);

                //Datos de la venta
                Console.WriteLine(v1.ToString());

                //Serializo la lista de ventas
                if(Venta.SerializarVentas())
                    Console.WriteLine("Ventas serializadas en archivo xml");

                Console.WriteLine("Base de datos actualizada");


            }
            catch (DatosErroneosException errorEx)
            {
                Console.WriteLine(errorEx.Message);
            }
            catch (Exception errorGeneral)
            {
                Console.WriteLine(errorGeneral.Message);
            }
            LimpiarPantalla();

            try
            {
                Console.WriteLine("Testendo DatosErroneosException: ");
                Console.WriteLine("");
                Console.WriteLine("Se intentara cargar un numero negativo a el precio");

                Software softTest = new Software("SoftTesting",-10,10,"FSDFSDFF");
            }
            catch(DatosErroneosException datosErroneos)
            {
                Console.WriteLine(datosErroneos.Message);
            }
            LimpiarPantalla();

            try
            {
                Console.WriteLine("Testendo metodo de extension: ");
                Console.WriteLine("");
                Console.WriteLine("Se intentara ver la cantidad de productos disponibles para vender segun el tipo de producto");

                int stockProductosSoftware = ExtensionList.GetCantidadStockTotal(Stock.ListaProductosSoftware);
                int stockProductosHardware = ExtensionList.GetCantidadStockTotal(Stock.ListaProductosHardware);

                Console.WriteLine("");
                Console.WriteLine($"Stock productos de software: {stockProductosSoftware}");
                Console.WriteLine($"Stock productos de Hardware: {stockProductosHardware}");
            }
            catch (DatosErroneosException datosErroneos)
            {
                Console.WriteLine(datosErroneos.Message);
            }

            LimpiarPantalla();

        }




        /// <summary>
        /// Muestra una linea divisora, pide que se presione una tecla para continuar y limpia la pantalla
        /// </summary>
        private static void LimpiarPantalla()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Toque una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
