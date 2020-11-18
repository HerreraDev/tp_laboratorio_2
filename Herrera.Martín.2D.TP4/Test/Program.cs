using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Testeando la excepcion DatosErroneosExcepcion: ");

                Hardware h1 = new Hardware(1, "HDD", -30, 4, Producto.ETipoDeProducto.hardware);

                if (Stock.ListaProductos + h1)
                {
                    Console.WriteLine(h1.ToString());
                }

            }
            catch(DatosErroneosException errorEx)
            {
                Console.WriteLine(errorEx.Message);
            }

            Console.ReadKey();

        }
    }
}
