using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class ManejoBaseDeDatos
    {
        static SqlConnection conexionALaBase;
        static SqlCommand comandoAEjecutar;
        static ManejoBaseDeDatos()
        {
            conexionALaBase = new SqlConnection();
            conexionALaBase.ConnectionString = "Data Source=.\\sqlexpress; Initial Catalog=TP4; Integrated Security=True;";
            comandoAEjecutar = new SqlCommand();
            comandoAEjecutar.Connection = conexionALaBase;
            comandoAEjecutar.CommandType = CommandType.Text;
        }
        public static List<Producto> TraerProductos()
        {
            try
            {
                List<Producto> listaDeProductos = new List<Producto>();
                comandoAEjecutar.CommandText = "select * from Productos";

                conexionALaBase.Open();

                SqlDataReader lector = comandoAEjecutar.ExecuteReader();

                while (lector.Read())
                {
                    string tipo = lector["tipo"].ToString();

                    switch (tipo)
                    {
                        case "hardware":
                            listaDeProductos.Add(new Hardware((int)((decimal)lector["idProducto"]), lector["nombre"].ToString(), (double)lector["precio"], (int)((decimal)lector["cantidad"]), Producto.ETipoDeProducto.hardware));
                            break;
                        case "software":
                            listaDeProductos.Add(new Software((int)((decimal)lector["idProducto"]), lector["nombre"].ToString(), (double)lector["precio"], (int)((decimal)lector["cantidad"]), Producto.ETipoDeProducto.software));
                            break;
                    }

                }
                return listaDeProductos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                conexionALaBase.Close();
            }
        }

        public static bool InsertarALaBase(Producto auxProd)
        {
            bool exito = false;
            try
            {
                comandoAEjecutar.CommandText = "Insert into Productos(idProducto,nombre,precio, cantidad, tipo)" +
                "values(@auxId,@auxNombre,@auxPrecio, @auxCantidad, @auxTipo)"; ;

                comandoAEjecutar.Parameters.Clear();
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxId", auxProd.IdProducto));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxNombre", auxProd.NombreProducto));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxPrecio", auxProd.Precio));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxCantidad", auxProd.Cantidad));
                comandoAEjecutar.Parameters.Add(new SqlParameter("@auxTipo", auxProd.Tipo.ToString()));
                conexionALaBase.Open();
                comandoAEjecutar.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception e)
            {
                exito = false;
                throw e;
            }
            finally
            {
                conexionALaBase.Close();
            }

            return exito;
        }

    }

}

