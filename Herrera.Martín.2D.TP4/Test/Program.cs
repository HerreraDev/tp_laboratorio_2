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
                /*Console.WriteLine("Testeando insertar productos a la base de datos: ");

                Hardware h1 = new Hardware("Placa de video 2.4", 430, 8,403331);
                Hardware h2 = new Hardware("Procesador 5.2", 350, 100, 5011343);
                Software s1 = new Software("Tetris", 40, 430, "ASDKKGK343JTTE");
                Software s2 = new Software("Face app", 530, 543, "AKFKPRASIDKS");

                if (Stock.ListaProductosHardware + h1 &&
                    Stock.ListaProductosHardware + h2 &&
                    Stock.ListaProductosSoftware + s1 &&
                    Stock.ListaProductosSoftware + s2)
                {

                }*/
                Console.WriteLine("Tabla Software actualmente: ");
                Console.WriteLine(Stock.ListarLosProductos());




            }
            catch (DatosErroneosException errorEx)
            {
                Console.WriteLine(errorEx.Message);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
