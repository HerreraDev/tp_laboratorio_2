using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace System.Collections.Generic
{
    public static class ExtensionList
    {
        /// <summary>
        /// Calcula la cantidad total que hay de productos disponibles
        /// </summary>
        /// <param name="listaPedidos"></param>
        /// <returns></returns>
        public static int GetCantidadStockTotal<T>(this List<T> listaPedidos) where T : Producto
        {
            if(listaPedidos.Count>0)
            {
                int cantidadTotal = 0;

                StringBuilder datos = new StringBuilder();
                foreach (T item in listaPedidos)
                {
                    cantidadTotal += item.Cantidad;
                }

                return cantidadTotal;
            }
            else
            {
                throw new Exception("Error, la lista esta vacia");
            }

        }
    }
}
