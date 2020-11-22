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
            /*try
            {
               Console.WriteLine("Testeando insertar productos a la base de datos: ");

                Hardware h1 = new Hardware("Placa de video 1.5", 430, 8,78789789);
                Hardware h2 = new Hardware("Procesador 2.6", 350, 100, 7894618);
                Software s1 = new Software("Google", 50, 130, "APOSJPFRPE");
                Software s2 = new Software("Mozilla", 20, 243, "OKDSAOPAKSD");


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
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Toque una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            */

            try
            {
                //Genero un numero random que servida de indice para elegir un cliente aleatorio de la lista
                Random random = new Random();
                int clienteRandom = random.Next(0, Stock.Clientes.Count-1);
                Console.WriteLine($"El cliente que realizara la compra es: {Stock.Clientes[clienteRandom].ToString()}");

                int productoRandom = random.Next(0, Stock.ListaProductosSoftware.Count - 1);
                int producto2Random = random.Next(0, Stock.ListaProductosHardware.Count - 1);

                //Lista que simularia un carrito ya que almacena los prodcutos de la venta
                List<Producto> listaTestVenta = new List<Producto>();

                Console.WriteLine("");
                Console.WriteLine("Los productos elegidos son: ");
                Console.WriteLine($"{Stock.ListaProductosSoftware[productoRandom]}");
                Console.WriteLine($"{Stock.ListaProductosHardware[producto2Random]}");


                //Agrego productos random a el carrito
                listaTestVenta.Add(Stock.ListaProductosSoftware[productoRandom]);
                listaTestVenta.Add(Stock.ListaProductosHardware[producto2Random]);

                //Creo una venta
                Venta v1 = new Venta(Stock.GetUltimaIdVentas(),
                                     Stock.Clientes[clienteRandom],
                                     listaTestVenta,
                                     Venta.PrecioFinalCalculado(listaTestVenta));

                Stock.VentasRealizadas.Add(v1);
                if(Venta.SerializarVentas())
                    Console.WriteLine("Ventas serializadas en archivo xml");

            }
            catch (DatosErroneosException errorEx)
            {
                Console.WriteLine(errorEx.Message);
            }
            catch (Exception errorGeneral)
            {
                //Console.WriteLine(errorGeneral.Message);
                throw errorGeneral;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Toque una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
